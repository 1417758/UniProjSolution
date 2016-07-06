USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertProvide]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertProvide', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertProvide ;
GO
CREATE PROCEDURE  [dbo].[InsertProvide]	
	@staffID int,
	@servID int 
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO Provide VALUES (@staffID, @servID);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
