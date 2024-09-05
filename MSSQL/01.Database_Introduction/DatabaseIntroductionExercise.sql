--1
CREATE DATABASE [Minions]
USE [Minions]

--2
CREATE TABLE [Minions]
(
	[Id]	INT PRIMARY KEY,
	[Name]	VARCHAR(100),
	[Age]	INT
);
CREATE TABLE [Towns]
(
	[Id]	INT PRIMARY KEY,
	[Name]	VARCHAR(100)
);

--3
ALTER TABLE [Minions]
	ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]);

--4
INSERT INTO [Towns]
	([Id], [Name])
	VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO [Minions]
	([Id], [Name], [Age], [TownId])
	VALUES
	(1,	'Kevin',	22,		1),
	(2,	'Bob',		15,		3),
	(3,	'Steward',	NULL,	2);

--5
TRUNCATE TABLE [Minions];

--6
DROP TABLE [Minions];
DROP TABLE [Towns];

--7
CREATE TABLE [People]
(
	[Id]		INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[Name]		NVARCHAR(200)	NOT NULL,
	[Picture]	VARBINARY(MAX)	NULL,		--LIMIT TO 2MB!!!
	[Height]	DECIMAL(4, 2)	NULL,
	[Weight]	DECIMAL(5, 2)	NULL,
	[Gender]	VARCHAR(1)		NOT NULL,
	[Birthdate]	DATETIME2		NOT NULL,
	[Biography] NVARCHAR(MAX)	NULL
);
INSERT INTO [People]
	VALUES
	('Gosho',	NULL, NULL, NULL, 'm',	'02-13-2004',	NULL),
	('Pesho',	NULL, NULL, NULL, 'm',	'07-23-1968',	NULL), 
	('Maria',	NULL, NULL, NULL, 'f',	'04-06-1989',	NULL), 
	('Petya',	NULL, NULL, NULL, 'f',	'01-08-2009',	NULL), 
	('Dimitur',	NULL, NULL, NULL, 'm',	'08-12-2000',	NULL);

--8
CREATE TABLE [Users]
(
	[Id]				BIGINT			NOT NULL	PRIMARY KEY IDENTITY (1, 1),
	[Username]			VARCHAR(30)		NOT NULL,
	[Password]			VARCHAR(26)		NOT NULL,
	[ProfilePicture]	VARBINARY(MAX)	NULL,		--LIMIT TO 900KB!!!
	[LastLoginTime]		DATETIME2		NULL,
	[IsDeleted]			BIT				NOT NULL
);
INSERT INTO [Users]
	VALUES
	('Gosho',	'Gosho123',		NULL,	'01-08-2009',	1),
	('Pesho',	'Pesho123',		NULL,	'09-04-2021',	0), 
	('Maria',	'Maria123',		NULL,	'05-25-2018',	0), 
	('Petya',	'Petya123',		NULL,	NULL,			0), 
	('Dimitur',	'Dimitur123',	NULL,	'02-13-2004',	1);

--9
ALTER TABLE [Users]
	DROP CONSTRAINT [PK__Users__3214EC07BF030067];
ALTER TABLE [Users]
	ADD CONSTRAINT [PK_IdUsername]
	PRIMARY KEY ([Id], [Username]);

--10
ALTER TABLE [Users]
	ADD CONSTRAINT [CHK_PasswordMinLen]
	CHECK(LEN([Password]) >= 5);

--11
ALTER TABLE [Users]
	ADD CONSTRAINT [DF_Users_LastLoginTime]
	DEFAULT GETDATE() FOR [LastLoginTime];

--12
ALTER TABLE [Users]
	DROP CONSTRAINT [PK_IdUsername];
ALTER TABLE [Users]
	ADD CONSTRAINT [PK_Users_Id] PRIMARY KEY ([Id]);
ALTER TABLE [Users]
	ADD CONSTRAINT [UQ_Users_Username] UNIQUE ([Username]);
ALTER TABLE [Users]
	ADD CONSTRAINT [CHK_Users_UsernameMinLen] CHECK(Len([Username]) >= 3);

