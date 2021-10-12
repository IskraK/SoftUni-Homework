--Create a trigger that deletes all of the relations of a product upon its deletion.

CREATE TRIGGER tr_DeleteProduct
ON Products INSTEAD OF DELETE
AS
	DECLARE @deletedProductId INT = (SELECT p.Id 
									   FROM Products AS p
									   JOIN deleted AS d ON p.Id=d.Id)
	DELETE FROM ProductsIngredients
	WHERE ProductId=@deletedProductId

	DELETE FROM Feedbacks
	WHERE ProductId=@deletedProductId

	DELETE FROM Products
	WHERE Id=@deletedProductId
GO

DELETE FROM Products WHERE Id = 7