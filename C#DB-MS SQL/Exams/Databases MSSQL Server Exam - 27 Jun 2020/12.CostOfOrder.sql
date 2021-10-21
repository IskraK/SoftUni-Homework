--Create a user defined function (udf_GetCost) that receives a job’s ID 
--and returns the total cost of all parts that were ordered for it. Return 0 if there are no orders.
--Parameters:
--•	JobId

CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(18,2)
BEGIN
DECLARE @ordersCount INT=
							(SELECT COUNT(o.OrderId) 
							FROM Jobs AS j
							LEFT JOIN Orders AS o ON j.JobId=o.JobId
							WHERE j.JobId=@jobId)

IF(@ordersCount=0)
	RETURN 0

DECLARE @totalPrice DECIMAL(18,2)=
									(SELECT SUM(p.Price*op.Quantity) 
									FROM Jobs AS j
									LEFT JOIN Orders AS o ON j.JobId=o.JobId
									LEFT JOIN OrderParts AS op ON o.OrderId=op.OrderId
									LEFT JOIN Parts AS p ON op.PartId=p.PartId
									WHERE j.JobId=@jobId)
RETURN @totalPrice
END


SELECT dbo.udf_GetCost(1)