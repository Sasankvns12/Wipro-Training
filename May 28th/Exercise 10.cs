using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
     class SqlConnection9
    {
        static void GetCustomerOrderHistory(string customerId)
        {
            string connStr = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Northwind; Integrated Security = SSPI";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("CustOrderHist", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("{0,-45} {1,-25}","ProductName", "Total");
                Console.WriteLine(new string('-', 50));
                while (reader.Read())
                {
                    Console.WriteLine("{0,-45} {1,-25}", reader["ProductName"],reader["Total"]);
                }

                reader.Close();
            }
        }

        static void Main()
        {
            Console.Write("Enter Customer ID: ");
            string customerId = Console.ReadLine();

            GetCustomerOrderHistory(customerId);
        }
    }
}