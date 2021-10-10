--Delete repository "Softuni-Teamwork" in repository contributors and issues.
SELECT * FROM Repositories
WHERE [Name]='Softuni-Teamwork'

--Id=3

SELECT * FROM RepositoriesContributors
WHERE RepositoryId=3

SELECT * FROM Issues
WHERE RepositoryId=3


DELETE FROM RepositoriesContributors
WHERE RepositoryId=3

DELETE FROM Issues
WHERE RepositoryId=3



