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

namespace RBS
{
    public partial class BestelScherm : Form
    {
        private ProductDAO productDAO;

        private int TafelId;

        public BestelScherm(int tafelId)
        {
            InitializeComponent();

            this.productDAO = DataHelper.ProductDao;
            this.TafelId = tafelId;

            SetButtons();
        }

        private void SetButtons()
        {
            List<Product> lunch = productDAO.GetLunch();
            for(int i = 0; i < lunch.Count; i++)
            {
                Button btnItem = this.Controls.Find("btnItem" + i, true).FirstOrDefault() as Button;
                Button btnDecrement = this.Controls.Find("btnDecrement" + i, true).FirstOrDefault() as Button;
                Button btnRemove = this.Controls.Find("btnRemove" + i, true).FirstOrDefault() as Button;

                btnItem.Text = lunch[i].Naam.Trim();
                btnItem.Enabled = true;
                btnDecrement.Enabled = true;
                btnRemove.Enabled = true;
            }
        }
    }
}
