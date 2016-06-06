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

        public void VerwerkBestelling(List<BestelRegel> items)
        {
            dbConnection.Open();

            foreach (BestelRegel br in items)
            {
                string query = String.Format("INSERT INTO bestelRegels (bestelId, productId, aantal, comment, productstatus) " +
                    "VALUES ({0},{1},{2},@comment,{3})", br.BestelId, br.ProductId, br.Aantal, br.Status);
                SqlCommand command = new SqlCommand(query, dbConnection);
                command.Parameters.AddWithValue("@comment", br.Comment);
                command.ExecuteNonQuery();

                query = String.Format("UPDATE producten " +
                    "SET aantalVoorraad=aantalVoorraad-{0} " +
                    "WHERE productId={1}", br.Aantal, br.ProductId);
                command = new SqlCommand(query, dbConnection);
                command.ExecuteNonQuery();
            }

            dbConnection.Close();
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
            int id = (int)reader["productId"];
            string naam = (string)reader["productNaam"];
            decimal prijs = (decimal)reader["prijs"];
            int aantalVoorraad = (int)reader["aantalVoorraad"];
            int subCategorieId = (int)reader["subCategorieId"];

            return new Product(id, naam, prijs, aantalVoorraad, subCategorieId);
        }
    }
}
    

