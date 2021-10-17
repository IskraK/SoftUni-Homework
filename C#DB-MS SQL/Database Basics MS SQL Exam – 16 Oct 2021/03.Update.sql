--We’ve decided to increase the price of some cigars by 20%. 
--Update the table Cigars and increase the price of all cigars, which TasteType is "Spicy" by 20%. 
--Also add the text "New description" to every brand, which does not has BrandDescription.

SELECT * FROM Cigars
WHERE TastId =1

SELECT * FROM Tastes
WHERE TasteType='Spicy'

--Id=1

UPDATE Cigars
SET PriceForSingleCigar*=1.2
WHERE TastId =1

UPDATE Brands
SET BrandDescription='New description'
WHERE BrandDescription IS NULL

SELECT * FROM Brands
WHERE BrandDescription IS NULL