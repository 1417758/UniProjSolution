USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetPersonByASPuserID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetPersonByASPuserID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetPersonByASPuserID ;
GO
CREATE PROCEDURE  [dbo].[GetPersonByASPuserID]	
	@ASPNETuserID uniqueidentifier              
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM [Person] as P 
	WHERE aspnetUserID =@ASPNETuserID;
--	ORDER BY personID ASC;
	
END
