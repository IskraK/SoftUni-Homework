SELECT Id,[Name],Size 
FROM Files
WHERE Size> 1000 AND [NAME] LIKE '%html%'
ORDER BY Size DESC,Id,[Name]