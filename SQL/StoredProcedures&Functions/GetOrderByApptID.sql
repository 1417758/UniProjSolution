USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetOrderByApptID]    Script Date: 28/06/2016 09:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[GetOrderByApptID]	
	@apptID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Order]
	WHERE appt = @apptID;
	
--	ORDER BY personID ASC;
	
END
