using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace RBS
{
    public partial class AfrondingAfrekenen : Form
    {
        private BestellingDAO bestellingDao;

        public AfrondingAfrekenen(int bestelId, string betaalMethode)
        {
            InitializeComponent();
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

            bestellingDAO.AfrondingBestelling(bestelId, betaalMethode);

        }

        private void AfrondingAfrekenen_Load(object sender, EventArgs e)
        {

        }
    }
}
