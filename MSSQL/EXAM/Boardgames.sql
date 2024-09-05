CREATE DATABASE Boardgames;
GO

USE Boardgames;
GO

--1.Database design
CREATE TABLE Categories
(
	Id		INT			NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name]	VARCHAR(50)	NOT NULL
);

CREATE TABLE Addresses
(
	Id				INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
	StreetName		VARCHAR(100)	NOT NULL,
	StreetNumber	INT				NOT NULL,
	Town			VARCHAR(30)		NOT NULL,
	Country			VARCHAR(50)		NOT NULL,
	ZIP				INT				NOT NULL
);

CREATE TABLE Publishers
(
	Id			INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name]		VARCHAR(30)		NOT NULL UNIQUE,
	AddressId	INT				NOT NULL FOREIGN KEY REFERENCES Addresses(Id), 
	Website		NVARCHAR(40)	NOT NULL,
	Phone		NVARCHAR(20)	NOT NULL
);

CREATE TABLE PlayersRanges
(
	Id			INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	PlayersMin	INT NOT NULL,
	PlayersMax	INT NOT NULL
);

CREATE TABLE Boardgames
(
	Id				INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Name]			NVARCHAR(30)	NOT NULL,
	YearPublished	INT				NOT NULL,
	Rating			DECIMAL(10, 2)	NOT NULL,
	CategoryId		INT				NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	PublisherId		INT				NOT NULL FOREIGN KEY REFERENCES Publishers(Id),
	PlayersRangeId	INT				NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id)
);

CREATE TABLE Creators
(
	Id			INT				NOT NULL PRIMARY KEY IDENTITY(1, 1),
	FirstName	NVARCHAR(30)	NOT NULL,
	LastName	NVARCHAR(30)	NOT NULL,
	Email		NVARCHAR(30)	NOT NULL
);

CREATE TABLE CreatorsBoardgames
(
	CreatorId	INT NOT NULL FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId	INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id)
	PRIMARY KEY(CreatorId, BoardgameId)
);

--2.Insert
INSERT INTO Boardgames
([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES
('Deep Blue',			2019,	5.67,	1,	15,	7),
('Paris',				2016,	9.78,	7,	1,	5),
('Catan: Starfarers',	2021,	9.87,	7,	13,	6),
('Bleeding Kansas',		2020,	3.25,	3,	7,	4),
('One Small Step',		2019,	5.75,	5,	9,	2);

INSERT INTO Publishers
([Name], AddressId, Website, Phone)
VALUES
('Agman Games',		5,	'www.agmangames.com',		'+16546135542'),
('Amethyst Games',	7,	'www.amethystgames.com',	'+15558889992'),
('BattleBooks',		13,	'www.battlebooks.com',		'+12345678907');

--3.Update
UPDATE PlayersRanges
SET PlayersMax += 1
WHERE
		PlayersMax = 2
	AND PlayersMin = 2;

UPDATE Boardgames
SET [Name] = [Name] + 'V2'
WHERE
	YearPublished >= 2020;

--4.Delete
DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN
(
	SELECT
		b.Id
	FROM Boardgames AS b
	WHERE
		PublisherId IN
		(
			SELECT
				p.Id
			FROM Publishers AS p
			WHERE
				AddressId IN
				(
					SELECT
						a.Id
					FROM Addresses AS a
					WHERE
						Town LIKE 'L%'
				)
		)
);

DELETE FROM Boardgames
WHERE PublisherId IN
(
	SELECT
		p.Id
	FROM Publishers AS p
	WHERE
		AddressId IN
		(
			SELECT
				a.Id
			FROM Addresses AS a
			WHERE
				Town LIKE 'L%'
		)
);

DELETE FROM Publishers
WHERE AddressId IN
(
	SELECT
		a.Id
	FROM Addresses AS a
	WHERE
		Town LIKE 'L%'
);

DELETE FROM Addresses
WHERE Town LIKE 'L%';

--5.Boardgames by Year of Publication
SELECT
	b.[Name],
	b.Rating
FROM Boardgames AS b
ORDER BY
	b.YearPublished	ASC,
	b.[Name]		DESC;

--6.Boardgames by Category
SELECT
	b.Id,
	b.[Name],
	b.YearPublished,
	c.[Name] AS Categoryname
FROM Boardgames AS b
JOIN Categories AS c ON b.CategoryId = c.Id
WHERE
	c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY
	b.YearPublished DESC;

--7.Creators without Boardgames
SELECT
	c.Id,
	CONCAT_WS(' ', c.FirstName, c.LastName) AS CreatorName,
	c.Email
FROM		Creators			AS c
LEFT JOIN	CreatorsBoardgames	AS cb ON c.Id = cb.CreatorId
WHERE
	cb.BoardgameId IS NULL
ORDER BY
	CreatorName ASC;

--8.First 5 Boardgames
SELECT TOP(5)
	b.[Name],
	b.Rating,
	c.[Name] AS CategoryName
FROM Boardgames		AS b
JOIN PlayersRanges	AS pr	ON b.PlayersRangeId = pr.Id
JOIN Categories		AS c	ON b.CategoryId = c.Id
WHERE
	(
		b.Rating > 7.00
	AND b.[Name] LIKE '%a%'
	)
	OR
	(
		b.Rating > 7.50
	AND pr.PlayersMin = 2
	AND pr.PlayersMax = 5
	)
ORDER BY
	b.[Name] ASC,
	b.Rating DESC;

--9.Creators with Emails
SELECT
	CONCAT_WS(' ', cbr.FirstName, cbr.LastName) AS FullName,
	cbr.Email,
	cbr.Rating
FROM
(
	SELECT
		c.FirstName,
		c.LastName,
		c.Email,
		b.Rating,
		ROW_NUMBER() OVER(PARTITION BY c.Id ORDER BY b.Rating DESC) AS InvisRank
	FROM Creators AS c
	JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
	JOIN Boardgames AS b ON cb.BoardgameId = b.Id
	WHERE
			c.Email LIKE '%.com'
) AS cbr
WHERE
	cbr.InvisRank = 1
ORDER BY
	FullName ASC;

--10.Creators by Rating
SELECT
	c.LastName,
	CEILING(AVG(b.Rating)) AS AverageRating,
	p.[Name]
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
JOIN Publishers AS p ON p.Id = b.PublisherId
GROUP BY
	c.Id,
	p.[Name],
	c.LastName
HAVING
	p.[Name] = 'Stonemaier Games'
ORDER BY
	AVG(b.Rating) DESC;

GO

--11.Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT
			COUNT(*)
		FROM Creators			AS c
		JOIN CreatorsBoardgames	AS cb ON cb.CreatorId = c.Id
		WHERE
			c.FirstName = @name
	)
END;

GO

--12.Search for Boardgame with Specific Category
CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
	SELECT
		b.[Name],
		b.YearPublished,
		b.Rating,
		c.[Name] AS CategoryName,
		p.[Name] AS PublisherName,
		CONCAT_WS(' ', pr.PlayersMin, 'people') AS MinPlayers,
		CONCAT_WS(' ', pr.PlayersMax, 'people') AS MaxPlayers
	FROM Boardgames		AS b
	JOIN Categories		AS c	ON b.CategoryId = c.Id
	JOIN PlayersRanges	AS pr	ON b.PlayersRangeId = pr.Id
	JOIN Publishers		AS p	ON b.PublisherId = p.Id
	WHERE
		c.[Name] = @category
	ORDER BY
		p.[Name]		ASC,
		b.YearPublished	DESC
END;