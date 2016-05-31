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
    public partial class Afrekenen : Form
    {
        public Afrekenen()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

            List<BestelRegel> rekeningRegels = bestellingDAO.GetRekening(1);
            decimal totaalPrijs = 0;
            foreach (var rekeningRegel in rekeningRegels)
            {
                label1.Text = "Tafel " + rekeningRegel.TafelId.ToString();
                listBox1.Items.Add(rekeningRegel.Product);
                listBox2.Items.Add(rekeningRegel.Aantal.ToString());
                listBox3.Items.Add(rekeningRegel.TotaalPrijs.ToString());
                totaalPrijs += rekeningRegel.TotaalPrijs;
            }
            label5.Text = "Totaal: " + totaalPrijs;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
