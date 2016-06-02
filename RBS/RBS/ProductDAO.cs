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

        // niet nodig???? altijd per categorie verdeelt volgens mij, ivbm met bar/keuken
        /*public List<Product> GetAll()
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
        }*/

        public List<Product> GetAllByCategorie(int categorie)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM producten " +
                "INNER JOIN subCategorieen ON oducten.prsubCategorieId = subCategorieen.id " +
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
        //getLunch en getDiner is één methode met een categorie parameter
        public List<Product> GetLunch()
        {
            dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM producten " +
                "WHERE subCategorieID=1 OR subCategorieID=2 OR subCategorieID=3", dbConnection);

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

        public List<Product> GetDiner()
        {
            dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM producten " +
                "INNER JOIN subCategorieen ON producten.subCategorieId=subCategorieen.id " +
                "INNER JOIN categorieen ON subCategorieen.categorieId=categorieen.id " +
                "WHERE categorieen.id=2", dbConnection);

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
            int id = (int)reader["id"];
            string naam = (string)reader["productNaam"];
            decimal prijs = (decimal)reader["prijs"];
            int aantalVoorraad = (int)reader["aantalVoorraad"];
            int subCategorieId = (int)reader["subCategorieId"];

            return new Product(id, naam, prijs, aantalVoorraad, subCategorieId);
        }
    }
}
    

