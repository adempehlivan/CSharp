using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetDemo
{
    public class ProductDal
    {
        public DataTable GetAll2()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security=true");
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand("Select * from Products", connection);

            SqlDataReader reader = command.ExecuteReader();

            dataTable.Load(reader);
            reader.Close();
            connection.Close();
            return dataTable;
        }

        public List<Product> GetAll()
        {
            //doldurmak istediğimiz nesneyi 1 kere list olarak oluşturururz.
            List<Product> products = new List<Product>();

            SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security=true");
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            SqlCommand command = new SqlCommand("Select * from Products", connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                //her seferinde yeni kayıt eklenceği için yeni product nesnesi oluşturuyoruz
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    StockAmount = Convert.ToInt32(reader["StockAmount"]),
                    UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
                };
                products.Add(product);
 
            }
            reader.Close();
            connection.Close();
            return products;
        }

        public void Add(Product product)
        {
            SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=ETrade;integrated security=true");
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
    }
}
