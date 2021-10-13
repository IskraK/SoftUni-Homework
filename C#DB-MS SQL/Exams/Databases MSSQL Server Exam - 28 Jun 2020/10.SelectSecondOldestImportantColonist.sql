--Find all colonists and their job during journey with rank 2. 
--Keep in mind that all the selected colonists with rank 2 must be the oldest ones. You can use ranking over their job during their journey.
--Required Columns
--•	JobDuringJourney
--•	FullName
--•	JobRank


SELECT r.JobDuringJourney AS JobDuringJourney,
	   r.FullName,
	   r.JobRank
FROM
			(SELECT 
					t.JobDuringJourney,
					CONCAT(c.FirstName,' ',c.LastName) AS FullName,
					DATEDIFF(YEAR,c.BirthDate,'2019-01-01') AS Age,
					DENSE_RANK() OVER(PARTITION BY t.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
			FROM Colonists AS c
			JOIN TravelCards AS t ON c.Id=t.ColonistId
			JOIN Journeys AS j ON t.JourneyId=j.Id
			GROUP BY t.JobDuringJourney,c.FirstName,c.LastName,c.BirthDate) AS r
WHERE JobRank=2


--2nd decision
SELECT JobDuringJourney,FULLNAME, RANKQUERY.RANK
     FROM (SELECT TC.JobDuringJourney AS JobDuringJourney,
       C.FirstName+' '+C.LastName AS FULLNAME,
      ( DENSE_RANK() over (PARTITION BY TC.JobDuringJourney ORDER BY C.BirthDate)) AS RANK
FROM Colonists AS C
JOIN TravelCards TC on C.Id = TC.ColonistId) AS RANKQUERY
WHERE RANK=2