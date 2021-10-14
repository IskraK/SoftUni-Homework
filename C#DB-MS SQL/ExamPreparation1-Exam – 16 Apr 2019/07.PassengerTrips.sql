--Select the full name of the passengers with their trips (origin - destination). 
--Order them by full name (ascending), origin (ascending) and destination (ascending).

SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
	   f.Origin,
	   f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id=t.PassengerId
JOIN Flights AS f ON t.FlightId=f.Id
ORDER BY [Full Name],Origin,Destination