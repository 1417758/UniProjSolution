USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetServiceByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetServiceByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetServiceByID ;
GO
CREATE PROCEDURE  [dbo].[GetServiceByID]	
	@servID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Services 
	WHERE serviceID = @servID;
	
--	ORDER BY personID ASC;
	
END
