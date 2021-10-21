--Select all mechanics without active jobs 
--(include mechanics which don’t have any job assigned or all of their jobs are finished). 
--Order by ID (ascending).
--Required columns:
--•	Mechanic Full Name

SELECT CONCAT(m.FirstName,' ',m.LastName) AS Available
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId=j.MechanicId
WHERE j.[Status]='Finished' OR j.JobId IS NULL
GROUP BY m.MechanicId,m.FirstName,m.LastName
ORDER BY m.MechanicId


