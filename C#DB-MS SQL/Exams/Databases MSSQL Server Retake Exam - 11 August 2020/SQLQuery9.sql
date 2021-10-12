--Select all distributors which distribute ingredients used in the making process of all products having average rate between 5 and 8 (inclusive). 
--Order by distributor name, ingredient name and product name all ascending.
--Required columns:
--•	DistributorName
--•	IngredientName
--•	ProductName
--•	AverageRate

SELECT d.[Name] AS DistributorName,
	   i.[Name] AS IngredientName,
	   p.[Name] AS ProductName,
	   AVG(f.Rate) AS AverageRate
FROM Distributors AS d
LEFT JOIN Ingredients AS i ON d.Id=i.DistributorId
LEFT JOIN ProductsIngredients AS pg ON i.Id=pg.IngredientId
LEFT JOIN Products AS p On pg.ProductId=p.Id
LEFT JOIN Feedbacks AS f ON p.Id=f.ProductId
GROUP BY d.[Name],i.[Name],p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8


