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
    public partial class BarScherm : Form
    {
        public BarScherm()
        {
            InitializeComponent();
            BarScherm_load();
        }

        private void BarScherm_load()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

            List<int> tafelid = new List<int>();
            List<string> productennaam = new List<string>();
            List<int> aantal = new List<int>();
            tafelid = bestellingDAO.GetAllTafel();
            productennaam = bestellingDAO.GetAllProducten();
            aantal = bestellingDAO.GetAllAantal();

            ListViewItem lvi = new ListViewItem();

            foreach (int tafelID in tafelid)
            {
                lvi.SubItems.Add(tafelID.ToString());
            }
            foreach (string Productennaam in productennaam)
            {
                lvi.SubItems.Add(productennaam.ToString());
            }
            foreach (int Aantal in aantal)
            {
                lvi.SubItems.Add(Aantal.ToString());
            }

            listView1.Items.Add(lvi);
        }
    }

}
