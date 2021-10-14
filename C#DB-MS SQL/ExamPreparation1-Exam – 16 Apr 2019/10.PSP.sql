--Select all planes with their name, seats count and passengers count. 
--Order the results by passengers count (descending), plane name (ascending) and seats (ascending)

SELECT pl.[Name],
	   pl.Seats,
	   COUNT(t.PassengerId) AS [Passengers Count]
FROM Planes AS pl
LEFT JOIN Flights AS f ON pl.Id=f.PlaneId
LEFT JOIN Tickets AS t ON f.Id=t.FlightId
GROUP BY pl.Id,pl.[Name],pl.Seats
ORDER BY [Passengers Count] DESC,pl.[Name],pl.Seats