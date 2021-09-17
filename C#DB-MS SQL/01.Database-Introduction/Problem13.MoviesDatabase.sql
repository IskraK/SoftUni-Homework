CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear DATE,
	[Length] TIME,
	GenreID INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryID INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating DECIMAL(2,1),
	Notes NVARCHAR(MAX)
	)

INSERT INTO Directors(DirectorName,Notes) VALUES
	('Pesho', 'director'),
	('Gosho', NULL),
	('Ivan', 'best director'),
	('Mimi', 'worst director'),
	('Ani', NULL)

INSERT INTO Genres(GenreName,Notes) VALUES
	('Comedy', 'family'),
	('Action', NULL),
	('Horror', '16+'),
	('Animation', 'children'),
	('БГ филм', 'БГ')

INSERT INTO Categories(CategoryName,Notes) VALUES
	('Family', 'for all'),
	('Historical', NULL),
	('Under 12', 'for children'),
	('Above 18', NULL),
	('Serial', NULL)

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreID,CategoryID,Rating,Notes) VALUES
	('Film1', 1, '2020', '02:25:00', 2, 1, 1, 'nothing'),
	('Film2', 3, '1973', '01:25:00', 3, 2, NULL, NULL),
	('Film3', 4, '1954', '01:45:00', 1, 3, 5, 'something'),
	('Film4', 2, '2021', '01:36:00', 5, 5, 6.2, 'no comments'),
	('Film5', 5, '1989', '02:55:00', 4, 3, 9, NULL)


