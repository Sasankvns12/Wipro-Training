using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp5
{
     class SqlConnection7
    {
        static void LoadPrducts()
        {
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=SSPI");

            SqlDataReader rdr = null;

            try
            {

                //conn.Open();

                string query = "SELECT ProductID, ProductName, UnitsInStock FROM Products WHERE UnitsInStock > 20";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "Products");

                DataTable table = ds.Tables["Products"];
                Console.WriteLine("{0,-15} {1,-35} {2,-15}","ProductID","ProductName","UnitsInStock");
                Console.WriteLine(new string('-', 80));

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine("{0,-15} {1,-35} {2,-15}", row["ProductID"],row["ProductName"],row["UnitsInStock"]);
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
            LoadPrducts();
        }
    }
}