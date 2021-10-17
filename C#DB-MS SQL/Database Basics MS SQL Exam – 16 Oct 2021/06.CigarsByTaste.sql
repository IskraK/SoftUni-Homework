--Select all cigars with "Earthy" or "Woody" tastes. Order results by PriceForSingleCigar (descending).
--Required columns:
--•	Id
--•	CigarName
--•	PriceForSingleCigar
--•	TasteType
--•	TasteStrength

SELECT c.id,
		c.CigarName,
		c.PriceForSingleCigar,
		t.TasteType,
		t.TasteStrength
FROM Cigars AS c
JOIN Tastes AS t ON c.TastId=t.Id
WHERE t.TasteType IN ('Earthy','Woody')
ORDER BY c.PriceForSingleCigar DESC