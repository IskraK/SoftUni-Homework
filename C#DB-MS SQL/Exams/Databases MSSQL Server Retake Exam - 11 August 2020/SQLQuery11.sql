--Create a view named v_UserWithCountries which selects all customers with their countries.
--Required columns:
--•	CustomerName – first name plus last name, with space between them
--•	Age
--•	Gender
--•	CountryName

CREATE VIEW v_UserWithCountries AS
SELECT 
	   CONCAT(c.FirstName,' ',c.LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   ct.Name
FROM Customers AS c
LEFT JOIN Countries AS ct ON c.CountryId=ct.Id

GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

