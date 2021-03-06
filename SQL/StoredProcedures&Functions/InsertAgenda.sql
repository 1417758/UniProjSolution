USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertAgenda]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertAgenda', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertAgenda ;
GO
CREATE PROCEDURE  [dbo].[InsertAgenda]	
	@isAppUser bit,
	@syncCalendar bit
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO Agenda VALUES (@isAppUser, @syncCalendar);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
