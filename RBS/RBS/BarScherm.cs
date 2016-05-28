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
        BestellingDAO bestellingDAO;
        public void ShowBestelling();

        private void ShowBestelling(BestellingDAO bestellingDAO)
        {
            this.bestellingDAO = bestellingDAO;
            foreach (Bestelling item in bestellingDAO.GetAll())
            {
                ListViewItem test = new ListViewItem(item.id.ToString());

            }

        }
    }

}
