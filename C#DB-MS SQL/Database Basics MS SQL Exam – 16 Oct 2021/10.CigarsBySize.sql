--Select all clients which own cigars. 
--Select their last name, average length, and ring range (rounded up to the next biggest integer) of their cigars. 
--Order the results by average cigar length (descending).

SELECT c.LastName,
		AVG(s.[Length]) AS CiagrLength,
		CEILING(AVG(s.RingRange)) AS CiagrRingRange
FROM ClientsCigars AS cc
JOIN Clients AS c ON cc.ClientId=c.Id
JOIN Cigars AS ci ON cc.CigarId=ci.Id
JOIN Sizes AS s ON ci.SizeId=s.Id
GROUP BY c.LastName
ORDER BY CiagrLength DESC


