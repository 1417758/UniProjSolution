USE [EasyBook]
GO
/****** Object:  UserDefinedFunction [dbo].[GetPersonInherWithDetByID]    Script Date: 20/06/2016 17:15:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPersonInherWithDetByID', N'TF') IS NOT NULL
    DROP FUNCTION dbo.GetPersonInherWithDetByID ;
GO
 
CREATE FUNCTION [dbo].[GetPersonInherWithDetByID](
	@pInherited smallint
)
RETURNS  @innerTableFinds2 TABLE(
	fpersonID int NOT NULL,
	ftitle varchar(3) NOT NULL,
	ffirstName varchar(50) NOT NULL,	
	flastName varchar(50) NOT NULL,
	fcontactDet int NOT NULL,
	frole int NOT NULL,
	fnatInsNumb varchar(20),
	fjobTitle varchar(50),
	fagenda int,
	faddress varchar(200),	
	fpostCode varchar(50),
	fcity varchar(70),
	fcountry varchar(70),
	flandLine varchar(20),
	fmobile varchar(20),
	femail varchar(100),
	fdateCreated smalldatetime,
	flastUpdated smalldatetime 
)
AS
BEGIN

	IF @pInherited = 0 
	begin 
		--ALTER TABLE @innerTableFinds2
		--DROP COLUMN natInsNumb;
		INSERT @innerTableFinds2(fpersonID, ftitle, ffirstName,flastName, fcontactDet, frole, fnatInsNumb, fjobTitle, fagenda, 	faddress, fpostCode, fcity, fcountry, flandLine, fmobile, femail, fdateCreated, flastUpdated) 
				SELECT *
				FROM [EndUser] as U
				INNER JOIN [Person] as P ON U.userID=P.personID
				INNER JOIN [ContactDetails] as C ON P.contactDet=C.contactDetID
	end
	
	ELSE IF @pInherited = 1 
	begin
		INSERT @innerTableFinds2(fpersonID, ftitle, ffirstName,flastName, fcontactDet, frole)
				SELECT C.clientID, P.title, P.firstName, P.lastName, P.contactDet, P.role
				FROM [Client] as C					   
				INNER JOIN [Person] as P ON C.clientID=P.personID
				INNER JOIN [ContactDetails] as D ON P.contactDet=D.contactDetID
	end

	ELSE IF @pInherited = 2
	begin
		INSERT @innerTableFinds2(fpersonID, ftitle, ffirstName,flastName, fcontactDet, frole, fnatInsNumb, fjobTitle, fagenda)
				SELECT S.staffID, P.title, P.firstName, P.lastName, P.contactDet, P.role, S.natInsNumb, S.jobTitle, S.agenda
				FROM [Employee] as S					   
				INNER JOIN [Person] as P ON S.staffID=P.personID
				INNER JOIN [ContactDetails] as C ON P.contactDet=C.contactDetID
	end

RETURN 
END;
GO
