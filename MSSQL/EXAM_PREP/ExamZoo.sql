--Section 1
CREATE DATABASE [Zoo];
GO

USE [Zoo];
GO

--1.Database design
CREATE TABLE Owners
(
	Id			INT			/*NOT NULL*/ PRIMARY KEY IDENTITY,
	[Name]		VARCHAR(50)	NOT NULL,
	PhoneNumber	VARCHAR(15) NOT NULL,
	[Address]		VARCHAR(50)	/*NULL*/
);

CREATE TABLE AnimalTypes
(
	Id			INT			/*NOT NULL*/ PRIMARY KEY IDENTITY,
	AnimalType	VARCHAR(30)	NOT NULL
);

CREATE TABLE Cages
(
	Id				INT /*NOT NULL*/ PRIMARY KEY IDENTITY,
	AnimalTypeId	INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
);

CREATE TABLE Animals
(
	Id				INT			/*NOT NULL*/	PRIMARY KEY IDENTITY,
	[Name]			VARCHAR(30)	NOT NULL,
	BirthDate		DATE		NOT NULL,
	OwnerId			INT			/*NULL*/		FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId	INT			NOT NULL	FOREIGN KEY REFERENCES AnimalTypes(Id)
);

CREATE TABLE AnimalsCages
(
	CageId		INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
	AnimalId	INT NOT NULL FOREIGN KEY REFERENCES Animals(Id)
	PRIMARY KEY (CageId, AnimalId)
);

CREATE TABLE VolunteersDepartments
(
	Id				INT			/*NOT NULL*/ PRIMARY KEY IDENTITY,
	DepartmentName	VARCHAR(30)	NOT NULL
);

CREATE TABLE Volunteers
(
	Id				INT			/*NOT NULL*/	PRIMARY KEY IDENTITY,
	[Name]			VARCHAR(50) NOT NULL,
	PhoneNumber		VARCHAR(15) NOT NULL,
	[Address]			VARCHAR(50) /*NULL*/,
	AnimalId		INT			/*NULL*/		FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId	INT			NOT NULL	FOREIGN KEY REFERENCES VolunteersDepartments(Id)
);

--2.Insert
INSERT INTO Volunteers
(Name, PhoneNumber, Address, AnimalId, DepartmentId)
VALUES
('Anita Kostova',	'0896365412', 'Sofia, 5 Rosa str.',			15, 1),
('Dimitur Stoev',	'0877564223',	NULL,						42, 4),
('Kalina Evtimova',	'0896321112', 'Silistra, 21 Breza str.',	9,	7),
('Stoyan Tomov',	'0898564100', 'Montana, 1 Bor str.',		18,	8),
('Boryana Mileva',	'0888112233', NULL,							31, 5);

INSERT INTO Animals
(Name, BirthDate, OwnerId, AnimalTypeId)
VALUES
('Giraffe',				'2018-09-21', 21,	1),
('Harpy Eagle',			'2015-04-17', 15,	3),
('Hamadryas Baboon',	'2017-11-02', NULL,	1),
('Tuatara',				'2021-06-30', 2,	4);

--3.Update
DECLARE @userId INT = (SELECT Id FROM Owners WHERE [Name] = 'Kaloqn Stoqnov');

UPDATE Animals
SET OwnerId = @userId
WHERE OwnerId IS NULL;

--4.Delete
DECLARE @departmentId INT = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant');

DELETE FROM Volunteers
WHERE DepartmentId = @departmentId;

DELETE FROM VolunteersDepartments
WHERE Id = @departmentId;

--5.Volunteers
SELECT
	v.[Name],
	v.PhoneNumber,
	v.[Address],
	v.AnimalId,
	v.DepartmentId
FROM Volunteers AS v
ORDER BY
	v.[Name]		ASC,
	v.AnimalId		ASC,
	v.DepartmentId	ASC;

--6.Animals data
SELECT
	a.[Name],
	aty.AnimalType,
	FORMAT(a.BirthDate, 'dd.MM.yyy')
FROM Animals		AS a
JOIN AnimalTypes	AS aty on a.AnimalTypeId = aty.Id
ORDER BY
	a.[Name] ASC;

--7.Owners and Their Animals
SELECT TOP(5)
	o.[Name] AS [Owner],
	COUNT(*) AS CountOfAnimals
FROM Owners AS o
JOIN Animals AS a ON o.Id = a.OwnerId
GROUP BY
	o.Id,
	o.[Name]
ORDER BY
	COUNT(*) DESC,
	o.[Name] ASC;

--8.Owners, Animals and Cages
SELECT
	CONCAT_WS('-', o.[Name], a.[Name]) AS OwnersAnimals,
	o.PhoneNumber,
	c.CageId
FROM Owners			AS o
JOIN Animals		AS a	ON o.Id = a.OwnerId
JOIN AnimalTypes	AS aty	ON a.AnimalTypeId = aty.Id
JOIN AnimalsCages	AS c	ON c.AnimalId = a.Id
WHERE
	aty.AnimalType = 'mammals'
ORDER BY
	o.[Name] ASC,
	a.[Name] DESC;

--9.Volunteers in Sofia
SELECT
	v.[Name],
	v.PhoneNumber,
	SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 2, LEN(v.[Address]) - CHARINDEX(',', v.[Address]))
FROM Volunteers				AS v
JOIN VolunteersDepartments	AS vd ON v.DepartmentId = vd.Id
WHERE
		vd.DepartmentName = 'Education program assistant'
	AND	v.[Address] LIKE '%Sofia%'
ORDER BY
	v.[Name] ASC;

--10.Animals for Adoption
SELECT
	a.[Name],
	FORMAT(a.BirthDate, 'yyyy'),
	aty.AnimalType
FROM Animals		AS a
JOIN AnimalTypes	AS aty ON a.AnimalTypeId = aty.Id
WHERE	
		a.OwnerId IS NULL
	AND a.BirthDate > '01/01/2018'
	AND	aty.AnimalType <> 'Birds'
ORDER BY
	a.[Name];

GO

--11.All Volunteers in a Department
CREATE FUNCTION udf_GetVolunteersCountFromADepartment
(
	@VolunteersDepartment VARCHAR(30)
)
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT
			COUNT(*)
		FROM VolunteersDepartments	AS vd
		JOIN Volunteers				AS v	ON vd.Id = v.DepartmentId
		WHERE
			vd.DepartmentName = @VolunteersDepartment
		GROUP BY
			vd.DepartmentName
	)
END;

GO

--12.Animals with Owner or Not
CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT
		a.[Name],
		CASE
			WHEN o.[Name] IS NULL	THEN 'For adoption'
									ELSE o.[Name]
		END AS OwnersName
	FROM		Animals	AS a
	LEFT JOIN	Owners	AS o ON a.OwnerId = o.Id
	WHERE
		a.[Name] = @AnimalName
END;

--Database deletion
DROP DATABASE Zoo;