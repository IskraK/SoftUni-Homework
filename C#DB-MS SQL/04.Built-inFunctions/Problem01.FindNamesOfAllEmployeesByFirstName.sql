USE SoftUni

SELECT FirstName,LastName 
FROM [Employees]
WHERE LEFT([FirstName],2) = 'Sa'


--2-nd solution
SELECT FirstName,LastName 
FROM [Employees]
WHERE [FirstName] LIKE 'Sa%'


--3-rd solution
SELECT FirstName,LastName 
FROM [Employees]
WHERE SUBSTRING([FirstName],1,2) = 'Sa'
