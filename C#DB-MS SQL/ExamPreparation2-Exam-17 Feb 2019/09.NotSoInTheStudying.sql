--Find all students who don’t have any subjects. 
--Select their full name. The full name is combination of first name, middle name and last name. 
--Order the result by full name
--NOTE: If the middle name is null you have to concatenate the first name and last name separated with single space.

SELECT 
		CASE
			WHEN s.MiddleName IS NULL THEN CONCAT(s.FirstName,' ',s.LastName)
			ELSE CONCAT(s.FirstName,' ',s.MiddleName,' ',s.LastName) END AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS ss ON s.Id=ss.StudentId
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]
