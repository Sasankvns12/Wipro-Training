using System;
using System.Data.SqlClient;
class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;" + "Integrated Security=true";
        //Provide the query string with a parameter placeholder.
        string queryString = "select Suppliers.City,Suppliers.CompanyName,Products.UnitPrice,Products.ProductName from Suppliers Inner Join Products ON Suppliers.SupplierID = Products.SupplierID";
        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();
                Console.WriteLine("City".PadRight(20) + "CompanyName".PadRight(40) + "UnitPrice".PadRight(30).PadLeft(20) + "ProductName");
                Console.WriteLine(new string('-', 25) + new string('-', 20) + new string('-', 30) + new string('-', 30));
                while(rdr.Read())
                {
                    string City = rdr[0].ToString();
                    string CompanyName = rdr[1].ToString();
                    string UnitPrice = rdr[2].ToString();
                    string ProductName = rdr[3].ToString();
                    Console.WriteLine(City.PadRight(20) + CompanyName.PadRight(40) + UnitPrice.PadRight(30).PadLeft(20) + ProductName);

                }
                rdr.Close();
             }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
