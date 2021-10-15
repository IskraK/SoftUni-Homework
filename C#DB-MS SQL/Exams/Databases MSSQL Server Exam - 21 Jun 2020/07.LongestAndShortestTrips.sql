--Find the longest and shortest trip for each account, in days. 
--Filter the results to accounts with no middle name and trips, which are not cancelled (CancelDate is null).
--Order the results by Longest Trip days (descending), then by Shortest Trip (ascending).

SELECT a.Id,
	   CONCAT(a.FirstName,' ',a.LastName) AS FullName,
	   MAX(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id=at.AccountId
JOIN Trips AS t ON at.TripId=t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id,CONCAT(a.FirstName,' ',a.LastName)
ORDER BY LongestTrip DESC,ShortestTrip
