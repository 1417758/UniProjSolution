USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetPersonByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPersonByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetPersonByID ;
GO
CREATE PROCEDURE  [dbo].[GetPersonByID]	
	@personID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Person] as P 
	WHERE personID = @personID
--	ORDER BY personID ASC;
	
END
