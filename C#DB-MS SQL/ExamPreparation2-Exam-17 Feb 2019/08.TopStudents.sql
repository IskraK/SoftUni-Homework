--Find top 10 students, who have highest average grades from the exams.
--Format the grade, two symbols after the decimal point.
--Order them by grade (descending), then by first name (ascending), then by last name (ascending)

SELECT TOP(10) s.FirstName,s.LastName,CAST(AVG(se.Grade) AS DECIMAL(3,2)) AS Grade
FROM Students AS s
LEFT JOIN StudentsExams AS se ON s.Id=se.StudentId
GROUP BY s.FirstName,s.LastName
ORDER BY Grade DESC,s.FirstName,s.LastName