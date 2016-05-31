using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //fake db
            string tafel = "4";
            string bestelling = "eten";
            string aantal = "8";

            //vul kolommen
            ListViewItem lvi = new ListViewItem(tafel);
            lvi.SubItems.Add(bestelling);
            lvi.SubItems.Add(aantal);
            listView1.Items.Add(lvi);
            


        }
    }

}
