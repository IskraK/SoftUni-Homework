CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY, 
Recipient INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL, 
[Subject] VARCHAR(50), 
Body VARCHAR(MAX)
)


GO

ALTER TRIGGER tr_LogsEmail ON Logs FOR INSERT
AS
DECLARE @accountId INT=(SELECT TOP(1) AccountId FROM inserted)
DECLARE @oldSum DECIMAL(15,2)=(SELECT TOP(1) OldSum FROM inserted)
DECLARE @newSum DECIMAL(15,2)=(SELECT TOP(1) NewSum FROM inserted)
INSERT INTO NotificationEmails(Recipient,Subject,Body) VALUES
	(@accountId,
	'Balance change for account: '+CAST(@accountId AS VARCHAR(20)),
	'On '+CAST(GETDATE() AS VARCHAR(30))+' your balance was changed from '+CAST(@oldSum AS VARCHAR(20))+' to '+CAST(@newSum AS VARCHAR(20))+'.'
	)

GO

SELECT * FROM Accounts
WHERE Id=1

UPDATE Accounts
SET Balance+=100
WHERE Id=1

SELECT * FROM Logs

SELECT * FROM NotificationEmails