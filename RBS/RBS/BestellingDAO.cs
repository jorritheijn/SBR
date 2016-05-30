using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace RBS
{
    public class BestellingDAO
    {

        protected SqlConnection dbConnection;

        public BestellingDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public List<Bestelling> GetAllBesteld()
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM bestellingen WHERE status='besteld' ORDER by tafelId");
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Bestelling> alleBestellingen = new List<Bestelling>();

            while (reader.Read())
            {
                Bestelling bestelling = ReadBestelling(reader);
                alleBestellingen.Add(bestelling);
            }

            dbConnection.Close();

            return alleBestellingen;
        }
        public List<Bestelling> GetAllGereed()
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM bestellingen WHERE status='gereed' ORDER by tafelId");
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Bestelling> alleBestellingen = new List<Bestelling>();

            while (reader.Read())
            {
                Bestelling bestelling = ReadBestelling(reader);
                alleBestellingen.Add(bestelling);
            }

            dbConnection.Close();

            return alleBestellingen;
        }

        public List<Bestelling> GetAllGereserveerd()
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM bestellingen WHERE status='gereserveerd' ORDER by tafelId");
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Bestelling> alleBestellingen = new List<Bestelling>();

            while (reader.Read())
            {
                Bestelling bestelling = ReadBestelling(reader);
                alleBestellingen.Add(bestelling);
            }

            dbConnection.Close();

            return alleBestellingen;
        }

        //voor bestell-regel class.
        /*private void GetRekening(int bestelId)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM rekeningen INNER JOIN producten ON rekeningen.productId = producten.id WHERE bestelId={0}", bestelId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                product = (string)reader["producten.naam"];
                aantal = (int)reader["rekeningen.aantal"];
                prijs = (double)reader["rekeningen.prijs"]; 
            }
            dbConnection.Close();
        }*/

        private Bestelling ReadBestelling(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            int personeelId = (int)reader["personeelId"];
            int tafelId = (int)reader["tafelId"];
            int betaalMethode = (int)reader["betaalMethode"];
            DateTime opnameTijd = (DateTime)reader["opnameTijd"];
            string status = (string)reader["status"];

            return new Bestelling(id, personeelId, tafelId, betaalMethode, opnameTijd, status);
        }
    }
}
