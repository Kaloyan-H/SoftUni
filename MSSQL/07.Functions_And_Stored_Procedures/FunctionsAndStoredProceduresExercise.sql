--SoftUni database queries
USE [SoftUni];
GO

--1
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
(
	SELECT
		e.[FirstName]	AS [First Name],
		e.[LastName]	AS [Last Name]
	FROM [Employees] AS e
	WHERE
		e.[Salary] > 35000
);

DROP PROC usp_GetEmployeesSalaryAbove35000; -- Procedure deletion
GO

--2
CREATE PROC usp_GetEmployeesSalaryAboveNumber
(
	@Number DECIMAL(18, 4)
)
AS
(
	SELECT
		e.[FirstName]	AS [First Name],
		e.[LastName]	AS [Last Name]
	FROM [Employees] AS e
	WHERE
		e.[Salary] >= @Number
);

DROP PROC usp_GetEmployeesSalaryAboveNumber; -- Procedure deletion
GO

--3
CREATE PROC usp_GetTownsStartingWith
(
	@String NVARCHAR(100)
)
AS
(
	SELECT
		t.[Name]
	FROM [Towns] AS t
	WHERE
		t.[Name] LIKE (@String + '%')
);

DROP PROC usp_GetTownsStartingWith;
GO

--4
CREATE PROC usp_GetEmployeesFromTown
(
	@TownName NVARCHAR(100)
)
AS
(
	SELECT
		e.[FirstName]	AS [First Name],
		e.[LastName]	AS [Last Name]
	FROM [Employees]	AS e
	JOIN [Addresses]	AS a ON e.[AddressID] = a.[AddressID]
	JOIN [Towns]		AS t ON t.[TownID] = a.[TownID]
	WHERE
		t.[Name] = @TownName
);

DROP PROC usp_GetEmployeesFromTown;
GO

--5
CREATE FUNCTION ufn_GetSalaryLevel --Should be udf (user-defined function) :/
(
	@Salary DECIMAL(18, 4)
)
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @Result NVARCHAR(50);

	IF (@Salary < 30000)
		SET @Result = 'Low'
	ELSE IF (@Salary <= 50000)
		SET @Result = 'Average'
	ELSE
		SET @Result = 'High'

	RETURN @Result;
END;
GO

DROP FUNCTION ufn_GetSalaryLevel;
GO

--6
CREATE PROC usp_EmployeesBySalaryLevel
(
	@SalaryLevel NVARCHAR(50)
)
AS
(
	SELECT
		e.[FirstName],
		e.[LastName]
	FROM [Employees] AS e
	WHERE
		dbo.ufn_GetSalaryLevel(e.[Salary]) = @SalaryLevel
);

DROP PROC usp_EmployeesBySalaryLevel;
GO

--7
CREATE FUNCTION ufn_IsWordComprised
(
	@SetOfLetter	NVARCHAR(50),
	@Word			NVARCHAR(50)
)
RETURNS BIT
AS
BEGIN
	DECLARE @Counter SMALLINT = 0;

	WHILE (@Counter <= LEN(@Word))
	BEGIN
		IF (@SetOfLetter NOT LIKE '%' + SUBSTRING(@Word, @Counter, 1) + '%') RETURN 0
		SET @Counter += 1
	END

	RETURN 1
END;
GO

DROP FUNCTION ufn_IsWordComprised
GO

--8
CREATE PROC usp_DeleteEmployeesFromDepartment
(
	@departmentId INT
)
AS
BEGIN
	ALTER TABLE [Departments]
		ALTER COLUMN [ManagerID] INT NULL;

	DELETE FROM [EmployeesProjects]
	WHERE [EmployeeID] IN
	(
		SELECT
			e.[EmployeeID]
		FROM [Employees] AS e
		WHERE
			e.[DepartmentID] = @departmentId
	);

	UPDATE [Employees]
	SET [ManagerID] = NULL
	WHERE
		[ManagerID] IN
		(
			SELECT e.[EmployeeID]
			FROM [Employees] AS e
			WHERE
				e.[DepartmentID] = @departmentId
		);

	UPDATE [Departments]
	SET [ManagerID] = NULL
	WHERE
		[DepartmentID] = @departmentId;

	DELETE FROM [Employees]
	WHERE
		[DepartmentID] = @departmentId;

	DELETE FROM [Departments]
	WHERE
		[DepartmentID] = @departmentId;

	SELECT COUNT(*)
	FROM [Employees] AS e
	WHERE
		e.[DepartmentID] = @departmentId;
END;

DROP PROC usp_DeleteEmployeesFromDepartment;
GO

--Bank database queries
USE [Bank];
GO

--9
CREATE PROC usp_GetHoldersFullName
AS
(
	SELECT
		CONCAT_WS(' ', ah.[FirstName], ah.[LastName]) AS [Full name]
	FROM [AccountHolders] AS ah
);

DROP PROC usp_GetHoldersFullName;
GO

--10
CREATE PROC usp_GetHoldersWithBalanceHigherThan
(
	@number DECIMAL(18, 4)
)
AS
BEGIN
	SELECT
		ah.[FirstName],
		ah.[LastName]
	FROM		[AccountHolders]	AS ah
	RIGHT JOIN	[Accounts]			AS a ON ah.[Id] = a.[AccountHolderId]
	GROUP BY
		ah.[Id],
		ah.[FirstName],
		ah.[LastName]
	HAVING
		SUM(a.[Balance]) > @number
	ORDER BY
		ah.[FirstName]	ASC,
		ah.[LastName]	ASC
END;

DROP PROC usp_GetHoldersWithBalanceHigherThan;
GO

--11
CREATE FUNCTION ufn_CalculateFutureValue
(
	@sum				DECIMAL(18, 4),
	@yearlyInterestRate	FLOAT,
	@numberOfYears		INT
)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	RETURN @sum * POWER(1 + @yearlyInterestRate, @numberOfYears)
END;
GO

DROP FUNCTION ufn_CalculateFutureValue;
GO

--12
CREATE PROC usp_CalculateFutureValueForAccount
(
	@accountId		INT,
	@interestRate	FLOAT
)
AS
BEGIN
	SELECT
		ah.[Id]			AS [Account Id],
		ah.[FirstName]	AS [First Name],
		ah.[LastName]	AS [Last Name],
		a.[Balance]		AS [Current Balance],
		dbo.ufn_CalculateFutureValue
		(
			a.[Balance],
			@interestRate,
			5
		) AS [Balance in 5 years]
	FROM [Accounts]			AS a
	JOIN [AccountHolders]	AS ah ON a.[AccountHolderId] = ah.[Id]
	WHERE
		a.[Id] = 1;
END;

DROP PROC usp_CalculateFutureValueForAccount;
GO

--Diablo database queries
USE [Diablo];
GO

--13
CREATE FUNCTION ufn_CashInUsersGames
(
	@gameName VARCHAR(50)
)
RETURNS TABLE
AS
RETURN
	SELECT
		SUM([Cash]) AS [SumCash]
	FROM
	(
		SELECT
			ug.[GameId],
			ug.[Cash],
			ROW_NUMBER() OVER (ORDER BY ug.[Cash] DESC) AS [RowNumber]
		FROM [UsersGames]	AS ug
		JOIN [Games]		AS g ON ug.[GameId] = g.[Id]
		WHERE
			g.[Name] = @gameName
		GROUP BY
			ug.[GameId],
			ug.[Cash]
	) AS g
	WHERE
		g.[RowNumber] % 2 = 1

