USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetContactDetByPersLastName]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetContactDetByPersLastName', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetContactDetByPersLastName ;
GO
CREATE PROCEDURE  [dbo].[GetContactDetByPersLastName]	
	@lastName varchar(50)
AS
BEGIN
DECLARE @persID int;

	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;


	EXEC dbo.GetPersonIDByLastName 
	@lastNm = @lastName---- (NB MORE THEN ONE RESULT),  @pID = @persID OUTPUT;

	--REVISE
	--EXEC dbo.GetContactDetByPersonID 
	--@personID =  @persID;


END
