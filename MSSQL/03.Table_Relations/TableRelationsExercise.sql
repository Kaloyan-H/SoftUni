--1
--CREATE DATABASE [People];

USE [People];

CREATE TABLE [Passports]
(
	[PassportID]		INT			NOT NULL	IDENTITY(101, 1),
	[PassportNumber]	VARCHAR(20)	NOT NULL,
	CONSTRAINT [PK_Passports]
		PRIMARY KEY([PassportID])
);
CREATE TABLE [Persons]
(
	[PersonID]		INT				NOT NULL	IDENTITY(1, 1),
	[FirstName]		VARCHAR(50)		NOT NULL,
	[Salary]		DECIMAL(14, 2)	NOT NULL,
	[PassportID]	INT				NOT NULL	UNIQUE,
	CONSTRAINT [PK_Persons]
		PRIMARY KEY([PersonID]),
	CONSTRAINT [FK_Persons_Passports]
		FOREIGN KEY([PassportID])
		REFERENCES [Passports]([PassportID])
);

INSERT INTO [Passports]
	VALUES
	('N34FG21B'),
	('K65L04R7'),
	('ZE657QP2');

INSERT INTO [Persons]
	VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101);

--2
--CREATE DATABASE [Models];

USE [Models];

CREATE TABLE [Manufacturers]
(
	[ManufacturerID]	INT			NOT NULL	IDENTITY(1, 1),
	[Name]				VARCHAR(50)	NOT NULL,
	[EstablishedOn]		DATETIME2	NOT NULL,
	CONSTRAINT [PK_Manufacturers]
		PRIMARY KEY([ManufacturerID])
);
CREATE TABLE [Models]
(
	[ModelID]			INT			NOT NULL	IDENTITY(101, 1),
	[Name]				VARCHAR(20)	NOT NULL,
	[ManufacturerID]	INT			NOT NULL,
	CONSTRAINT [PK_Models]
		PRIMARY KEY([ModelID]),
	CONSTRAINT [FK_Models_Manufacturers]
		FOREIGN KEY([ManufacturerID])
		REFERENCES [Manufacturers]([ManufacturerID])
);

INSERT INTO [Manufacturers]
	VALUES
	('BMW',		'07-03-1916'),
	('Tesla',	'01-01-2003'),
	('Lada',	'01-05-1966');

INSERT INTO [Models]
	VALUES
	('X1',		1),
	('i6',		1),
	('Model S',	2),
	('Model X', 2),
	('Model 3', 2),
	('Nova',	3);

--3
--CREATE DATABASE [Students];

USE [Students];

CREATE TABLE [Students]
(
	[StudentID] INT NOT NULL IDENTITY(1, 1),
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Students]
		PRIMARY KEY([StudentID])
);
CREATE TABLE [Exams]
(
	[ExamID] INT NOT NULL IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Exams]
		PRIMARY KEY([ExamID])
);
CREATE TABLE [StudentsExams]
(
	[StudentID] INT NOT NULL,
	[ExamID] INT NOT NULL,
	CONSTRAINT [PK_StudentsExams]
		PRIMARY KEY([StudentID], [ExamID]),
	CONSTRAINT [FK_StudentsExams_Students]
		FOREIGN KEY([StudentID])
		REFERENCES [Students]([StudentID]),
	CONSTRAINT [FK_StudentsExams_Exams]
		FOREIGN KEY([ExamID])
		REFERENCES [Exams]([ExamID]),
);

INSERT INTO [Students]
	VALUES
	('Mila'),                                   
	('Toni'),
	('Ron');

INSERT INTO [Exams]
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g');

INSERT INTO [StudentsExams]
	VALUES
	(1,	101),
	(1,	102),
	(2,	101),
	(3,	103),
	(2,	102),
	(2,	103);

--4
--CREATE DATABASE [Teachers];

USE [Teachers];

CREATE TABLE [Teachers]
(
	[TeacherID] INT NOT NULL IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT,
	CONSTRAINT [PK_Teachers]
		PRIMARY KEY([TeacherID]),
	CONSTRAINT [FK_Teachers_Teachers]
		FOREIGN KEY([ManagerID])
		REFERENCES [Teachers]([TeacherID])
);

INSERT INTO [Teachers]
	VALUES
	('John',	NULL),
	('Maya',	106),
	('Silvia',	106),
	('Ted',		105),
	('Mark',	101),
	('Greta',	101);

--5
--CREATE DATABASE [OnlineStore];

USE [OnlineStore];


