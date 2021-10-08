CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @SenderId,@Amount
EXEC usp_DepositMoney @ReceiverId,@Amount
COMMIT

SELECT * FROM Accounts
WHERE Id=1 OR ID=2

EXEC usp_TransferMoney 2,1,100.00
