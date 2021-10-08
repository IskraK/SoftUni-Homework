CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY NOT NULL, 
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL, 
	JobTitle VARCHAR(50) NOT NULL, 
	DepartmentId INT NOT NULL,
	Salary MONEY NOT NULL
)

GO

CREATE OR ALTER TRIGGER tr_DeletedEmployees 
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees (FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
	SELECT d.FirstName,d.LastName,d.MiddleName,d.JobTitle,d.DepartmentID,d.Salary 
	FROM deleted AS d

GO


SELECT * FROM Employees

DELETE FROM Employees WHERE FirstName='Guy'

SELECT * FROM Deleted_Employees