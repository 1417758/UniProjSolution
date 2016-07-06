Use EasyBook
Go
------TYPES
-- https://msdn.microsoft.com/en-us/library/ms177596.aspx
--------  PROCEDURES --------
--EXEC [dbo].[GetAllEndUsers]

--EXEC dbo.GetEndUserByID @endUserID=6;

--EXEC dbo.GetPersonByID @personID=2;

--EXEC dbo.GetPersonByLastName @lastNm = N'contact';

EXEC dbo.GetPersonIDByLastName @lastNm = N'contact';

--EXEC dbo.GetContactDetByID @contactDetID=2;

--EXEC GetContactDetByPersonID @personID=6;

----UNDER CONSTRUCTION
----EXEC GetContactDetByPersLastName @lastNm=N'smith';

--EXEC [dbo].[GetAdmStaff];

--EXEC dbo.GetAllCompanies

--EXEC dbo.GetAllCompaniesByID @compID=2;

--EXEC [dbo].[GetContactDetByCompID] @compID=2;

	--SELECT *
	--FROM Services
	
	--SELECT *
	--FROM Provide

--EXEC [dbo].[GetServicesProvByStaffID] @staffID = 2;

--EXEC [dbo].[GetStaffByServiceID] @servID = 3;

--EXEC [dbo].[GetAllServices];

--	SELECT *
--	FROM Employee

--EXEC [dbo].[GetStaffByServiceName] @servName = N'acunp';

--EXEC [dbo].[GetAllappt];

--EXEC [dbo].[GetApptByID] @apptID = 3;

--EXEC [dbo].[GetApptsByUserID] @end_userID=6;

--EXEC [dbo].[GetApptsByDate]	@appt_date='2016/06/15';

	--SELECT A.apptID, A.date, A.endUser, A.service, S.serviceID, S.name, S.duration, P.staffID, P.serviceID
	--FROM Appointments as A
	--INNER JOIN Services as S ON A.service=S.serviceID
	--INNER JOIN [Provide] as P ON S.serviceID = P.serviceID	

--EXEC [dbo].[GetApptsByStaffID] @staffID = 3; --#NB @staffID=3 IS CORRECT (error inserting sample data)

--EXEC [dbo].[GetApptsByStaffName] @staff1stName = 'f';

--exec  [dbo].[GetAllOrders];
----exec  [dbo].[GetOrderByID] @orderID = 1;
----exec  [dbo].GetOrderByApptID @apptID = 2;

--EXEC [dbo].GetOrderAndFinTransByOrderID	@orderID=2;

--EXEC [GetOrderIDByApptID] @apptID=3;
	

---------   FUNCTIONS  ------------
----@parameter: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
--DECLARE @Endusers tinyint = 2,
--		@Staff tinyint = 3,
--		@Clients tinyint = 4

----select * from Person

--------   TABLE FUNCTIONS  ----

---- get all employees
--SELECT *
--FROM dbo.GetALLPersonInher3(@Staff); 

--SELECT *
--FROM dbo.GetAllPersonInherWithDet(2); 

----GET end-user with id=7
--SELECT *
--FROM dbo.GetPersonInherByID(2,7); 

----GET staff with santos on its lastName
--SELECT *
--FROM dbo.GetPersonInherByLastName(@Staff,'santos'); --(@Clients,'contact'); --client with surName 'contact'



------   SCALAR FUNCTIONS   ----
