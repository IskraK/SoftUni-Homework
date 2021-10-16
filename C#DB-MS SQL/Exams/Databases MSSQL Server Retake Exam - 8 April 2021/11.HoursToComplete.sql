--Create a user defined function with the name udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
--that receives a start date and end date and must returns the total hours which has been taken for this task. 
--If start date is null or end is null return 0.

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @hours INT;
	IF(@StartDate IS NULL OR @EndDate IS NULL)
		SET @hours=0
	ELSE
		SET @hours=DATEDIFF(HOUR,@StartDate,@EndDate)
RETURN @hours
END

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports
