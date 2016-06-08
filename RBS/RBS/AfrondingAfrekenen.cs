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
        int tafelId;
        int bestelId;
        string betaalMethode;


        public AfrondingAfrekenen(int bestelIdPara, string betaalMethodePara, int tafelIdPara)
        {
            InitializeComponent();
            bestelId = bestelIdPara;
            betaalMethode = betaalMethodePara;
            tafelId = tafelIdPara;
        }

        private void AfrondingAfrekenen_Load(object sender, EventArgs e)
        {

        }

        private void afrondButton_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

            string commentaar = commentaarBox.Text;
            bestellingDAO.AfrondingBestelling(bestelId, betaalMethode, commentaar);
            this.Close();
        }

        private void terugBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form afrekenen = new Afrekenen(tafelId);
            afrekenen.Show();
        }
    }
}
