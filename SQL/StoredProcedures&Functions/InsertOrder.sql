USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertOrder', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertOrder ;
GO
CREATE PROCEDURE  [dbo].[InsertOrder]	
	@status varchar(50), --ie: waiting payment, waiting appointment confirmation   
	@amount smallmoney,
	@isPaidinFull bit,
--	gracePeriod tinyint,
--	gracePdUnit varchar(10),
	@finTransID int,
	@apptID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO [Order] VALUES (@status, @amount, @isPaidinFull, @finTransID, @apptID);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
