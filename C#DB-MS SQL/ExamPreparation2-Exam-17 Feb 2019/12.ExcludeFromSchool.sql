--Create a user defined stored procedure, named usp_ExcludeFromSchool(@StudentId), 
--that receives a student id and attempts to delete the current student. 
--A student will only be deleted if all of these conditions pass:
--•	If the student doesn’t exist, then it cannot be deleted. Raise an error with the message “This school has no student with the provided id!”
--If all the above conditions pass, delete the student and ALL OF HIS REFERENCES!

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
IF(@StudentId NOT IN (SELECT Id FROM Students))
	THROW 50001,'This school has no student with the provided id!',1

DELETE FROM StudentsExams
WHERE StudentId=@StudentId

DELETE FROM StudentsSubjects
WHERE StudentId=@StudentId

DELETE FROM StudentsTeachers
WHERE StudentId=@StudentId

DELETE FROM Students
WHERE Id=@StudentId
GO

EXEC usp_ExcludeFromSchool 1
SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 301
