USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetAllPersonInherit]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetAllPersonInherit', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetAllPersonInherit ;
GO
CREATE PROCEDURE  [dbo].[GetAllPersonInherit]	
	--***   NOTE  **** @p_roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@p_roleTypeID tinyint
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	----@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	--DECLARE @Endusers tinyint = 2,
	--		@Staff tinyint = 3,
	--		@Clients tinyint = 4;

	-- get all employees
	SELECT *
	FROM dbo.GetALLPersonInher3(@p_roleTypeID); 

	
END
