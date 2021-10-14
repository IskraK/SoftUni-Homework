--Select the total profit for each flight from database. 
--Order them by total price (descending), flight id (ascending).

SELECT FlightId,SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC,FlightId