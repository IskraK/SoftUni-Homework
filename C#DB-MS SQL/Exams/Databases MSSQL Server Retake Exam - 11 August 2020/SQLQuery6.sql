--Select all feedbacks alongside with the customers which gave them. 
--Filter only feedbacks which have rate below 5.0. 
--Order results by ProductId (descending) then by Rate (ascending).
--Required columns:
--•	ProductId
--•	Rate
--•	Description
--•	CustomerId
--•	Age
--•	Gender

SELECT f.ProductId,
	   f.Rate,
	   f.[Description],
	   f.CustomerId,
	   c.Age,
	   c.Gender
FROM Feedbacks AS f
JOIN Customers AS c ON f.CustomerId=c.Id
WHERE f.Rate < 5.00
ORDER BY f.ProductId DESC,f.Rate
