USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertRole]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertRole', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertRole ;
GO
CREATE PROCEDURE  [dbo].[InsertRole]	
	@isAdmin bit,
	@roleType varchar(50)
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO Roles VALUES (@isAdmin, @roleType);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	--return @@ROWCOUNT;  
	
END
