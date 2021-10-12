--Select customers that are either at least 21 old and contain “an” in their first name 
--or their phone number ends with “38” and are not from Greece. 
--Order by first name (ascending), then by age(descending).
--Required columns:
--•	FirstName
--•	Age
--•	PhoneNumber

SELECT c.FirstName,
	   c.Age,
	   c.PhoneNumber
FROM Customers AS c
JOIN Countries AS ct ON c.CountryId=ct.Id
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR (c.PhoneNumber LIKE '%38' AND ct.[Name] <> 'Greece') 
ORDER BY c.FirstName,c.Age DESC
