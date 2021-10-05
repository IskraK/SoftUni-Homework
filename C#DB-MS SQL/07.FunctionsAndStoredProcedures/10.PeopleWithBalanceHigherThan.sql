CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,2))
AS
SELECT FirstName AS [First Name],
LastName AS [Last Name]
FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id=a.AccountHolderId
GROUP BY FirstName,LastName
HAVING SUM(a.Balance) > @number
ORDER BY [First Name],[Last Name]


EXEC usp_GetHoldersWithBalanceHigherThan 10000