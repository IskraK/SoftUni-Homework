--Select all people who don't have tickets. 
--Select their first name, last name and age .
--Order them by age (descending), first name (ascending) and last name (ascending).

SELECT p.FirstName,p.LastName,p.Age 
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id=t.PassengerId
WHERE t.Id IS NULL
ORDER BY p.Age DESC,p.FirstName,p.LastName