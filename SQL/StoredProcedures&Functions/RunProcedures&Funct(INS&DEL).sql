Use EasyBook
Go

--------TYPES
---- https://msdn.microsoft.com/en-us/library/ms177596.aspx

----@parameter: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
--DECLARE @Endusers tinyint = 2,
--		@Staff tinyint = 3,
--		@Clients tinyint = 4


----------  PROCEDURES --------
----EXEC [dbo].[InsertRole]	@isAdmin = 0, @roleType = 'Rock&roll2';

--DECLARE @returnID int;
--EXEC [dbo].[InsertPerson]	
--		@returnID = @returnID OUTPUT,
--		@title = N'mr',
--		@firstName = N'oi its me',
--		@lastName = N'just testing',
--		@contactDet = 1,
--		@role = 1,
--		@aspnetUserID = '10883C00-8892-43C2-9F6D-FF399123DC50';
--select @returnID AS RESULT;

----Select * from Roles	

---------- DELETE & RESET ID ---------------------------
--delete from EndUser
----where userID IN (select personID from Person where aspnetUserID = '294CB0FF-0F68-4A31-8F12-C26E34DCC0B8');	
--where userID IN (select personID from Person where aspnetUserID = '10883C00-8892-43C2-9F6D-FF399123DC50');
--delete from Person
--where aspnetUserID = '10883C00-8892-43C2-9F6D-FF399123DC50';	
--where aspnetUserID = '294CB0FF-0F68-4A31-8F12-C26E34DCC0B8';
--DBCC CHECKIDENT(Person, RESEED,7);
--------------------------------------------------------------

--DECLARE @userADDED int;
--EXEC [dbo].[InsertPersonInher]	
--	@p_title = 'ms',
--	@p_firstName = 'MAMMA WEB-USER',	
--	@p_lastName = 'FEVER',
--	@p_contactDet = 2,
--	--***   NOTE  **** @p_roleTypeID: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
--	@p_role = 2, 
--	@p_aspnetUserID = '10883C00-8892-43C2-9F6D-FF399123DC50', 
--	@p_natInsNumb = 'woteva',
--	@p_jobTitle ='developer',
--	@p_agenda =NULL; 	

select * from Person
Select * from EndUser	
--select * from Employee
--select * from Client


--EXEC [dbo].[InsertService]	
--	@name = 'newest SErvice',	
--	@industry ='oil&gas',
--	@nature =56,
--	@isCertifReq =1,
--	@isInsReq =0,
--	@description ='the beste service in town',
--	@duration ='30',
--	@durationUnit = 'hr'

--select * from Services;

--EXEC [dbo].[InsertAppt]	
--	@date ='2016/06/25',	
--	@time = '23:25:26',
--	@endUserID = 7,
--	@serviceID = 4,
--	@provider = 'Mr Dunno', --(1st Name of allocated member of staff)
--	@notes = 'is it really happening'

--DECLARE @return_value tinyint;
----@parameter: 2=Endusers, 3=Staff, 4=Clients -- REF to table ROLES --
--DECLARE @Endusers tinyint = 2;
--EXEC @return_value = [dbo].[DeletePersonInhertByID]
--		@p_personID = 11, @p_roleTypeID = @Endusers;
--PRINT @return_value;




-----------   FUNCTIONS  ------------

-------- table Functions ----
-------- @param: 2=Endusers, 4=Clients, 3=Staff, 

----DECLARE @pInherited smallint = 2;





-------- Scalar Functions ----
