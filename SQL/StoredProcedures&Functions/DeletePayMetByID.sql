USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeletePayMetByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeletePayMetByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeletePayMetByID ;
GO
CREATE PROCEDURE  [dbo].[DeletePayMetByID]	
	@payMetID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM PaymentMethods  
	WHERE payMethodID = @payMetID;

	SELECT @@ROWCOUNT;  
	
END
