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
        public List<BestelRegel> GetRekening(int bestelId)
        {
            dbConnection.Open();

            string sql2 = string.Format("SELECT * FROM rekeningen INNER JOIN producten ON rekeningen.productId = producten.id WHERE bestelId={0}", bestelId);
            string sql = string.Format(
                "SELECT * FROM bestellingen" +
                    "INNER JOIN bestelRegels ON bestellingen.id = bestelRegels.bestelId" +
                    "INNER JOIN producten ON bestelRegels.productId = producten.id WHERE bestelId={0}"
            , bestelId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<BestelRegel> rekeningRegels = new List<BestelRegel>();

            while (reader.Read())
            {
                BestelRegel bestelRegel = ReadBestelRegel(reader);
                rekeningRegels.Add(bestelRegel);
            }
            dbConnection.Close();

            return rekeningRegels;
        }

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

        private BestelRegel ReadBestelRegel(SqlDataReader reader)
        {
            int tafelId = (int)reader["bestellingen.tafelId"];
            string product = (string)reader["producten.naam"];
            int aantal = (int)reader["bestelRegels.aantal"];
            int prijs = (int)reader["producten.prijs"];
            int totaalPrijs = prijs * aantal;

            return new BestelRegel(tafelId, product, aantal, totaalPrijs);
        }
    }
}
