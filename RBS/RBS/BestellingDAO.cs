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
        private List<Bestelling> bestellingen;

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
                totaalPrijs = aantal * prijs;
            }
            conn.Close();
        }

    }
}
