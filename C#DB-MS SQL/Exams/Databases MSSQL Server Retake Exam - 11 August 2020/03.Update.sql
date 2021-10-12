--We’ve decided to switch some of our ingredients to a local distributor. 
--Update the table Ingredients and change the DistributorId of "Bay Leaf", "Paprika" and "Poppy" to 35. 
--Change the OriginCountryId to 14 of all ingredients with OriginCountryId equal to 8.

SELECT * FROM Ingredients
WHERE [Name] IN ('Bay Leaf','Paprika','Poppy')

--Id=3,23,26

UPDATE Ingredients
SET DistributorId=35
WHERE [Name] IN ('Bay Leaf','Paprika','Poppy')

UPDATE Ingredients
SET OriginCountryId=14
WHERE OriginCountryId=8