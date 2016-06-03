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

        public Afrekenen(int tafelId)
        {
            InitializeComponent();

            this.bestellingDao = DataHelper.BestellingDao;
            this.productDao = DataHelper.ProductDao;
 

            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            ProductDAO productdao = new ProductDAO(dbConnection);

            int bestelId = bestellingDAO.GetBestelIdFromTafel(tafelId);
            List<BestelRegel> rekeningRegels = bestellingDAO.GetRekening(bestelId);
            decimal totaalPrijs = 0;
            int regels = 0;

            foreach (var rekeningRegel in rekeningRegels)
            {
                //form items toevoegen

                /*product = productdao.GetProductById(rekeningRegel.ProductId);
                label1.Text = "Tafel " + rekeningRegel.TafelId.ToString();

                listBox1.Items.Add(rekeningRegel.Product);
                listBox2.Items.Add(rekeningRegel.Aantal.ToString());
                listBox3.Items.Add(rekeningRegel.TotaalPrijs.ToString());
                totaalPrijs += rekeningRegel.TotaalPrijs;
                regels++;*/
            }

            //Form aanpassen op hoogte van de lijst
            label5.Text = "Totaal: " + totaalPrijs;
            int y = 63 + (regels * 13);                    //één regel is 13 pixels, basis plaats is 63pixels
            label5.Location = new Point(203, y);
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
