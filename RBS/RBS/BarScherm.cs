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
            tafelid = bestellingDAO.GetAllTafels();

            //fake db
            string bestelling = "eten";
            string aantal = "8";

            foreach (int tafelID in tafelid)
            {
                ListViewItem lvi = new ListViewItem(tafelID.ToString());
                lvi.SubItems.Add(bestelling);
                lvi.SubItems.Add(aantal);
                listView1.Items.Add(lvi);
            }
            //vul kolommen
        


        }
    }

}
