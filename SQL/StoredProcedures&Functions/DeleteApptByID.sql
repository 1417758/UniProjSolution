USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteApptByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteApptByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteApptByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteApptByID]	
	@p_apptID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM Appointments  
	WHERE apptID = @p_apptID;

	SELECT @@ROWCOUNT;  
	
END
