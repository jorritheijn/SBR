using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RBS
{
    class ProductDAO
    {
        protected SqlConnection dbConnection;

        public ProductDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public List<Product> GetAll()
        {
            dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM product", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> alleProduct = new List<Product>();

            while (reader.Read())
            {
                Product product = ReadProduct(reader);
                alleProduct.Add(product);
            }

            dbConnection.Close();

            return alleProduct;
        }

        public List<Product> GetLunch()
        {
            dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM product WHERE subCategorieID=1", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> lunch = new List<Product>();

            while (reader.Read())
            {
                Product p = ReadProduct(reader);
                lunch.Add(p);
            }

            dbConnection.Close();

            return lunch;
        }

        private Product ReadProduct(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            string naam = (string)reader["naam"];
            double prijs = (double)reader["prijs"];
            int aantalVoorraad = (int)reader["aantalVoorraad"];

            return new Product(id, naam, prijs, aantalVoorraad);
        }
    }
}
    

