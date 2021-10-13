--Create a user defined function with the name dbo.udf_GetColonistsCount(PlanetName VARCHAR (30)) 
--that receives planet name and returns the count of all colonists sent to that planet.

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	DECLARE @count INT = 
						(SELECT COUNT(p.Id) AS Count
						FROM Colonists AS c
						JOIN TravelCards AS t On c.Id=t.ColonistId
						JOIN Journeys AS j ON t.JourneyId=j.Id
						JOIN Spaceports AS sp ON j.DestinationSpaceportId=sp.Id
						JOIN Planets AS p ON sp.PlanetId=p.Id
						WHERE p.[Name]=@PlanetName)
	RETURN @count 
END


SELECT dbo.udf_GetColonistsCount('Otroyphus')
