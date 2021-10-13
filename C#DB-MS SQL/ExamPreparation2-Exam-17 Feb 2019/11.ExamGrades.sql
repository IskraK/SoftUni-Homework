--Create a user defined function, named udf_ExamGradesToUpdate(@studentId, @grade), that receives a student id and grade.
--The function should return the count of grades, for the student with the given id, 
--which are above the received grade and under the received grade with 0.50 added 
--(example: you are given grade 3.50 and you have to find all grades for the provided student which are between 3.50 and 4.00 inclusive):
--If the condition is true, you must return following message in the format:
--•	 “You have to update {count} grades for the student {student first name}”
--If the provided student id is not in the database the function should return “The student with provided id does not exist in the school!”
--If the provided grade is above 6.00 the function should return “Grade cannot be above 6.00!”
--Note: Do not update any records in the database!


CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@studentId NOT IN(SELECT Id FROM Students))
		RETURN 'The student with provided id does not exist in the school!'
	IF(@grade > 6.00)
		RETURN 'Grade cannot be above 6.00!'
	DECLARE @count INT =
						   (SELECT COUNT(StudentId) 
							FROM StudentsExams 
							WHERE StudentId=@studentId AND (Grade BETWEEN @grade AND @grade+0.5))

	DECLARE @studentFirstName VARCHAR(30) = (SELECT FirstName FROM Students WHERE Id=@studentId)
	RETURN ('You have to update '+CAST(@count AS VARCHAR(5))+' grades for the student '+@studentFirstName)
END

GO

--SELECT COUNT(StudentId) 
--	FROM StudentsExams 
--	WHERE StudentId=12 AND (Grade BETWEEN 5.50 AND 5.50+0.5)

SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)