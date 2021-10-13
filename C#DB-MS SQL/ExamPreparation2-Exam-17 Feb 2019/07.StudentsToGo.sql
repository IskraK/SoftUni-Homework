--Find all students, who have not attended an exam. 
--Select their full name (first name + last name).
--Order the results by full name (ascending).

SELECT CONCAT(s.FirstName,' ',s.LastName) AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON s.Id=se.StudentId
WHERE se.ExamId IS NULL
ORDER BY [Full Name]