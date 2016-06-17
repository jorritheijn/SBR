using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using RBS.Enums;

namespace RBS
{
    /// <summary>
    /// Class dient als link tussen de databasetabellen 'bestellingen', 'bestelRegels' en de applicatie
    /// </summary>
    public class BestellingDAO
    {
        private SqlConnection dbConnection;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbConnection">Bevat de informatie om met de database te kunnen verbinden</param>
        public BestellingDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        /// <summary>
        /// Verkrijg alle rekening regels van één bestelling
        /// </summary>
        /// <param name="bestelId"></param>
        /// <returns></returns>
        public List<BestelRegel> GetRekening(int bestelId)
        {
            string sql = string.Format(
                "SELECT * FROM bestellingen " +
                    "INNER JOIN bestelRegels ON bestellingen.bestelId = bestelRegels.bestelId " +
                    "INNER JOIN producten ON bestelRegels.productId = producten.productId WHERE bestelRegels.bestelId={0} AND bestelStatus=1", bestelId);

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            dbConnection.Open();

            List<BestelRegel> rekeningRegels = new List<BestelRegel>();

            while (reader.Read())
            {
                BestelRegel bestelRegel = ReadBestelRegel(reader);
                rekeningRegels.Add(bestelRegel);
            }
            dbConnection.Close();

            return rekeningRegels;
        }

        public List<BestelRegel> GetAllByStatus(int status, int afdeling)
        {
            dbConnection.Open();

            string sql = string.Format(
                "SELECT * FROM bestellingen " + 
                    "INNER JOIN bestelRegels ON bestellingen.bestelId = bestelRegels.bestelId " +
                    "INNER JOIN producten ON producten.productId = bestelRegels.productId " +
                    "WHERE bestelRegels.productStatus = {0} ", status);
            if (afdeling == 1)
            {
                sql = sql + " AND SubcategorieId<8 ";
            }
            else
            {
                sql = sql + " AND SubcategorieId>8 ";
            }
            sql = sql + " ORDER BY tafelId";
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<BestelRegel> alleBestellingen = new List<BestelRegel>();

            while (reader.Read())
            {
                BestelRegel bestelling = ReadBestelRegel(reader);
                alleBestellingen.Add(bestelling);
            }

            dbConnection.Close();

            return alleBestellingen;
        }

        /// <summary>
        /// Lees alle niet gesloten bestellingen van de database.
        /// </summary>
        /// <returns>De niet gesloten bestellingen</returns>
        public List<Bestelling> GetAllNonClosedBestellingen()
        {
            //opent connectie
            dbConnection.Open();

            // Lees de data uit de database
            SqlCommand command = new SqlCommand("SELECT * FROM bestellingen WHERE bestelStatus!=@status ORDER BY bestelStatus ASC", dbConnection);
            command.Parameters.AddWithValue("@status", BestelStatus.Uitgeserveerd);

            SqlDataReader reader = command.ExecuteReader();

            var alleBestellingen = new List<Bestelling>();
            while (reader.Read())
            {
                // Creeer een nieuw tafel model
                var bestelling = ReadBestelling(reader);
                alleBestellingen.Add(bestelling);
            }

            //sluit de connectie
            dbConnection.Close();

            return alleBestellingen;
        }

        public void UpdateTafelBestellingen(int tafelId, BestelStatus status)
        {
            //opent connectie
            dbConnection.Open();

            // Lees de data uit de database
            SqlCommand command = new SqlCommand("UPDATE bestellingen SET bestelStatus = @status WHERE tafelId=@tafelId", dbConnection);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@tafelId", tafelId);
            command.ExecuteNonQuery();
            
            //sluit de connectie
            dbConnection.Close();
        }

