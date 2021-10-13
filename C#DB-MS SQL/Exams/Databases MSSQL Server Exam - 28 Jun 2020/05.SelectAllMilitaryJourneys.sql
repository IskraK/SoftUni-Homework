--Extract from the database, all Military journeys in the format "dd-MM-yyyy". Sort the results ascending by journey start.
--Required Columns
--•	Id
--•	JourneyStart
--•	JourneyEnd


SELECT Id,
	   FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
	   FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose='Military'
ORDER BY JourneyStart