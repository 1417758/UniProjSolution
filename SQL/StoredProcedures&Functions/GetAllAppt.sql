USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAllAppt]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAllAppt', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAllAppt ;
GO
CREATE PROCEDURE  [dbo].[GetAllAppt]	
	--Add parameter here
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Appointments;
	
--	ORDER BY personID ASC;
	
END
