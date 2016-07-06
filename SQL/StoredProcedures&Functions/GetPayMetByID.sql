USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetPayMetByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPayMetByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetPayMetByID ;
GO
CREATE PROCEDURE  [dbo].[GetPayMetByID]	
	@payMetID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM PaymentMethods
	WHERE payMethodID = @payMetID;
	
--	ORDER BY personID ASC;
	
END
