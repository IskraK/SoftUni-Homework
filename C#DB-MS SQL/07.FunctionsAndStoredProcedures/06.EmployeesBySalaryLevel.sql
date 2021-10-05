CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
SELECT sl.FirstName AS [First Name],
	   sl.LastName AS [Last Name]
FROM
	(SELECT FirstName,
			LastName,
		    dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
	FROM Employees) AS sl
WHERE sl.[Salary Level] = @salaryLevel


EXEC usp_EmployeesBySalaryLevel 'High'