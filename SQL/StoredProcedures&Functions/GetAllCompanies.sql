USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCompanies]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAllCompanies', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAllCompanies ;
GO
CREATE PROCEDURE  [dbo].[GetAllCompanies]	
	--add parameters here
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Company 
	
--	ORDER BY personID ASC;
	
END
