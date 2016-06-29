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
        private SqlConnection Connection()
        {
            string connString = ConfigurationManager.ConnectionStrings["MayaMayaConnection"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connString);
            return dbConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categorie"></param>
        /// <param name="productID"></param>
        public ProductUpdaten(int categorie, int productID)
        {
            InitializeComponent();

            this.categorie = categorie;
            this.productID = productID;
            InitProductUpdate();



        }

        private void InitProductUpdate()
        {
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

            list_Subcategorie.Text = GetSubcategorie(product.SubCategorieId);
        }

        private string GetSubcategorie(int subCategorieId)
        {

            string subCategorie = "";
            if (subCategorieId < 4)
            {
                subCategorie = ((Lunch)subCategorieId).ToString();
            }
            else if (subCategorieId < 8)
            {
                subCategorie = ((Diner)subCategorieId).ToString();

            }
            else if (subCategorieId < 13)
            {
                subCategorie = ((Drank)subCategorieId).ToString();
            }
            return subCategorie;
        }

        /// <summary>
        /// Past het product aan en sluit dit venster. Als er een subcategorie ingevoegd wordt moet dit hier veranderd worden.
        /// try en catch zit hier in om error te geven bij verkeerde invoer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


    }
}
