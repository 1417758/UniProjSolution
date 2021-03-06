USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertPayMethod]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertPayMethod', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertPayMethod ;
GO
CREATE PROCEDURE  [dbo].[InsertPayMethod]	
	@isOnlinePay bit, 
	@isCashPay bit,
	@payMetType varchar(50)
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO PaymentMethods VALUES (@isOnlinePay, @isCashPay, @payMetType);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
