namespace RBS
{
    partial class PersoneelsBeheer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstAccounts = new System.Windows.Forms.ListView();
            this.lstColID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstColNaam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstColFunctie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnDelEmployee = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Voorraad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstAccounts
            // 
            this.lstAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstColID,
            this.lstColNaam,
            this.lstColFunctie});
            this.lstAccounts.FullRowSelect = true;
            this.lstAccounts.GridLines = true;
            this.lstAccounts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstAccounts.Location = new System.Drawing.Point(12, 50);
            this.lstAccounts.MultiSelect = false;
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(440, 431);
            this.lstAccounts.TabIndex = 0;
            this.lstAccounts.Tag = "";
            this.lstAccounts.UseCompatibleStateImageBehavior = false;
            this.lstAccounts.View = System.Windows.Forms.View.Details;
            this.lstAccounts.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstAccounts_ItemSelectionChanged);
            // 
            // lstColID
            // 
            this.lstColID.Tag = "ID";
            this.lstColID.Text = "ID";
            this.lstColID.Width = 75;
            // 
            // lstColNaam
            // 
            this.lstColNaam.Tag = "Naam";
            this.lstColNaam.Text = "Naam";
            this.lstColNaam.Width = 265;
            // 
            // lstColFunctie
            // 
            this.lstColFunctie.Tag = "Functie";
            this.lstColFunctie.Text = "Functie";
            this.lstColFunctie.Width = 93;
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Location = new System.Drawing.Point(12, 487);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(440, 48);
            this.btnAddEmployee.TabIndex = 1;
            this.btnAddEmployee.Text = "Add employee";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnDelEmployee
            // 
            this.btnDelEmployee.Enabled = false;
            this.btnDelEmployee.Location = new System.Drawing.Point(12, 541);
            this.btnDelEmployee.Name = "btnDelEmployee";
            this.btnDelEmployee.Size = new System.Drawing.Size(440, 48);
            this.btnDelEmployee.TabIndex = 2;
            this.btnDelEmployee.Text = "Delete employee";
            this.btnDelEmployee.UseVisualStyleBackColor = true;
            this.btnDelEmployee.Click += new System.EventHandler(this.btnDelEmployee_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(361, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log Uit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Voorraad
            // 
            this.btn_Voorraad.Location = new System.Drawing.Point(26, 10);
            this.btn_Voorraad.Name = "btn_Voorraad";
            this.btn_Voorraad.Size = new System.Drawing.Size(75, 23);
            this.btn_Voorraad.TabIndex = 4;
            this.btn_Voorraad.Text = "Voorraad";
            this.btn_Voorraad.UseVisualStyleBackColor = true;
            this.btn_Voorraad.Click += new System.EventHandler(this.btn_Voorraad_Click);
            // 
            // PersoneelsBeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.btn_Voorraad);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDelEmployee);
            this.Controls.Add(this.btnAddEmployee);
            this.Controls.Add(this.lstAccounts);
            this.Name = "PersoneelsBeheer";
            this.Text = "PersoneelsBeheer";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader lstColID;
        private System.Windows.Forms.ColumnHeader lstColNaam;
        private System.Windows.Forms.ColumnHeader lstColFunctie;
        private System.Windows.Forms.ListView lstAccounts;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnDelEmployee;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Voorraad;
    }
}