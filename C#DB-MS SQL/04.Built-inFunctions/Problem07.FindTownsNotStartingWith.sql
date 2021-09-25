SELECT * 
FROM [Towns]
WHERE [Name] NOT LIKE '[rbd]%'
ORDER BY [Name]


--2-nd decision
SELECT * 
FROM [Towns]
WHERE LEFT([Name],1) NOT IN('R', 'B', 'D')
ORDER BY [Name]