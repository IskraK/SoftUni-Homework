--In table Addresses, delete every country which name starts with 'C', keep in mind that could be foreign key constraint conflicts.

SELECT * FROM Addresses
WHERE Country LIKE 'C%'

--Id=7,8,10,23

DELETE FROM Clients
WHERE AddressId IN (7,8,10,23)

DELETE FROM Addresses
WHERE Country LIKE 'C%'