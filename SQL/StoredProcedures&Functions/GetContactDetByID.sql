USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetContactDetByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetContactDetByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetContactDetByID ;
GO
CREATE PROCEDURE  [dbo].[GetContactDetByID]	
	@contactDetID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM ContactDetails as C
	WHERE contactDetID = @contactDetID
--	ORDER BY personID ASC;
	
END
