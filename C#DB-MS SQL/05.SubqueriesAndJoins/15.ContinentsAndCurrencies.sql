SELECT [ContinentCode],
       [CurrencyCode],
       [CurrencyCount] AS [CurrencyUsage]
FROM (
        SELECT *,
               DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) 
               AS [CurrencyRank]
        FROM (
                    SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyCount]
                    FROM [Countries]
                    GROUP BY [ContinentCode], [CurrencyCode]
             ) AS [CurrencyCountSubQuery]
        WHERE [CurrencyCount] > 1
      ) AS [CurrencyRankingSubQuery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]


--2-nd decision
SELECT Result.ContinentCode,Result.CurrencyCode,Result.[Count]
   FROM (SELECT c.ContinentCode,
	   c.CurrencyCode,COUNT(c.CurrencyCode) AS [Count],
	   DENSE_RANK() OVER (PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank] 
	FROM Countries AS c	
 GROUP BY c.ContinentCode,c.CurrencyCode) AS Result
 WHERE Result.[Rank] = 1 AND Result.[Count] > 1