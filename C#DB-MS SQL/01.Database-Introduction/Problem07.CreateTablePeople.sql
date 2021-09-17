CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,3),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO People ([Name],Gender,Birthdate) VALUES
	('Iskra Krasimirova','f','1977-07-31'),
	('Georgi Georgiev','m','1971-12-03'),
	('Vladi Vlad','f','2005-04-17'),
	('Petar Petrov','m','1933-11-11'),
	('Ivan Ivanov','m','1957-09-10')



