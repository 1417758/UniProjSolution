USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetRoleByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetRoleByID ;
GO
CREATE PROCEDURE  [dbo].[GetRoleByID]	
	@roleID tinyint
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Roles] 
	WHERE roleID = @roleID;
	
--	ORDER BY personID ASC;
	
END
