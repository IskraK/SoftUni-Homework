--Select all info for reports along with employee first name and last name (concataned with space), 
--their department name, category name, report description, open date, status label and name of the user. 
--Order them by first name (descending), last name (descending), department (ascending), 
--category (ascending), description (ascending), open date (ascending), status (ascending) and user (ascending).
--Date should be in format - dd.MM.yyyy
--If there are empty records, replace them with 'None'. 

SELECT 
		IIF(CONCAT(e.FirstName,' ',e.LastName) =' ','None',CONCAT(e.FirstName,' ',e.LastName)) AS Employee,
		IIF(d.[Name] IS NULL OR d.[Name]='','None',d.[Name]) AS Department,
		ISNULL(c.[Name],'None') AS Category,
		r.[Description],
		FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
		s.[Label] AS [Status],
		IIF(u.[Name]='','None',u.[Name]) AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId=e.Id
LEFT JOIN Departments AS d ON e.DepartmentId=d.Id
LEFT JOIN Categories AS c ON r.CategoryId=c.Id
LEFT JOIN [Status] AS s ON r.StatusId=s.Id
LEFT JOIN Users AS u ON r.UserId=u.Id
ORDER BY e.FirstName DESC,e.LastName DESC,d.[Name],c.[Name],r.[Description],r.OpenDate,[Status],[User]

--2nd decision
SELECT CASE WHEN CONCAT(e.FirstName, ' ', e.LastName) = ' ' THEN 'None' ELSE CONCAT(e.FirstName, ' ', e.LastName) END AS Employee,
	   CASE WHEN d.Name = '' OR d.Name IS NULL THEN 'None' ELSE d.Name END AS Department,
	   c.Name AS CategoryName,
	   r.Description,
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.Label AS Status,
	   CASE WHEN u.Name = '' THEN 'None' ELSE u.Name END AS [User]
		FROM Reports r
	LEFT JOIN Employees e ON r.EmployeeId = e.Id
	LEFT JOIN Departments d ON e.DepartmentId = d.Id
	LEFT JOIN Categories c ON r.CategoryId = c.Id
	LEFT JOIN Status s ON r.StatusId = s.Id
	LEFT JOIN Users u ON r.UserId = u.Id
  ORDER BY e.FirstName DESC, e.LastName DESC, d.Name, c.Name, r.Description, r.OpenDate, Status, User

 