--SoftUni database queries
USE [SoftUni];

--1
SELECT TOP(5)
	e.[EmployeeID],
	e.[JobTitle],
	e.[AddressID],
	a.[AddressText]
FROM [Employees] AS e
JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
ORDER BY
	a.[AddressID] ASC;

--2
SELECT TOP(50)
	e.[FirstName],
	e.[LastName],
	t.[Name] AS [Town],
	a.[AddressText]
FROM [Employees]	AS e
JOIN [Addresses]	AS a ON e.[AddressID] = a.[AddressID]
JOIN [Towns]		AS t ON a.[TownID] = t.[TownID]
ORDER BY
	e.[FirstName]	ASC,
	e.[LastName]	ASC;

--3
SELECT
	e.[EmployeeID],
	e.[FirstName],
	e.[LastName],
	d.[Name] AS [DepartmentName]
FROM [Employees]	AS e
JOIN [Departments]	AS d ON e.[DepartmentID] = d.[DepartmentID]
WHERE
	d.[Name] = 'Sales'
ORDER BY
	e.[EmployeeID] ASC;

--4
SELECT TOP(5)
	e.[EmployeeID],
	e.[FirstName],
	e.[Salary],
	d.[Name] AS [DepartmentName]
FROM [Employees]	AS e
JOIN [Departments]	AS d ON e.[DepartmentID] = d.[DepartmentID]
WHERE
	e.[Salary] > 15000
ORDER BY
	d.[DepartmentID] ASC;

--5
SELECT TOP(3)
	e.[EmployeeID],
	e.[FirstName]
FROM		[Employees]			AS e
LEFT JOIN	[EmployeesProjects]	AS ep	ON e.[EmployeeID] = ep.[EmployeeID]
WHERE
	ep.[ProjectID] IS NULL
ORDER BY
	e.[EmployeeID] ASC;

--6
SELECT
	e.[FirstName],
	e.[LastName],
	e.[HireDate],
	d.[Name] AS [DeptName]
FROM [Employees]	AS e
JOIN [Departments]	AS d ON e.[DepartmentID] = d.[DepartmentID]
WHERE
		DATEPART(YEAR, e.[HireDate]) >= 1999
	AND d.[Name] IN ('Sales', 'Finance')
ORDER BY
	e.[HireDate] ASC;

--7
SELECT TOP(5)
	e.[EmployeeID],
	e.[FirstName],
	p.[Name] AS [ProjectName]
FROM [Employees]			AS e
JOIN [EmployeesProjects]	AS ep	ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects]				AS p	ON ep.[ProjectID] = p.[ProjectID]
WHERE
		p.[StartDate] > '08/13/2002'
	AND	p.[EndDate] IS NULL
ORDER BY
	e.[EmployeeID] ASC;

--8
SELECT
	e.[EmployeeID],
	e.[FirstName],
	CASE
		WHEN
			DATEPART(YEAR, p.[StartDate]) >= 2005
		THEN
			NULL
		ELSE p.[Name]
	END AS [ProjectName]
FROM [Employees]			AS e
JOIN [EmployeesProjects]	AS ep	ON e.[EmployeeID] = ep.[EmployeeID]
JOIN [Projects]				AS p	ON ep.[ProjectID] = p.[ProjectID]
WHERE
	e.[EmployeeID] = 24;

--9
SELECT
	e.[EmployeeID],
	e.[FirstName],
	m.[EmployeeID]	AS [ManagerID],
	m.[FirstName]	AS [ManagerName]
FROM [Employees] AS e
JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
WHERE
	e.[ManagerID] IN (3, 7)
ORDER BY
	e.[EmployeeID] ASC;

--10
SELECT TOP(50)
	e.[EmployeeID],
	CONCAT_WS(' ', e.[FirstName], e.[LastName])	AS [EmployeeName],
	CONCAT_WS(' ', m.[FirstName], m.[LastName])	AS [ManagerName],
	d.[Name]									AS [DepartmentName]
FROM [Employees]	AS e
JOIN [Employees]	AS m ON e.[ManagerID] = m.[EmployeeID]
JOIN [Departments]	AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY
	e.[EmployeeID] ASC;

--11
SELECT
	MIN([as].[AverageSalary]) AS [MinAverageSalary]
FROM
(
	SELECT
		AVG(e.[Salary]) AS [AverageSalary]
	FROM [Employees] AS e
	GROUP BY e.[DepartmentID]
) AS [as];

--Geography database queries
USE [Geography];

--12
SELECT
	c.[CountryCode],
	m.[MountainRange],
	p.[PeakName],
	p.[Elevation]
FROM [Countries]			AS c
JOIN [MountainsCountries]	AS mc	ON c.[CountryCode] = mc.[CountryCode]
JOIN [Mountains]			AS m	ON m.[Id] = mc.[MountainId]
JOIN [Peaks]				AS p	ON m.[Id] = p.[MountainId]
WHERE
		c.[CountryCode] = 'BG'
	AND	p.[Elevation] > 2835
