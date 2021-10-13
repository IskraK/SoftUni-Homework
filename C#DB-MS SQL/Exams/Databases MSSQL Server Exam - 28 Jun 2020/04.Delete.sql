--Delete first three inserted Journeys (be careful with the relationships).

SELECT * FROM Journeys

DELETE FROM TravelCards
WHERE JourneyId BETWEEN 1 AND 3

DELETE FROM Journeys
WHERE Id BETWEEN 1 AND 3