CREATE PROCEDURE GetOrdersByProduct
    @ProductID INT
AS
BEGIN
    SELECT
        o.OrderID,
        o.Quantity,
        o.OrderDate,
        p.ProductName,
        p.Price
    FROM Orders o
    INNER JOIN Products p ON o.ProductID = p.ProductID
    WHERE o.ProductID = @ProductID;
END;

// To Execute
EXEC GetOrdersByProduct @ProductID = 1;