--Select all of the files, which are NOT a parent to any other file. 
--Select their size of the file and add "KB" to the end of it. 
--Order them file id (ascending), file name (ascending) and file size (descending).

SELECT f.Id,
	   f.[Name],
	   CONVERT(VARCHAR,f.Size)+'KB' AS Size
FROM Files AS f
LEFT JOIN Files AS pf ON f.Id=pf.ParentId
WHERE pf.Id IS NULL
ORDER BY f.Id,f.[Name],f.Size DESC