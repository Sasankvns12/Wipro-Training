using System;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp5
{
     class SqlConnection8
    {

        static void InsertOrderWithDetails()
        {
            string connStr = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = SSPI";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                   
                    string insertOrderQuery = @"
                    INSERT INTO Orders (CustomerID, OrderDate, ShipCountry)
                    VALUES (@CustomerID, @OrderDate, @ShipCountry);
                    SELECT SCOPE_IDENTITY();";

                    SqlCommand orderCmd = new SqlCommand(insertOrderQuery, conn, transaction);
                    orderCmd.Parameters.AddWithValue("@CustomerID", "ALFKI");
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCmd.Parameters.AddWithValue("@ShipCountry", "USA");

                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                   
                    string insertDetailQuery = @"
                    INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity)
                    VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity)";

                    SqlCommand detailCmd = new SqlCommand(insertDetailQuery, conn, transaction);
                    detailCmd.Parameters.AddWithValue("@OrderID", orderId);
                    detailCmd.Parameters.AddWithValue("@ProductID", 1);
                    detailCmd.Parameters.AddWithValue("@UnitPrice", 25);
                    detailCmd.Parameters.AddWithValue("@Quantity", 2);

                    detailCmd.ExecuteNonQuery();

                   
                    transaction.Commit();
                    Console.WriteLine("Order and Order Details inserted successfully.");
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine("Error: " + ex.Message);
                    transaction.Rollback();
                }
            }
        }

        static void Main()
        {
            InsertOrderWithDetails();
        }
    }
}