--13
CREATE DATABASE [Movies];
USE [Movies];

CREATE TABLE [Directors]
(
	[Id]			INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[DirectorName]	VARCHAR(100)	NOT NULL,
	[Notes]			VARCHAR(2000)	NULL
);
CREATE TABLE [Genres]
(
	[Id]			INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[GenreName]		VARCHAR(100)	NOT NULL,
	[Notes]			VARCHAR(2000)	NULL
);
CREATE TABLE [Categories]
(
	[Id]			INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[CategoryName]	VARCHAR(100)	NOT NULL,
	[Notes]			VARCHAR(2000)	NULL
);
CREATE TABLE [Movies]
(
	[Id]			INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[Title]			NVARCHAR(150)	NOT NULL,
	[DirectorId]	INT				NULL		FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear]	DATETIME2		NULL,
	[Length]		TIME			NULL,
	[GenreId]		INT				NULL		FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId]	INT				NULL		FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating]		DECIMAL(3, 1)	NULL		CHECK([Rating] >= 0 AND [Rating] <= 10),
	[Notes]			NVARCHAR(2000)	NULL
);

INSERT INTO [Directors]
	VALUES
	('Quentin Tarantino',	NULL),
	('Vin Diesel',			NULL),
	('James Cameron',		NULL),
	('Christopher Nolan',	NULL),
	('Steven Spielberg',	NULL);
INSERT INTO [Genres]
	VALUES
	('Science fiction',		NULL),
	('Action',				NULL),
	('Drama',				NULL),
	('Fantasy',				NULL),
	('Crime film',			NULL);
INSERT INTO [Categories]
	VALUES
	('Aliens',		NULL),
	('Racing',		NULL),
	('Space',		NULL),
	('Dinosaurs',	NULL),
	('Crime',		NULL);
INSERT INTO [Movies]
	VALUES
	('Interstellar',				4,	'10-26-2014',	'2:49:00',	1,	3,	8.6,	NULL),
	('Avatar',						3,	'12-17-2009',	'2:42:00',	2,	1,	7.9,	NULL),
	('The Fast and the Furious',	2,	'06-22-2001',	'1:46:00',	2,	2,	6.8,	NULL),
	('Jurassic Park',				5,	'09-17-1993',	'2:07:00',	1,	4,	8.2,	NULL),
	('Pulp Fiction',				1,	'10-14-1994',	'2:45:00',	5,	5,	8.9,	NULL);

--14
CREATE DATABASE [CarRental];
USE [CarRental];

CREATE TABLE [Categories]
(
	[Id]			INT			NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[CategoryName]	VARCHAR(50)	NOT NULL,
	[DailyRate]		SMALLMONEY	NOT NULL,
	[WeeklyRate]	SMALLMONEY	NOT NULL,
	[MonthlyRate]	SMALLMONEY	NOT NULL,
	[WeekendRate]	SMALLMONEY	NOT NULL
);
CREATE TABLE [Cars]
(
	[Id]			INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[PlateNumber]	VARCHAR(20)		NOT NULL,
	[Manufacturer]	VARCHAR(70)		NOT NULL,
	[Model]			NVARCHAR(50)	NOT NULL,
	[CarYear]		DATETIME2		NOT NULL,
	[CategoryId]	INT				NULL		FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors]			TINYINT			NOT NULL,
	[Picture]		VARCHAR(MAX)	NULL,
	[Condition]		VARCHAR(50)		NULL,
	[Available]		BIT				NOT NULL
);
CREATE TABLE [Employees]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] VARCHAR(40) NOT NULL,
	[Notes] VARCHAR(500) NULL
);
CREATE TABLE [Customers]
(
	[Id]					INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[DriverLicenseNumber]	VARCHAR(100)	NOT NULL,
	[FullName]				NVARCHAR(80)	NOT NULL,
	[Address]				NVARCHAR(150)	NULL,
	[City]					NVARCHAR(70)	NULL,
	[ZIPCode]				VARCHAR(15)		NULL,
	[Notes]					VARCHAR(500)	NULL
);
CREATE TABLE [RentalOrders]
(
	[Id]				INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId]		INT				NOT NULL	FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId]		INT				NOT NULL	FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId]				INT				NOT NULL	FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel]			DECIMAL(4, 1)	NOT NULL,
	[KilometrageStart]	INT				NOT NULL,
	[KilometrageEnd]	INT				NOT NULL,
	[TotalKilometrage]	INT				NOT NULL,
	[StartDate]			DATETIME2		NOT NULL,
	[EndDate]			DATETIME2		NOT NULL,
	[TotalDays]			SMALLINT		NOT NULL,
	[RateApplied]		SMALLMONEY		NOT NULL,
	[TaxRate]			SMALLMONEY		NOT NULL,
	[OrderStatus]		VARCHAR(30)		NOT NULL,
	[Notes]				VARCHAR(500)	NULL
);

