--Select the top 5 repositories in terms of count of commits. 
--Order them by commits count (descending), repository id (ascending) then by repository name (ascending).

SELECT TOP(5) 
			  r.Id,
			  r.[Name],
			  COUNT(c.Id) AS [Commits]
FROM Repositories AS r
JOIN Commits AS c ON r.Id=c.RepositoryId
JOIN RepositoriesContributors AS rc ON c.RepositoryId=rc.RepositoryId
GROUP BY r.Id,r.[Name]
ORDER BY Commits DESC,r.Id,r.Name


