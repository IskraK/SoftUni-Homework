SELECT SUM([Difference]) AS [SumDifference] 
FROM
	(SELECT wd1.[FirstName] AS [Host Wizard],
		wd1.[DepositAmount] AS [Host Wizard Deposit],
		wd2.[FirstName] AS [Guest Wizard],
		wd2.[DepositAmount] AS [Guest Wizard Deposit],
		wd1.[DepositAmount]-wd2.[DepositAmount] AS [Difference]
	FROM [WizzardDeposits] AS wd1
	JOIN [WizzardDeposits] AS wd2 ON wd1.[Id] + 1 =wd2.[Id]) AS [DifferenceSubquery]


--2-nd decision with LEAD()
SELECT SUM([Difference]) AS [SumDifference] 
FROM
	(SELECT [FirstName] AS [Host Wizard],
		   [DepositAmount] AS [Host Wizard Deposit],
		   LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizard],
		   LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Guest Wizard Deposit],
		   [DepositAmount] - LEAD([DepositAmount]) OVER(ORDER BY [Id]) AS [Difference]
	FROM [WizzardDeposits]) AS [DifferenceSubquery]