USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertCompany]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertCompany', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertCompany ;
GO
CREATE PROCEDURE  [dbo].[InsertCompany]	
	@name varchar(200),	
	@industry varchar(70),
	@nature smallint,
	@coNumb varchar(50),
	@incorporated date,
	@url varchar(100),
	@mainContact int,
	@contactDet int,
	@isVATreg bit,
	@vatNumb varchar(50),
	@notes varchar(200)
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO Company VALUES (@name, @industry, @nature, @coNumb, @incorporated, @url, @mainContact, @contactDet, @isVATreg, @vatNumb, @notes);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
