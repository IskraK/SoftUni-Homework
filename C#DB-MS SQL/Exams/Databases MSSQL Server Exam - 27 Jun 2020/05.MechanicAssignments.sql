--Select all mechanics with their jobs. Include job status and issue date. Order by mechanic Id, issue date, job Id (all ascending).
--Required columns:
--•	Mechanic Full Name
--•	Job Status
--•	Job Issue Date

SELECT CONCAT(m.FirstName,' ',m.LastName) AS Mechanic,
		j.[Status],
		j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j ON m.MechanicId=j.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId