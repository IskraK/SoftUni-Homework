CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
DECLARE @id INT=(SELECT Id FROM Accounts WHERE Id=@accountId)
IF (@id IS NULL)
	BEGIN
		ROLLBACK
		--THROW 50001,'Invalid account Id!',1
		RAISERROR('Invalid account Id!',16,1)
		RETURN
	END

IF (@moneyAmount < 0)
	BEGIN
		ROLLBACK
		--THROW 50001,'Invalid account Id!',1
		RAISERROR('Negative money amount!',16,1)
		RETURN
	END

UPDATE Accounts
SET Balance+=@moneyAmount
WHERE Id=@accountId
COMMIT


EXEC usp_DepositMoney 1,100.45

SELECT * FROM Accounts
WHERE Id=1

SELECT * FROM Logs

SELECT * FROM NotificationEmails
