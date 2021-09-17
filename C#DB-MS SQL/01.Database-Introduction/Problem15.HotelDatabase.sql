CREATE DATABASE Hotel 

USE Hotel 

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	EmergencyName NVARCHAR(50),
	EmergencyNumber VARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE BedTypes(
	BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY NOT NULL,
	RoomType NVARCHAR(20) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(3,1),
	RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10,2) NOT NULL,
	TaxRate DECIMAL(3,1),
	TaxAmount DECIMAL(5,2) NOT NULL,
	PaymentTotal DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(MAX)
	)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber) NOT NULL,
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber) NOT NULL,
	RateApplied DECIMAL(3,1),
	PhoneCharge DECIMAL(5,2),
	Notes NVARCHAR(MAX)
	)

INSERT INTO Employees(FirstName,LastName,Title,Notes) VALUES
	('Ivan', 'Ivanov', 'Director', NULL),
	('Petar', 'Petrov', 'Mechanic', NULL),
	('Maria', 'Todorova', 'Secretary', NULL)

INSERT INTO Customers(FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber,Notes) VALUES
	('Pesho', 'Peshev', '0888123456', 'Misho', '0884987654', NULL),
	('Tosho', 'Ivanow', '0887123456', 'Misho', '0882987654', NULL),
	('Anna', 'Aneva', '0889123456', NULL, '0889987654', NULL)

INSERT INTO RoomStatus(RoomStatus,Notes) VALUES
	('free', NULL),
	('buzy', NULL),
	('not cleaned', NULL)

INSERT INTO RoomTypes(RoomType,Notes) VALUES
	('single', NULL),
	('double', NULL),
	('studio', NULL)

INSERT INTO BedTypes(BedType,Notes) VALUES
	('double bed', NULL),
	('single bed', NULL),
	('large bed', NULL)

INSERT INTO Rooms(RoomNumber,RoomType,BedType,Rate,RoomStatus,Notes) VALUES
	(11, 'single', 'double bed', 9.3, 'buzy', NULL),
	(22, 'double', 'single bed', 7.8, 'free', NULL),
	(33, 'studio', 'large bed', 10, 'not cleaned', NULL)



INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal,Notes) VALUES
	(1, '2021-09-15', 2, '2021-09-10', '2021-09-15', 5, 123.5, 25, 1, 1250, NULL),
	(3, '2021-09-15', 1, '2021-09-10', '2021-09-14', 4, 103.2, 10, 1, 1000.8, NULL),
	(2, '2021-09-15', 3, '2021-09-10', '2021-09-11', 1, 15, 1.4, 1, 250, NULL)

INSERT INTO Occupancies VALUES
	(2, '2021-09-10', 1, 22, 5, 12.3, NULL),
	(3, '2021-09-10', 1, 11, 15, 15.3, NULL),
	(1, '2021-09-10', 1, 33, 16.7, 22.3, NULL)