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

        public List<BestelRegel> GetRekening(int bestelId)
        {
            dbConnection.Open();

            string sql = string.Format(
                "SELECT * FROM bestellingen " +
                    "INNER JOIN bestelRegels ON bestellingen.bestelId = bestelRegels.bestelId " +
                    "INNER JOIN producten ON bestelRegels.productId = producten.productId WHERE bestelRegels.bestelId={0} AND bestelStatus=1", bestelId);

            System.Diagnostics.Debug.WriteLine("cooldduud" + bestelId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<BestelRegel> rekeningRegels = new List<BestelRegel>();

            while (reader.Read())
            {
                //System.Diagnostics.Debug.WriteLine((int)reader["tafelId"]);
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
                "SELECT * FROM bestellingen " + //producten.id as product_id, bestellingen.id as bestellingen_id, bestelRegels.id as bestelregels_id, aantal, bestelId, comment, productStatus, persooneelId, tafelId, productNaam, subCategorieId FROM bestelRegels " +
                    "INNER JOIN bestelRegels ON bestellingen.bestelId = bestelRegels.bestelId " +
                    "INNER JOIN producten ON producten.productId = bestelRegels.productId " +
                    "WHERE bestelRegels.productStatus = {0} ", status);
            if (afdeling != 3) {
                sql = sql + " AND subCategorieId!=3";
            }
            else
            {
                sql = sql + " AND subCategorieId=3";
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

        public void MarkeerBestelRegel(int bestelregelid)
        {
            
            dbConnection.Open();
            string sql = string.Format(
            "UPDATE bestelRegels SET productStatus = 2 WHERE  regelId = {0}", bestelregelid);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

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
        /// Checkt voor een open bestelId voor de tafel, als deze er niet is wordt er een nieuwe gemaakt
        /// </summary>
        /// <param name="tafelId">ID van de tafel</param>
        /// <returns>Een bestelId</returns>
        //public int GetBestelId(int tafelId)
        //{
        //    dbConnection.Open();

        //    string sql = string.Format("SELECT TOP 1 bestelId,bestelStatus FROM bestellingen WHERE tafelId={0} ORDER BY opnameTijd DESC", tafelId);

        //    SqlCommand command = new SqlCommand(sql, dbConnection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    int bestelId = 0, bestelStatus = 1;

        //    while (reader.Read())
        //    {
        //        bestelId = (int)reader["bestelId"];
        //        bestelStatus = (int)reader["bestelStatus"];
        //    }
        //    dbConnection.Close();

        //    if (bestelStatus == 1) { return bestelId; }
        //    else return GenerateNewBestelId();
        //}

        /// <summary>
        /// Genereert een nieuw, uniek bestelId
        /// </summary>
        /// <returns>Nieuw bestelId</returns>
        //public int GenerateNewBestelId()
        //{
        //    dbConnection.Open();

        //    string sql = string.Format("SELECT TOP 1 bestelId FROM bestellingen ORDER BY bestelId DESC");

        //    SqlCommand command = new SqlCommand(sql, dbConnection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    int bestelId = 0;

        //    while (reader.Read())
        //    {
        //        bestelId = (int)reader["bestelId"];
        //    }

        //    bestelId++;

        //    dbConnection.Close();

        //    return bestelId;
        //}

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

        /*public List<Bestelling> GetAll(string status)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT * FROM bestellingen WHERE status='{0}' ORDER by tafelId", status);
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

            string sql = string.Format(
                "SELECT * FROM bestellingen " +
                    "INNER JOIN bestelRegels ON bestellingen.id = bestelRegels.bestelId " +
                    "INNER JOIN producten ON bestelRegels.productId = producten.id WHERE bestelId={0}", bestelId);

            System.Diagnostics.Debug.WriteLine("cooldduud" + bestelId);
            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<BestelRegel> rekeningRegels = new List<BestelRegel>();

            while (reader.Read())
            {
                //System.Diagnostics.Debug.WriteLine((int)reader["tafelId"]);
                BestelRegel bestelRegel = ReadBestelRegel(reader);
                rekeningRegels.Add(bestelRegel);
            }
            dbConnection.Close();

            return rekeningRegels;
        }
        public int GetBestelIdFromTafel(int tafelId)
        {
            dbConnection.Open();

            string sql = string.Format("SELECT TOP 1 id FROM bestellingen WHERE tafelId={0} ORDER BY opnameTijd DESC", tafelId);

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            int bestelId = 0;
            while (reader.Read())
            {
                bestelId = (int)reader["id"];
            }

            dbConnection.Close();

            return bestelId;
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


        public List<Tafel> GetAllTafel()
        {
            dbConnection.Open();

            string sql = string.Format(
                    "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<int> tafelid = new List<int>();
            while (reader.Read())
            {
                int tafelID = (int)reader["tafelId"];
                tafelid.Add(tafelID);
            }
            dbConnection.Close();

            return tafelid;
        }
        public List<string> GetAllProducten()
        {
            dbConnection.Open();

            string sql = string.Format(
                     "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string> productennaam = new List<string>();

            while (reader.Read())
            {
                string Productennaam = (string)reader["naam"];

                productennaam.Add(Productennaam);
            }

            dbConnection.Close();

            return productennaam;
        }
        public List<string> GetAllComment()
        {
            dbConnection.Open();

            string sql = string.Format(
                     "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string> comment = new List<string>();

            while (reader.Read())
            {
                string comments;
                try { comments = (string)reader["comment"]; }
                catch { comments = ""; }

                comment.Add(comments);
            }

            dbConnection.Close();

            return comment;
        }
        public List<int> GetAllAantal()
        {
            dbConnection.Open();

            string sql = string.Format(
                     "SELECT tafelId, naam, comment, aantal FROM bestellingen " +
                        "INNER JOIN bestelRegels on bestellingen.id = bestelRegels.bestelId " +
                        "INNER JOIN producten on productId = producten.id " +
                        "ORDER BY tafelId");

            SqlCommand command = new SqlCommand(sql, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<int> aantal = new List<int>();

            while (reader.Read())
            {
                int Aantal = (int)reader["aantal"];

                aantal.Add(Aantal);
            }

            dbConnection.Close();

            return aantal;
        }*/
    }
}
