SELECT DepartmentID,
	   MAX(Salary) AS [MaxSalary]
FROM [Employees]
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000


--2-nd decision
SELECT DepartmentID,
	   MAX(Salary) AS [MaxSalary]
FROM [Employees]
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000