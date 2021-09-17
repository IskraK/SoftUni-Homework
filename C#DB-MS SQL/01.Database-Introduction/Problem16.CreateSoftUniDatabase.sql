CREATE DATABASE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	)

	CREATE TABLE Addresses(
		Id INT PRIMARY KEY IDENTITY,
		AddressText NVARCHAR(200) NOT NULL,
		TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
		)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATE NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
	)

INSERT INTO Towns VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Ruse')

INSERT INTO Addresses VALUES
	('bul.Vardar 47, bl.5', 1),
	('bul.K.Velichkov 125', 1),
	('ul.Musala 4', 4),
	('ul.Pirin 25', 2)

INSERT INTO Departments VALUES
	('Software Development'),
	('Design Creative'),
	('Foundation'),
	('Administration')

INSERT INTO Employees VALUES
	('Pesho', 'Ivanov', 'Ivanov', 'C# Developer', 4, '2020-02-05', 3000, 1),
	('Ivan', 'Petrov', 'Georgiev', 'Designer', 2, '2015-04-01', 4850.26, 4),
	('Mimi', 'Ivanova', 'Ivanova', 'Developer', 3, '2008-05-02', 13000, 2),
	('Gosho', 'Peshev', 'Peshev', 'Secretary', 1, '2002-07-18', 2140.5, 3)