--Create a user defined stored procedure, named usp_ChangeJourneyPurpose(@JourneyId, @NewPurpose), 
--that receives an journey id and purpose, and attempts to change the purpose of that journey. 
--An purpose will only be changed if all of these conditions pass:
--•	If the journey id doesn’t exists, then it cannot be changed. Raise an error with the message “The journey does not exist!”
--•	If the journey has already that purpose, raise an error with the message “You cannot change the purpose!”
--If all the above conditions pass, change the purpose of that journey.


CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose NVARCHAR(11))
AS
IF(@JourneyId  NOT IN (SELECT Id FROM Journeys))
	THROW 50001,'The journey does not exist!',1

IF(@NewPurpose=(SELECT Purpose FROM Journeys WHERE Id=@JourneyId))
	THROW 50002,'You cannot change the purpose!',1

UPDATE Journeys
SET Purpose=@NewPurpose
WHERE Id=@JourneyId

GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'

EXEC usp_ChangeJourneyPurpose 2, 'Educational'

EXEC usp_ChangeJourneyPurpose 196, 'Technical'

SELECT * FROM Journeys
WHERE Id=4

--2nd decision
CREATE PROC usp_ChangeJourneyPurpose @JourneyId INT , @NewPurpose VARCHAR(11)
AS
	IF(NOT EXISTS(SELECT * FROM Journeys WHERE Id = @JourneyId ))
	BEGIN
		RAISERROR('The journey does not exist!',16,1)
		RETURN
	END

	IF(EXISTS(SELECT * FROM Journeys WHERE Id = @JourneyId AND Purpose = @NewPurpose))
	BEGIN
		RAISERROR('You cannot change the purpose!',16,1)
		RETURN
	END

	UPDATE Journeys
	SET Purpose = @NewPurpose
	WHERE Id = @JourneyId