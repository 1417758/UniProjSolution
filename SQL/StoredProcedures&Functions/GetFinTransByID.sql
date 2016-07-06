USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetFinTransByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetFinTransByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetFinTransByID ;
GO
CREATE PROCEDURE  [dbo].[GetFinTransByID]	
	@finTransID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM FinancialTransaction
	WHERE transID = @finTransID;
	
--	ORDER BY personID ASC;
	
END
