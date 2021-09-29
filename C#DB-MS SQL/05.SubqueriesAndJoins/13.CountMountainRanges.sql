SELECT 
   mc.CountryCode,
   COUNT(m.MountainRange) AS MountainRanges
FROM MountainsCountries AS mc
LEFT JOIN Mountains AS m ON mc.MountainId=m.Id
WHERE mc.CountryCode IN ('US','RU','BG')
GROUP BY mc.CountryCode