USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetOrderIDByApptID]    Script Date: 28/06/2016 09:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID(N'GetOrderIDByApptID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetOrderIDByApptID ;
GO
CREATE PROCEDURE  [dbo].[GetOrderIDByApptID]	
	@apptID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT orderID
	FROM [Order]
	WHERE appt = @apptID;
	
--	ORDER BY personID ASC;
	
END
