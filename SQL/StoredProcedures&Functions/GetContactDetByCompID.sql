USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetContactDetByCompID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetContactDetByCompID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetContactDetByCompID ;
GO
CREATE PROCEDURE  [dbo].[GetContactDetByCompID]	
	@compID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT *
	FROM ContactDetails as C
------	INNER JOIN [Person] as P ON C.contactDetID = P.contactDet
	WHERE contactDetID IN ( SELECT contactDet
						   FROM Company
						   WHERE companyID = @compID)
	
--	ORDER BY personID ASC;
	
END
