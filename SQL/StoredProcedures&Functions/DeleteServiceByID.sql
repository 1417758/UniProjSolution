USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteServiceByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteServiceByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteServiceByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteServiceByID]	
	@servID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM Services  
	WHERE serviceID = @servID;

	SELECT @@ROWCOUNT;  
	
END
