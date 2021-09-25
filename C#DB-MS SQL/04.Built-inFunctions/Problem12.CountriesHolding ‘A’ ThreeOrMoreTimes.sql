USE [Geography]

SELECT CountryName AS [Country Name],
IsoCode AS [ISO Code]
FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]


--2-nd decision
SELECT CountryName AS [Country Name],
IsoCode AS [ISO Code]
FROM [Countries]
WHERE LEN([CountryName]) - LEN(REPLACE(CountryName,'a','')) >= 3
ORDER BY [IsoCode]