INSERT INTO [Categories]
	VALUES
	('Sport', 70, 430, 1400, 100),
	('Off-road', 50, 320, 1150, 70),
	('Commuter', 20, 120, 400, 30)
INSERT INTO [Cars]
	VALUES
	('PB4568EX', 'Nissan',	'Skyline GT-R R34',	'09-29-2001',	1,	2,	NULL,	'Barely driven',	0),
	('PB8723PO', 'Toyota',	'Tacoma TRD Pro',	'03-14-2022',	2,	4,	NULL,	'Brand new',		1),
	('PB5935KA', 'Honda',	'Jazz',				'11-07-1985',	3,	2,	NULL,	'Beaten up',		1)
INSERT INTO [Employees]
	VALUES
	('Petar',	'Petrov',	'Mechanic', NULL),
	('Ivan',	'Ivanov',	'Salesman',	NULL),
	('Georgi',	'Georgiev',	'Cashier',	NULL)
INSERT INTO [Customers]
	VALUES
	('349345821904', 'Stamat Ivanov',		NULL, NULL, NULL, NULL),
	('345919204391', 'Onufrii Stamatov',	NULL, NULL, NULL, NULL),
	('654929387503', 'Gelyo Gelev',			NULL, NULL, NULL, NULL)
INSERT INTO [RentalOrders]
	VALUES
	(1, 1, 1, 19.2, 6432,	6832,	400,	'09-22-2022',	'09-30-2022', 8, 70, 20, 'Done', NULL),
	(2, 2, 2, 18.2, 432,	832,	400,	'09-22-2022',	'09-30-2022', 8, 70, 20, 'Done', NULL),
	(3, 3, 3, 14.2, 60432,	60832,	400,	'09-22-2022',	'09-30-2022', 8, 70, 20, 'Done', NULL)

--15
CREATE DATABASE [Hotel];
USE [Hotel];

