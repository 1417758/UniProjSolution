USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertFinTrans]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertFinTrans', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertFinTrans ;
GO
CREATE PROCEDURE  [dbo].[InsertFinTrans]	
	@status varchar(50), 
	@amount smallmoney,
	@payMetType int,
	@authorisCode uniqueidentifier,
	@timeStamp smalldatetime
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO FinancialTransaction VALUES (@status, @amount, @payMetType, @authorisCode, @timeStamp);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
