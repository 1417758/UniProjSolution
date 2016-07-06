USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAgendaByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAgendaByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAgendaByID ;
GO
CREATE PROCEDURE  [dbo].[GetAgendaByID]	
	@agendaID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM Agenda as A
	WHERE agendaID = @agendaID;
		
END
