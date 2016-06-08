namespace RBS
{
    partial class ProductUpdaten
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
            this.lbl_Categorie = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Naam = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_Aantal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.list_Subcategorie = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Prijs = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Aantal)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Categorie
            // 
            this.lbl_Categorie.AutoSize = true;
            this.lbl_Categorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbl_Categorie.Location = new System.Drawing.Point(149, 9);
            this.lbl_Categorie.Name = "lbl_Categorie";
            this.lbl_Categorie.Size = new System.Drawing.Size(63, 24);
            this.lbl_Categorie.TabIndex = 33;
            this.lbl_Categorie.Text = "Lunch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Naam);
            this.groupBox1.Controls.Add(this.btn_OK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_Cancel);
            this.groupBox1.Controls.Add(this.txt_Aantal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.list_Subcategorie);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Prijs);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 170);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product";
            // 
            // txt_Naam
            // 
            this.txt_Naam.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Naam.Location = new System.Drawing.Point(112, 19);
            this.txt_Naam.Name = "txt_Naam";
            this.txt_Naam.Size = new System.Drawing.Size(238, 20);
            this.txt_Naam.TabIndex = 17;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(15, 124);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(87, 32);
            this.btn_OK.TabIndex = 16;
            this.btn_OK.Text = "Bewerken";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Naam:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(263, 124);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(87, 32);
            this.btn_Cancel.TabIndex = 27;
            this.btn_Cancel.Text = "Annuleren";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_Aantal
            // 
            this.txt_Aantal.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Aantal.Location = new System.Drawing.Point(112, 71);
            this.txt_Aantal.Name = "txt_Aantal";
            this.txt_Aantal.Size = new System.Drawing.Size(238, 20);
            this.txt_Aantal.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Aantal:";
            // 
            // list_Subcategorie
            // 
            this.list_Subcategorie.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.list_Subcategorie.FormattingEnabled = true;
            this.list_Subcategorie.Location = new System.Drawing.Point(112, 97);
            this.list_Subcategorie.Name = "list_Subcategorie";
            this.list_Subcategorie.Size = new System.Drawing.Size(238, 21);
            this.list_Subcategorie.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Prijs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Subcategorie:";
            // 
            // txt_Prijs
            // 
            this.txt_Prijs.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Prijs.Location = new System.Drawing.Point(112, 45);
            this.txt_Prijs.Name = "txt_Prijs";
            this.txt_Prijs.Size = new System.Drawing.Size(238, 20);
            this.txt_Prijs.TabIndex = 23;
            // 
            // ProductUpdaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 213);
            this.Controls.Add(this.lbl_Categorie);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductUpdaten";
            this.Text = "Product bewerken";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Aantal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Categorie;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Naam;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.NumericUpDown txt_Aantal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox list_Subcategorie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Prijs;
    }
}