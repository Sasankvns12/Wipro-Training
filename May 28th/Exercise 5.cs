using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
     class SqlConnection4
    {
        static void DeleteProduct(int productId)
        {

            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                conn.Open();

                string deleteQuery ="DELETE FROM Products WHERE ProductID = @ProductID";

                SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

               
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine($"Product with ID {productId} deleted successfully.");
                else
                    Console.WriteLine($"No product found with ID {productId}.");



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

        static void Main()
        {
            Console.WriteLine("Enter productId");
            int productId = int.Parse(Console.ReadLine());

            DeleteProduct(productId);
        }
    }
}