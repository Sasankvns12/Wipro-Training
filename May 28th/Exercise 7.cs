using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
    class SqlConnection6
    {
        static void DisplayByCategory()
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                conn.Open();

                string Query = @"
                SELECT p.CategoryID,SUM(od.UnitPrice * od.Quantity) AS TotalSales
                FROM [Order Details] od
                JOIN Products p ON od.ProductID = p.ProductID
                GROUP BY p.CategoryID";

                SqlDataAdapter adapter = new SqlDataAdapter(Query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);



                Console.WriteLine("CategoryID\tTotalSales");
                foreach(DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row["CategoryID"]}\t\t{row["TotalSales"]}");
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
            DisplayByCategory();
        }
    }
}