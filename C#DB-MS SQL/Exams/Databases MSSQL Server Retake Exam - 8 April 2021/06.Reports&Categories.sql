--Select all descriptions from reports, which have category. 
--Order them by description (ascending) then by category name (ascending).

SELECT r.[Description],c.[Name] AS CategoryName
FROM Reports As r
LEFT JOIN Categories AS c ON r.CategoryId=c.Id
WHERE CategoryId IS NOT NULL
ORDER BY [Description],c.[Name]
