USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAgendaByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteAgendaByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteAgendaByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteAgendaByID]	
	@agendaID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM Agenda  
	WHERE agendaID = @agendaID;

	SELECT @@ROWCOUNT;  
	
END
