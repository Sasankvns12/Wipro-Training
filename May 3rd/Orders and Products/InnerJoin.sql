SELECT
    Orders.OrderID,
    Products.ProductName,
    Orders.Quantity,
    Products.Price,
    (Orders.Quantity * Products.Price) AS TotalAmount,
    Orders.OrderDate
FROM Orders
INNER JOIN Products ON Orders.ProductID = Products.ProductID;