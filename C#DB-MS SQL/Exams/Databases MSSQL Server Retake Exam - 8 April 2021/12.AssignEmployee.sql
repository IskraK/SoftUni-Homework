--Create a stored procedure with the name usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
--that receives an employee's Id and a report's Id 
--and assigns the employee to the report 
--only if the department of the employee and the department of the report's category are the same. 
--Otherwise throw an exception with message: "Employee doesn't belong to the appropriate department!". 

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	IF(@EmployeeId IN (SELECT e.Id
						FROM Reports AS r
						JOIN Categories AS c ON r.CategoryId=c.Id
						JOIN Departments AS d ON c.DepartmentId=d.Id
						JOIN Employees AS e ON e.DepartmentId=c.DepartmentId
						WHERE r.Id = @ReportId ))
		BEGIN
		UPDATE Reports
		SET EmployeeId=@EmployeeId
		WHERE Id=@ReportId
		END
	ELSE
		RAISERROR('Employee doesn''t belong to the appropriate department!',16,1)
		--THROW 50001,'Employee doesn''t belong to the appropriate department!',1
GO


EXEC usp_AssignEmployeeToReport 30, 1

EXEC usp_AssignEmployeeToReport 17, 2

-----------------------------------------------------------
--2nd decision
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @EmployeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId)

	DECLARE @CategoryDepartmentId INT = (SELECT c.DepartmentId FROM Reports r 
						LEFT JOIN Categories c ON r.CategoryId = c.Id	
						WHERE r.Id = @ReportId)
	IF(@EmployeeDepartmentId != @CategoryDepartmentId)
		THROW 50001,'Employee doesn''t belong to the appropriate department!',1
	ELSE
		BEGIN
			UPDATE Reports
			SET EmployeeId=@EmployeeId
			WHERE Id=@ReportId
		END