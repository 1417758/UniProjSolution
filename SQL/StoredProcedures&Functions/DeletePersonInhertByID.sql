USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[DeletePersonInhertByID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'DeletePersonInhertByID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.DeletePersonInhertByID ;
GO
CREATE PROCEDURE  [dbo].[DeletePersonInhertByID]	
	@p_personID int,
	--***   NOTE  **** @p_roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	@p_roleTypeID tinyint
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--@roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	DECLARE @Endusers tinyint = 2,
			@Staff tinyint = 3,
			@Clients tinyint = 4;

	IF @p_roleTypeID = @Endusers 
		--End-user
		DELETE FROM EndUser WHERE userID= @p_personID;
	ELSE IF @p_roleTypeID = @Clients 
		--Client
		DELETE FROM Client WHERE clientID= @p_personID;
	ELSE IF @p_roleTypeID = @Staff
		--Staff
		DELETE FROM Employee WHERE staffID= @p_personID;

	EXEC [dbo].[DeletePersonByID]
			@personID = @p_personID;

	SELECT @@ROWCOUNT;  

	
END
