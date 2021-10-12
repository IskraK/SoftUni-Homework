--Select all customers without feedbacks. Order them by customer id (ascending).
--Required columns:
--•	CustomerName – customer’s first and last name, concatenated with space
--•	PhoneNumber
--•	Gender

SELECT 
		CONCAT(c.FirstName,' ',c.LastName) AS CustomerName,
		c.PhoneNumber,
		c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id=f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id