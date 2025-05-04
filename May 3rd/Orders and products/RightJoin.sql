SELECT
    Products.ProductID,
    Products.ProductName,
    Orders.OrderID,
    Orders.Quantity,
    Orders.OrderDate
FROM Products
RIGHT JOIN Orders ON Products.ProductID = Orders.ProductID;