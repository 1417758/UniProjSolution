USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoleByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeleteRoleByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeleteRoleByID ;
GO
CREATE PROCEDURE  [dbo].[DeleteRoleByID]	
	@roleID tinyint
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--delete row from table that has specified paramenter ID
	DELETE FROM Roles  
	WHERE roleID = @roleID;

	SELECT @@ROWCOUNT;  
	
END
