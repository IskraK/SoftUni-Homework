SELECT TOP(10) 
		e.FirstName,
	    e.LastName,
	    e.DepartmentID
FROM [Employees] AS e
WHERE e.Salary > 
	(SELECT AVG(Salary) AS [AvgSalary]
		FROM [Employees] AS esub
		WHERE esub.DepartmentID=e.DepartmentID
		GROUP BY DepartmentID)
ORDER BY DepartmentID


--2-nd decision
SELECT TOP(10) FirstName,LastName,e.DepartmentID
FROM 
	(SELECT DepartmentID,AVG(Salary) AS [AvgSalary]
	 FROM Employees
	 GROUP BY DepartmentID) AS r,Employees AS e
 WHERE r.DepartmentID = e.DepartmentID AND e.Salary > r.AvgSalary
 ORDER BY DepartmentID


--3-rd decision
SELECT TOP(10)
	   e.FirstName, e.LastName, e.DepartmentID
FROM Employees AS e
LEFT JOIN 
	    (SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
		FROM Employees e
		GROUP BY e.DepartmentID) AS [Avg]
ON e.DepartmentID = [Avg].DepartmentID
WHERE e.Salary > [Avg].AverageSalary
ORDER BY DepartmentID