USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetPersonIDByLastName]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPersonIDByLastName', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetPersonIDByLastName ;
GO
CREATE PROCEDURE  [dbo].[GetPersonIDByLastName]	
	@lastNm varchar(50)
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT personID
	FROM [Person] as P 
	WHERE LOWER(lastName) LIKE LOWER('%'+@lastNm+'%')

	
END
