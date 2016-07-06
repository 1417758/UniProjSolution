USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetApptByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetApptByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetApptByID ;
GO
CREATE PROCEDURE  [dbo].[GetApptByID]	
	@apptID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Appointments 
	WHERE apptID = @apptID;
	
--	ORDER BY personID ASC;
	
END
