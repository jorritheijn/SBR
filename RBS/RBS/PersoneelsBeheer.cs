using RBS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBS
{
    public partial class PersoneelsBeheer : Form
    {
        private PersoneelDAO dao;

        /// <summary>
        /// Constructor
        /// </summary>
        public PersoneelsBeheer()
        {
            InitializeComponent();

            this.dao = DataHelper.PersoneelDao;

            CreateList();
        }

        /// <summary>
        /// Maakt een lijst van personeel en toont deze op de ListView
        /// </summary>
        private void CreateList()
        {
            lstAccounts.Items.Clear();

            foreach(Personeel p in dao.GetAll())
            {
                ListViewItem item = new ListViewItem();
                item.Text = p.Id.ToString();
                item.SubItems.Add(p.Username);
                item.SubItems.Add(p.Functie);
                lstAccounts.Items.Add(item);
            }
        }

        /// <summary>
        /// Pop-up dialog voor het toevoegen van personeel
        /// </summary>
        /// <param name="personeel"></param>
        /// <returns>De waarde van de gekozen DialogResult</returns>
        private DialogResult InputForm_AddUser(ref Personeel personeel)
        {
            Form form = new Form();
            Label lblNaam = new Label();
            Label lblPin = new Label();
            Label lblFunctie = new Label();
            TextBox tbNaam = new TextBox();
            TextBox tbPin = new TextBox();
            ComboBox cbFunctie = new ComboBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = "Personeel toevoegen";
            
            lblNaam.Text = "Naam";
            lblPin.Text = "Pincode";
            lblFunctie.Text = "Functie";
            
            tbNaam.Text = "";
            tbPin.Text = "";

            cbFunctie.Items.Add("Manager");
            cbFunctie.Items.Add("Keuken");
            cbFunctie.Items.Add("Bar");
            cbFunctie.Items.Add("Bediening");
            cbFunctie.SelectedIndex = 3;

            btnOk.Text = "Toevoegen";
            btnCancel.Text = "Annuleren";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            lblNaam.SetBounds(9, 3, 372, 13);
            tbNaam.SetBounds(12, 17, 372, 20);

            lblPin.SetBounds(9, 49, 372, 13);
            tbPin.SetBounds(12, 63, 372, 20);

            lblFunctie.SetBounds(9, 95, 372, 13);
            cbFunctie.SetBounds(12, 109, 372, 20);
            cbFunctie.DropDownStyle = ComboBoxStyle.DropDownList;

            btnOk.SetBounds(182, 141, 100, 25);
            btnCancel.SetBounds(285, 141, 100, 25);

            tbNaam.MaxLength = 15;
            tbPin.MaxLength = 4;
            
            lblNaam.AutoSize = true;
            lblPin.AutoSize = true;
            lblFunctie.AutoSize = true;
            
            tbNaam.Anchor = tbNaam.Anchor | AnchorStyles.Right;
            tbPin.Anchor = tbPin.Anchor | AnchorStyles.Right;
            cbFunctie.Anchor = cbFunctie.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 169);
            form.Controls.AddRange(new Control[] { lblNaam, lblPin, lblFunctie,
                tbNaam, tbPin, cbFunctie, btnOk, btnCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                personeel.Username = tbNaam.Text;
                personeel.Pincode = tbPin.Text;
                personeel.Functie = cbFunctie.Text;
            }
            return result;
        }

        /// <summary>
        /// Pop-up dialog voor het verwijderen van personeel
        /// </summary>
        /// <returns>De waarde van de gekozen DialogResult</returns>
        private DialogResult InputForm_DeleteUser()
        {
            Form form = new Form();
            Label label = new Label();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = "Personeel verwijderen";

            label.Text = String.Format("Weet u zeker dat u {0} uit het systeem wilt verwijderen?",
                lstAccounts.SelectedItems[0].SubItems[1].Text.Trim());

            btnOk.Text = "Verwijderen";
            btnCancel.Text = "Annuleren";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 3, 372, 13);

            btnOk.SetBounds(182, 22, 100, 25);
            btnCancel.SetBounds(285, 22, 100, 25);

            label.AutoSize = true;

            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 50);
            form.Controls.AddRange(new Control[] { label, btnOk, btnCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult result = form.ShowDialog();
            return result;
        }

        /// <summary>
        /// Event voor de Button om personeel toe te voegen, roept InputForm_AddUser
        /// </summary>
        /// <param name="sender">De Button waar op gedrukt is</param>
        /// <param name="e"></param>
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Personeel p = new Personeel();

            if (InputForm_AddUser(ref p) == DialogResult.OK)
            {
                dao.AddEmployee(p.Username, p.Pincode, p.Functie);
                CreateList();
            }
        }

        /// <summary>
        /// Event voor de Button om personeel te verwijderen, roept InputForm_DeleteUser
        /// </summary>
        /// <param name="sender">De Button waar op gedrukt is</param>
        /// <param name="e"></param>
        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedIndices.Count == 1 && InputForm_DeleteUser() == DialogResult.OK)
            {
                dao.DeleteEmployee(int.Parse(lstAccounts.SelectedItems[0].Text));
                CreateList();
            }
        }

        /// <summary>
        /// Event bij het veranderen van de selectie in de ListView.
        /// Enabled/disabled de Delete Employee Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstAccounts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnDelEmployee.Enabled = lstAccounts.SelectedIndices.Count != 0;
        }

        /// <summary>
        /// Uitloggen als gebruiker en teruggaan naar het inlogscherm
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            InlogScherm Inloggen = new InlogScherm();

            UserHelper.Uitloggen();

            Inloggen.Show();
            Hide();
        }

        private void btn_Voorraad_Click(object sender, EventArgs e)
        {
            Application.Run(new VoorraadBeheer());
            this.Close();
        }
    }
}
