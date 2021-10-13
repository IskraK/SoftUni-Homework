--Delete all teachers, whose phone number contains ‘72’.

SELECT * FROM Teachers
WHERE Phone LIKE'%72%'

--Id=7,12,15,18,24,26

DELETE FROM StudentsTeachers
WHERE TeacherId IN (7,12,15,18,24,26)

DELETE FROM Teachers
WHERE Phone LIKE'%72%'
