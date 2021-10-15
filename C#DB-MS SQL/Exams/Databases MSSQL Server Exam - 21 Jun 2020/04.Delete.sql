--Delete all of Account ID 47’s account’s trips from the mapping table.

DELETE FROM AccountsTrips
WHERE AccountId=47

SELECT * FROM AccountsTrips
WHERE AccountId=47