SELECT PeakName,
	   RiverName,
	   LOWER(CONCAT(LEFT(PeakName, LEN(PeakName)-1), RiverName)) AS [Mix]
FROM [Peaks] AS p,
	 [Rivers] AS r
WHERE LOWER(RIGHT(PeakName,1)) = LOWER(LEFT(RiverName,1))
ORDER BY [Mix]


--2-nd decision
SELECT PeakName,
	   RiverName,
	   LOWER(CONCAT(PeakName, SUBSTRING(RiverName,2,LEN(RiverName)))) AS [Mix]
FROM [Peaks] AS p,
	 [Rivers] AS r
WHERE LOWER(RIGHT(PeakName,1)) = LOWER(LEFT(RiverName,1))
ORDER BY [Mix]