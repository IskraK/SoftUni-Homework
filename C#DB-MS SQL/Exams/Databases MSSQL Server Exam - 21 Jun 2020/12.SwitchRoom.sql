--Create a user defined stored procedure, named usp_SwitchRoom(@TripId, @TargetRoomId), 
--that receives a trip and a target room, and attempts to move the trip to the target room. 
--A room will only be switched if all of these conditions are true:
--•	If the target room ID is in a different hotel, than the trip is in, raise an exception with the message “Target room is in another hotel!”.
--•	If the target room doesn’t have enough beds for all the trip’s accounts, raise an exception with the message “Not enough beds in target room!”.
--If all the above conditions pass, change the trip’s room ID to the target room ID.


CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
DECLARE @hotelRoom INT=(SELECT HotelId FROM Rooms WHERE Id=@TargetRoomId)
DECLARE @tripRoom INT = (SELECT RoomId FROM Trips WHERE Id = @TripId)
DECLARE @hotelTrip INT = (SELECT HotelId FROM Rooms WHERE Id = @TripRoom)

IF(@hotelTrip<>@hotelRoom)
	THROW 50001,'Target room is in another hotel!',1

DECLARE @accounts INT= (SELECT COUNT(TripId) FROM AccountsTrips WHERE TripId = @TripId)
DECLARE @beds INT=(SELECT Beds FROM Rooms WHERE Id=@TargetRoomId)

IF(@beds < @accounts)
	THROW 50002,'Not enough beds in target room!',1

UPDATE Trips
SET RoomId=@TargetRoomId
WHERE Id=@TripId
GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10

EXEC usp_SwitchRoom 10, 7

EXEC usp_SwitchRoom 10, 8




