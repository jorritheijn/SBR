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
            listView1.View = View.Details;

            int status = 1;
            int afdeling = 1;
            int i = 0;
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
                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = new Size(76, 15);
                btn.Text = "Klaar";
                btn.Tag = Bestelregel;
                btn.Font = new Font("Arial", 5);
                btn.Click += button_Click;
                tabPage1.Controls.Add(btn);
                button.Add(btn);
                top += btn.Height + 2;
                i++;

            }
        }
            void button_Click(object sender, EventArgs e)
            {
                string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
                SqlConnection dbConnection = new SqlConnection(connString);
                BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);

                Button btn = (Button)sender;
                BestelRegel regel = (BestelRegel)btn.Tag;

                bestellingDAO.MarkeerBestelRegel(regel.Status, regel.Id);
                listView1.Items.Clear();
                listView2.Items.Clear();
            int i = 0;
            foreach (var buttonlist in button)
            {
                button[i].Dispose();
                i++;
            }
                BarScherm_Huidig_load();
                BarScherm_Geschiedenis_load();
     
        }

        private void BarScherm_Geschiedenis_load()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            BestellingDAO bestellingDAO = new BestellingDAO(dbConnection);
            listView2.View = View.Details;

            int status = 2;
            int afdeling = 1;
            int i = 0;
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
                //listView2.Tag = Bestelregel;

                //create buttons
                /*button[i].Left = left;
                button[i].Top = top;
                button[i].Size = new Size(76, 15);
                button[i].Text = "Verwijder";
                button[i].Tag = Bestelregel;
                button[i].Font = new Font("Arial", 5);
                button[i].Click += button_Click;
                tabPage2.Controls.Add(button[i]);
                top += button[i].Height + 2;*/

                Button btn = new Button();
                btn.Left = left;
                btn.Top = top;
                btn.Size = new Size(76, 15);
                btn.Text = "Klaar";
                btn.Tag = Bestelregel;
                btn.Font = new Font("Arial", 5);
                btn.Click += button_Click;
                tabPage2.Controls.Add(btn);
                button.Add(btn);
                top += btn.Height + 2;
                i++;
            }
        }


        /*void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Bestelregel regel = (BstelRegel)btn.Tag;*/
        }
    }
