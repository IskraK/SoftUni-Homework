--Select all finished jobs and the total cost of all parts that were ordered for them. 
--Sort by total cost of parts ordered (descending) and by job ID (ascending).
--Required columns:
--•	Job ID
--•	Total Parts Cost

SELECT j.JobId,
		ISNULL(SUM(p.Price*op.Quantity),0) AS Total
FROM Jobs AS j
LEFT JOIN Orders AS o ON j.JobId=o.JobId
LEFT JOIN OrderParts AS op ON o.OrderId=op.OrderId
LEFT JOIN Parts AS p ON op.PartId=p.PartId
WHERE j.[Status]='Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId
