--Select all products ordered by price (descending) then by name (ascending). 
--Required columns:
--•	Name
--•	Price
--•	Description


SELECT [Name],Price,[Description] 
FROM Products
ORDER BY Price DESC,[Name]