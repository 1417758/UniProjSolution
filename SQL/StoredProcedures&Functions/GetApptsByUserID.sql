USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetApptsByUserID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetApptsByUserID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetApptsByUserID ;
GO
CREATE PROCEDURE  [dbo].[GetApptsByUserID]	
	@end_userID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Appointments as A
	WHERE endUser = @end_userID;
	
--	ORDER BY personID ASC;
	
END
