using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace RBS
{
    class TafelDAO
    {
        bool status;

        private void LeesTafel(int tafelId)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["ReserveringsConnectionStringSQL"]
                .ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();


        }
    }
}
