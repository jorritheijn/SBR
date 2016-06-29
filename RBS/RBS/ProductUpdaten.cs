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
            InitProducten();



        }
        
        private void InitProducten()
        {
            dao = new ProductDAO(Connection());
            Product product = dao.GetProductById(productID);
       
            if (categorie == 1) {
                lbl_Categorie.Text = "Lunch";
                for (int i = 1; i < 4; i++) {
                    GetSubcategory(i);
                }
            }
            else if (categorie == 2)
            {
                lbl_Categorie.Text = "Diner";
                for (int i = 4; i < 8; i++)
                {
                    GetSubcategory(i);
                }
            }
            else if (categorie == 3)
            {
                lbl_Categorie.Text = "Drank";
                for (int i = 8; i < 13; i++)
                {
                    GetSubcategory(i);
                }
            }
 
            list_Subcategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            list_Subcategorie.SelectedIndex = 0;
 
            txt_Naam.Text = product.Naam;
            txt_Aantal.Value = product.AantalVoorraad;
            txt_Prijs.Text = product.Prijs.ToString();
 
            GetSubcategory(product.SubCategorieId);
         }
    
        private void GetSubcategory(int i)
        {
            string subcategoryNaam = "";
 
            if (Enum.IsDefined(typeof(Lunch), i))
            {
                subcategoryNaam = ((Lunch)i).ToString();
                list_Subcategorie.Items.Add(subcategoryNaam);
            }
            else if (Enum.IsDefined(typeof(Diner), i))
            {
                subcategoryNaam = ((Diner)i).ToString();
                list_Subcategorie.Items.Add(subcategoryNaam);
            }
            else if (Enum.IsDefined(typeof(Drank), i))
            {
                subcategoryNaam = ((Drank)i).ToString();
                list_Subcategorie.Items.Add(subcategoryNaam);
            }
            list_Subcategorie.Text = subcategoryNaam;
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
