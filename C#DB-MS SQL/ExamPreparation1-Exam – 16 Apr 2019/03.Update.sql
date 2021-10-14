--Make all flights to "Carlsbad" 13% more expensive.

SELECT * FROM Flights
WHERE Destination='Carlsbad'

--Id=41

SELECT * FROM Tickets
WHERE FlightId=41

UPDATE Tickets
SET Price*=1.13
WHERE FlightId=41


--2nd decision
UPDATE Tickets
SET Price*=1.13
WHERE FlightId IN (SELECT Id FROM Flights
					WHERE Destination='Carlsbad')