CREATE TABLE [People](
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL
	)

INSERT INTO [People] VALUES
	('Pesho','2005-03-17'),
	('Gosho','1961-12-03'),
	('Ani','1979-12-08'),
	('Mimi','2016-10-22'),
	('Vladi','1977-07-31')

SELECT [Name],
Birthday,
DATEDIFF(YEAR,Birthday,GETDATE()) AS [Age in years],
DATEDIFF(MONTH,Birthday,GETDATE()) AS [Age in months],
DATEDIFF(DAY,Birthday,GETDATE()) AS [Age in days],
DATEDIFF(MINUTE,Birthday,GETDATE()) AS [Age in minutes]
FROM [People]
