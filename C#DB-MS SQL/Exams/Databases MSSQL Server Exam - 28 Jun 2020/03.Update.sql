--Update all spaceships light speed rate with 1 where the Id is between 8 and 12.

UPDATE Spaceships
SET LightSpeedRate+=1
WHERE Id BETWEEN 8 AND 12

SELECT * FROM Spaceships