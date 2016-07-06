USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetApptsByDate]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetApptsByDate', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetApptsByDate ;
GO
CREATE PROCEDURE  [dbo].[GetApptsByDate]	
	@appt_date datetime
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Appointments as A
	WHERE date = @appt_date;
	
--	ORDER BY personID ASC;
	
END
