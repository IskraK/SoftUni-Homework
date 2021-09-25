SELECT * 
FROM [Towns]
WHERE [Name] LIKE '[mkbe]%'
ORDER BY [Name]


--2-nd decision
SELECT * 
FROM [Towns]
WHERE LEFT([Name],1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]