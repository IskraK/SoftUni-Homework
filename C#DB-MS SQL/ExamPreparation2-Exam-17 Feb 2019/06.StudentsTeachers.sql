--Select all students and the count of teachers each one has. 

SELECT s.FirstName,S.LastName,COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
LEFT JOIN StudentsTeachers AS st ON s.Id=st.StudentId
GROUP BY s.FirstName,S.LastName