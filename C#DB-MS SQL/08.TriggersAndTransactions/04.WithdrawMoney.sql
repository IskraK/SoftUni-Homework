CREATE OR ALTER PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
DECLARE @id INT=(SELECT Id FROM Accounts WHERE Id=@accountId)
DECLARE @balance DECIMAL(18,4)=(SELECT Balance FROM Accounts WHERE Id=@accountId)
IF (@id IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account Id!',16,1)
		RETURN
	END

IF (@moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Negative money amount!',16,1)
		RETURN
	END

IF (@balance - @moneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Not enough money!',16,1)
		RETURN
	END

UPDATE Accounts
SET Balance-=@moneyAmount
WHERE Id=@accountId
COMMIT



EXEC usp_WithdrawMoney 5,25.00

SELECT * FROM Accounts
WHERE Id=5

SELECT * FROM Logs

SELECT * FROM NotificationEmails