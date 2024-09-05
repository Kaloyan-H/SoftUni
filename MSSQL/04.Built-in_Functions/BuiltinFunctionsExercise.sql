--SoftUni database queries
USE [SoftUni];

--1
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE
	e.[FirstName] LIKE 'Sa%';

--2
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE
	e.[LastName] LIKE '%ei%';

--3
SELECT
	e.[FirstName]
FROM [Employees] AS e
WHERE
		e.[DepartmentID] IN(3, 10)
	AND	DATEPART(YEAR, e.[HireDate]) BETWEEN 1995 AND 2005;

--4
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE
	NOT	e.[JobTitle] LIKE '%engineer%';

--5
SELECT
	t.[Name]
FROM [Towns] AS t
WHERE
	LEN(t.[Name]) IN(5, 6)
ORDER BY
	t.[Name] ASC;

--6
SELECT
	t.[TownID],
	t.[Name]
FROM [Towns] AS t
WHERE
	LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY
	t.[Name] ASC;

--7
SELECT
	t.[TownID],
	t.[Name]
FROM [Towns] AS t
WHERE
	NOT	LEFT([Name], 1) IN ('R', 'B', 'D')
ORDER BY
	t.[Name] ASC;

--8
GO

CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE
	DATEPART(YEAR, e.[HireDate]) > 2000;

GO

--9
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE
	LEN(e.[LastName]) = 5;

--10
SELECT
	e.[EmployeeID],
	e.[FirstName],
	e.[LastName],
	e.[Salary],
	DENSE_RANK() OVER (PARTITION BY e.[Salary] ORDER BY e.[EmployeeID]) AS [Rank]
FROM [Employees] AS e
WHERE
	e.[Salary] BETWEEN 10000 AND 50000
ORDER BY
	e.[Salary] DESC;

--11
SELECT *
FROM
(
	SELECT
		e.[EmployeeID],
		e.[FirstName],
		e.[LastName],
		e.[Salary],
		DENSE_RANK() OVER (PARTITION BY e.[Salary] ORDER BY e.[EmployeeID]) AS [Rank]
	FROM [Employees] AS e
)
AS e
WHERE
		e.[Salary] BETWEEN 10000 AND 50000
	AND e.[Rank] = 2
ORDER BY
	e.[Salary] DESC;

--Geography database queries
USE [Geography];

--12
SELECT
	c.[CountryName]	AS [Country Name],
	c.[IsoCode]		AS [ISO Code]
FROM [Countries] AS c
WHERE
	LOWER(c.[CountryName]) LIKE '%a%a%a%'
ORDER BY
	c.[IsoCode];

--13
SELECT
	p.[PeakName],
	r.[RiverName],
	LOWER(STUFF(p.[PeakName], LEN(p.[PeakName]), 1, r.[RiverName])) AS [Mix]
FROM [Peaks] AS p
JOIN [Rivers] AS r
ON SUBSTRING(LOWER(p.[PeakName]), LEN(p.[PeakName]), 1) = SUBSTRING(LOWER(r.[RiverName]), 1, 1)
ORDER BY
	[Mix];

--Diablo database queries
USE [Diablo];

--14
SELECT TOP(50)
	g.[Name],
	FORMAT(g.[Start], 'yyyy-MM-dd') AS [Start]
FROM [Games] AS g --Judge doesn't like aliases :D
WHERE
	YEAR(g.[Start]) IN (2011, 2012)
ORDER BY
	g.[Start]	ASC,
	g.[Name]	ASC;

--15
SELECT
	u.[Username],
	RIGHT(u.[Email], LEN(u.[Email]) - CHARINDEX('@', u.[Email], 1)) AS [Email Provider]
FROM [Users] AS u
ORDER BY
	[Email Provider]	ASC,
	u.[Username]		ASC;

--16
SELECT
	u.[Username],
	u.[IpAddress] AS [IP Address]
FROM [Users] AS u
WHERE
	u.[IpAddress] LIKE '___.1%.%.___'
ORDER BY
	u.[Username]	ASC;

--17
SELECT
	g.[Name],
	CASE
		WHEN
				DATEPART(HOUR, g.[Start]) >= 0
			AND DATEPART(HOUR, g.[Start]) <	12
		THEN	'Morning'
		WHEN
				DATEPART(HOUR, g.[Start]) >= 12
			AND DATEPART(HOUR, g.[Start]) < 18
		THEN	'Afternoon'
		WHEN
				DATEPART(HOUR, g.[Start]) >= 18
			AND DATEPART(HOUR, g.[Start]) < 24
		THEN	'Evening'
	END AS [Part of the Day],
	CASE
		WHEN
			g.[Duration] <= 3
		THEN	'Extra Short'
		WHEN
				g.[Duration] >= 4
			AND	g.[Duration] <= 6
		THEN	'Short'
		WHEN
			g.[Duration] > 6
		THEN	'Long'
		ELSE	'Extra Long'
	END AS [Duration]
FROM [Games] AS g
ORDER BY
	g.[Name]	ASC,
	[Duration]	ASC;

--Orders database queries
USE [Orders];

--18
SELECT
	o.[ProductName],
	o.[OrderDate],
	DATEADD(DAY,	3, o.[OrderDate])		AS [Pay Due],
	DATEADD(MONTH,	1, o.[OrderDate])	AS [Deliver Due]
FROM [Orders] AS o

--People database queries
CREATE DATABASE [People];
GO;
USE [People];

--19
CREATE TABLE [People]
(
	[Id]		INT				NOT NULL	IDENTITY(1, 1),
	[Name]		NVARCHAR(50)	NOT NULL,
	[Birthdate]	DATETIME2		NOT NULL,
	CONSTRAINT [PK_People]
		PRIMARY KEY([Id])
)

INSERT INTO [People] VALUES
	('Victor',	'2000-12-07'),
	('Steven',	'1992-09-10'),
	('Stephen',	'1910-09-19'),
	('John',	'2010-01-06')

SELECT
	p.[Name],
	DATEDIFF(YEAR,		p.[Birthdate], GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH,		p.[Birthdate], GETDATE()) AS [Age in Months],
	DATEDIFF(DAY,		p.[Birthdate], GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE,	p.[Birthdate], GETDATE()) AS [Age in Minutes]
FROM [People] AS p;