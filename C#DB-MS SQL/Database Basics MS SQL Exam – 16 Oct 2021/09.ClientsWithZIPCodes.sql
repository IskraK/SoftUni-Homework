--Select all clients which have addresses with ZIP code that contains only digits, and display they're the most expensive cigar. 
--Order by client full name ascending.
--Required columns:
--•	FullName
--•	Country
--•	ZIP
--•	CigarPrice – formated as "${CigarPrice}"


SELECT r.FullName,r.Country,r.ZIP,r.CigarPrice 
FROM
		(SELECT CONCAT(c.FirstName,' ',c.LastName) AS FullName,
				a.Country,
				a.ZIP,
				CONCAT('$',ci.PriceForSingleCigar) AS CigarPrice,
				DENSE_RANK() OVER (PARTITION BY CONCAT(c.FirstName,' ',c.LastName) ORDER BY ci.PriceForSingleCigar DESC) AS [Rank]
		FROM ClientsCigars AS cc
		LEFT JOIN Clients AS c ON cc.ClientId=c.Id
		LEFT JOIN Addresses AS a ON c.AddressId=a.Id
		LEFT JOIN Cigars AS ci ON cc.CigarId=ci.Id
		WHERE a.ZIP NOT LIKE '%[^0-9]%'
		GROUP BY CONCAT(c.FirstName,' ',c.LastName),a.Country,a.ZIP,ci.PriceForSingleCigar) AS r
WHERE [Rank]=1
ORDER BY r.FullName

--------------------------
--2nd decision
SELECT    CONCAT(c.[FirstName], ' ', c.[LastName]) AS [FullName],
        a.[Country],
        a.[ZIP],
        CONCAT('$',MAX([PriceForSingleCigar])) AS [CigarPrice]
FROM [Clients] AS c
JOIN [Addresses] AS a
ON c.[AddressId] = a.[Id]
JOIN [ClientsCigars] AS cl
ON c.[Id] = cl.ClientId
JOIN [Cigars] AS ci
ON cl.[CigarId] = ci.[Id]
WHERE a.ZIP NOT LIKE '%[a-z]%'
GROUP BY c.[FirstName] , c.[LastName], a.[Country], a.[ZIP]
ORDER BY [FullName]

------------------------------
--3rd decision
SELECT
	CONCAT(c.[FirstName], ' ', c.[LastName]) AS [FullName],
	a.[Country],
	a.[ZIP],
	CONCAT('$', MAX(cg.[PriceForSingleCigar])) AS [CigarPrice]
FROM [Clients] AS c
	JOIN [Addresses] AS a ON c.[AddressId] = a.[Id]
	JOIN [ClientsCigars] AS cc ON c.[Id] = cc.[ClientId]
	JOIN [Cigars] AS cg ON cc.[CigarId] = cg.[Id]
WHERE ISNUMERIC(a.[ZIP]) = 1
GROUP BY c.[FirstName], c.[LastName], a.[Country], a.[ZIP]
ORDER BY [FullName]