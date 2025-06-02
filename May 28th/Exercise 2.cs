using System;
using System.Data;
using System.Data.SqlClient;
namespace ConsoleApp5
{
    class SqlConnection1
    {
        public static void GetOrdersByCustomer(string CustomerId)
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                conn.Open();

                string query = "Select  OrderId ,OrderDate, Shipcountry From Orders Where CustomerId = @CustomerId ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"OrderId : {rdr["OrderId"]} OrderDate : {rdr["OrderDate"]} Ship Country: {rdr["Shipcountry"]}");
                }

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
            Console.WriteLine("Enter CustomerId");
            string CustomerId = Console.ReadLine();
            GetOrdersByCustomer(CustomerId);
        }
    }
}