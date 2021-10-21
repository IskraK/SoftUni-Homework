--Select the names of all clients with active jobs (not Finished). 
--Include the status of the job and how many days it’s been since it was submitted. 
--Assume the current date is 24 April 2017. 
--Order results by time length (descending) and by client ID (ascending).
--Required columns:
--•	Client Full Name
--•	Days going – how many days have passed since the issuing
--•	Status


SELECT CONCAT(c.FirstName,' ',c.LastName) AS Client,
		DATEDIFF(DAY,j.IssueDate,'2017-04-24') AS [Days going],
		j.Status
FROM Clients AS c
LEFT JOIN Jobs AS j ON c.ClientId=j.ClientId
WHERE j.Status<>'Finished'
ORDER BY [Days going] DESC,c.ClientId