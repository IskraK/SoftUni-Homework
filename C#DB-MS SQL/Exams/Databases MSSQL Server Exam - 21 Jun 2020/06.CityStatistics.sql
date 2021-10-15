--Select all cities with the count of hotels in them. 
--Order them by the hotel count (descending), then by city name. 
--Do not include cities, which have no hotels in them.

SELECT c.[Name] AS City,
	   COUNT(h.Id) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON c.Id=h.CityId
GROUP BY c.Id,c.Name
ORDER BY COUNT(h.Id) DESC,c.[Name]