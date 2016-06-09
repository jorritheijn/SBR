using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RBS
{
    public class PersoneelDAO
    {
        protected SqlConnection dbConnection;

        public static int personeelId = 0;

        public PersoneelDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public List<Personeel> GetAll()
        {
            dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM personeel", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<Personeel> allePersoneel = new List<Personeel>();

            while (reader.Read())
            {
                Personeel personeel = ReadPersoneel(reader);
                allePersoneel.Add(personeel);
            }

            dbConnection.Close();

            return allePersoneel;
        }

        public Personeel GetByPincode(string pincode)
        {
            dbConnection.Open();

            var command = new SqlCommand("SELECT * FROM personeel WHERE pincode=@pincode", dbConnection);
            command.Parameters.AddWithValue("@pincode", pincode);

            var reader = command.ExecuteReader();

            Personeel werknemer = null;
            while (reader.Read())
            {
                // Creeer een nieuw werknemer model
                werknemer = ReadPersoneel(reader);
            }

            //Tijdelijk voor de presentatie n shit
            try
            {
                personeelId = werknemer.Id;
            }
            catch
            {
                personeelId = 1;
            }

            //sluit de connectie
            dbConnection.Close();

                return werknemer;
            }

        public void AddEmployee(string username, string pincode, string functie)
        {
            dbConnection.Open();

            string query = "INSERT INTO personeel (username, pincode, functie) " +
                "VALUES (@username,@pincode,@functie)";

            SqlCommand command = new SqlCommand(query, dbConnection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@pincode", pincode);
            command.Parameters.AddWithValue("@functie", functie);

            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        public void DeleteEmployee(int id)
        {
            dbConnection.Open();

            string query = String.Format("DELETE FROM personeel WHERE personeelId={0}", id);

            SqlCommand command = new SqlCommand(query, dbConnection);

            command.ExecuteNonQuery();

            dbConnection.Close();
        }

        private Personeel ReadPersoneel(SqlDataReader reader)
        {
            int id = (int)reader["personeelId"];
            string username = (string)reader["username"];
            string pincode = (string)reader["pincode"];
            string functie = (string)reader["functie"];

            return new Personeel(id, username, pincode, functie);
        }
    }
}
