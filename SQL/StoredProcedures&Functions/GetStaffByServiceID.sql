USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[GetStaffByServiceID]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'GetStaffByServiceID', N'P') IS NOT NULL
    DROP PROCEDURE dbo.GetStaffByServiceID ;
GO
CREATE PROCEDURE  [dbo].[GetStaffByServiceID]	
	@servID int
AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	----***   NOTE  ****  @roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
	DECLARE @Endusers tinyint = 2,
			@Staff tinyint = 3,
			@Clients tinyint = 4;

 	SELECT S.*
	FROM dbo.GetALLPersonInher3(@Staff) as S
	INNER JOIN [Provide] as P ON S.personID = P.staffID
	WHERE P.serviceID = @servID;
		
--	ORDER BY personID ASC;
	
END
