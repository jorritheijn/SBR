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

         public List<Product> Dranken()
        {
             dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT dranken FROM product ORDER BY productId", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> Dranken = new List<Product>();

            while (reader.Read())
            {
                Product product = ReadProduct(reader);
                Dranken.Add(product);
            }

            dbConnection.Close();

            return Dranken;
        }

        

        private Product ReadProduct(SqlDataReader reader)
        {
            int productId = (int)reader["productId"];
            string productNaam = (string)reader["naam"];
            double productPrijs = (double)reader["prijs"];
            int aantalVoorraad = (int)reader["aantalVoorraad"];

            return new Product(productId, productNaam, productPrijs, aantalVoorraad);
        }
        public void VoegtoeProduct(int ProductId, string productNaam, double productPrijs, int aantalVoorraad)
        {
            dbConnection.Open();
            string sql = "INSERT INTO Producten (id, naam, prijs, aantal) " + "VALUES (@id, @naam, @prijs, @aantal)";
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.Parameters.AddWithValue("@id", ProductId);
            command.Parameters.AddWithValue("@naam", productNaam);
            command.Parameters.AddWithValue("@prijs", productPrijs);
            command.Parameters.AddWithValue("@aantal", aantalVoorraad);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }
        public void WijzigProduct(int productId, string productNaam, double productPrijs, int aantalVoorraad)
        {
            dbConnection.Open();
            string sql = String.Format(
                "UPDATE Producten " + "SET naam = @naam, prijs = @prijs, aantal= @aantal" + "WHERE Id={0}", productId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.Parameters.AddWithValue("@naam", productNaam);
            command.Parameters.AddWithValue("@prijs", productPrijs);
            command.Parameters.AddWithValue("@aantal", aantalVoorraad);
            command.ExecuteNonQuery();
        }
        public void VerwijderProduct(int productId, string productNaam, double ProductPrijs, int aantalVoorraad)
        {
            dbConnection.Open();
            string sql = String.Format("DELETE FROM Producten WHERE ID={0}", productId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
    }
}


    

