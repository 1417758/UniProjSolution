USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetApptsByStaffID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetApptsByStaffID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetApptsByStaffID ;
GO
CREATE PROCEDURE  [dbo].[GetApptsByStaffID]	
	@staffID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Appointments as A
	WHERE A.service IN (SELECT serviceID
						FROM Provide
						WHERE staffID = @staffID
					   )

	--SELECT A.apptID, A.date, A.endUser, A.service, S.serviceID, S.name, S.duration, P.staffID, P.serviceID
	--FROM Appointments as A
	--INNER JOIN Services as S ON A.service=S.serviceID
	--INNER JOIN [Provide] as P ON S.serviceID = P.serviceID	

END