        /// <summary>
        /// Update de bestelling naar betaald
        /// </summary>
        public void AfrondingBestelling(int bestelId, string betaalMethode, string commentaar)
        {
            dbConnection.Open();
            string sql = String.Format(
                "UPDATE bestellingen SET bestelStatus = @status, betaalMethode = @betaalMethode, bestelComment = @commentaar WHERE bestelId={0}", bestelId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.Parameters.AddWithValue("@status", 2);
            command.Parameters.AddWithValue("@betaalMethode", betaalMethode);
            command.Parameters.AddWithValue("@commentaar", commentaar);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        /// <summary>
        /// Leest één record uit de tabel 'bestelRegels'
        /// </summary>
        /// <param name="reader">De reader waaruit gelezen wordt</param>
        /// <returns>Een object van het type bestelRegel</returns>
        private BestelRegel ReadBestelRegel(SqlDataReader reader)
        {
            int productId = (int)reader["productId"];
            int aantal = (int)reader["aantal"];
            int bestelId = (int)reader["bestelId"];
            int tafelId = (int)reader["tafelId"];
            string comment = "";
            if (reader["comment"] != DBNull.Value) comment= (string)reader["comment"];
            int status = (int)reader["productStatus"];
            int BestelRegelId = (int)reader["RegelId"];

            return new BestelRegel(tafelId, productId, aantal, bestelId, comment, status, BestelRegelId);
        }

        public void MarkeerBestelRegel(int bestelregelid, int status)
        {
            if (status == 2)
            {
                status = 1;
            }
            else if (status == 1)
            {
                status = 2;
            }
            dbConnection.Open();
            string sql = string.Format(
            "UPDATE bestelRegels SET productStatus = {1} WHERE  regelId = {0}", bestelregelid, status);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        /// <summary>
        /// Geeft de huidige bestel id van de tafel op
        /// </summary>
        public int GetBestelIdFromTafel(int tafelId)
        {
            dbConnection.Open();
            
            string sql = string.Format("SELECT TOP 1 bestelId FROM bestellingen WHERE tafelId={0} ORDER BY opnameTijd DESC", tafelId);

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            int bestelId = 0;
            while (reader.Read())
            {
                bestelId = (int)reader["bestelId"];
            }

            dbConnection.Close();

            return bestelId;
        }

        /// <summary>
        /// Controlleert voor een openstaande bestelling voor een gegeven tafel
        /// </summary>
        /// <param name="tafelId">Het ID van de tafel die gecontrolleerd wordt</param>
        /// <returns>
        /// True=Er is een openstaande bestelling
        /// False=Er is geen openstaande bestelling</returns>
        public bool OpenstaandeBestelling(int tafelId)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT TOP 1 bestelId,bestelStatus FROM bestellingen WHERE tafelId={0} ORDER BY opnameTijd DESC", tafelId);

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            int bestelId, bestelStatus = 2;

            while (reader.Read())
            {
                bestelId = (int)reader["bestelId"];
                bestelStatus = (int)reader["bestelStatus"];
            }

            dbConnection.Close();

            if (bestelStatus == 1) { return true; }
            else return false;
        }

        /// <summary>
        /// Voeg nieuwe bestelling toe aan database tabel bestellingen
        /// </summary>
        /// <param name="personeelId">ID van 't personeelslid</param>
        /// <param name="tafelId">ID van de tafel</param>
        public void CreateNewBestelling(int personeelId, int tafelId)
        {
            dbConnection.Open();

            string query = String.Format("INSERT INTO bestellingen (persooneelId, tafelId, opnameTijd, bestelStatus) " +
                "VALUES ({0},{1},GETDATE(),1)", personeelId, tafelId);

            SqlCommand command = new SqlCommand(query, dbConnection);

            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        private Bestelling ReadBestelling(SqlDataReader reader)
        {
            int id = (int)reader["bestelId"];
            int personeelId = (int)reader["persooneelId"];
            int tafelId = (int)reader["tafelId"];
            DateTime opnameTijd = (DateTime)reader["opnameTijd"];
            BestelStatus status = (BestelStatus)reader["bestelStatus"];

            string betaalMethode = String.Empty;
            if (!(reader["betaalMethode"] is DBNull))
            {
                betaalMethode = (string)reader["betaalMethode"];
            }

            return new Bestelling(id, personeelId, tafelId, betaalMethode, opnameTijd, status);
        }
    }
}
