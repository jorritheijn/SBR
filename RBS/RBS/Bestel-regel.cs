using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace RBS
{
    class Rekening
    {
        string product;
        int aantal;
        double prijs;
        double totaalPrijs;

        private void LeesRekening(int bestelId)
        {
            string connString = ConfigurationManager
                .ConnectionStrings["ReserveringsConnectionStringSQL"]
                .ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            string sql = string.Format("SELECT * FROM rekeningen INNER JOIN producten ON rekeningen.productId = producten.id WHERE bestelId={0}", bestelId);
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                product = (string)reader["producten.naam"];
                aantal = (int)reader["rekeningen.aantal"];
                prijs = (double)reader["rekeningen.prijs"];
            }
            conn.Close();
        }
    }
}
