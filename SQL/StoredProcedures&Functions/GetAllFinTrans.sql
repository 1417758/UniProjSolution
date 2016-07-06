USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAllFinTrans]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAllFinTrans', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAllFinTrans ;
GO
CREATE PROCEDURE  [dbo].[GetAllFinTrans]	
	--Add parameter here
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM FinancialTransaction;
	
--	ORDER BY personID ASC;
	
END
