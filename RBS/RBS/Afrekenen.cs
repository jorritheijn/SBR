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
    /// <summary>
    /// Class voor het scherm waar bestellingen worden afgerekend
    /// </summary>
    public partial class Afrekenen : Form
    {
        private BestellingDAO bestellingDao;
        private ProductDAO productDao;

        private int bestelId, tafelId;

        /// <summary>
        /// Het afrekenscherm
        /// </summary>
        public Afrekenen(int tafelId)
        {
            InitializeComponent();

            this.tafelId = tafelId;

            this.bestellingDao = DataHelper.BestellingDao;
            this.productDao = DataHelper.ProductDao;

            bestelId = bestellingDao.GetBestelIdFromTafel(tafelId);

            List<BestelRegel> rekeningRegels = bestellingDao.GetRekening(bestelId);

            decimal totaalPrijs = 0;
            decimal totaalBtw = 0;

            label1.Text = "Tafel " + tafelId;
            listBox3.RightToLeft = RightToLeft.Yes;

            foreach (BestelRegel rekeningRegel in rekeningRegels)
            {
                Product product = productDao.GetProductById(rekeningRegel.ProductId);

                int aantal = rekeningRegel.Aantal;
                decimal prijs = product.Prijs;
                decimal regelPrijs = aantal * prijs;

                listBox1.Items.Add(product.Naam);
                listBox2.Items.Add(aantal.ToString());
                listBox3.Items.Add(regelPrijs.ToString());

                totaalPrijs += regelPrijs;
                decimal btw = Math.Ceiling(product.BerekenBTW * 100) / 100;
                totaalBtw += (btw * aantal);
            }

            // ----- Form changes ----- //
            totaalTxt.Text = "Totaal: " + totaalPrijs;
            btwTxt.Text = "BTW: " + totaalBtw.ToString("0.00");

            listBox1.Height = listBox1.PreferredHeight;
            listBox2.Height = listBox2.PreferredHeight;
            listBox3.Height = listBox3.PreferredHeight;

            //set panel height Listbox + BTW and Totaal labels(50px)
            panel1.Height = listBox1.Height + 50;

            //set max panel Height
            if (panel1.Height > 330)
            {
                panel1.Height = 330;
                //set other padding for labels because of the vertical scrollbar
                totaalTxt.Padding = new Padding(0, 0, 8, 0);
                btwTxt.Padding = new Padding(0, 9, 8, 0);  //9top for space between listbox and label
            }

        }

        private void printBon_Click(object sender, EventArgs e)
        {
            printBon.Enabled = false;
        }

        /// <summary>
        /// Naar het afrondingAfrekenen scherm
        /// </summary>
        /// <remarks>
        /// Wordt opgeroepen door de knoppen Pin, Cash en Creditcard
        /// </remarks>
        private void afronding_Click(object sender, EventArgs e)
        {
            var afronding = sender as Button;
            string betaalMethode = afronding.Name.ToLower();
            Form afrondFrm = new AfrondingAfrekenen(bestelId, betaalMethode, tafelId);
            afrondFrm.Show();
            this.Close();
        }

        /// <summary>
        /// Terug naar het tafel overzicht
        /// </summary>
        private void terugBtn_Click(object sender, EventArgs e)
        {
            Form tafelOverzicht = new TafelOverzicht();
            tafelOverzicht.Show();
            this.Close();
        }
    }
}
