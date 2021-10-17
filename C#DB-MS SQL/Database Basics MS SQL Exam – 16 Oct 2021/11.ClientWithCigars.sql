--Create a user-defined function, named udf_ClientWithCigars(@name) that receives a client’s first name.
--The function should return the total number of cigars that the client has:

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN 
DECLARE @totalCigarCount INT = 
								(SELECT COUNT(cc.CigarId) 
								FROM Clients AS c
								JOIN ClientsCigars AS cc ON c.Id=cc.ClientId
								WHERE c.FirstName=@name)
RETURN @totalCigarCount
END

GO

SELECT COUNT(cc.CigarId) 
FROM Clients AS c
JOIN ClientsCigars AS cc ON c.Id=cc.ClientId
WHERE c.FirstName='Betty'


SELECT dbo.udf_ClientWithCigars('Betty')