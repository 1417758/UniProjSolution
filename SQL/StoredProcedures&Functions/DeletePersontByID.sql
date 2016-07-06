USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeletePersonByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeletePersonByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeletePersonByID ;
GO
CREATE PROCEDURE  [dbo].[DeletePersonByID]	
	@personID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT ON;

	--delete row from table that has specified paramenter ID
	DELETE FROM Person  
	WHERE personID = @personID;

	SELECT @@ROWCOUNT;  
	
END
