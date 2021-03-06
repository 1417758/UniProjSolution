USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrderByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteOrderByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteOrderByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteOrderByID]	
	@p_orderID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM [Order]  
	WHERE orderID = @p_orderID;

	SELECT @@ROWCOUNT;  
	
END
