--Create a user defined function, named udf_AllUserCommits(@username) that receives a username.
--The function must return count of all commits for the user:


CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
DECLARE @count INT =(SELECT COUNT(c.Id) FROM Users AS u
										JOIN Commits AS c ON u.Id=c.ContributorId
										WHERE Username=@username)
	RETURN @count
END

SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

SELECT COUNT(c.Id) FROM Users AS u
JOIN Commits AS c ON u.Id=c.ContributorId
WHERE Username='UnderSinduxrein'