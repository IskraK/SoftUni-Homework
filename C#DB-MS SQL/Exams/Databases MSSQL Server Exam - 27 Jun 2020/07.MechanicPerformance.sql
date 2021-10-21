--Select all mechanics and the average time they take to finish their assigned jobs. 
--Calculate the average as an integer. 
--Order results by mechanic ID (ascending).
--Required columns:
--•	Mechanic Full Name
--•	Average Days – average number of days the machanic took to finish the job


SELECT CONCAT(m.FirstName,' ',m.LastName) AS Mechanic,
		AVG(DATEDIFF(DAY,j.IssueDate,j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId=j.MechanicId
GROUP BY m.MechanicId,m.FirstName,m.LastName
ORDER BY m.MechanicId