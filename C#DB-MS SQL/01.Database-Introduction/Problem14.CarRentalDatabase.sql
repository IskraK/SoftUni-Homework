CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(3,1),
	WeeklyRate DECIMAL(3,1),
	MonthlyRate DECIMAL(3,1),
	WeekendRate DECIMAL(3,1)
	)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(15) NOT NULL,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear TIME NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(50),
	Available BIT NOT NULL
	)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(200) NOT NULL,
	[Address] NVARCHAR(200) NOT NULL,
	City NVARCHAR(50),
	ZIPCode INT,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(3,1),
	TaxRate DECIMAL(3,1),
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

INSERT INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
	('Category1', 2.3, 2.4, 2.1, 2.5),
	('Category2', 5.3, 5.4, 5.1, 3.5),
	('Category3', 4.4, 4.4, 4.1, 10)


INSERT INTO Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Picture,Condition,Available) VALUES
	('CA 1234 MX', 'BMW', 'X5', '2020', 1, 5, NULL, NULL, 1),
	('CB 1254 MA', 'Audi', 'A8', '2017', 2, 4, NULL, NULL, 0),
	('C 1234', 'Fiat', 'Bravo', '2010', 3, 5, NULL, NULL, 1)

INSERT INTO Employees(FirstName,LastName,Title,Notes) VALUES
	('Ivan', 'Ivanov', 'Director', NULL),
	('Petar', 'Petrov', 'Mechanic', NULL),
	('Maria', 'Todorova', 'Secretary', NULL)

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes) VALUES
	(1234567, 'Pesho Peshev', 'bul. Vardar 54', 'Sofia', 847653, NULL),
	(9876543, 'Mimi Petrova', 'ul. Musala 4', 'Varna', 272844, NULL),
	(1357986, 'Gosho Goshev', 'ul. Stara planina 22', 'Plovdiv', 128463, NULL)

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus,Notes) VALUES
	(2, 2, 1, 30, 100, 200, 100, '2021-05-05', '2020-05-15', 10, 6.5, 7.8, 'free', 'notes'),
	(3, 1, 3, 33, 150000, 152000, 2000, '2021-07-05', '2020-08-05', 30, 7.5, 9.8, 'free', 'notes'),
	(3, 3, 2, 40, 100, 300, 200, '2021-05-05', '2020-05-06', 1, 2.5, 9, 'free', 'notes')
