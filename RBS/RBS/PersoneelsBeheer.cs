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

        public PersoneelsBeheer()
        {
            InitializeComponent();

            this.dao = DataHelper.PersoneelDao;

            CreateList();
        }

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

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Personeel p = new Personeel();

            if (InputForm_AddUser(ref p) == DialogResult.OK)
            {
                dao.AddEmployee(p.Username, p.Pincode, p.Functie);
                CreateList();
            }
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            if (lstAccounts.SelectedIndices.Count == 1 && InputForm_DeleteUser() == DialogResult.OK)
            {
                dao.DeleteEmployee(int.Parse(lstAccounts.SelectedItems[0].Text));
                CreateList();
            }
        }

        private void lstAccounts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnDelEmployee.Enabled = lstAccounts.SelectedIndices.Count != 0;
        }
    }
}
