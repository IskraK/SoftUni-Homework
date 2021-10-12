--Select all countries with their most active distributor (the one with the greatest number of ingredients). 
--If there are several distributors with most ingredients delivered, list them all. 
--Order by country name then by distributor name.
--Required columns:
--•	CountryName
--•	DistributorName

SELECT 
	CountryName,
	DistributorName 
FROM
	(SELECT 
		c.[Name] AS CountryName,
		d.[Name] AS DistributorName,
		COUNT(i.Id) AS IngredientCount,
		DENSE_RANK() OVER(PARTITION BY c.[Name] ORDER BY COUNT(i.Id) DESC) AS Rank
	FROM Countries AS c
	LEFT JOIN Distributors AS d ON c.Id=d.CountryId
	LEFT JOIN Ingredients AS i ON d.Id=i.DistributorId
	GROUP BY c.[Name],d.[Name]) AS r
WHERE r.Rank=1
ORDER BY CountryName,DistributorName

