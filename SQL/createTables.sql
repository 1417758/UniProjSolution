use EasyBook
go

-----  delete --------
--DROP TABLE [Order];
--DROP TABLE Appointments;
--DROP TABLE FinancialTransaction;
--DROP TABLE PaymentMethods;
--DROP TABLE Provide;
--DROP TABLE [Services];
--DROP TABLE Company;
--DROP TABLE EndUser;
--DROP TABLE Client;
--DROP TABLE Employee;
--DROP TABLE Person;
--DROP TABLE ContactDetails;
--DROP TABLE Agenda;
--DROP TABLE Roles;

---****** TABLE STRUCTURE UPDATE *****-----------
----To change the data type of a column
--ALTER TABLE FinancialTransaction
--ALTER COLUMN authorisCode uniqueidentifier;

----add a column in a table
--ALTER TABLE PersonReturn
--ADD aspnetUserID uniqueIdentifier
----To change the data type of a column
-- ALTER TABLE PersonReturn
-- ALTER COLUMN [agenda] smallint

----delete a column in a table
--ALTER TABLE table_name
--DROP COLUMN column_name
-----*********************************-----------

--Create Role
CREATE TABLE [Roles] (
	roleID tinyint PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	isAdmin bit NOT NULL,
	roleType varchar(50) NOT NULL,
)

--Create Agenda
CREATE TABLE Agenda (
	agendaID smallint PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	isAppUser bit NOT NULL,
	syncCalendar bit,
)

--Create ContactDetails
CREATE TABLE ContactDetails (
	contactDetID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	[address] varchar(200),	
	postCode varchar(50),
	city varchar(70),
	country varchar(70),
	landLine varchar(20),
	mobile varchar(20),
	email varchar(100),
	dateCreated smalldatetime,
	lastUpdated smalldatetime
)

--CREATE TABLE PersonReturn(
--	personID int NOT NULL,
--	title varchar(3) CHECK(title IN('Mr', 'Ms', 'Mrs')),
--	firstName varchar(50) NOT NULL,	
--	lastName varchar(50) NOT NULL,
--	contactDet int,
--	[role] tinyint NOT NULL,
--	aspnetUserID uniqueIdentifier,
--	natInsNumb varchar(20),
--	jobTitle varchar(50),
--	agenda smallint 
--)
--Create Person
CREATE TABLE Person (
	personID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	title varchar(3) NOT NULL CHECK(title IN('Mr', 'Ms', 'Mrs')),
	firstName varchar(50) NOT NULL,	
	lastName varchar(50) NOT NULL,
	contactDet int NOT NULL FOREIGN KEY REFERENCES ContactDetails (contactDetID) ON DELETE CASCADE ON UPDATE CASCADE,
	[role] tinyint NOT NULL FOREIGN KEY REFERENCES Roles (roleID) ON DELETE CASCADE ON UPDATE CASCADE,
	aspnetUserID uniqueidentifier NOT NULL FOREIGN KEY REFERENCES aspnet_Users (UserId) ON DELETE CASCADE ON UPDATE CASCADE,	
)
--Create Employee
CREATE TABLE Employee (
	staffID int PRIMARY KEY CLUSTERED REFERENCES Person(personID) NOT NULL,
	natInsNumb varchar(20),
	jobTitle varchar(50),
	agenda smallint FOREIGN KEY REFERENCES Agenda (agendaID) ON DELETE CASCADE ON UPDATE CASCADE	
)

--Create Client
CREATE TABLE Client (
	clientID int PRIMARY KEY CLUSTERED REFERENCES Person(personID) NOT NULL
)

--Create User
CREATE TABLE EndUser (
	userID int PRIMARY KEY CLUSTERED REFERENCES Person(personID) NOT NULL
)

--Create Company
CREATE TABLE Company (
	companyID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	name varchar(200),	
	industry varchar(70),
	nature smallint,
	coNumb varchar(50),
	incorporated date,
	url varchar(100),
	mainContact int FOREIGN KEY REFERENCES Client (clientID) ON DELETE CASCADE ON UPDATE CASCADE,
	contactDet int NOT NULL FOREIGN KEY REFERENCES ContactDetails (contactDetID) ON DELETE CASCADE ON UPDATE CASCADE,
	isVATreg bit,
	vatNumb varchar(50),
	notes varchar(200)
)

--Create Services
CREATE TABLE [Services] (
	serviceID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	name varchar(100),	
	industry varchar(70),
	nature smallint,
	isCertifReq bit,
	isInsReq bit,
	[description] varchar(200),
	duration tinyint,
	durationUnit varchar(10),
	dateCreated smalldatetime
)

-- many to many Normalisation (Staff & Services)
CREATE TABLE Provide(
  staffID int NOT NULL,
  serviceID int NOT NULL,
  CONSTRAINT PK_Provide PRIMARY KEY NONCLUSTERED (staffID, serviceID),
  FOREIGN KEY (staffID) REFERENCES Employee (staffID) ON DELETE CASCADE ON UPDATE CASCADE,
  FOREIGN KEY (serviceID) REFERENCES Services (serviceID) ON DELETE CASCADE ON UPDATE CASCADE
)

--Create PaymentMethods
CREATE TABLE PaymentMethods (
	payMethodID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	isOnlinePay bit, 
	isCashPay bit,
	payMetType varchar(50)
)

--Create FinancialTransaction
CREATE TABLE FinancialTransaction (
	transID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	[status] varchar(50) NOT NULL, --ie: completed, aborted, cancelled, pending, processing  
	amount smallmoney NOT NULL,
	payMetType int NOT NULL FOREIGN KEY REFERENCES PaymentMethods (payMethodID) ON DELETE CASCADE ON UPDATE CASCADE,
	authorisCode uniqueidentifier,
	[date] smalldatetime
)

--Create Appointments
CREATE TABLE Appointments (
	apptID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	[date] date,	
	[time] time,
	endUser int NOT NULL FOREIGN KEY REFERENCES EndUser (userID) ON DELETE NO ACTION ON UPDATE CASCADE,
	[service] int NOT NULL FOREIGN KEY REFERENCES Services (serviceID) ON DELETE NO ACTION ON UPDATE CASCADE,
	provider varchar(20), --(Name of allocated member of staff)
	notes varchar(200)
)

--Create Order
CREATE TABLE [Order] (
	orderID int PRIMARY KEY CLUSTERED IDENTITY(1,1) NOT NULL,
	[status] varchar(50) NOT NULL, --ie: waiting payment, waiting appointment confirmation   
	amount smallmoney NOT NULL,
	isPaidinFull bit,
--	gracePeriod tinyint,
--	gracePdUnit varchar(10),
	finTrans int NOT NULL FOREIGN KEY REFERENCES FinancialTransaction (transID) ON DELETE CASCADE ON UPDATE CASCADE,
	appt int NOT NULL FOREIGN KEY REFERENCES Appointments (apptID) ON DELETE CASCADE ON UPDATE CASCADE	
)







