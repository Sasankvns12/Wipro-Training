using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Demonstrates how to work with SqlConnection objects
/// </summary>
class SqlConnectionDemo
{
    static void Main()
    {
        // 1. Instantiate the connection
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=true";
        SqlConnection conn = new SqlConnection(connectionString);
        //"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

        SqlDataReader rdr = null;

        try
        {
            // 2. Open the connection
            conn.Open();

            // 3. Pass the connection to a command object
            SqlCommand cmd = new SqlCommand("SELECT ContactName, City, CompanyName FROM Customers", conn);

            //
            // 4. Use the connection
            //

            // get query results
            rdr = cmd.ExecuteReader();

            // print the ContactName, City, CompanyName of each record
            while (rdr.Read())
            {
                Console.WriteLine($"ContactName:{rdr["ContactName"]}");//Access by Column Name
                Console.WriteLine($"City:{rdr["City"]}");
                Console.WriteLine($"CompanyName:{rdr["CompanyName"]}");

                Console.WriteLine();
                //Add an empty line for better readability between records

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
        }
        finally
        {
            // close the reader
            if (rdr != null)
            {
                rdr.Close();
            }

            // 5. Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
        Console.WriteLine();
    }
}