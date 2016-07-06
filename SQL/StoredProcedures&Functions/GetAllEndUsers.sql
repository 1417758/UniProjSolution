use EasyBook
go

/***** Object: StoredProcedure [dbo].[GetAllEndUsers] Script Date: 20/06/2016 10:46:38  *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE  [dbo].[GetAllEndUsers]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT U.userID, P.title, P.firstName, P.lastName, P.contactDet, P.role
	FROM [EndUser] as U
	INNER JOIN [Person] as P ON U.userID=P.personID
	ORDER BY userID ASC;
	
END
GO
