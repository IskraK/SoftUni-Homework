--Select all employees and show how many unique users each of them has served to.
--Order by users count  (descending) and then by full name (ascending).

SELECT CONCAT(e.FirstName,' ',e.LastName) AS FullName, COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id=r.EmployeeId
LEFT JOIN Users AS u ON r.UserId=u.Id
GROUP BY e.Id,e.FirstName,e.LastName
ORDER BY COUNT(u.Id) DESC,FullName