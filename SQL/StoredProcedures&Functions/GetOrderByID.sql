USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetOrderByID]    Script Date: 28/06/2016 09:33:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE  [dbo].[GetOrderByID]	
	@orderID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Order]
	WHERE orderID = @orderID;
	
--	ORDER BY personID ASC;
	
END
