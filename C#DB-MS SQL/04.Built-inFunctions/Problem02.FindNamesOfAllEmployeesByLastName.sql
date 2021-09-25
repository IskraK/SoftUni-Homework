SELECT FirstName,LastName 
FROM [Employees]
WHERE [LastName] LIKE '%ei%'



--2-nd decision
SELECT FirstName,LastName 
FROM [Employees]
WHERE CHARINDEX('ei',[LastName]) <> 0