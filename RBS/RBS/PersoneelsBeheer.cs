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

        public PersoneelsBeheer(PersoneelDAO dao)
        {
            this.dao = dao;
            InitializeComponent();
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

        private DialogResult AddUserInput2(ref int id, ref string naam, ref int pincode, ref string functie)
        {
            Form form = new Form();
            Label lblId = new Label();
            Label lblNaam = new Label();
            Label lblPin = new Label();
            Label lblFunctie = new Label();
            TextBox tbId = new TextBox();
            TextBox tbNaam = new TextBox();
            TextBox tbPin = new TextBox();
            TextBox tbFunctie = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = "Personeel toevoegen";

            lblId.Text = "ID";
            lblNaam.Text = "Naam";
            lblPin.Text = "Pincode";
            lblFunctie.Text = "Functie";

            tbId.Text = "";
            tbNaam.Text = "";
            tbPin.Text = "";
            tbFunctie.Text = "";

            btnOk.Text = "Toevoegen";
            btnCancel.Text = "Annuleren";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            lblId.SetBounds(9, 20, 372, 13);
            tbId.SetBounds(12, 36, 372, 20);

            lblNaam.SetBounds(9, 66, 372, 13);
            tbNaam.SetBounds(12, 82, 372, 20);

            lblPin.SetBounds(9, 112, 372, 13);
            tbPin.SetBounds(12, 126, 372, 20);

            lblFunctie.SetBounds(9, 158, 372, 13);
            tbFunctie.SetBounds(12, 172, 372, 20);

            lblId.AutoSize = true;
            lblNaam.AutoSize = true;
            lblPin.AutoSize = true;
            lblFunctie.AutoSize = true;

            tbId.Anchor = tbId.Anchor | AnchorStyles.Right;
            tbNaam.Anchor = tbNaam.Anchor | AnchorStyles.Right;
            tbPin.Anchor = tbPin.Anchor | AnchorStyles.Right;
            tbFunctie.Anchor = tbFunctie.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 500);
            form.Controls.AddRange(new Control[] { lblId, lblNaam, lblPin, lblFunctie,
            tbId, tbNaam, tbPin, tbFunctie, btnOk, btnCancel });
            //form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult result = form.ShowDialog();
            id = int.Parse(tbId.Text);
            naam = tbNaam.Text;
            pincode = int.Parse(tbPin.Text);
            functie = tbFunctie.Text;
            return result;
        }

        private DialogResult AddUserInput(ref Personeel personeel)
        {
            Form form = new Form();
            Label lblNaam = new Label();
            Label lblPin = new Label();
            Label lblFunctie = new Label();
            TextBox tbNaam = new TextBox();
            TextBox tbPin = new TextBox();
            TextBox tbFunctie = new TextBox();
            Button btnOk = new Button();
            Button btnCancel = new Button();

            form.Text = "Personeel toevoegen";
            
            lblNaam.Text = "Naam";
            lblPin.Text = "Pincode";
            lblFunctie.Text = "Functie";
            
            tbNaam.Text = "";
            tbPin.Text = "";
            tbFunctie.Text = "";

            btnOk.Text = "Toevoegen";
            btnCancel.Text = "Annuleren";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;

            lblNaam.SetBounds(9, 66, 372, 13);
            tbNaam.SetBounds(12, 82, 372, 20);

            lblPin.SetBounds(9, 112, 372, 13);
            tbPin.SetBounds(12, 126, 372, 20);

            lblFunctie.SetBounds(9, 158, 372, 13);
            tbFunctie.SetBounds(12, 172, 372, 20);
            
            lblNaam.AutoSize = true;
            lblPin.AutoSize = true;
            lblFunctie.AutoSize = true;
            
            tbNaam.Anchor = tbNaam.Anchor | AnchorStyles.Right;
            tbPin.Anchor = tbPin.Anchor | AnchorStyles.Right;
            tbFunctie.Anchor = tbFunctie.Anchor | AnchorStyles.Right;
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 500);
            form.Controls.AddRange(new Control[] { lblNaam, lblPin, lblFunctie,
            tbNaam, tbPin, tbFunctie, btnOk, btnCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            DialogResult result = form.ShowDialog();
            personeel.Username = tbNaam.Text;
            personeel.Pincode = int.Parse(tbPin.Text);
            personeel.Functie = tbFunctie.Text;
            return result;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Personeel p = new Personeel();

            if (AddUserInput(ref p) == DialogResult.OK)
            {
                dao.AddEmployee(p.Username, p.Pincode, p.Functie);
            }

            CreateList();
        }

        private void btnDelEmployee_Click(object sender, EventArgs e)
        {
            dao.DeleteEmployee(int.Parse(lstAccounts.SelectedItems[0].Text));

            CreateList();
        }
    }
}
