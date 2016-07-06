USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].GetOrdersByID    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetOrdersByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetOrdersByID ;
GO
CREATE PROCEDURE  [dbo].GetOrdersByID	
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
