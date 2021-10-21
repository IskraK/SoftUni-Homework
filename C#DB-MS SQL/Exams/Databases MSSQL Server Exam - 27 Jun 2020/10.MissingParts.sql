--List all parts that are needed for active jobs (not Finished) without sufficient quantity in stock 
--and in pending orders (the sum of parts in stock and parts ordered is less than the required quantity). 
--Order them by part ID (ascending).
--Required columns:
--•	Part ID
--•	Description
--•	Required – number of parts required for active jobs
--•	In Stock – how many of the part are currently in stock
--•	Ordered – how many of the parts are expected to be delivered (associated with order that is not Delivered)

SELECT * FROM
				(SELECT p.PartId,
						p.[Description],
						pn.Quantity AS [Required],
						p.StockQty AS [In Stock],
						ISNULL(op.Quantity,0) AS Ordered
				FROM Parts AS p
				LEFT JOIN PartsNeeded AS pn ON p.PartId=pn.PartId
				LEFT JOIN Jobs AS j ON pn.JobId=j.JobId
				LEFT JOIN Orders AS o ON j.JobId=o.OrderId
				LEFT JOIN OrderParts AS op ON o.OrderId=op.OrderId
				WHERE j.[Status]<>'Finished' AND (o.Delivered=0 OR o.Delivered IS NULL)) AS Subquery
WHERE [In Stock] + Ordered < [Required]
ORDER BY PartId

--Zero test failed in Judge

-------------------------
--2nd decision

SELECT * FROM
				(SELECT p.PartId,
						p.[Description],
						pn.Quantity AS [Required],
						p.StockQty AS [In Stock],
						ISNULL(op.Quantity,0) AS Ordered
				FROM Jobs AS j
				LEFT JOIN PartsNeeded AS pn ON j.JobId=pn.JobId
				LEFT JOIN Parts AS p ON pn.PartId=p.PartId
				LEFT JOIN Orders AS o ON j.JobId=o.JobId
				LEFT JOIN OrderParts AS op ON o.OrderId=op.OrderId
				WHERE j.[Status]<>'Finished' AND (o.Delivered=0 OR o.Delivered IS NULL)) AS Subquery
WHERE [In Stock] + Ordered < [Required]
ORDER BY PartId