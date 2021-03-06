USE [EasyBook]
GO

/****** Object:  StoredProcedure [dbo].[InsertEndUser]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


IF OBJECT_ID(N'InsertPersonInher', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertPersonInher ;
GO
CREATE PROCEDURE  [dbo].[InsertPersonInher]	
	@p_title varchar(3),
	@p_firstName varchar(50),	
	@p_lastName varchar(50),
	@p_contactDet int,
--***   NOTE  **** @p_roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@p_role tinyint,
	@p_aspnetUserID uniqueIdentifier,
	@p_natInsNumb varchar(20),
	@p_jobTitle varchar(50),
	@p_agenda smallint 	
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT ON;

	--@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	DECLARE @Endusers tinyint = 2,
			@Staff tinyint = 3,
			@Clients tinyint = 4,
			@PersonINSERTreturn_value int;
			--@TEST int, @TEST2 int;

	--insert new tuple with given paramenters
		EXEC [dbo].[InsertPerson]	
		@returnID = @PersonINSERTreturn_value OUTPUT,
		@title = @p_title,
		@firstName = @p_firstName,
		@lastName =  @p_lastName,
		@contactDet = @p_contactDet,
		@role = @p_role,	
		@aspnetUserID  = @p_aspnetUserID;

	--SET @TEST = SCOPE_IDENTITY() ;
	--SET @TEST2 =  @@IDENTITY ;

	IF @p_role = @Endusers 
		--End-user
		INSERT INTO EndUser VALUES (@PersonINSERTreturn_value);

	ELSE IF @p_role = @Clients 
		--Client
		INSERT INTO Client VALUES (@PersonINSERTreturn_value);
	ELSE IF @p_role = @Staff
		--Staff
		INSERT INTO Employee VALUES (@PersonINSERTreturn_value, @p_natInsNumb, @p_jobTitle, @p_agenda);
	--//5/7/16 both below always returns NULL, NB 6/7/16 behaviour on VS2015 isnt the same 
	SELECT SCOPE_IDENTITY() AS [@@IDENTITY]; 
	--SELECT @@IDENTITY AS [@@IDENTITY]
	--RETURN @PersonINSERTreturn_value;  
	
END

