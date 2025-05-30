using System;
using System.Data;
using System.Data.SqlClient;
class SqlConnectionDemo
{
    static void Main()
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");
        SqlDataReader rdr = null;
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers", conn);
            rdr = cmd.ExecuteReader();
            Console.WriteLine("{0,-15} {1,-40} {2,-25}", "CustomerID", "CompanyName", "Country");
            Console.WriteLine(new string('-', 80));
            while(rdr.Read())
            {
                string CustomerId = rdr["CustomerId"].ToString();
                string CompanyName = rdr["CompanyName"].ToString();
                string Country = rdr["Country"].ToString();
                Console.WriteLine("{0,-15} {1,-40} {2,-25}", CustomerId, CompanyName, Country);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error:" + ex.Message);
        }
        finally
        {
            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }
        }
    }
}