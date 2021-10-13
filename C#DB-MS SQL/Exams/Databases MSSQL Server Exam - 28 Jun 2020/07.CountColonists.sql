--Count all colonists that are on technical journey. 
--Required Columns
--•	Count

SELECT COUNT(c.Id) AS Count
FROM Colonists AS c
JOIN TravelCards AS t ON c.Id=t.ColonistId
JOIN Journeys AS j ON t.JourneyId=j.Id
WHERE j.Purpose='technical'