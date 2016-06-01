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

            List<string> tafelid = new List<string>();
            List<string> productennaam = new List<string>();
            List<string> aantal = new List<string>();
            tafelid = bestellingDAO.GetAllTafel();
            productennaam = bestellingDAO.GetAllProducten();
            aantal = bestellingDAO.GetAllAantal();

            foreach (string tafelID in tafelid)
            {
                ListViewItem lvi = new ListViewItem(tafelID.ToString());
                lvi.SubItems.Add(productennaam.ToString());
                lvi.SubItems.Add(aantal.ToString());
                listView1.Items.Add(lvi);
            }
            //vul kolommen
   
        }
    }

}
