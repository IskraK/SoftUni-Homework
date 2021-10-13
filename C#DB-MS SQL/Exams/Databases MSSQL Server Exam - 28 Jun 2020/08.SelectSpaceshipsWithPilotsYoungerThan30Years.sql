--Extract from the database those spaceships, which have pilots, younger than 30 years old. In other words, 30 years from 01/01/2019. 
--Sort the results alphabetically by spaceship name.
--Required Columns
--•	Name
--•	Manufacturer

SELECT DISTINCT s.[Name],s.Manufacturer 
FROM Spaceships AS s
JOIN Journeys AS j ON s.Id=j.SpaceshipId
JOIN TravelCards AS t ON j.Id=t.JourneyId
JOIN Colonists AS c ON t.ColonistId=c.Id
WHERE t.JobDuringJourney='Pilot' AND DATEDIFF(YEAR,c.BirthDate,'2019-01-01') < 30
ORDER BY s.[Name]