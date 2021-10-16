--Update the CloseDate with the current date of all reports, which don't have CloseDate. 

UPDATE Reports
SET CloseDate=GETDATE()
WHERE CloseDate IS NULL

SELECT * FROM Reports
WHERE CloseDate IS NULL