CREATE TABLE [Cities]
(
	[CityID]	INT			NOT NULL	IDENTITY(1, 1),
	[Name]		VARCHAR(50)	NOT NULL,
	CONSTRAINT	[PK_Cities]	PRIMARY KEY(CityID)
);
CREATE TABLE [Customers]
(
	[CustomerID]	INT			NOT NULL	IDENTITY(1, 1),
	[Name]			VARCHAR(50)	NOT NULL,
	[Birthday]		DATETIME2	NOT NULL,
	[CityID]		INT			NOT NULL,
	CONSTRAINT	[PK_Customers]			PRIMARY KEY([CustomerID]),
	CONSTRAINT	[FK_Customers_Cities]	FOREIGN KEY([CityID])		REFERENCES [Cities]([CityID])
);
CREATE TABLE [Orders]
(
	[OrderID]		INT	NOT NULL	IDENTITY(1, 1),
	[CustomerID]	INT	NOT NULL,
	CONSTRAINT	[PK_Orders]				PRIMARY KEY([OrderID]),
	CONSTRAINT	[FK_Orders_Customers]	FOREIGN KEY([CustomerID])	REFERENCES [Customers]([CustomerID])
);
CREATE TABLE [ItemTypes]
(
	[ItemTypeID]	INT			NOT NULL	IDENTITY(1, 1),
	[Name]			VARCHAR(50)	NOT NULL,
	CONSTRAINT	[PK_ItemTypes]	PRIMARY KEY([ItemTypeID])
);
CREATE TABLE [Items]
(
	[ItemID]		INT			NOT NULL	IDENTITY(1, 1),
	[Name]			VARCHAR(50)	NOT NULL,
	[ItemTypeID]	INT			NOT NULL,
	CONSTRAINT	[PK_Items]				PRIMARY KEY([ItemID]),
	CONSTRAINT	[FK_Items_ItemTypes]	FOREIGN KEY([ItemTypeID])	REFERENCES [ItemTypes]([ItemTypeID])
);
CREATE TABLE [OrderItems]
(
	[OrderID]	INT	NOT NULL,
	[ItemID]	INT	NOT NULL,
	CONSTRAINT	[PK_OrderItems]			PRIMARY KEY([OrderID], [ItemID]),
	CONSTRAINT	[FK_OrderItems_Orders]	FOREIGN KEY([OrderID])				REFERENCES [Orders]([OrderID]),
	CONSTRAINT	[FK_OrderItems_Items]	FOREIGN KEY([ItemID])				REFERENCES [Items]([ItemID])
);

--6
--CREATE DATABASE [University];

USE [University];

CREATE TABLE [Majors]
(
	[MajorID]	INT				NOT NULL	IDENTITY(1, 1),
	[Name]		VARCHAR(100)	NOT NULL,
	CONSTRAINT	[PK_Majors]	PRIMARY KEY([MajorID])
);
CREATE TABLE [Students]
(
	[StudentID]		INT			NOT NULL	IDENTITY(1, 1),
	[StudentNumber]	VARCHAR(30)	NOT NULL,
	[StudentName]	VARCHAR(50)	NOT NULL,
	[MajorID]		INT			NOT NULL,
	CONSTRAINT	[PK_Students]			PRIMARY KEY([StudentID]),
	CONSTRAINT	[FK_Students_Majors]	FOREIGN KEY([MajorID])		REFERENCES [Majors]([MajorID])
);
CREATE TABLE [Payments]
(
	[PaymentID]		INT				NOT NULL	IDENTITY(1, 1),
	[PaymentDate]	DATETIME2		NOT NULL,
	[PaymentAmount]	DECIMAL(14, 2)	NOT NULL,
	[StudentID]		INT				NOT NULL,
	CONSTRAINT	[PK_Payments]			PRIMARY KEY([PaymentID]),
	CONSTRAINT	[FK_Payments_Students]	FOREIGN KEY([StudentID])	REFERENCES [Students]([StudentID])
);
CREATE TABLE [Subjects]
(
	[SubjectID]		INT				NOT NULL	IDENTITY(1, 1),
	[SubjectName]	VARCHAR(100)	NOT NULL,
	CONSTRAINT	[PK_Subjects]	PRIMARY KEY([SubjectID])
);
CREATE TABLE [Agenda]
(
	[StudentID]	INT	NOT NULL,
	[SubjectID]	INT	NOT NULL,
	CONSTRAINT	[PK_Agenda]				PRIMARY KEY([StudentID], [SubjectID]),
	CONSTRAINT	[FK_Agenda_Students]	FOREIGN KEY([StudentID])				REFERENCES [Students]([StudentID]),
	CONSTRAINT	[FK_Agenda_Subjects]	FOREIGN KEY([SubjectID])				REFERENCES [Subjects]([SubjectID]),
);

--9
USE [Geography];

SELECT
	m.[MountainRange],
	p.[PeakName],
	p.[Elevation]
FROM [Mountains]	AS m
JOIN [Peaks]		AS p	ON p.[MountainId] = m.[Id]
WHERE
	m.[MountainRange] = 'Rila'
ORDER BY
	p.[Elevation] DESC;

--DROPS
--DROP DATABASE [Models];
--DROP DATABASE [People];
--DROP DATABASE [Students];
--DROP DATABASE [Teachers];
--DROP DATABASE [University];
--DROP DATABASE [OnlineStore];