--Extract from the database all colonists, which have a pilot job. Sort the result by id, ascending.
--Required Columns
--	Id
--	FullName

SELECT c.Id,
	   CONCAT(c.FirstName,' ',c.LastName) AS FullName
FROM Colonists AS c
LEFT JOIN TravelCards AS t ON c.Id=t.ColonistId
WHERE t.JobDuringJourney = 'Pilot'
ORDER BY c.Id