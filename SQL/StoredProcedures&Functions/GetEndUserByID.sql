USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetEndUserByID]    Script Date: 20/06/2016 17:05:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[GetEndUserByID]	
	@endUserID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	SELECT U.userID, P.title, P.firstName, P.lastName, P.contactDet, P.role
	FROM [EndUser] as U
	INNER JOIN [Person] as P ON U.userID=P.personID
	WHERE U.userID = (SELECT userID
					  FROM EndUser
					  WHERE userID = @endUserID)
	--ORDER BY userID ASC;
	
END
