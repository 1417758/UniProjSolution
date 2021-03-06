USE [EasyBook]
GO
/****** Object:  StoredProcedure [dbo].[InsertAppt]    Script Date: 20/06/2016 17:25:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID(N'InsertAppt', N'P') IS NOT NULL
    DROP PROCEDURE dbo.InsertAppt ;
GO
CREATE PROCEDURE  [dbo].[InsertAppt]	
	@date date,	
	@time time,
	@endUserID int,
	@serviceID int,
	@provider varchar(20), --(1st Name of allocated member of staff)
	@notes varchar(200)

AS
BEGIN
	-- SET NOCOUNT OFF to display the number of rows affected
	SET NOCOUNT OFF;

	--insert new tuple with given paramenters
	INSERT INTO Appointments VALUES (@date, @time, @endUserID, @serviceID, @provider, @notes);

	SELECT SCOPE_IDENTITY() AS [@@IDENTITY];  
	
END
