SELECT FirstName,LastName 
FROM [Employees]
WHERE JobTitle NOT LIKE '%engineer%'


--2-nd decision
SELECT FirstName,LastName 
FROM [Employees]
WHERE CHARINDEX('engineer',[JobTitle]) < 1