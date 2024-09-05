--SoftUni database queries
USE [SoftUni];

--2
SELECT * FROM [Departments];

--3
SELECT
	d.[Name]
FROM [Departments] AS d;

--4
SELECT
	e.[FirstName],
	e.[LastName],
	e.[Salary]
FROM [Employees] AS e;

--5
SELECT
	e.[FirstName],
	e.[MiddleName],
	e.[LastName]
FROM [Employees] AS e;

--6
SELECT
	e.[FirstName] + '.' + e.[LastName] + '@softuni.bg' AS [Full Email Address]
FROM [Employees] AS e;

--7
SELECT DISTINCT
	e.[Salary]
FROM [Employees] AS e;

--8
SELECT * 
FROM [Employees] AS e
WHERE e.[JobTitle] = 'Sales Representative';

--9
SELECT
	e.[FirstName],
	e.[LastName],
	e.[JobTitle]
FROM [Employees] AS e
WHERE
		e.[Salary] >= 20000
	AND e.[Salary] <= 30000;

--10
SELECT
	e.[FirstName] + ' ' + e.[MiddleName] + ' ' + e.[LastName] AS [Full Name]
FROM [Employees] AS e
WHERE
		e.[Salary] IN (25000, 14000, 12500, 23600);

--11
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE e.[ManagerID] IS NULL;

--12
SELECT
	e.[FirstName],
	e.[LastName],
	e.[Salary]
FROM [Employees] AS e
WHERE
		e.[Salary] >= 50000
ORDER BY
	e.[Salary] DESC;

--13
SELECT TOP(5)
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
ORDER BY
	e.[Salary] DESC;

--14
SELECT
	e.[FirstName],
	e.[LastName]
FROM [Employees] AS e
WHERE
	NOT	(e.[DepartmentID] = 4);

--15
SELECT *
FROM [Employees] AS e
ORDER BY
	e.[Salary]		DESC,
	e.[FirstName]	ASC,
	e.[LastName]	DESC,
	e.[MiddleName]	ASC;

--16
GO

CREATE VIEW [V_EmployeesSalaries] AS
(
	SELECT
		e.[FirstName],
		e.[LastName],
		e.[Salary]
	FROM [Employees] AS e
);

GO

--17
GO

CREATE VIEW [V_EmployeeNameJobTitle] AS
(
	SELECT
		CONCAT(e.[FirstName], ' ', e.[MiddleName], ' ', e.[LastName]) AS [Full Name],
		e.JobTitle AS [Job Title]
	FROM [Employees] AS e
);

GO

--18
SELECT DISTINCT
	e.[JobTitle]
FROM [Employees] AS e;

--19
SELECT TOP(10) *
FROM [Projects] AS p
WHERE p.[StartDate] IS NOT NULL
ORDER BY
	p.[StartDate]	ASC,
	p.[Name]		ASC;

--20
SELECT TOP(7)
	e.[FirstName],
	e.[LastName],
	e.[HireDate]
FROM [Employees] AS e
ORDER BY
	e.[HireDate]	DESC;

--21
BEGIN TRANSACTION

UPDATE [Employees]
	SET [Salary] *= 1.12
	WHERE [DepartmentID] IN
	(
		SELECT d.[DepartmentID]
		FROM [Departments] AS d
		WHERE d.[Name] IN
		(
			'Engineering',
			'Tool Design',
			'Marketing',
			'Information Services'
		)
	)

SELECT	e.[Salary]
FROM [Employees] AS e;

ROLLBACK

--Geography database queries
USE [Geography];

--22
SELECT
	p.[PeakName]
FROM [Peaks] AS p
ORDER BY
	p.[PeakName] ASC;

--23
SELECT TOP(30)
	c.[CountryName],
	c.[Population]
FROM [Countries] AS c
WHERE
	c.[ContinentCode] IN 
	(
		SELECT TOP(1)
			con.[ContinentCode]
		FROM [Continents] AS con
		WHERE
			con.[ContinentName] = 'Europe'
	)
ORDER BY
	c.[Population]	DESC,
	c.[CountryName]	ASC;

--24
SELECT
	c.[CountryName],
	c.[CountryCode],
	CASE
		WHEN
			c.[CurrencyCode] IN
			(
				SELECT
					cur.[CurrencyCode]
				FROM [Currencies] AS cur
				WHERE
					cur.[Description] LIKE '%Euro%'
			)
		THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM [Countries] AS c
ORDER BY
	c.[CountryName]	ASC;

--Diablo database queries
USE [Diablo];

--25
SELECT
	c.[Name]
FROM [Characters] AS c
ORDER BY
	c.[Name] ASC;