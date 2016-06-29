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
    /// <summary>
    /// Class voor het beheren van de voorraad
    /// </summary>
    public partial class VoorraadBeheer : Form
    {
        /// <summary>
        /// Constructor waarin de geselecteerde button op Lunch staat, database connectie en dao's aangeroepen worden en een foreach als de subcategorieId < 4 is dan wordt deze uitgelezen in de listbox.
        /// Als er een subcategorie ingevoerd wordt moet dit hier veranderen.
        /// </summary>
        public VoorraadBeheer()
        {

            InitializeComponent();


            ButtonSelected(btn_Lunch);

            SqlConnection dbConnection = Connection();
            dao = new ProductDAO(dbConnection);

            List<Product> producten = dao.GetAllByCategorie(categorie);


            categorie = 1;

            foreach (Product product in producten)
            {
                VulLijst(product);
            }

        }
        /// <summary>
        /// Vult de listboxes
        /// </summary>
        /// <param name="product"></param>
        public void VulLijst(Product product)
        {

            list_Producten.Items.Add(product.Id + ". " + product.Naam);
            list_Aantal.Items.Add(product.AantalVoorraad);
            list_Prijs.Items.Add(product.Prijs);
        }
        /// <summary>
        /// Leegt alle listboxes
        /// </summary>
        public void LeegLijst()
        {

            list_Producten.Items.Clear();
            list_Aantal.Items.Clear();
            list_Prijs.Items.Clear();
        }
        /// <summary>
        /// Database connectie
        /// </summary>
        /// <returns>dbConnection</returns>
        private SqlConnection Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            return dbConnection;
        }

        private ProductDAO dao;

        // 1 = lunch, 2 = diner, 3 = drank
        private int categorie;




        /// <summary>
        ///  Loguit button die terug gaat naar het loginscherm als hier op geklikt wordt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_logout_Click(object sender, EventArgs e)
        {

            InlogScherm Check = new InlogScherm();
            Check.Show();
            Hide();
        }
        /// <summary>
        /// Klik op button lunch dan worden de listboxes gecleared en worden de prijzen, naam en het aantal van de producten met subcategorie 1,2 of 3 uitgelezen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Lunch_Click(object sender, EventArgs e)
        {
            ButtonSelected((Button)sender);
            LeegLijst();

            //string name = Button.name();


            categorie = 1;
            List<Product> producten = dao.GetAllByCategorie(categorie);
            foreach (Product product in producten)
            {
                VulLijst(product);
            }
        }

        /// <summary>
        /// Klik, categorie wordt op 2 gezet, listboxes gecleared, product prijs, naam, aantal uitgelezen in listbox van subcategorie 4 t/m 7.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Diner_Click(object sender, EventArgs e)
        {
            ButtonSelected((Button)sender);
            LeegLijst();
            categorie = 2;
            List<Product> producten = dao.GetAllProducts();
            foreach (Product product in producten)
            {
                if (product.SubCategorieId > 3 && product.SubCategorieId < 8)
                {
                    VulLijst(product);
                }
            }
        }
        /// <summary>
        /// Klik, categorie wordt op 3 gezet, listboxes gecleared en product prijs, naam en aantaal uitgelezen in listbox van subcategorie 8 t/m 12.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Drank_Click(object sender, EventArgs e)
        {
            ButtonSelected((Button)sender);
            LeegLijst();
            categorie = 3;
            List<Product> producten = dao.GetAllProducts();

            foreach (Product product in producten)
            {
                if (product.SubCategorieId > 7 && product.SubCategorieId < 13)
                {
                    VulLijst(product);
                }
            }
        }





        /// <summary>
        /// Maakt de actieve btn LightGray en alle andere knoppen WhiteSmoke
        /// </summary>
        /// <param name="btn"></param>
        private void ButtonSelected(Button btn)
        {
            btn_Lunch.BackColor = Color.WhiteSmoke;
            btn_Diner.BackColor = Color.WhiteSmoke;
            btn_Drank.BackColor = Color.WhiteSmoke;

            btn.BackColor = Color.LightGray;
        }


        /// <summary>
        /// opent het producttoevoegen scherm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Toevoeg_Click(object sender, EventArgs e)
        {

            ProductToevoegen toevoegen = new ProductToevoegen(categorie);
            toevoegen.FormClosed += new FormClosedEventHandler(VensterGesloten);
            toevoegen.Show();
        }
        /// <summary>
        /// Bij venster sluiten controleren op welke categorie deze stond en dan klikken op de btn die hier bij hoort.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Klik op btn, geselecteerde product wordt uit de lijst en database verwijderd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Zet de index van de listboxes gelijk zodat als er op één geklikt wordt alle listboxes op de zelfde rij worden geselecteerd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_Producten_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_Aantal.SelectedIndex = list_Producten.SelectedIndex;
            list_Prijs.SelectedIndex = list_Producten.SelectedIndex;



        }

        private void list_Aantal_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_Producten.SelectedIndex = list_Aantal.SelectedIndex;
            list_Prijs.SelectedIndex = list_Aantal.SelectedIndex;


        }
        private void list_Prijs_SelectedIndexChanged(object sender, EventArgs e)
        {
            list_Aantal.SelectedIndex = list_Prijs.SelectedIndex;
            list_Prijs.SelectedIndex = list_Producten.SelectedIndex;

        }
        /// <summary>
        /// Pakt substr van begin tot de . en stopt deze in een int, opent het productupdaten scherm en geeft de categorie en dit productid mee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void list_Producten_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string productStr = list_Producten.GetItemText(list_Producten.SelectedItem);
            int index = productStr.IndexOf(".");
            string productIDstr = productStr.Substring(0, index);
            int productID = int.Parse(productIDstr);

            ProductUpdaten update = new ProductUpdaten(categorie, productID);
            update.FormClosed += new FormClosedEventHandler(VensterGesloten);
            update.Show();
        }

       






    }

}