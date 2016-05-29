using System.Data.SqlClient;
using RBS.Enums;

namespace RBS
{

    /// <summary>
    /// Tafel model
    /// </summary>
    public class Tafel
    {
        public int ID; 
        public TafelStatus Status;

        public Tafel() { }

        public Tafel(SqlDataReader record)
        {
            // Kijk of er iets binnen komt
            if (record == null) return;

            // Zet de waarden in de eigenschappen
            ID = (int) record["id"];
            Status = (TafelStatus) record["status"];
        }
    }
}
