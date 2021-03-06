USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAdmStaff]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAdmStaff', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAdmStaff ;
GO
CREATE PROCEDURE  [dbo].[GetAdmStaff]	
	--add parameters here
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
DECLARE @Endusers tinyint = 2,
		@Staff tinyint = 3,
		@Clients tinyint = 4;

	--***   NOTE  **** @roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	SELECT *
	FROM dbo.GetALLPersonInher3(@Staff)
	WHERE frole IN ( SELECT roleID
					 FROM Roles
					 WHERE isAdmin = 1); 
	
--	ORDER BY personID ASC;
	
END
