USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertPerson]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertPerson', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertPerson ;
GO
CREATE PROCEDURE  [dbo].[InsertPerson]
	@returnID int OUTPUT,		
	@title varchar(3),
	@firstName varchar(50),	
	@lastName varchar(50),
	@contactDet int,
	@role tinyint, 
	@aspnetUserID uniqueIdentifier
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT ON;

	--insert new tuple with given paramenters
	INSERT INTO Person VALUES (@title, @firstName, @lastName, @contactDet, @role, @aspnetUserID);

	SET @returnID = SCOPE_IDENTITY();
	SELECT SCOPE_IDENTITY() AS [@@IDENTITY]  
	--RETURN SCOPE_IDENTITY();
	--RETURN @@IDENTITY 
	
END
