--Create a user defined function, named udf_GetAvailableRoom(@HotelId, @Date, @People), 
--that receives a hotel ID, a desired date, and the count of people that are going to be signing up.
--The total price of the room can be calculated by using this formula:
--•	(HotelBaseRate + RoomPrice) * PeopleCount
--The function should find a suitable room in the provided hotel, based on these conditions:
--•	The room must not be already occupied. 
--	A room is occupied if the date the customers want to book is between the arrival and return dates of a trip to that room and the trip is not canceled.
--•	The room must be in the provided hotel.
--•	The room must have enough beds for all the people.
--If any rooms in the desired hotel satisfy the customers’ conditions, 
--	find the highest priced room (by total price) of all of them and provide them with that room.
--The function must return a message in the format:
--•	“Room {Room Id}: {Room Type} ({Beds} beds) - ${Total Price}”
--If no room could be found, the function should return “No rooms available”.


CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(400)
AS
BEGIN
DECLARE @roomId INT=
					(SELECT TOP(1) r.Id 
					FROM Trips AS t
                    JOIN Rooms AS r ON t.RoomId = r.Id
                    JOIN Hotels AS h ON r.HotelId = h.Id
					WHERE h.Id=@HotelId 
						  AND r.Beds >= @People 
						  AND (@Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate) 
						  AND t.CancelDate IS NULL
						  AND YEAR(@Date) = YEAR(t.ArrivalDate)
					ORDER BY r.Price DESC)

	IF(@roomId IS NULL)
		RETURN 'No rooms available'

	DECLARE @beds INT=(SELECT Beds FROM Rooms WHERE Id=@roomId)
	DECLARE @roomPrice DECIMAL(18, 2)=(SELECT Price FROM Rooms WHERE Id = @roomId)
	DECLARE @roomType VARCHAR(20)=(SELECT [Type] FROM Rooms WHERE Id=@roomId)
	DECLARE @hotelBaseRate DECIMAL(18,2)=(SELECT h.BaseRate FROM Rooms AS r
													JOIN Hotels AS h ON r.HotelId=h.Id
													WHERE h.Id=@HotelId AND r.Id=@roomId)

	DECLARE @totalPrice DECIMAL(18,2)=(@hotelBaseRate+@roomPrice)*@People

		--DECLARE @totalPrice DECIMAL(18,2)=(SELECT TOP(1) (h.BaseRate+r.Price)*@People 
											 --FROM Rooms AS r
											 --JOIN Hotels AS h ON r.HotelId=h.Id
											 --WHERE h.Id=@HotelId AND r.Id=@roomId
											 --ORDER BY (h.BaseRate+r.Price)*@People DESC)

	RETURN CONCAT('Room ',@roomId,': ',@roomType,' (',@beds,' beds) - $',@totalPrice)
END


SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)


