USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetPersonInheritByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPersonInheritByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetPersonInheritByID ;
GO
CREATE PROCEDURE  [dbo].[GetPersonInheritByID]	
	--***   NOTE  **** @p_roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@p_roleTypeID tinyint,
	@p_ID int

AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	----@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	--DECLARE @Endusers tinyint = 2,
	--		@Staff tinyint = 3,
	--		@Clients tinyint = 4;

	-- get all as per given parameters 
	SELECT *
	FROM dbo.GetPersonInherByID(@p_roleTypeID, @p_ID); 


	
END
