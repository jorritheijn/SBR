using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBS
{
    public partial class VoorraadBeheer : Form
    {
        //private TabControl tabControl1;
        private TabPage personeelszaken;
        private TabPage klachten;
        private TabPage voorraad;
        private TabPage tafels;

        


        private void MyTabs()
        {
            this.tabControl1.SelectedTab = tabPage3;
        }

          

        private ProductDAO dao;

        // 1 = lunch, 2 = diner, 3 = drank
        private int categorie;


        public VoorraadBeheer()
        {
            
            InitializeComponent();
            
            ButtonSelected(btn_Lunch);

            SqlConnection dbConnection = Connection();
            dao = new ProductDAO(dbConnection);

            List<Product> producten = dao.GetAllProducts();

            categorie = 1;
            foreach (Product product in producten)
            {
                if (product.SubCategorieId < 4)
                {

                    list_Producten.Items.Add(product.Id + ". " + product.Naam);
                    list_Aantal.Items.Add(product.AantalVoorraad);
                    
                }
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            
            InlogScherm Check = new InlogScherm();
            Check.Show();
            Hide();
        }

        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            ButtonSelected((Button)sender);
            list_Producten.Items.Clear();
            list_Aantal.Items.Clear();

            categorie = 1;
            List<Product> producten = dao.GetAllProducts();
            foreach (Product product in producten)
            {
                if (product.SubCategorieId < 4)
                {
                    list_Producten.Items.Add(product.Id + ". " + product.Naam);
                    list_Aantal.Items.Add(product.AantalVoorraad);
                }
            }
        }

        private void btn_Diner_Click(object sender, EventArgs e)
        {
            ButtonSelected((Button)sender);
            list_Producten.Items.Clear();
            list_Aantal.Items.Clear();
            categorie = 2;
            List<Product> producten = dao.GetAllProducts();
            foreach (Product product in producten)
            {
                if (product.SubCategorieId > 3 && product.SubCategorieId < 8)
                {
                    list_Producten.Items.Add(product.Id + ". " + product.Naam);
                    list_Aantal.Items.Add(product.AantalVoorraad);
                }
            }
        }

        private void btn_Drank_Click(object sender, EventArgs e)
        {
            ButtonSelected((Button)sender);
            list_Producten.Items.Clear();
            list_Aantal.Items.Clear();
            categorie = 3;
            List<Product> producten = dao.GetAllProducts();

            foreach (Product product in producten)
            {
                if (product.SubCategorieId > 7 && product.SubCategorieId < 13)
                {
                    list_Producten.Items.Add(product.Id + ". " + product.Naam);
                    list_Aantal.Items.Add(product.AantalVoorraad);
                }
            }
        }

        private SqlConnection Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            return dbConnection;
        }


        // ButtonSelected heeft als parameter Button btn. Het object sender van de knop wordt hierin toegepast.
        // Maakt de actieve knop (btn) LightGray en alle andere knoppen WhiteSmoke.
        private void ButtonSelected(Button btn)
        {
            btn_Lunch.BackColor = Color.WhiteSmoke;
            btn_Diner.BackColor = Color.WhiteSmoke;
            btn_Drank.BackColor = Color.WhiteSmoke;

            btn.BackColor = Color.LightGray;
        }



        private void btn_Toevoeg_Click(object sender, EventArgs e)
        {
           
            ProductToevoegen toevoegen = new ProductToevoegen(categorie);
            toevoegen.FormClosed += new FormClosedEventHandler(VensterGesloten);
            toevoegen.Show();
        }

        private void VensterGesloten(object sender, FormClosedEventArgs e)
        {
            list_Producten.Items.Clear();
            if (categorie == 1)
            {
                btn_Lunch.PerformClick();
            }
            else if (categorie == 2)
            {
                btn_Diner.PerformClick();
            }
            else if (categorie == 3)
            {
                btn_Drank.PerformClick();
            }
        }

        private void btn_Verwijder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u dit product wilt verwijderen?", "Product verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // -1 is niet geselecteerde index.
                if (list_Producten.SelectedIndex != -1)
                {
                    // Pak van de geselecteerde item in de listbox (list_Producten) de text
                    string productStr = list_Producten.GetItemText(list_Producten.SelectedItem);

                    // Zoek de index (locatie) van de .-teken en stop het in een int variable
                    int positie = productStr.IndexOf('.');

                    // geef met SubString het gedeelte terug met alleen cijfers, geen punt. 0 TOT positie, niet 0 tot en met positie.
                    int productID = int.Parse(productStr.Substring(0, positie));

                    // verwijder product met een productID die zojuist gekozen is.
                    dao.VerwijderProduct(productID);

                    if (categorie == 1)
                    {
                        btn_Lunch.PerformClick();
                    }
                    else if (categorie == 2)
                    {
                        btn_Diner.PerformClick();
                    }
                    else if (categorie == 3)
                    {
                        btn_Drank.PerformClick();
                    }
                }
            }
        }

        private void list_Producten_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_Aantal.SelectedIndex = list_Producten.SelectedIndex;

        }

        private void list_Aantal_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_Producten.SelectedIndex = list_Aantal.SelectedIndex;
        }

        private void list_Producten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string productStr = list_Producten.GetItemText(list_Producten.SelectedItem);
            int index = productStr.IndexOf(".");
            string productIDstr = productStr.Substring(0,index);
            int productID = int.Parse(productIDstr);

            ProductUpdaten update = new ProductUpdaten(categorie, productID);
            update.FormClosed += new FormClosedEventHandler(VensterGesloten);
            update.Show();
        }

        private void btn_personeelbeheer_Click(object sender, EventArgs e)
        {
            Application.Run(new PersoneelsBeheer());
            this.Close();
            
        }

        private void goPersoneel(object sender, EventArgs e)
        {
            Form personeel = new PersoneelsBeheer();
            personeel.Show();
            
        }
    }    
}

