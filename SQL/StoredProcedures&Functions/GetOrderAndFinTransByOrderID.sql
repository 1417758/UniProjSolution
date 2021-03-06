USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].GetOrderAndFinTransByOrderID    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetOrderAndFinTransByOrderID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetOrderAndFinTransByOrderID ;
GO
CREATE PROCEDURE  [dbo].GetOrderAndFinTransByOrderID	
	@orderID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Order] as O
	INNER JOIN FinancialTransaction as F ON O.finTrans = F.transID
	WHERE O.orderID = @orderID;
	
--	ORDER BY personID ASC;
	
END
