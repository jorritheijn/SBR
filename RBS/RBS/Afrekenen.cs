using RBS.Helpers;
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
        private BestellingDAO bestellingDao;
        private ProductDAO productDao;

        int bestelId;

        public Afrekenen(int tafelId)
        {
            InitializeComponent();

            this.bestellingDao = DataHelper.BestellingDao;
            this.productDao = DataHelper.ProductDao;

            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            ProductDAO productdao = new ProductDAO(dbConnection);

            bestelId = bestellingDAO.GetBestelIdFromTafel(tafelId);

            List<BestelRegel> rekeningRegels = bestellingDAO.GetRekening(bestelId);

            decimal totaalPrijs = 0;
            decimal totaalBtw = 0;
            int regels = 0;

            label1.Text = "Tafel " + tafelId;
            listBox3.RightToLeft = RightToLeft.Yes;

            foreach (BestelRegel rekeningRegel in rekeningRegels)
            {
                Product product = productdao.GetProductById(rekeningRegel.ProductId);

                int aantal = rekeningRegel.Aantal;
                decimal prijs = product.Prijs;
                decimal regelPrijs = aantal * prijs;

                listBox1.Items.Add(product.Naam);
                listBox2.Items.Add(aantal.ToString());
                listBox3.Items.Add(regelPrijs.ToString());

                totaalPrijs += regelPrijs;
                decimal btw = Math.Ceiling(product.BerekenBTW * 100) / 100;
                totaalBtw += (btw * aantal);
                regels++;
            }

            //Form aanpassen op hoogte van de lijst
            label5.Text = "Totaal: " + totaalPrijs;
            label6.Text = "BTW: " + totaalBtw;
            int y = regels * 13;                    //één regel is 13 pixels, basis plaats is 63pixels
            label5.Location = new Point(208, (85 + y));
            label6.Location = new Point(208, (70 + y));
            listBox1.Height = listBox1.PreferredHeight;
            listBox2.Height = listBox2.PreferredHeight;
            listBox3.Height = listBox3.PreferredHeight;
        }

        private void printBon_Click(object sender, EventArgs e)
        {
            printBon.Enabled = false;
            pin.Enabled = true;
            cash.Enabled = true;
            creditcard.Enabled = true;
        }

        private void afronding_Click(object sender, EventArgs e)
        {

            var afronding = sender as Button;
            string naam = afronding.Name.ToLower();
            var afronden = new AfrondingAfrekenen(bestelId, naam);
            afronden.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
