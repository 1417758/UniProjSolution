USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPayMet]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAllPayMet', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAllPayMet ;
GO
CREATE PROCEDURE  [dbo].[GetAllPayMet]	
	--add parameter here --ie:@payMetID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM PaymentMethods

	
END
