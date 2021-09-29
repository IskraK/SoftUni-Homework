SELECT TOP(1) AVG(Salary) 
FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary)


--2-nd decision with subquery
SELECT MIN(s.AvgSalary) AS MinAvgSalary
FROM 
	(SELECT AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID) AS s