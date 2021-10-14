-- 1. DDL
 
CREATE TABLE Planes
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL,
    Seats INT NOT NULL,
    [Range] INT NOT NULL
);
 
CREATE TABLE Flights
(
    Id INT PRIMARY KEY IDENTITY,
    DepartureTime DATETIME,
    ArrivalTime DATETIME,
    Origin VARCHAR(50) NOT NULL,
    Destination VARCHAR(50) NOT NULL,
    PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
);
 
CREATE TABLE Passengers
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
    Age INT NOT NULL,
    [Address] VARCHAR(30) NOT NULL,
    PassportId CHAR(11) NOT NULL
);
 
CREATE TABLE LuggageTypes
(
    Id INT PRIMARY KEY IDENTITY,
    [Type] VARCHAR(30) NOT NULL
);
 
CREATE TABLE Luggages
(
    Id INT PRIMARY KEY IDENTITY,
    LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
    PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
);
 
CREATE TABLE Tickets
(
    Id INT PRIMARY KEY IDENTITY,
    PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
    FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
    LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
    Price DECIMAL(18,2) NOT NULL
)
 
-- 2. INSERT
INSERT INTO Planes ([Name], Seats, [Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254,  2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)
 
 
INSERT INTO LuggageTypes ([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')
 
-- 3. UPDATE
 
UPDATE Tickets SET Price = Price * 1.13 
WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Carlsbad')
 
-- 4. DELETE
 
DELETE FROM Tickets WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim');
DELETE FROM Flights WHERE Destination = 'Ayn Halagim';
 
-- 5. The "Tr" Planes
 
SELECT * FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]
 
-- 6. Flight Profits
 
SELECT FlightId, SUM(Price) AS TotalPrice FROM Tickets
GROUP BY FlightId
ORDER BY TotalPrice DESC, FlightId
 
-- 7. Passenger Trips
 
SELECT 
    CONCAT(ps.FirstName, ' ', ps.LastName) AS [Full Name], 
    f.Origin, 
    f.Destination  
FROM Tickets AS ts
JOIN Passengers AS ps ON ts.PassengerId = ps.Id
JOIN Flights AS f ON ts.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination
 
-- 8. Non Adventures People
 
SELECT
    ps.FirstName,
    ps.LastName,
    ps.Age
FROM Passengers AS ps
LEFT JOIN Tickets AS ts ON ts.PassengerId = ps.Id
WHERE ts.Id IS NULL
ORDER BY ps.Age DESC, ps.FirstName, ps.LastName
 
-- 9. Full Info
 
SELECT 
    CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
    pl.[Name] AS [Plane Name],
    CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
    lt.[Type] AS [Luggage Type] 
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
ORDER BY [Full Name], [Plane Name], Trip, [Luggage Type]
 
-- 10. PSP
 
SELECT
    pl.[Name],
    pl.Seats,
    COUNT(t.Id) AS [Passengers Count]
FROM Planes AS pl
LEFT JOIN Flights AS f ON f.PlaneId = pl.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY pl.Id, pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC, [Name], Seats
 
-- 11. Vacation
 
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT) 
RETURNS VARCHAR(50) AS
BEGIN
    IF (@peopleCount <= 0) RETURN 'Invalid people count!'
    IF (NOT EXISTS (SELECT 1 FROM Flights WHERE Origin = @origin AND Destination = @destination))
        RETURN 'Invalid flight!'
    RETURN CONCAT('Total price ', 
    (SELECT TOP(1) ts.Price FROM Tickets AS ts 
    JOIN Flights AS f ON ts.FlightId = f.Id
    WHERE f.Origin = @origin AND f.Destination = @destination) * @peopleCount)
END
 
-- 12. Wrong Data
 
CREATE PROCEDURE usp_CancelFlights
AS
UPDATE Flights SET
DepartureTime = NULL, ArrivalTime = NULL
WHERE ArrivalTime > DepartureTime