USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetServicesProvByStaffID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetServicesProvByStaffID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetServicesProvByStaffID ;
GO
CREATE PROCEDURE  [dbo].[GetServicesProvByStaffID]	
	@staffID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT S.*
	FROM Services as S
	INNER JOIN [Provide] as P ON S.serviceID = P.serviceID
	WHERE P.staffID = @staffID;
	
--	ORDER BY personID ASC;
	
END
