CREATE FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(18,4), @yearlyInterest FLOAT, @years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN 
	DECLARE @futureValue DECIMAL(18,4) 
	SET @futureValue = @initialSum * POWER((1 + @yearlyInterest),@years)
	RETURN @futureValue
END


SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)