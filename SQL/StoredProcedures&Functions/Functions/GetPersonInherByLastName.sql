USE [EasyBook]
GO
/****** Object:  UserDefinedFunction [dbo].[GetPersonInherByLastName    Script Date: 20/06/2016 17:04:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF OBJECT_ID(N'GetPersonInherByLastName', N'TF') IS NOT NULL
    DROP FUNCTION dbo.GetPersonInherByLastName ;
GO
 
CREATE FUNCTION [dbo].[GetPersonInherByLastName](
--***   NOTE  **** @roleTypeI: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@roleTypeID tinyint,
	@lastName varchar(50)
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
DECLARE @find varchar(50) = '%'+@lastName+'%', 		
		--@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
		@Endusers tinyint = 2,
		@Staff tinyint = 3,
		@Clients tinyint = 4;
	
	IF @roleTypeID = @Endusers  --=GET_all_Endusers
	begin 
		--ALTER TABLE @innerTableFinds2
		--DROP COLUMN natInsNumb;
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID)
				SELECT P.*
				FROM [EndUser] as U
				INNER JOIN [Person] as P ON U.userID=P.personID
				WHERE P.personID IN( SELECT P.personID
										FROM [Person] as P 
										WHERE LOWER(lastName) LIKE LOWER(@find))
	end
	
	ELSE IF @roleTypeID = @Clients  --=GET_all_Clients
	begin
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID)
				SELECT P.*
				FROM [Client] as C					   
				INNER JOIN [Person] as P ON C.clientID=P.personID
				WHERE P.personID IN( SELECT P.personID
										FROM [Person] as P 
										WHERE lastName LIKE @find)

	end

	ELSE IF @roleTypeID = @Staff --=GET_all_Staff, 
	begin
		INSERT @innerTableFinds2(personID, title, firstName, lastName, contactDet, [role], aspnetUserID, natInsNumb, jobTitle, agenda)
				SELECT P.*, S.natInsNumb, S.jobTitle, S.agenda
				FROM [Employee] as S					   
				INNER JOIN [Person] as P ON S.staffID=P.personID
				WHERE P.personID IN( SELECT P.personID
										FROM [Person] as P 
										WHERE lastName LIKE @find)

	end

RETURN 
END;
