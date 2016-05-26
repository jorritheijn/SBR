using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RBS
{
    class PersoneelDAO
    {
        protected SqlConnection dbConnection;

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

            while(reader.Read())
            {
                Personeel personeel = ReadPersoneel(reader);
                allePersoneel.Add(personeel);
            }

            dbConnection.Close();

            return allePersoneel;
        }

        private Personeel ReadPersoneel(SqlDataReader reader)
        {
            int id = (int)reader["id"];
            string username = (string)reader["username"];
            int pincode = (int)reader["pincode"];
            string functie = (string)reader["functie"];

            return new Personeel(id, username, pincode, functie);
        }
    }
}
