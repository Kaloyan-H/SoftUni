--Gringottts database queries
USE [Gringotts];
GO;

--1
SELECT
	COUNT(*) AS [Count]
FROM [WizzardDeposits] AS wd;

--2
SELECT
	MAX(wd.[MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits] AS wd;

--3
SELECT
	wd.[DepositGroup],
	MAX(wd.[MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits] AS wd
GROUP BY
	wd.[DepositGroup];

--4
SELECT TOP(2)
	wd.[DepositGroup]
FROM [WizzardDeposits] AS wd
GROUP BY
	wd.[DepositGroup]
ORDER BY
	AVG(wd.[MagicWandSize]) ASC;

--5
SELECT
	wd.[DepositGroup],
	SUM(wd.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS wd
GROUP BY
	wd.[DepositGroup];

--6
SELECT
	wd.[DepositGroup],
	SUM(wd.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS wd
WHERE
	wd.[MagicWandCreator] = 'Ollivander family'
GROUP BY
	wd.[DepositGroup];

--7
SELECT
	wd.[DepositGroup],
	SUM(wd.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS wd
WHERE
	wd.[MagicWandCreator] = 'Ollivander family'
GROUP BY
	wd.[DepositGroup]
HAVING
	SUM(wd.[DepositAmount]) < 150000
ORDER BY
	SUM(wd.[DepositAmount]) DESC;

--8
SELECT
	wd.[DepositGroup],
	wd.[MagicWandCreator],
	MIN(wd.[DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits] AS wd
GROUP BY
	wd.[DepositGroup],
	wd.[MagicWandCreator]
ORDER BY
	wd.[MagicWandCreator]	ASC,
	wd.[DepositGroup]		ASC;

--9
SELECT
	wdq.[AgeGroup],
	COUNT(*) AS [WizardCount]
FROM
(
	SELECT
		CASE
			WHEN wd.[Age] < 11 THEN	'[0-10]'
			WHEN wd.[Age] < 21 THEN	'[11-20]'
			WHEN wd.[Age] < 31 THEN	'[21-30]'
			WHEN wd.[Age] < 41 THEN	'[31-40]'
			WHEN wd.[Age] < 51 THEN	'[41-50]'
			WHEN wd.[Age] < 61 THEN	'[51-60]'
			ELSE					'[61+]'
		END AS [AgeGroup]
	FROM [WizzardDeposits] AS wd
) AS wdq
GROUP BY
	wdq.[AgeGroup];

--10
SELECT
	wdq.[FirstLetter]
FROM
(
	SELECT
		SUBSTRING(wd.[FirstName], 0, 2) AS [FirstLetter]
	FROM [WizzardDeposits] AS wd
	WHERE
		wd.[DepositGroup] = 'Troll Chest'
) AS wdq
GROUP BY
	[FirstLetter];

--11
SELECT
	wd.[DepositGroup],
	wd.[IsDepositExpired],
	AVG(wd.[DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits] AS wd
WHERE
	wd.[DepositStartDate] > '01/01/1985'
GROUP BY
	wd.[DepositGroup],
	wd.[IsDepositExpired]
ORDER BY
	wd.[DepositGroup]		DESC,
	wd.[IsDepositExpired]	ASC;

--12
SELECT
	SUM(HostGuestDifferences.[Difference])
FROM
(
	SELECT
		wd.[FirstName]								AS [Host Wizard],
		wd.[DepositAmount]							AS [Host Wizard Deposit],
		wdj.[FirstName]								AS [Guest Wizard],
		wdj.[DepositAmount]							AS [Guest Wizard Deposit],
		wd.[DepositAmount] - wdj.[DepositAmount]	AS [Difference]
	FROM [WizzardDeposits] AS wd
	JOIN [WizzardDeposits] AS wdj ON wd.[Id] + 1 = wdj.[Id]
) AS [HostGuestDifferences];

--SoftUni database queries
USE [SoftUni];
GO;

--13
SELECT
	e.[DepartmentID],
	SUM(e.[Salary])
FROM [Employees] AS e
GROUP BY
	e.[DepartmentID]
ORDER BY
	e.[DepartmentID];

--14
SELECT
	e.[DepartmentID],
	MIN(e.[Salary]) AS [MinimumSalary]
FROM [Employees] AS e
WHERE
		e.[DepartmentID] IN (2, 5, 7)
	AND	e.[HireDate] > '01/01/2000'
GROUP BY
	e.[DepartmentID];

--15
SELECT *
INTO [EmployeesAverageSalaries]
FROM [Employees] AS e
WHERE
	e.[Salary] > 30000;

DELETE
FROM [EmployeesAverageSalaries]
WHERE
	[ManagerID] = 42;

UPDATE [EmployeesAverageSalaries]
SET
	[Salary] += 5000
WHERE
	[DepartmentID] = 1;

SELECT
	eas.[DepartmentID],
	AVG(eas.[Salary]) AS [AverageSalary]
FROM [EmployeesAverageSalaries] AS eas
GROUP BY
	eas.[DepartmentID];

DROP TABLE [EmployeesAverageSalaries]; --Table deletion

--16
SELECT
	e.[DepartmentID],
	MAX(e.[Salary]) AS [MaxSalary]
FROM [Employees] AS e
GROUP BY
	e.[DepartmentID]
HAVING NOT
	MAX(e.[Salary]) BETWEEN 30000 AND 70000;

--17
SELECT
	COUNT(e.[Salary]) AS [Count]
FROM [Employees] AS e
WHERE e.[ManagerID] IS NULL;

--18
SELECT
	[DepartmentID],
	[Salary] AS [ThirdHighestSalary]
FROM
(
	SELECT
		e.[DepartmentID],
		e.[Salary],
		DENSE_RANK() OVER
		(
			PARTITION BY	e.[DepartmentID]
			ORDER BY		e.[Salary] DESC
		) AS [InvisRank]
	FROM [Employees] AS e
) AS [SalaryRanked]
WHERE
	[InvisRank] = 3
GROUP BY
	[DepartmentID],
	[Salary];

--19
SELECT TOP(10)
	e.[FirstName],
	e.[LastName],
	e.[DepartmentID]
FROM [Employees] AS e
JOIN
(
	SELECT
		e.[DepartmentID],
		AVG(e.[Salary]) AS [AverageSalary]
	FROM [Employees] AS e
	GROUP BY
		e.[DepartmentID]
) AS d ON e.[DepartmentID] = d.[DepartmentID]
WHERE
	e.[Salary] > d.[AverageSalary];
