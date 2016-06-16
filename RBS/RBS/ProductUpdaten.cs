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
    public partial class ProductUpdaten : Form
    {
        private int categorie;
        private ProductDAO dao;
        private int productID;

        public ProductUpdaten()
        {
            InitializeComponent();
        }

        public ProductUpdaten(int categorie, int productID)
        {
            this.categorie = categorie;
            this.productID = productID;

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

            
            dao = new ProductDAO(Connection());
            Product product = dao.GetProductById(productID);

            txt_Naam.Text = product.Naam;
            txt_Aantal.Value = product.AantalVoorraad;
            txt_Prijs.Text = product.Prijs.ToString();
            switch (product.SubCategorieId)
            {
                case 1:
                    list_Subcategorie.Text = "Voorgerecht";
                    break;
                case 2:
                    list_Subcategorie.Text = "Hoofdgerecht";
                    break;
                case 3:
                    list_Subcategorie.Text = "Nagerecht";
                    break;
                case 4:
                    list_Subcategorie.Text = "Voorgerecht";
                    break;
                case 5:
                    list_Subcategorie.Text = "Tussengerecht";
                    break;
                case 6:
                    list_Subcategorie.Text = "Hoofdgerecht";
                    break;
                case 7:
                    list_Subcategorie.Text = "Nagerecht";
                    break;
                case 8:
                    list_Subcategorie.Text = "Frisdrank";
                    break;
                case 9:
                    list_Subcategorie.Text = "Bier";
                    break;
                case 10:
                    list_Subcategorie.Text = "Wijn";
                    break;
                case 11:
                    list_Subcategorie.Text = "Gedestilleerde dranken";
                    break;
                case 12:
                    list_Subcategorie.Text = "Koffie/thee";
                    break;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            
            try
            {
                Product product = new Product();
                product.Id = productID;
                product.Naam = txt_Naam.Text;
                product.AantalVoorraad = (int)txt_Aantal.Value;
                product.Prijs = decimal.Parse(txt_Prijs.Text);
                if (categorie == 2)
                {
                    product.SubCategorieId = list_Subcategorie.SelectedIndex + 1 + 3;
                }
                else if (categorie == 3)
                {
                    product.SubCategorieId = list_Subcategorie.SelectedIndex + 1 + 7;
                }
                else
                    product.SubCategorieId = list_Subcategorie.SelectedIndex + 1;

                if (MessageBox.Show("Weet u zeker dat u dit product wilt aanpassen?", "Akkoord", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dao.WijzigProduct(product);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("U heeft bij prijs of aantal mogelijk een ongeldige invoer gegeven.");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private SqlConnection Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            return dbConnection;
        }
    }
}
