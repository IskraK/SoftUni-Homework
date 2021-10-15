--Retrieve the following information about each trip:
--•	Trip ID
--•	Account Full Name
--•	From – Account hometown
--•	To – Hotel city
--•	Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”
--Order the results by full name, then by Trip ID.

SELECT t.Id,
	   CONCAT(a.FirstName,' ',ISNULL(a.MiddleName + ' ',''),a.LastName) AS [Full Name],
	   c.[Name] AS [From],
	   c1.[Name] AS [To],
	   CASE 
			WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')
			ELSE 'Canceled' END AS Duration
FROM Trips AS t
JOIN AccountsTrips AS at ON t.Id=at.TripId
JOIN Accounts AS a ON at.AccountId=a.Id
JOIN Cities AS c ON a.CityId=c.Id
JOIN Rooms AS r ON t.RoomId=r.Id
JOIN Hotels AS h ON r.HotelId=h.Id
JOIN Cities AS c1 ON h.CityId=c1.Id
ORDER BY [Full Name],t.Id

