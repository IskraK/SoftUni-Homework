--Select accounts whose emails start with the letter “e”. 
--Select their first and last name, their birthdate in the format "MM-dd-yyyy", their city name, and their Email.
--Order them by city name (ascending)

SELECT a.FirstName,
	   a.LastName,
	   FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,
	   c.[Name] AS Hometown,
	   a.Email
FROM Accounts AS a
JOIN Cities AS c ON a.CityId=c.Id
WHERE Email LIKE 'e%'
ORDER BY c.[Name]
