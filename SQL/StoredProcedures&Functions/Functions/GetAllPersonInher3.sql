use EasyBook
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF OBJECT_ID(N'GetALLPersonInher3', N'TF') IS NOT NULL
    DROP FUNCTION dbo.GetALLPersonInher3;
GO
CREATE FUNCTION [dbo].[GetALLPersonInher3](
--***   NOTE  **** @roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@roleTypeID tinyint
)
RETURNS  @innerTableFinds2 TABLE(
	personID int NOT NULL,
	title varchar(3) NOT NULL,
	firstName varchar(50) NOT NULL,	
	lastName varchar(50) NOT NULL,
	contactDet int NOT NULL,
	[role] tinyint NOT NULL,
	aspnetUserID uniqueIdentifier NOT NULL,
	natInsNumb varchar(20),
	jobTitle varchar(50),
	agenda smallint 
)	
AS
BEGIN
--@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
DECLARE @Endusers tinyint = 2,
		@Staff tinyint = 3,
		@Clients tinyint = 4;


--DECLARE @innerTableFinds TABLE(
--	personID int NOT NULL,
--	ftitle varchar(3) NOT NULL,
--	ffirstName varchar(50) NOT NULL,	
--	flastName varchar(50) NOT NULL,
--	fcontactDet int NOT NULL,
--	frole int NOT NULL 
--)

	IF @roleTypeID = @Endusers 
	--begin 
		--ALTER TABLE @innerTableFinds2
		--DROP COLUMN natInsNumb;
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID)
				SELECT P.*
				FROM [EndUser] as U
				INNER JOIN [Person] as P ON U.userID=P.personID
	--end
	
	ELSE IF @roleTypeID = @Clients 
	--begin
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID)
				SELECT P.*
				FROM [Client] as C					   
				INNER JOIN [Person] as P ON C.clientID=P.personID
	--end

	ELSE IF @roleTypeID = @Staff
	--begin
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID, natInsNumb, jobTitle, agenda)
				SELECT P.*, S.natInsNumb, S.jobTitle, S.agenda
				FROM [Employee] as S					   
				INNER JOIN [Person] as P ON S.staffID=P.personID
	--end

RETURN 
END;
GO



