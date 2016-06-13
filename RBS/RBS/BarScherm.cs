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
using RBS.Helpers;

namespace RBS
{
    public partial class BarScherm : Form
    {
        List<Button> button = new List<Button>();
        public BarScherm()
        {
            InitializeComponent();
            BarScherm_Huidig_load();
            BarScherm_Geschiedenis_load();
        }
        //test
        private void BarScherm_Huidig_load()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            ProductDAO p = new ProductDAO(dbConnection);
            listView1.View = View.Details;

            int status = 1;
            int afdeling = 3;
            List<BestelRegel> bestelregel = bestellingDAO.GetAllByStatus(status, afdeling);



            int top = 25;
            int left = 380;
            foreach (var Bestelregel in bestelregel)
            {
                ListViewItem lvi = new ListViewItem(Bestelregel.TafelId.ToString());
                Product prod = p.GetProductById(Bestelregel.ProductId);
                lvi.SubItems.Add(prod.Naam);
                lvi.SubItems.Add(Bestelregel.Comment.ToString());
                lvi.SubItems.Add(Bestelregel.Aantal.ToString());
                listView1.Items.AddRange(new ListViewItem[] { lvi });

                //create buttons
                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = new Size(55, 15);
                btn.Text = "Klaar";
                btn.Tag = Bestelregel;
                btn.Font = new Font("Arial", 5);
                btn.Click += button_Click;
                tabPage1.Controls.Add(btn);
                button.Add(btn);
                top += btn.Height + 2;

            }
        }

        private void BarScherm_Geschiedenis_load()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            ProductDAO p = new ProductDAO(dbConnection);
            listView2.View = View.Details;

            int status = 2;
            int afdeling = 3;
            List<BestelRegel> bestelregel = bestellingDAO.GetAllByStatus(status, afdeling);

            int top = 25;
            int left = 380;
            foreach (var Bestelregel in bestelregel)
            {
                ListViewItem lvi = new ListViewItem(Bestelregel.TafelId.ToString());
                Product prod = p.GetProductById(Bestelregel.ProductId);
                lvi.SubItems.Add(prod.Naam);
                lvi.SubItems.Add(Bestelregel.Comment.ToString());
                lvi.SubItems.Add(Bestelregel.Aantal.ToString());
                listView2.Items.AddRange(new ListViewItem[] { lvi });

                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = new Size(55, 15);
                btn.Text = "Verwijder";
                btn.Tag = Bestelregel;
                btn.Font = new Font("Arial", 5);
                btn.Click += button_Click;
                tabPage2.Controls.Add(btn);
                button.Add(btn);
                top += btn.Height + 2;
            }
        }
        void button_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

            Button btn = (Button)sender;
            BestelRegel regel = (BestelRegel)btn.Tag;

            bestellingDAO.MarkeerBestelRegel(regel.Id, regel.Status);
            listView1.Items.Clear();
            listView2.Items.Clear();
            foreach (Button b in button)
            {
                b.Dispose();
            }
            BarScherm_Huidig_load();
            BarScherm_Geschiedenis_load();
            ActiveForm.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InlogScherm Inloggen = new InlogScherm();

            UserHelper.Uitloggen();

            Inloggen.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

            listView1.Items.Clear();
            listView2.Items.Clear();
            foreach (Button b in button)
            {
                b.Dispose();
            }
            BarScherm_Huidig_load();
            BarScherm_Geschiedenis_load();
            ActiveForm.Refresh();
        }
    }
}
