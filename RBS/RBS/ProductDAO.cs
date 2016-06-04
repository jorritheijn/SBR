using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RBS
{
    public class ProductDAO
    {
        protected SqlConnection dbConnection;

        public ProductDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public Product GetProductById(int productId)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT TOP 1 * FROM producten WHERE productId={0}", productId);
            SqlCommand command = new SqlCommand(sql, dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            Product product = new Product();

            while (reader.Read())
            {

                product = ReadProduct(reader);
            }

            dbConnection.Close();

            return product;
        }
        public List<Product> GetAllByCategorie(int categorie)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM producten " +
                "INNER JOIN subCategorieen ON producten.subCategorieId = subCategorieen.subCategorieId " +
                "WHERE categorieId={0}", categorie);
            SqlCommand command = new SqlCommand(sql, dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> producten = new List<Product>();

            while (reader.Read())
            {
                Product product = ReadProduct(reader);
                producten.Add(product);
            }

            dbConnection.Close();

            return producten;
        }

        public List<Product> GetAllBySubCategorie(int subCategorie)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM producten WHERE subCategorieId={0}", subCategorie);
            SqlCommand command = new SqlCommand(sql, dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> producten = new List<Product>();

            while (reader.Read())
            {
                Product product = ReadProduct(reader);
                producten.Add(product);
            }

            dbConnection.Close();

            return producten;
        }

        public List<Product> GetFrisdrank()
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM producten WHERE subCategorieId=8", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> fris = new List<Product>();

            while(reader.Read())
            {
                Product p = ReadProduct(reader);
                fris.Add(p);
            }

            dbConnection.Close();

            return fris;
        }

        public List<Product> GetAlcoholhoudend()
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM producten " +
                "WHERE subCategorieId=9 OR subCategorieId=10 OR subCategorieId=11", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> alcohol = new List<Product>();

            while (reader.Read())
            {
                Product p = ReadProduct(reader);
                alcohol.Add(p);
            }

            dbConnection.Close();

            return alcohol;
        }

        public List<Product> GetWarmeDranken()
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM producten WHERE subCategorieId=12", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Product> dranken = new List<Product>();

            while (reader.Read())
            {
                Product p = ReadProduct(reader);
                dranken.Add(p);
            }

            dbConnection.Close();

            return dranken;
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
            dbConnection.Close();
        }

        public void VerwijderProduct(int productId, string productNaam, double ProductPrijs, int aantalVoorraad)
        {
            dbConnection.Open();
            string sql = String.Format("DELETE FROM Producten WHERE ID={0}", productId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }


        private Product ReadProduct(SqlDataReader reader)
        {
            //int id = (int)reader["productId"];
            int id = 1;
            string naam = (string)reader["productNaam"];
            decimal prijs = (decimal)reader["prijs"];
            int aantalVoorraad = (int)reader["aantalVoorraad"];
            int subCategorieId = (int)reader["subCategorieId"];

            return new Product(id, naam, prijs, aantalVoorraad, subCategorieId);
        }
    }
}
    

