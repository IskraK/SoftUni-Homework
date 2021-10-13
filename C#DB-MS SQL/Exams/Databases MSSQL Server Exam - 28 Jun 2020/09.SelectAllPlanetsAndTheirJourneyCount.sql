--Extract from the database all planets’ names and their journeys count. 
--Order the results by journeys count, descending and by planet name ascending.
--Required Columns
--•	PlanetName
--•	JourneysCount

SELECT p.Name AS  PlanetName,
	   COUNT(j.Id) AS JourneysCount
FROM Planets AS p
JOIN Spaceports AS s ON p.Id=s.PlanetId
JOIN Journeys AS j ON s.Id=j.DestinationSpaceportId
GROUP BY p.[Name]
ORDER BY COUNT(j.Id) DESC,p.[Name]