ORDER BY
	p.[Elevation] DESC;

--13
SELECT
	c.[CountryCode],
	COUNT(c.[CountryCode]) AS [MountainRanges]
FROM [Countries]			AS c
JOIN [MountainsCountries]	AS mc ON c.[CountryCode] = mc.[CountryCode]
WHERE
	c.[CountryName] IN ('United States', 'Russia', 'Bulgaria')
GROUP BY
	c.[CountryCode]

--14
SELECT TOP(5)
	c.[CountryName],
	r.[RiverName]
FROM		[Countries]			AS c
LEFT JOIN	[CountriesRivers]	AS cr	ON cr.[CountryCode] = c.[CountryCode]
LEFT JOIN	[Rivers]			AS r	ON cr.[RiverId] = r.[Id]
WHERE
	c.[ContinentCode] = 'AF'
ORDER BY
	c.[CountryName] ASC;

--15
SELECT
	cum.[ContinentCode],
	cum.[CurrencyCode],
	cum.[CurrencyUsage]
FROM
(
	SELECT
		cu.[ContinentCode],
		cu.[CurrencyCode],
		cu.[CurrencyUsage],
		RANK() OVER
		(PARTITION BY cu.[ContinentCode] ORDER BY cu.[CurrencyUsage] DESC) AS [InvisRank]
	FROM
	(
		SELECT
			c.[ContinentCode],
			c.[CurrencyCode],
			COUNT(*) AS [CurrencyUsage]
		FROM [Countries] AS c
		GROUP BY
			c.[CurrencyCode],
			c.[ContinentCode]
	) AS cu
	WHERE
		cu.[CurrencyUsage] > 1
) AS cum
WHERE
	cum.[InvisRank] = 1
ORDER BY
	cum.[ContinentCode];

--16
SELECT 
	COUNT(c.[CountryCode]) AS [Count]
FROM [Countries]				AS c
FULL JOIN [MountainsCountries]	AS mc ON c.[CountryCode] = mc.[CountryCode]
WHERE
	mc.[MountainId] IS NULL;

--17
SELECT TOP(5)
	cpr.[CountryName],
	cpr.[Elevation]	AS [HighestPeakElevation],
	cpr.[Length]	AS [LongestRiverLength]
FROM
(
	SELECT
		c.[CountryName],
		p.[PeakName],
		p.[Elevation],
		RANK() OVER
		(
			PARTITION BY	c.[CountryCode]
			ORDER BY		p.[Elevation] DESC
		) AS [PeakElevationRank],
		r.[RiverName],
		r.[Length],
		RANK() OVER
		(
			PARTITION BY	c.[CountryCode]
			ORDER BY		r.[Length] DESC
		) AS [RiverLengthRank]
	FROM [Countries]				AS c
	FULL JOIN [MountainsCountries]	AS mc	ON c.[CountryCode] = mc.[CountryCode]
	FULL JOIN [Mountains]			AS m	ON m.[Id] = mc.[MountainId]
	FULL JOIN [Peaks]				AS p	ON p.[MountainId] = m.[Id]
	FULL JOIN [CountriesRivers]		AS cr	ON c.[CountryCode] = cr.[CountryCode]
	FULL JOIN [Rivers]				AS r	ON r.[Id] = cr.[RiverId]
) AS cpr
WHERE
		cpr.[PeakElevationRank] = 1
	AND	cpr.[RiverLengthRank] = 1
ORDER BY
	cpr.[Elevation]		DESC,
	cpr.[Length]		DESC,
	cpr.[CountryName]	DESC;

--18
SELECT TOP(5)
	cp.[CountryName] AS [Country],
	CASE
		WHEN cp.[PeakName] IS NULL THEN '(no highest peak)'
		ELSE cp.[PeakName]
	END AS [Highest Peak Name],
	CASE
		WHEN cp.[Elevation] IS NULL THEN 0
		ELSE cp.[Elevation]
	END AS [Highest Peak Elevation],
	CASE
		WHEN cp.[MountainRange]	IS NULL THEN '(no mountain)'
		ELSE cp.[MountainRange]
	END AS [Mountain]
FROM
(
	SELECT
		c.[CountryName],
		p.[PeakName],
		p.[Elevation],
		m.[MountainRange],
		RANK() OVER
		(
			PARTITION BY	c.[CountryCode]
			ORDER BY		p.[Elevation] DESC
		) AS [PeakElevationRank]
	FROM [Countries]				AS c
	FULL JOIN [MountainsCountries]	AS mc	ON c.[CountryCode] = mc.[CountryCode]
	FULL JOIN [Mountains]			AS m	ON m.[Id] = mc.[MountainId]
	FULL JOIN [Peaks]				AS p	ON p.[MountainId] = m.[Id]
) AS cp
WHERE
		cp.[PeakElevationRank] = 1
	AND	cp.[CountryName] IS NOT NULL
ORDER BY
	cp.[CountryName] ASC;