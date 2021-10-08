CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
	OldSum DECIMAL(15,2), 
	NewSum DECIMAL(15,2)
	)

GO

CREATE TRIGGER tr_AddToLogsOnAccountsUpdate
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT i.Id,d.Balance,i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id=d.Id
	WHERE i.Balance <> d.Balance

GO

--2nd decision
--CREATE TRIGGER tr_AddToLogsOnAccounts
--ON Accounts FOR UPDATE
--AS
--	DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
--	DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
--	DECLARE @accountId INT =(SELECT Id FROM inserted)
--	INSERT INTO Logs(AccountId,OldSum,NewSum) VALUES
--		(@accountId,@oldSum,@newSum)

UPDATE Accounts
SET Balance+=10
WHERE Id=1

SELECT * FROM Logs


