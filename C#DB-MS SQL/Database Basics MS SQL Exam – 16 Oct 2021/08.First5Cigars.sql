--Select the first 5 cigars that are at least 12cm long 
--and contain "ci" in the cigar name 
--or price for a single cigar is bigger than $50 
--and ring range is bigger than 2.55. 
--Order the result by cigar name (ascending), then by price for a single cigar (descending).
--Required columns:
--•	CigarName
--•	PriceForSingleCigar
--•	ImageURL

SELECT TOP(5) c.CigarName,c.PriceForSingleCigar,c.ImageURL 
FROM Cigars AS c
JOIN Sizes AS s ON c.SizeId=s.Id
WHERE s.[Length] >= 12 AND (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND s.RingRange > 2.55
ORDER BY c.CigarName,c.PriceForSingleCigar DESC
