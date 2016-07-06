use EasyBook
go

---------  delete  ------
------TRUNCATE TABLE Roles;
--DELETE FROM Person
--DBCC CHECKIDENT(Person, RESEED,0);

----TRUNCATE TABLE Agenda;
--DELETE FROM Person
--DBCC CHECKIDENT(Person, RESEED,0);

------  sample data  ------
DECLARE
@d1c datetime, @d2u datetime, @d3 datetime;
SET @d1c = '2016/01/23 23:59:59';
SET @d2u = '2016/06/01 11:03:28';
SET @d3 = '2015/12/31 01:22:14';

-- Roles - (isAdmin, roleType)
INSERT INTO [Roles] VALUES (1, 'Admin');
INSERT INTO [Roles] VALUES (0, 'End-user');
INSERT INTO [Roles] VALUES (0, 'Staff');
INSERT INTO [Roles] VALUES (0, 'Client');

-- Agenda - (isAppUser, syncCalendar) 
INSERT INTO Agenda VALUES (1, 0);
INSERT INTO Agenda VALUES (0, 1);
INSERT INTO Agenda VALUES (0, NULL);

--ContactDetails - ([address], postCode, city, country, landLine, mobile, email, dateCreated, lastUpdated)
INSERT INTO ContactDetails VALUES ('12 Bellfield View', 'AB15 7TD', 'Aberdeen', 'UK', '+44(0)1224 312797', '+44(0)7901672728', '1417758@rgu.ac.uk', @d1c, @d2u);
INSERT INTO ContactDetails VALUES('Rua GB 6 Quadra 9 Lote 12 Jd. Guanara II', '740680-740', 'Goiania', 'Brazil', '+55(62)3204 1890', NULL, 'kellondon2004@yahoo.com', @d3, @d1c);
INSERT INTO ContactDetails VALUES ('45 no mans land', '892ASSS', 'Zurich', 'Switzerland', 'dunno', NULL, NULL, @d1c, @d2u);


-- Person - (title, firstName, lastName, contactDet, [role])
--(Employee)
INSERT INTO Person VALUES ('Ms', 'Rachie', 'McSantos', 1, 1, (select top 1 UserId from aspnet_Users));
INSERT INTO Person VALUES('Mr', 'Rite', 'Rite', 2, 3, (SELECT UserId FROM aspnet_Users WHERE  LoweredUserName = 'rachelb'));
INSERT INTO Person VALUES ('Mrs', 'Future', 'Hand', 3, 3, (SELECT UserId FROM aspnet_Users WHERE  LoweredUserName = 'rachelc'));
--(clients)
INSERT INTO Person VALUES ('Ms', 'Client', 'CompanyContact', 2, 4, (SELECT UserId FROM aspnet_Users WHERE  LoweredUserName = 'rachelb'));
INSERT INTO Person VALUES('Mr', 'Client2', 'CompanyContact2', 3, 4, (select top 1 UserId from aspnet_Users));
--(end-user)
INSERT INTO Person VALUES ('Mrs', 'geek-user1', 'Capello', 2, 2, (SELECT UserId FROM aspnet_Users WHERE  LoweredUserName = 'rachelc'));
INSERT INTO Person VALUES ('Mrs', 'geek-user2', 'Smith', 1, 2, (select top 1 UserId from aspnet_Users));

-- Employee - (staffID, natInsNumb, jobTitle, agenda)
INSERT INTO Employee VALUES (1, NULL , NULL, 3);
INSERT INTO Employee VALUES (2, 'BP-75845212-B', 'perky', 1);
INSERT INTO Employee VALUES(3, '95892348423890', 'Handy woman', 2);

-- Client - (clientID)
INSERT INTO Client VALUES (4);
INSERT INTO Client VALUES(5);

-- EndUser - (userID)
INSERT INTO EndUser VALUES (6);
INSERT INTO EndUser VALUES(7);

-- Company - (name, industry, nature, coNumb, incorporated, url, mainContact, contactDet, isVATreg, vatNumb, notes)
INSERT INTO Company VALUES ('HAPPY PET SHOP', 'pet industry', 255, '546854685', @d1c, 'www.happypet.co.uk', 4, 1, 0, NULL, 'no comments this this around');
INSERT INTO Company VALUES ('Beautiful Nail Art', 'beauty Salon', 13, '34ed56665756', @d2u, 'www.gumtree.com/naiArt', 5, 3, 1, '89034805', NULL);
INSERT INTO Company VALUES ('Acunpuncture Me Me', 'health', 5, NULL , @d3, NULL, 4, 3, 0, NULL, NULL);

-- Services - (name, industry, nature, isCertifReq, isInsReq, [description], duration, durationUnit, dateCreated)
INSERT INTO Services VALUES ('dog walking', 'pet industry', 255, 0, 1, 'a walk in the park', 1, 'hr', @d1c);
INSERT INTO Services VALUES ('dog walking', 'pet industry', 255, 0, 1, 'a walk in the park', 30, 'min', @d1c);
INSERT INTO Services VALUES ('acunpuncture', 'health', 5, 1 , 1, 'various body parts aplly :D', 10, 'min', @d3);

-- Provide -Staff & Services Norma - (staffID, serviceID)
INSERT INTO Provide VALUES (1, 2);
INSERT INTO Provide VALUES (1, 2);
INSERT INTO Provide VALUES (2, 3);
INSERT INTO Provide VALUES (3, 1);
INSERT INTO Provide VALUES (3, 2);
INSERT INTO Provide VALUES (3, 3);

-- PaymentMethods - (isOnlinePay, isCashPay, payMetType)
INSERT INTO PaymentMethods VALUES (1, 0, 'credit card');
INSERT INTO PaymentMethods VALUES (1, 0, 'wire transfer');
INSERT INTO PaymentMethods VALUES (1, 0, 'paypal');
INSERT INTO PaymentMethods VALUES (0, 1, 'cash');
INSERT INTO PaymentMethods VALUES (0, 0, 'direct debit');

-- FinancialTransaction - ([status], amount, payMetType, authorisCode, [date])
INSERT INTO FinancialTransaction VALUES ('completed', '23.65', 1, '0E984725-C51C-4BF4-9960-E1C80E27ABA0', @d1c);
INSERT INTO FinancialTransaction VALUES ('processing', '445.05', 2, '0E984725-C51C-4BF4-9960-E1C80E27ABA0', @d2u);
INSERT INTO FinancialTransaction VALUES ('aborted', '89.36', 3, '0E984725-C51C-4BF4-9960-E1C80E27ABA0', @d3);
INSERT INTO FinancialTransaction VALUES ('cancelled', '14.04', 4, NULL, @d1c);
INSERT INTO FinancialTransaction VALUES ('pending', '986.32', 5, '0E984725-C51C-4BF4-9960-E1C80E27ABA0', @d3);

-- Appointments - ([date], [time], endUser, [service], provider, notes)
INSERT INTO Appointments VALUES ('2016/06/15', '12:00:00', 6, 1, 'Amanda', 'always late');
INSERT INTO Appointments VALUES ('2015/05/23', '13:30:00', 7, 2, 'Fabio', NULL);
INSERT INTO Appointments VALUES ('2016/01/14', '08:15:00', 6, 3, 'Fernando', 'hot');

-- [Order] - ([status], amount, isPaidinFull, finTrans, appt)
INSERT INTO [Order] VALUES ('waiting payment', '589.32', 1, 1, 2);
INSERT INTO [Order] VALUES ('waiting appointment confirmation', '21.36', 1, 3, 3);
INSERT INTO [Order] VALUES ('completed', '9.31', 0, 4, 1);

