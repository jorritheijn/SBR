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
using System.Diagnostics;

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

            DateTime t1 = DateTime.Now;
            DateTime t2 = Convert.ToDateTime("18:00:00");
            if (DateTime.Compare(t1, t2) >= 0)
                tabControl.SelectedTab = tabPageDiner;

            this.productDAO = DataHelper.ProductDao;
            this.tafelId = tafelId;
            DrawButtons();
        }

        /// <summary>
        /// Creëert alle buttons en toont deze
        /// </summary>
        private void DrawButtons()
        {
            DrawLunch();
            DrawDiner();
            DrawFrisdranken();
            DrawAlcoholhoudend();
            DrawWarmeDranken();
        }

        private void BtnAddComment_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Control[] controls = tabControl.SelectedTab.Controls.Find(btn.Name, true);
            Product p = (Product)controls[0].Tag;
            BestelRegel br = FindBestelRegel(p.Id);

            InputForm_AddComment(ref br);
        }

        private void InputForm_AddComment(ref BestelRegel br)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox comment = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = "Personeel toevoegen";

            label.Text = "Voeg een opmerking toe:";

            comment.Text = br.Comment;

            btnOk.Text = "Toevoegen";
            btnCancel.Text = "Annuleren";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 3, 372, 13);
            comment.SetBounds(12, 17, 372, 20);

            btnOk.SetBounds(182, 141, 100, 25);
            btnCancel.SetBounds(285, 141, 100, 25);

            label.AutoSize = true;

            comment.Anchor = comment.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 169);
            form.Controls.AddRange(new Control[] { label, comment, btnOk, btnCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                br.Comment = comment.Text;
            }
        }

        private void BtnDecrement_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Control[] controls = tabControl.SelectedTab.Controls.Find(btn.Name, true);
            Product p = (Product)controls[0].Tag;

            RemoveProduct(p.Id);
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
            Control[] controls = tabControl.SelectedTab.Controls.Find(btn.Name, true);
            Product p = (Product)btn.Tag;

            if (p.AantalVoorraad > 0)
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
            foreach (Control c in controls)
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
            List<Product> items = productDAO.GetAllByCategorie(1);
            for (int i = 0; i < items.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                Label lblNum = new Label();
                Button btnDecrement = new Button();
                Button btnAddComment = new Button();

                btnItem.Click += BtnItem_Click;
                btnDecrement.Click += BtnDecrement_Click;
                btnAddComment.Click += BtnAddComment_Click;

                btnItem.Tag = items[i];
                lblNum.Tag = 0;
                btnDecrement.Tag = items[i];

                btnItem.Enabled = items[i].AantalVoorraad > 0;
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
                btnDecrement.SetBounds(381, 7 + ((height + 3) * i), 50, height);
                btnAddComment.SetBounds(433, 7 + ((height + 3) * i), 75, height);

                btnItem.Text = items[i].Naam.Trim();
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
            List<Product> items = productDAO.GetAllByCategorie(2);
            for (int i = 0; i < items.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                Label lblNum = new Label();
                Button btnDecrement = new Button();
                Button btnAddComment = new Button();

                btnItem.Click += BtnItem_Click;
                btnDecrement.Click += BtnDecrement_Click;
                btnAddComment.Click += BtnAddComment_Click;

                btnItem.Tag = items[i];
                lblNum.Tag = 0;
                btnDecrement.Tag = items[i];

                btnItem.Enabled = items[i].AantalVoorraad > 0;
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
                btnDecrement.SetBounds(381, 7 + ((height + 3) * i), 50, height);
                btnAddComment.SetBounds(433, 7 + ((height + 3) * i), 75, height);

                btnItem.Text = items[i].Naam.Trim();
                lblNum.Text = "0";
                btnDecrement.Text = "-";
                btnAddComment.Text = "Opmerking";

                tabPageDiner.Controls.Add(btnItem);
                tabPageDiner.Controls.Add(lblNum);
                tabPageDiner.Controls.Add(btnDecrement);
                tabPageDiner.Controls.Add(btnAddComment);
            }
        }

        private void DrawFrisdranken()
        {
            List<Product> items = productDAO.GetAllBySubCategorie(8);
            for (int i = 0; i < items.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                Label lblNum = new Label();
                Button btnDecrement = new Button();
                Button btnAddComment = new Button();

                btnItem.Click += BtnItem_Click;
                btnDecrement.Click += BtnDecrement_Click;
                btnAddComment.Click += BtnAddComment_Click;

                btnItem.Tag = items[i];
                lblNum.Tag = 0;
                btnDecrement.Tag = items[i];

                btnItem.Enabled = items[i].AantalVoorraad > 0;
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
                btnDecrement.SetBounds(381, 7 + ((height + 3) * i), 50, height);
                btnAddComment.SetBounds(433, 7 + ((height + 3) * i), 75, height);

                btnItem.Text = items[i].Naam.Trim();
                lblNum.Text = "0";
                btnDecrement.Text = "-";
                btnAddComment.Text = "Opmerking";

                tabPageFris.Controls.Add(btnItem);
                tabPageFris.Controls.Add(lblNum);
                tabPageFris.Controls.Add(btnDecrement);
                tabPageFris.Controls.Add(btnAddComment);
            }
        }

        private void DrawAlcoholhoudend()
        {
            List<Product> items = productDAO.GetAllBySubCategorie(9);
            items.AddRange(productDAO.GetAllBySubCategorie(10));
            items.AddRange(productDAO.GetAllBySubCategorie(11));
            for (int i = 0; i < items.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                Label lblNum = new Label();
                Button btnDecrement = new Button();
                Button btnAddComment = new Button();

                btnItem.Click += BtnItem_Click;
                btnDecrement.Click += BtnDecrement_Click;
                btnAddComment.Click += BtnAddComment_Click;

                btnItem.Tag = items[i];
                lblNum.Tag = 0;
                btnDecrement.Tag = items[i];

                btnItem.Enabled = items[i].AantalVoorraad > 0;
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
                btnDecrement.SetBounds(381, 7 + ((height + 3) * i), 50, height);
                btnAddComment.SetBounds(433, 7 + ((height + 3) * i), 75, height);

                btnItem.Text = items[i].Naam.Trim();
                lblNum.Text = "0";
                btnDecrement.Text = "-";
                btnAddComment.Text = "Opmerking";

                tabPageDrank.Controls.Add(btnItem);
                tabPageDrank.Controls.Add(lblNum);
                tabPageDrank.Controls.Add(btnDecrement);
                tabPageDrank.Controls.Add(btnAddComment);
            }
        }

        private void DrawWarmeDranken()
        {
            List<Product> items = productDAO.GetAllBySubCategorie(12);
            for (int i = 0; i < items.Count; i++)
            {
                int width = 350, height = 30;

                Button btnItem = new Button();
                Label lblNum = new Label();
                Button btnDecrement = new Button();
                Button btnAddComment = new Button();

                btnItem.Click += BtnItem_Click;
                btnDecrement.Click += BtnDecrement_Click;
                btnAddComment.Click += BtnAddComment_Click;

                btnItem.Tag = items[i];
                lblNum.Tag = 0;
                btnDecrement.Tag = items[i];

                btnItem.Enabled = items[i].AantalVoorraad > 0;
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
                btnDecrement.SetBounds(381, 7 + ((height + 3) * i), 50, height);
                btnAddComment.SetBounds(433, 7 + ((height + 3) * i), 75, height);

                btnItem.Text = items[i].Naam.Trim();
                lblNum.Text = "0";
                btnDecrement.Text = "-";
                btnAddComment.Text = "Opmerking";

                tabPageKoffieThee.Controls.Add(btnItem);
                tabPageKoffieThee.Controls.Add(lblNum);
                tabPageKoffieThee.Controls.Add(btnDecrement);
                tabPageKoffieThee.Controls.Add(btnAddComment);
            }
        }

        private void AddProduct(int productId)
        {
            for (int i = 0; i < bestelRegels.Count; i++)
            {
                if (bestelRegels[i].ProductId == productId)
                {
                    bestelRegels[i].Aantal++;
                    return;
                }
            }

            bestelRegels.Add(new BestelRegel(tafelId, productId, 1, 0, "", 1, 0));
        }

        private void RemoveProduct(int productId)
        {
            for (int i = 0; i < bestelRegels.Count; i++)
            {
                if (bestelRegels[i].ProductId == productId)
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

        private BestelRegel FindBestelRegel(int productId)
        {
            foreach (BestelRegel br in bestelRegels)
                if (br.ProductId == productId) return br;
            return bestelRegels[0];
        }
    }
}
