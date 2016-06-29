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
        /// <summary>
        /// Constructor, kijkt naar categorie en stopt tekst in label en in dropdown
        /// </summary>
        /// <param name="categorie"></param>
        public ProductToevoegen(int categorie)
        {
            
            InitializeComponent();
            
            this.categorie = categorie;
            dao = new ProductDAO(Connection());
           InitProducten();

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

        private void InitProducten()
        {
            if (categorie == 1)
            {
                lbl_Categorie.Text = "Lunch";
                for (int i = 1; i < 4; i++)
                {
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
        }
        
        
        
        
        
         
        private void ProductToevoegen_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Kijkt naar de selectedindex om te bepalen welke subcategorie er wordt gegeven.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