CREATE TABLE [Employees]
(
	[Id]		INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[FirstName]	NVARCHAR(100)	NOT NULL,
	[LastName]	NVARCHAR(100)	NOT NULL,
	[Title]		VARCHAR(30)		NOT NULL,
	[Notes]		VARCHAR(MAX)	NULL
);
CREATE TABLE [Customers]
(
	[AccountNumber]		INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[FirstName]			NVARCHAR(100)	NOT NULL,
	[LastName]			NVARCHAR(100)	NOT NULL,
	[PhoneNumber]		VARCHAR(20)		NOT NULL,
	[EmergencyName]		NVARCHAR(100)	NOT NULL,
	[EmergencyNumber]	VARCHAR(20)		NOT NULL,
	[Notes]				VARCHAR(MAX)	NULL
);
CREATE TABLE [RoomStatus]
(
	[RoomStatus]	VARCHAR(20)		NOT NULL	PRIMARY KEY,
	[Notes]			VARCHAR(MAX)	NULL
);
CREATE TABLE [RoomTypes]
(
	[RoomType]	VARCHAR(20)		NOT NULL	PRIMARY KEY,
	[Notes]		VARCHAR(MAX)	NULL
);
CREATE TABLE [BedTypes]
(
	[BedType]	VARCHAR(20)		NOT NULL	PRIMARY KEY,
	[Notes]		VARCHAR(MAX)	NULL
);
CREATE TABLE [Rooms]
(
	[RoomNumber]	INT				NOT NULL	PRIMARY KEY	IDENTITY(10, 10),
	[RoomType]		VARCHAR(20)		NOT NULL	FOREIGN KEY	REFERENCES [RoomTypes]([RoomType]),
	[BedType]		VARCHAR(20)		NOT NULL	FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate]			DECIMAL(8, 2)	NOT NULL,
	[RoomStatus]	VARCHAR(20)		NOT NULL	FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes]			VARCHAR(MAX)	NULL
);
CREATE TABLE [Payments]
(
	[Id]				INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId]		INT				NOT NULL	FOREIGN KEY REFERENCES [Employees]([Id]),
	[PaymentDate]		DATETIME2		NOT NULL,
	[AccountNumber]		INT				NOT NULL	FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[FirstDateOccupied]	DATETIME2		NOT NULL,
	[LastDateOccupied]	DATETIME2		NOT NULL,
	[TotalDays]			SMALLINT		NOT NULL,
	[AmountCharged]		DECIMAL(15, 2)	NOT NULL,
	[TaxRate]			DECIMAL(13, 2)	NOT NULL,
	[TaxAmount]			DECIMAL(8, 2)	NOT NULL,
	[PaymentTotal]		DECIMAL(15, 2)	NOT NULL,
	[Notes]				VARCHAR(MAX)	NULL
);
CREATE TABLE [Occupancies]
(
	[Id]			INT				NOT NULL	PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId]	INT				NOT NULL	FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied]	DATETIME2		NOT NULL,
	[AccountNumber]	INT				NOT NULL	FOREIGN KEY REFERENCES [Customers]([AccountNumber]),
	[RoomNumber]	INT				NOT NULL	FOREIGN KEY REFERENCES [Rooms]([RoomNumber]),
	[RateApplied]	DECIMAL(8, 2)	NOT NULL,
	[PhoneCharge]	DECIMAL(8, 2)	NOT NULL,
	[Notes]			VARCHAR(MAX)	NULL
);

INSERT INTO [Employees]
	VALUES
	('a', 'a', 'a', NULL),
	('b', 'b', 'b', NULL),
	('c', 'c', 'c', NULL);
INSERT INTO [Customers]
	VALUES
	('a', 'a', '08881', 'a', '09991', NULL),
	('b', 'b', '08882', 'b', '09992', NULL),
	('c', 'c', '08883', 'c', '09993', NULL);
INSERT INTO [RoomStatus]
	VALUES
	('Available',	NULL),
	('Occupied',	NULL),
	('Unknown',		NULL);
INSERT INTO [RoomTypes]
	VALUES
	('Small',	NULL),
	('Medium',	NULL),
	('Big',		NULL);
INSERT INTO [BedTypes]
	VALUES
	('Single',		NULL),
	('Double',		NULL),
	('Queen-size',	NULL);
INSERT INTO [Rooms]
	VALUES
	('Small',	'Single',		1,	'Available',	NULL),
	('Medium',	'Double',		2,	'Occupied',		NULL),
	('Big',		'Queen-size',	3,	'Unknown',		NULL);
INSERT INTO [Payments]
	VALUES
	(1,	'01-01-2022',	1,	'01-01-2020',	'01-01-2021',	365,	1111.11,	10,	100,	1211.11,	NULL),
	(2, '02-02-2022',	2,	'02-02-2020',	'02-02-2021',	365,	2222.22,	20,	200,	2422.22,	NULL),
	(3, '03-03-2022',	3,	'03-03-2020',	'03-03-2021',	365,	3333.33,	30,	300,	3633.33,	NULL);
INSERT INTO [Occupancies]
	VALUES
	(1,	'01-01-2020',	1,	10,	1,	10,	NULL),
	(2, '02-02-2020',	2,	20,	2,	20,	NULL),
	(3, '03-03-2020',	3,	30,	3,	30,	NULL);