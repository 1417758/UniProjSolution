USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetApptsByStaffName]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetApptsByStaffName', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetApptsByStaffName ;
GO
CREATE PROCEDURE  [dbo].[GetApptsByStaffName]	
	@staff1stName varchar(20)
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Appointments as A
	WHERE A.provider LIKE '%'+@staff1stName+'%';
	
END
