--Bank database queries
USE [Bank];
GO

--1
CREATE TABLE [Logs]
(
	[LogId]		INT		NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[AccountId]	INT		NOT NULL FOREIGN KEY REFERENCES [Accounts]([Id]),
	[OldSum]	MONEY	NOT NULL,
	[NewSum]	MONEY	NOT NULL
);
GO

CREATE TRIGGER tr_LogAccounts
ON [Accounts] FOR UPDATE
AS
	INSERT INTO [Logs]([AccountId], [OldSum], [NewSum])
	SELECT
		a.[Id],
		d.[Balance],
		a.[Balance]
	FROM [Accounts] AS a
	JOIN [deleted]	AS d ON a.[Id] = d.[Id]
	WHERE
		a.[Balance] <> d.[Balance];
GO

--2
CREATE TABLE [NotificationEmails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[Recipient] INT NOT NULL,
	[Subject] VARCHAR(255) NOT NULL,
	[Body] VARCHAR(255) NOT NULL
);
GO

CREATE TRIGGER tr_NotificationEmailsLogs
ON [Logs] FOR INSERT
AS
	INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
	SELECT
		l.[LogId] AS [Recipient],
		CONCAT
		(
			'Balance change for account: ',
			CAST(l.[AccountId] AS VARCHAR(255))
		) AS [Subject],
		CONCAT
		(
			'On ',
			FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt'),
			' your balance was changed from ',
			l.[OldSum],
			' to ',
			l.[NewSum],
			'.'
		) AS [Body]
	FROM [Logs] AS l;
GO

--3
