--Select all passengers who have trips. 
--Select their full name (first name – last name), plane name, trip (in format {origin} - {destination}) and luggage type. 
--Order the results by full name (ascending), name (ascending), origin (ascending), destination (ascending) and luggage type (ascending).


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
ORDER BY [Full Name], [Plane Name], f.Origin,f.Destination, [Luggage Type]