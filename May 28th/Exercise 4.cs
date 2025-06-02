using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
    class SqlConnection3
    {
        public static void UpdateEmployeeTitle(int employeeId, string title)
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                conn.Open();

                string UpdateQuery = "UPDATE Employees SET Title = @Title WHERE EmployeeID = @EmployeeId";

                SqlCommand cmd = new SqlCommand(UpdateQuery, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);


                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"UPDATED {rowsAffected} row(s) into Employees table.");

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
            Console.WriteLine("Enter EmployeeId");
            int employeeId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter new title");
            string title = Console.ReadLine();

            UpdateEmployeeTitle(employeeId, title)
        }
    }
}