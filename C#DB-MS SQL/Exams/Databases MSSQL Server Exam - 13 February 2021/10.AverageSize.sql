--Select all users which have commits. 
--Select their username and average size of the file, which were uploaded by them. 
--Order the results by average upload size (descending) and by username (ascending).

SELECT u.Username,
	   AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON u.Id=c.ContributorId
JOIN Files AS f ON c.Id=f.CommitId
GROUP BY u.Id,u.Username
ORDER BY AVG(f.Size) DESC,u.Username
