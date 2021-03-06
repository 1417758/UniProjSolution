USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertService]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertService', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertService ;
GO
CREATE PROCEDURE  [dbo].[InsertService]	
	@name varchar(100),	
	@industry varchar(70),
	@nature smallint,
	@isCertifReq bit,
	@isInsReq bit,
	@description varchar(200),
	@duration tinyint,
	@durationUnit varchar(10)--,
--	@dateCreated smalldatetime
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	DECLARE @timeNow smalldatetime = CONVERT(smalldatetime, GETDATE());  

	--insert new tuple with given paramenters
	INSERT INTO Services VALUES (@name, @industry, @nature, @isCertifReq, @isInsReq , @description, @duration, @durationUnit, @timeNow );

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
