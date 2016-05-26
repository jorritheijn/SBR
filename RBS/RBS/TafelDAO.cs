using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace RBS
{
    public class TafelDAO
    {
        protected SqlConnection dbConnection;

        public TafelDAO(SqlConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public List <Tafel> GetAll()
        {
            //opent connectie
            dbConnection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM TAFEL", dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            //sluit de connectie
            dbConnection.Close();
        }
    }
}
