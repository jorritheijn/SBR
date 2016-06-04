﻿using RBS.Helpers;
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

        private int tafelId;

        private List<BestelRegel> bestelRegels = new List<BestelRegel>();

        public BestelScherm(int tafelId)
        {
            InitializeComponent();

            this.productDAO = DataHelper.ProductDao;
            this.tafelId = tafelId;
            
            DrawButtons();
        }

        /// <summary>
        /// Creëert 
        /// </summary>
        private void DrawButtons()
        {
            DrawLunch();
            
            List<Product> diner = productDAO.GetAllByCategorie(2);
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

        private void BtnAddComment_Click(object sender, EventArgs e)
        {

        }

        private void BtnDecrement_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Control[] controls = tabControl1.SelectedTab.Controls.Find(btn.Name, true);
            Product p = (Product)controls[0].Tag;

            p.AantalVoorraad += 1;
            int n = (int)controls[1].Tag;
            controls[1].Tag = --n;
            controls[1].Text = n.ToString();
            
            controls[0].Enabled = true;

            if (n == 0)
            {
                controls[2].Enabled = false;
                controls[3].Enabled = false;
            }
            UpdateListView();
        }

        /// <summary>
        /// Pakt alle Controls in de regel van de gedrukte btnItem, voegt item toe aan bestellingen.</summary>
        /// <remarks>
        /// In de array: 0=btnItem, 1=lblNum, 2=btnDecrement, 3=btnRemove</remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnItem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Control[] controls = tabControl1.SelectedTab.Controls.Find(btn.Name, true);
            Product p = (Product)btn.Tag;

            if(p.AantalVoorraad > 0)
            {
                AddProduct(p.Id);

                int n = (int)controls[1].Tag;
                controls[1].Tag = ++n;
                controls[1].Text = n.ToString();
                p.AantalVoorraad -= 1;

                //if (p.AantalVoorraad == 0) { DisableButtons(controls); }
                btn.Enabled = p.AantalVoorraad != 0;

                controls[2].Enabled = true;
                controls[3].Enabled = true;
            }
            UpdateListView();
        }

        /// <summary>
        /// Disable alle Buttons in een gegeven rij.
        /// </summary>
        /// <param name="controls"></param>
        private void DisableButtons(Control[] controls)
        {
            foreach(Control c in controls)
            {
                c.Enabled = c.GetType() != typeof(Button);
            }
        }

        /// <summary>
        /// Enable alle Buttons in een gegeven rij.
        /// </summary>
        /// <param name="controls"></param>
        private void EnableButtons(Control[] controls)
        {
            foreach (Control c in controls)
            {
                c.Enabled = c.GetType() == typeof(Button);
            }
        }

        private void DrawLunch()
        {
            List<Product> lunch = productDAO.GetAllByCategorie(1);
            for (int i = 0; i < lunch.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                Label lblNum = new Label();
                Button btnDecrement = new Button();
                Button btnAddComment = new Button();

                btnItem.Click += BtnItem_Click;
                btnDecrement.Click += BtnDecrement_Click;
                btnAddComment.Click += BtnAddComment_Click;
                
                btnItem.Tag = lunch[i];
                lblNum.Tag = 0;
                btnDecrement.Tag = lunch[i];
                
                btnItem.Enabled = lunch[i].AantalVoorraad > 0;
                btnDecrement.Enabled = false;
                btnAddComment.Enabled = false;

                if (i < 10)
                {
                    btnItem.Name = "row0" + i;
                    lblNum.Name = "row0" + i;
                    btnDecrement.Name = "row0" + i;
                    btnAddComment.Name = "row0" + i;
                }
                else
                {
                    btnItem.Name = "row" + i;
                    lblNum.Name = "row" + i;
                    btnDecrement.Name = "row" + i;
                    btnAddComment.Name = "row" + i;
                }

                btnItem.SetBounds(7, 7 + ((height + 3) * i), width, height);
                lblNum.SetBounds(360, 15 + ((height + 3) * i), 20, 15);
                btnDecrement.SetBounds(390, 7 + ((height + 3) * i), 50, height);
                btnAddComment.SetBounds(450, 7 + ((height + 3) * i), 100, height);

                btnItem.Text = lunch[i].Naam.Trim();
                lblNum.Text = "0";
                btnDecrement.Text = "-";
                btnAddComment.Text = "Opmerking";

                tabPageLunch.Controls.Add(btnItem);
                tabPageLunch.Controls.Add(lblNum);
                tabPageLunch.Controls.Add(btnDecrement);
                tabPageLunch.Controls.Add(btnAddComment);
            }
        }

        private void DrawDiner()
        {

        }

        private void DrawFrisdranken()
        {

        }

        private void DrawAlcoholhoudend()
        {

        }

        private void DrawWarmeDranken()
        {

        }

        private void AddProduct(int productId)
        {
            for(int i = 0; i < bestelRegels.Count; i++)
            {
                if(bestelRegels[i].ProductId == productId)
                {
                    bestelRegels[i].Aantal++;
                    return;
                }
            }
            bestelRegels.Add(new BestelRegel(tafelId, productId, 1, 0, "", 1, 0));
        }

        private void RemoveProduct(int productId)
        {
            for(int i = 0; i < bestelRegels.Count; i++)
            {
                if(bestelRegels[i].ProductId == productId)
                {
                    if (bestelRegels[i].Aantal > 1)
                        bestelRegels[i].Aantal--;
                    else
                        bestelRegels.Remove(bestelRegels[i]);
                }
            }
        }

        private void UpdateListView()
        {
            lstProducten.Items.Clear();

            foreach (BestelRegel br in bestelRegels)
            {
                ListViewItem item = new ListViewItem();
                item.Text = br.ProductId.ToString();
                item.SubItems.Add(br.Aantal.ToString());
                lstProducten.Items.Add(item);
            }
        }
    }
}
