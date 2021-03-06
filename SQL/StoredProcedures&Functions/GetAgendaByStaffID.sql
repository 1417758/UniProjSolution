USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAgendaByStaffID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAgendaByStaffID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAgendaByStaffID ;
GO
CREATE PROCEDURE  [dbo].[GetAgendaByStaffID]	
	@staffID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Agenda as A
	--INNER JOIN [Employee] as E ON A.agendaID = E.agenda
	WHERE agendaID = (Select agendaID
					  FROM Employee
					  WHERE staffID = @staffID);
		
END
