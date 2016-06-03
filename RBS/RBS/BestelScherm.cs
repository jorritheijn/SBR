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

            //SetButtons();
            DrawButtons();
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

        private void DrawButtons()
        {
            List<Product> lunch = productDAO.GetLunch();
            for (int i = 0; i < lunch.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                btnItem.Click += BtnItem_Click;
                btnItem.Tag = lunch[i];
                if(i<10) { btnItem.Name = "row0" + i;}
                else { btnItem.Name = "row" + i; }
                btnItem.Enabled = lunch[i].AantalVoorraad > 0;
                Label lblNum = new Label();
                if(i<10) { lblNum.Name = "row0" + i; }
                else { lblNum.Name = "row" + i; }

                btnItem.SetBounds(7, 7 + ((height + 3) * i), width, height);
                lblNum.SetBounds(360, 15 + ((height + 3) * i), 20, 15);

                btnItem.Text = lunch[i].Naam.Trim();
                lblNum.Text = "0";
                lblNum.Tag = 0;

                tabPageLunch.Controls.Add(btnItem);
                tabPageLunch.Controls.Add(lblNum);
            }

            List<Product> diner = productDAO.GetDiner();
            for (int i = 0; i < diner.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                btnItem.Click += BtnItem_Click;
                btnItem.Tag = diner[i];
                if (i < 10) { btnItem.Name = "row0" + i; }
                else { btnItem.Name = "row" + i; }
                btnItem.Enabled = diner[i].AantalVoorraad > 0;
                Label lblNum = new Label();
                if (i < 10) { lblNum.Name = "row0" + i; }
                else { lblNum.Name = "row" + i; }

                btnItem.SetBounds(7, 7 + ((height + 3) * i), width, height);
                lblNum.SetBounds(360, 15 + ((height + 3) * i), 20, 15);

                btnItem.Text = diner[i].Naam.Trim();
                lblNum.Text = "99";

                tabPageDiner.Controls.Add(btnItem);
                tabPageDiner.Controls.Add(lblNum);
            }

            List<Product> fris = productDAO.GetFrisdrank();
            for (int i = 0; i < fris.Count; i++)
            {
                int width = 350, height = 30;
                Button btn = new Button();
                btn.SetBounds(7, 7 + ((height + 3) * i), width, height);
                btn.Text = fris[i].Naam.Trim();
                tabPageFris.Controls.Add(btn);
            }

            List<Product> alcohol = productDAO.GetAlcoholhoudend();
            for (int i = 0; i < alcohol.Count; i++)
            {
                int width = 350, height = 30;
                Button btn = new Button();
                btn.SetBounds(7, 7 + ((height + 3) * i), width, height);
                btn.Text = alcohol[i].Naam.Trim();
                tabPageDrank.Controls.Add(btn);
            }

            List<Product> warm = productDAO.GetWarmeDranken();
            for (int i = 0; i < warm.Count; i++)
            {
                int width = 350, height = 30;
                Button btn = new Button();
                btn.SetBounds(7, 7 + ((height + 3) * i), width, height);
                btn.Text = warm[i].Naam.Trim();
                tabPageKoffieThee.Controls.Add(btn);
            }
        }

        /// <summary>
        /// Pakt alle Controls in de regel van de gedrukte btnItem, voegt item toe aan bestellingen.</summary>
        /// <remarks>
        /// In de array: 0=btnItem, 1=lblNum, 2=btnDecrement, 3=btnRemove</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnItem_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            Button btn = sender as Button;
            //Control[] controls = tabControl1.SelectedTab.Controls.Find(btn.Name[btn.Name.Length - 1].ToString(), true);
            Control[] controls = tabControl1.SelectedTab.Controls.Find(btn.Name, true);
            Product p = (Product)btn.Tag;
            //tabControl1.SelectedTab.Controls.Find(btn.Name[btn.Name.Length-1].ToString(), true)[1].Text = "2";
            //controls[0].Text = btn.Name;
            if(p.AantalVoorraad > 1)
            {
                int i = (int)controls[1].Tag;
                controls[1].Tag = ++i;
                controls[1].Text = i.ToString();
            }
            
            if (p.AantalVoorraad == 1)
                DisableButtons(controls);
        }

        /// <summary>
        /// Disabled alle Buttons in een gegeven rij.
        /// </summary>
        /// <param name="controls"></param>
        private void DisableButtons(Control[] controls)
        {
            foreach(Control c in controls)
            {
                c.Enabled = c.GetType() != typeof(Button);
            }
        }
    }
}
