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
    /// Class voor het scherm waar afrekenen wordt afgerond
    /// </summary>
    public partial class AfrondingAfrekenen : Form
    {
        private BestellingDAO bestellingDao;

        private int tafelId, bestelId;
        private string betaalMethode;

        /// <summary>
        /// Het afronding afrekenscherm
        /// </summary>
        public AfrondingAfrekenen(int bestelId, string betaalMethode, int tafelId)
        {
            InitializeComponent();

            this.bestelId = bestelId;
            this.betaalMethode = betaalMethode;
            this.tafelId = tafelId;
        }

        /// <summary>
        /// De bestelling wordt afgerond en geupdate in de database
        /// </summary>
        private void afrondButton_Click(object sender, EventArgs e)
        {
            this.bestellingDao = DataHelper.BestellingDao;

            string commentaar = commentaarBox.Text;
            bestellingDao.AfrondingBestelling(bestelId, betaalMethode, commentaar);
     
            Form tafelOverzicht = new TafelOverzicht();
            tafelOverzicht.Show();
            this.Close();
        }

        private void terugBtn_Click(object sender, EventArgs e)
        {    
            Form afrekenen = new Afrekenen(tafelId);
            afrekenen.Show();
            this.Close();
        }
    }
}
