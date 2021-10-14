--Create a user defined function, named udf_CalculateTickets(@origin, @destination, @peopleCount) 
--that receives an origin (town name), destination (town name) and people count.
--The function must return the total price in format "Total price {price}"
--•	If people count is less or equal to zero return – "Invalid people count!"
--•	If flight is invalid return – "Invalid flight!"


CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(100)
AS
BEGIN 
	IF(@peopleCount <= 0)
		RETURN 'Invalid people count!'

	IF((SELECT TOP(1) Id FROM Flights WHERE Origin=@origin AND Destination=@destination) IS NULL)
		RETURN 'Invalid flight!'

	DECLARE @totalPrice DECIMAL(18,2)=
										(SELECT TOP(1) t.Price FROM Tickets AS t
										JOIN Flights AS f ON t.FlightId=f.Id
										WHERE Origin=@origin AND Destination=@destination)*@peopleCount

	RETURN CONCAT('Total price ',@totalPrice)
END


SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)

SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)