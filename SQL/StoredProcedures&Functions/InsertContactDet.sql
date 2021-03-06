USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertContactDet]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertContactDet', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertContactDet ;
GO
CREATE PROCEDURE  [dbo].[InsertContactDet]	
	@address varchar(200),	
	@postCode varchar(50),
	@city varchar(70),
	@country varchar(70),
	@landLine varchar(20),
	@mobile varchar(20),
	@email varchar(100),
	@dateCreated smalldatetime,
	@lastUpdated smalldatetime
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO ContactDetails VALUES (@address, @postCode, @city, @country, @landLine, @mobile, @email, @dateCreated, @lastUpdated);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
