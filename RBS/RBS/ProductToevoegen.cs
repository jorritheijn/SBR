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
    public partial class ProductToevoegen : Form
    {
        private int categorie;
        private ProductDAO dao;

        public ProductToevoegen()
        {
            InitializeComponent();
            
        }

        public ProductToevoegen(int categorie)
        {
            this.categorie = categorie;
            dao = new ProductDAO(Connection());
            InitializeComponent();
            if (categorie == 1)
            {
                lbl_Categorie.Text = "Lunch";
                list_Subcategorie.Items.Add("Voorgerecht");
                list_Subcategorie.Items.Add("Hoofdgerecht");
                list_Subcategorie.Items.Add("Nagerecht");
            }
            else if (categorie == 2)
            {
                lbl_Categorie.Text = "Diner";
                list_Subcategorie.Items.Add("Voorgerecht");
                list_Subcategorie.Items.Add("Tussengerecht");
                list_Subcategorie.Items.Add("Hoofdgerecht");
                list_Subcategorie.Items.Add("Nagerecht");
            }
            else
            {
                lbl_Categorie.Text = "Drank";
                list_Subcategorie.Items.Add("Frisdrank");
                list_Subcategorie.Items.Add("Bier");
                list_Subcategorie.Items.Add("Wijn");
                list_Subcategorie.Items.Add("Gedestilleerde dranken");
                list_Subcategorie.Items.Add("Koffie/thee");
            }

            list_Subcategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            list_Subcategorie.SelectedIndex = 0;
        }


        private void check_Btw_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ProductToevoegen_Load(object sender, EventArgs e)
        {

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            
            int subcategorie = 1;
            if (categorie == 1)
            {
                subcategorie = list_Subcategorie.SelectedIndex + 1;
            }
            else if (categorie == 2)
            {
                subcategorie = list_Subcategorie.SelectedIndex + 1 + 3;
            }
            else if (categorie == 3)
            {
                subcategorie = list_Subcategorie.SelectedIndex + 1 + 7;
            }


            try
            {
                Product product = new Product();
                product.Naam = txt_Naam.Text;
                product.AantalVoorraad = (int)txt_Aantal.Value;
                product.Prijs = decimal.Parse(txt_Prijs.Text);
                product.SubCategorieId = subcategorie;
                dao.VoegtoeProduct(product);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("U heeft bij prijs of aantal mogelijk een ongeldige invoer gegeven.");
            }
        }

        private SqlConnection Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            return dbConnection;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
