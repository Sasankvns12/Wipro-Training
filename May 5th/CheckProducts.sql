CREATE PROCEDURE CheckProductsExists
@ProductID INT
AS
BEGIN
if exists(select 1 FROM Products WHERE ProductID = @ProductID)
Print 'Product Exists'
ELSE
Print 'Product Not Found'
END;

// To Execute
EXEC CheckProductsExists @ProductID = 1;