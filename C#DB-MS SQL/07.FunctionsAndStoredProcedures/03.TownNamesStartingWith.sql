CREATE PROC usp_GetTownsStartingWith(@TownLetters VARCHAR(50))
AS
SELECT [Name] AS [Town] 
FROM Towns
WHERE LEFT([Name],LEN(@TownLetters)) = @TownLetters
--WHERE [Name] LIKE '@TownLetters%'

EXEC usp_GetTownsStartingWith b