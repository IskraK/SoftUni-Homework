CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID=@emloyeeId)
DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID=@projectID)
IF(@employee IS NULL OR @project IS NULL)
	BEGIN 
		ROLLBACK
		RAISERROR('The employee or project is invalid!',16,2)
		RETURN
	END

DECLARE @employeeProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID=@emloyeeId)
IF(@employeeProjectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!',16,1)
	END

INSERT INTO EmployeesProjects(EmployeeID,ProjectID) VALUES
	(@emloyeeId,@projectID)
COMMIT

GO

EXEC usp_AssignProject 1,5
EXEC usp_AssignProject 2,1
EXEC usp_AssignProject 2,2
EXEC usp_AssignProject 2,3
