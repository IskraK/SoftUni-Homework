USE Diablo

GO

CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT SUM(r.Cash) AS [SumCash] 
		 FROM (
				SELECT ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [RowNumber], ug.Cash
				FROM UsersGames AS ug
				JOIN Games AS g ON ug.GameId = g.Id
				WHERE g.[Name] = @gameName) AS r
		WHERE RowNumber % 2 =1)


SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')