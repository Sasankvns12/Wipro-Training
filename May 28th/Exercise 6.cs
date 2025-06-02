using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
    class SqlConnection5
    {
        static void JoinOrdersCustomers()
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                conn.Open();

                string joinQuery = @"
                SELECT o.OrderID, c.CompanyName, o.OrderDate
                FROM Orders o
                INNER JOIN Customers c ON o.CustomerID = c.CustomerID";

                SqlCommand cmd = new SqlCommand(joinQuery, conn);
               

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("{0,-15} {1,-40} {2,-25}", "ORDERID", "COMPANYNAME", "ORDERDATE");
                Console.WriteLine(new string('-', 80));

                while (reader.Read())
                {
                    string OrderId = reader["OrderId"].ToString();
                    string CompanyName = reader["CompanyName"].ToString();
                    string OrderDate = reader["OrderDate"].ToString();
                    Console.WriteLine("{0,-15} {1,-40} {2,-25}", OrderId, CompanyName, OrderDate);
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

        static void Main()
        {
            JoinOrdersCustomers();
        }
    }
}