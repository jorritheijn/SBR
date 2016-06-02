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
            listView1.View = View.Details;

            string status = "Besteld";
            string afdeling = "bar";
            List<BestelRegel> bestelregel = bestellingDAO.GetAllByStatus(status, afdeling);

            int top = 126;
            int left = 500;
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
                button.Size = new Size(76, 16);
                button.Text = "Klaar";
                button.Tag = Bestelregel;
                button.Font = new Font("Arial", 6);
                button.Click += button_Click;
                this.Controls.Add(button);
                top += button.Height + 2;		        
	        }
        }
            void button_Click(object sender, EventArgs e)
            {
                Button btn = (Button)sender;
                BestelRegel regel = (BestelRegel)btn.Tag;
                MessageBox.Show("test" + regel.ProductId);
            }

            /*List<int> tafelid = new List<int>();
            List<string> productennaam = new List<string>();
            List<string> comments = new List<string>();
            List<int> aantal = new List<int>();
            tafelid = bestellingDAO.GetAllTafel();
            productennaam = bestellingDAO.GetAllProducten();
            comments = bestellingDAO.GetAllComment();
            aantal = bestellingDAO.GetAllAantal();

            int top = 126;
            int left = 500;

            //vull listview en create button 
            for (int i = 0; i < tafelid.Count; i++)
            {
                //vul listviewitem
                ListViewItem lvi = new ListViewItem(tafelid[i].ToString());
                lvi.SubItems.Add(productennaam[i]);
                lvi.SubItems.Add(comments[i]);
                lvi.SubItems.Add(aantal[i].ToString());
                listView1.Items.AddRange(new ListViewItem[] { lvi });

                //if (tafel change...)
                //    ListViewGroup group = new ListViewGroup("tafel x");

                //create buttons
                Button button = new Button();
                button.Left = left;
                button.Top = top;
                button.Size = new Size(76, 16);
                button.BackColor = Color.Green;
                button.Text = "Klaar";
                //button.Tag = bestelRegel;
                button.Font = new Font("Arial", 6);
                button.Click += button_Click;
                this.Controls.Add(button);
                top += button.Height + 2;
            }   

        }

        void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //Bestelregel regel = (BstelRegel)btn.Tag;*/
        }
    }
