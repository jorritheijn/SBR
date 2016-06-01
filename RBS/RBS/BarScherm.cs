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
            listView1.View = View.Details;

            List<int> tafelid = new List<int>();
            List<string> productennaam = new List<string>();
            List<int> aantal = new List<int>();
            tafelid = bestellingDAO.GetAllTafel();
            productennaam = bestellingDAO.GetAllProducten();
            aantal = bestellingDAO.GetAllAantal();

            ListViewItem tafel = new ListViewItem("Tafels");
            foreach (int tafelID in tafelid)
            {
                tafel.SubItems.Add(tafelID.ToString());
            }
            ListViewItem product = new ListViewItem("Product");
            foreach (string Productennaam in productennaam)
            {
                product.SubItems.Add(Productennaam);        
            }
            ListViewItem aaantal = new ListViewItem("Aantal");
            foreach (int Aantal in aantal)
            {
                aaantal.SubItems.Add(Aantal.ToString());
            }

            listView1.Items.AddRange(new ListViewItem[] { tafel, product, aaantal });

        }
    }

}
