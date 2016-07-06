USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetPersonByLastName]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPersonByLastName', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetPersonByLastName ;
GO
CREATE PROCEDURE  [dbo].[GetPersonByLastName]	
	@lastNm varchar(50)
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Person] as P 
	WHERE LOWER(lastName) LIKE LOWER('%'+@lastNm+'%')

	
END
