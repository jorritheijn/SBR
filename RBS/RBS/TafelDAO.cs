using RBS.Enums;
using RBS.Helpers;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RBS
{
    public class TafelDAO
    {
        protected SqlConnection dbConnection {
            get
            {
                return DataHelper.Connection;
            }
        }

        /// <summary>
        /// Vraagt alle tafel resultaten op vanuit de database.
        /// </summary>
        /// <returns>Lijst met tafels</returns>
        public List<Tafel> GetAll()
        {
            //opent connectie
            dbConnection.Open();

            // Lees de data uit de database
            SqlCommand command = new SqlCommand("SELECT * FROM tafels", dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            var tafels = new List<Tafel>();

            while (reader.Read())
            {
                // Creeer een nieuw tafel model
                var tafel = new Tafel(reader);

                // Voeg de tafel aan de lijst toe
                tafels.Add(tafel);
            }

            //sluit de connectie
            dbConnection.Close();

            return tafels;
        }

        public Tafel GetTafel(int ID)
        {
            //opent connectie
            dbConnection.Open();

            // Lees de data uit de database
            SqlCommand command = new SqlCommand("SELECT * FROM tafels WHERE id=@id", dbConnection);
            command.Parameters.AddWithValue("@id", ID);

            SqlDataReader reader = command.ExecuteReader();

            Tafel tafel = null;
            while (reader.Read())
            {
                // Creeer een nieuw tafel model
                tafel = new Tafel(reader);
            }

            //sluit de connectie
            dbConnection.Close();

            return tafel;
        }

        public void UpdateTafel(int ID, TafelStatus status)
        {
            //opent connectie
            dbConnection.Open();

            // Lees de data uit de database
            SqlCommand command = new SqlCommand("UPDATE tafels SET status=@status WHERE id=@id", dbConnection);
            command.Parameters.AddWithValue("@id", ID);
            command.Parameters.AddWithValue("@status", status);

            SqlDataReader reader = command.ExecuteReader();

            dbConnection.Close();
        }
    }
}
