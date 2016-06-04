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
            BarScherm_Huidig_load();
            BarScherm_Geschiedenis_load();
        }
        //test
        private void BarScherm_Huidig_load()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            listView1.View = View.Details;

            int status = 1;
            int afdeling = 1;
            List<BestelRegel> bestelregel = bestellingDAO.GetAllByStatus(status, afdeling);

            int top = 25;
            int left = 480;
            foreach (var Bestelregel in bestelregel)
	        {
                ListViewItem lvi = new ListViewItem(Bestelregel.TafelId.ToString());
                lvi.SubItems.Add(Bestelregel.ProductId.ToString());
                lvi.SubItems.Add(Bestelregel.Comment.ToString());
                lvi.SubItems.Add(Bestelregel.Aantal.ToString());
                listView1.Items.AddRange(new ListViewItem[] { lvi });


                //create buttons
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Size = new Size(76, 15);
                button.Text = "Klaar";
                button.Tag = Bestelregel;
                button.Font = new Font("Arial", 5);
                button.Click += button_Click;
                top += button.Height + 2;
                tabPage1.Controls.Add(button);

            }
        }
            void button_Click(object sender, EventArgs e)
            {
                string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
                SqlConnection dbConnection = new SqlConnection(connString);
                BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

                Button btn = (Button)sender;
                BestelRegel regel = (BestelRegel)btn.Tag;

                //bestellingDAO.MarkeerBestelRegel(regel.Status, regel.Id);
                listView1.Items.Clear();
                listView2.Items.Clear();
                BarScherm_Huidig_load();
                BarScherm_Geschiedenis_load();
                btn.Dispose();           
        }

        private void BarScherm_Geschiedenis_load()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            listView2.View = View.Details;

            int status = 2;
            int afdeling = 1;
            List<BestelRegel> bestelregel = bestellingDAO.GetAllByStatus(status, afdeling);

            int top = 25;
            int left = 480;
            foreach (var Bestelregel in bestelregel)
            {
                ListViewItem lvi = new ListViewItem(Bestelregel.TafelId.ToString());
                lvi.SubItems.Add(Bestelregel.ProductId.ToString());
                lvi.SubItems.Add(Bestelregel.Comment.ToString());
                lvi.SubItems.Add(Bestelregel.Aantal.ToString());
                listView2.Items.AddRange(new ListViewItem[] { lvi });
                listView2.Tag = Bestelregel;

                //create buttons
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Size = new Size(76, 15);
                button.Text = "Verwijder";
                button.Tag = Bestelregel;
                button.Font = new Font("Arial", 5);
                button.Click += button_Click;
                tabPage2.Controls.Add(button);
                top += button.Height + 2;
            }
        }


        /*void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Bestelregel regel = (BstelRegel)btn.Tag;*/
        }
    }
