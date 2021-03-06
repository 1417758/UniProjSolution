USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteContDetByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteContDetByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteContDetByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteContDetByID]	
	@contDetID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM ContactDetails  
	WHERE contactDetID = @contDetID;

	SELECT @@ROWCOUNT;  
	
END
