USE [EasyBook]
GO
/****** Object:  UserDefinedFunction [dbo].[GetPersonInherbyID    Script Date: 20/06/2016 17:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF OBJECT_ID(N'GetPersonInherByID', N'TF') IS NOT NULL
    DROP FUNCTION dbo.GetPersonInherByID ;
GO
 
CREATE FUNCTION [dbo].[GetPersonInherByID](
--***   NOTE  **** @roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@roleTypeID tinyint,
	@personID int 
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
			
	IF @roleTypeID = @Endusers  --=GET_all_Endusers
	--begin 
		--ALTER TABLE @innerTableFinds2
		--DROP COLUMN natInsNumb;
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID)
				SELECT P.*
				FROM [EndUser] as U
				INNER JOIN [Person] as P ON U.userID=P.personID
				WHERE P.personID = (SELECT userID
									  FROM EndUser
									  WHERE userID = @personID)

	--end
	
	ELSE IF @roleTypeID = @Clients  --=GET_all_Clients
	--begin
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID)
				SELECT P.*
				FROM [Client] as C					   
				INNER JOIN [Person] as P ON C.clientID=P.personID
				WHERE P.personID = (SELECT clientID
									  FROM Client
									  WHERE clientID = @personID)

	--end

	ELSE IF @roleTypeID = @Staff -- =GET_all_Staff, 
	--begin
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID, natInsNumb, jobTitle, agenda)
				SELECT P.*, S.natInsNumb, S.jobTitle, S.agenda
				FROM [Employee] as S					   
				INNER JOIN [Person] as P ON S.staffID=P.personID
				WHERE P.personID = (SELECT staffID
									  FROM Employee
									  WHERE staffID = @personID)

	--end

RETURN 
END;
