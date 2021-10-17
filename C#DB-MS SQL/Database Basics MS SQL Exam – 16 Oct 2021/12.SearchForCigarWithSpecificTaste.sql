--Create a stored procedure, named usp_SearchByTaste(@taste), that receives taste type. 
--The procedure must print full information about all cigars with the given tastes: 
--CigarName, Price, TasteType, BrandName, CigarLength, CigarRingRange. 
--Add "$" at the beginning of the price and "cm" at the end of both CigarLength and CigarRingRange. 
--Order them by CigarLength (ascending), and CigarRingRange (descending).

CREATE PROC usp_SearchByTaste(@tasteType VARCHAR(20))
AS
SELECT c.CigarName,
		CONCAT('$',c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.[Length],' cm') AS CigarLength,
		CONCAT(s.RingRange,' cm') AS CigarRingRange
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId=t.Id
JOIN Brands AS b ON c.BrandId=b.Id
JOIN Sizes AS s ON c.SizeId=s.Id
WHERE t.TasteType=@tasteType
ORDER BY CigarLength,CigarRingRange DESC
GO


EXEC usp_SearchByTaste 'Woody'