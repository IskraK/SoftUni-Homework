--Delete all flights to "Ayn Halagim".

SELECT * FROM Flights 
WHERE Destination='Ayn Halagim'

--Id=30

DELETE FROM Tickets
WHERE FlightId IN (SELECT Id FROM Flights 
					WHERE Destination='Ayn Halagim')

DELETE FROM Flights
WHERE Destination='Ayn Halagim'