--Select all cigars ordered by price (ascending) then by cigar name  (descending). 
--Required columns:
--•	CigarName
--•	PriceForSingleCigar
--•	ImageURL

SELECT CigarName,PriceForSingleCigar,ImageURL 
FROM Cigars
ORDER BY PriceForSingleCigar,CigarName DESC