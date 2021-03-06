USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteProvideByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteProvideByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteProvideByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteProvideByID]	
	@servID int,
	@staffID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM Provide  
	WHERE serviceID = @servID AND staffID = @staffID;

	SELECT @@ROWCOUNT;  
	
END
