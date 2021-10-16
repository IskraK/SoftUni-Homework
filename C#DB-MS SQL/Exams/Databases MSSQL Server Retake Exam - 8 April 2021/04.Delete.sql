--Delete all reports who have a Status 4.

DELETE FROM Reports
WHERE StatusId=4

SELECT * FROM Reports
WHERE StatusId=4

SELECT * FROM [Status]