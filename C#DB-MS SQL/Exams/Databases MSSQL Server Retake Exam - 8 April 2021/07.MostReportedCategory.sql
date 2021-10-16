--Select the top 5 most reported categories 
--and order them by the number of reports per category in descending order 
--and then alphabetically by name.

SELECT TOP(5)
		c.[Name] AS CategoryName,
		COUNT(c.Id) AS ReportsNumber
FROM Categories As c
LEFT JOIN Reports AS r ON c.Id=r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC,c.[Name]

--2-nd decision
SELECT TOP(5)
	c.Name AS CategoryName, 
	Count(r.CategoryId) AS ReportsNumber 
		FROM Reports r
	LEFT JOIN Categories c ON r.CategoryId = c.Id
	GROUP BY c.Name
	ORDER BY ReportsNumber DESC, CategoryName

	