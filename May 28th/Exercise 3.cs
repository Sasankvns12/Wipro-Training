using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
    class SqlConnection2
    {
        public static void InsertProduct()
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                conn.Open();

                string query = @" INSERT INTO Products (ProductName, SupplierID, CategoryID, UnitPrice)
                                     VALUES (@ProductName, @SupplierID, @CategoryID, @UnitPrice)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", "Test Product");
                cmd.Parameters.AddWithValue("@SupplierID", 1);
                cmd.Parameters.AddWithValue("@CategoryID", 1);
                cmd.Parameters.AddWithValue("@UnitPrice", 25);


                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Inserted {rowsAffected} row(s) into Products table.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                if (rdr != null)
                {
                    rdr.Close();
                }


                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public static void Main()
        {
            InsertProduct();
        }
    }
}