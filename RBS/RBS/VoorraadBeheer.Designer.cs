namespace RBS
{
    partial class VoorraadBeheer
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
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_Diner = new System.Windows.Forms.Button();
            this.btn_Verwijder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_prijs = new System.Windows.Forms.Label();
            this.list_Prijs = new System.Windows.Forms.ListBox();
            this.list_Aantal = new System.Windows.Forms.ListBox();
            this.list_Producten = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Lunch = new System.Windows.Forms.Button();
            this.btn_Toevoeg = new System.Windows.Forms.Button();
            this.btn_Drank = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(12, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Manager";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(377, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Log uit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_Diner);
            this.tabPage3.Controls.Add(this.btn_Verwijder);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.btn_Lunch);
            this.tabPage3.Controls.Add(this.btn_Toevoeg);
            this.tabPage3.Controls.Add(this.btn_Drank);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(455, 549);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Voorraad";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_Diner
            // 
            this.btn_Diner.Location = new System.Drawing.Point(6, 95);
            this.btn_Diner.Name = "btn_Diner";
            this.btn_Diner.Size = new System.Drawing.Size(69, 23);
            this.btn_Diner.TabIndex = 5;
            this.btn_Diner.Text = "Diner";
            this.btn_Diner.UseVisualStyleBackColor = true;
            this.btn_Diner.Click += new System.EventHandler(this.btn_Diner_Click);
            // 
            // btn_Verwijder
            // 
            this.btn_Verwijder.Location = new System.Drawing.Point(304, 508);
            this.btn_Verwijder.Name = "btn_Verwijder";
            this.btn_Verwijder.Size = new System.Drawing.Size(143, 31);
            this.btn_Verwijder.TabIndex = 7;
            this.btn_Verwijder.Text = "Product verwijderen";
            this.btn_Verwijder.UseVisualStyleBackColor = true;
            this.btn_Verwijder.Click += new System.EventHandler(this.btn_Verwijder_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_prijs);
            this.panel1.Controls.Add(this.list_Prijs);
            this.panel1.Controls.Add(this.list_Aantal);
            this.panel1.Controls.Add(this.list_Producten);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(88, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 484);
            this.panel1.TabIndex = 4;
            // 
            // label_prijs
            // 
            this.label_prijs.AutoSize = true;
            this.label_prijs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_prijs.Location = new System.Drawing.Point(225, 3);
            this.label_prijs.Name = "label_prijs";
            this.label_prijs.Size = new System.Drawing.Size(35, 17);
            this.label_prijs.TabIndex = 9;
            this.label_prijs.Text = "Prijs";
            // 
            // list_Prijs
            // 
            this.list_Prijs.FormattingEnabled = true;
            this.list_Prijs.Location = new System.Drawing.Point(228, 37);
            this.list_Prijs.Name = "list_Prijs";
            this.list_Prijs.Size = new System.Drawing.Size(76, 420);
            this.list_Prijs.TabIndex = 8;
            // 
            // list_Aantal
            // 
            this.list_Aantal.FormattingEnabled = true;
            this.list_Aantal.Location = new System.Drawing.Point(310, 37);
            this.list_Aantal.Name = "list_Aantal";
            this.list_Aantal.Size = new System.Drawing.Size(56, 420);
            this.list_Aantal.TabIndex = 4;
            this.list_Aantal.SelectedIndexChanged += new System.EventHandler(this.list_Aantal_SelectedIndexChanged);
            // 
            // list_Producten
            // 
            this.list_Producten.FormattingEnabled = true;
            this.list_Producten.HorizontalScrollbar = true;
            this.list_Producten.Location = new System.Drawing.Point(-2, 38);
            this.list_Producten.Name = "list_Producten";
            this.list_Producten.Size = new System.Drawing.Size(224, 420);
            this.list_Producten.TabIndex = 3;
            this.list_Producten.SelectedIndexChanged += new System.EventHandler(this.list_Producten_SelectedIndexChanged);
            this.list_Producten.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_Producten_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.Location = new System.Drawing.Point(311, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aantal";
            // 
            // btn_Lunch
            // 
            this.btn_Lunch.Location = new System.Drawing.Point(6, 66);
            this.btn_Lunch.Name = "btn_Lunch";
            this.btn_Lunch.Size = new System.Drawing.Size(69, 23);
            this.btn_Lunch.TabIndex = 2;
            this.btn_Lunch.Text = "Lunch";
            this.btn_Lunch.UseVisualStyleBackColor = true;
            this.btn_Lunch.Click += new System.EventHandler(this.btn_Lunch_Click);
            // 
            // btn_Toevoeg
            // 
            this.btn_Toevoeg.Location = new System.Drawing.Point(87, 508);
            this.btn_Toevoeg.Name = "btn_Toevoeg";
            this.btn_Toevoeg.Size = new System.Drawing.Size(143, 31);
            this.btn_Toevoeg.TabIndex = 6;
            this.btn_Toevoeg.Text = "Product toevoegen";
            this.btn_Toevoeg.UseVisualStyleBackColor = true;
            this.btn_Toevoeg.Click += new System.EventHandler(this.btn_Toevoeg_Click);
            // 
            // btn_Drank
            // 
            this.btn_Drank.Location = new System.Drawing.Point(6, 124);
            this.btn_Drank.Name = "btn_Drank";
            this.btn_Drank.Size = new System.Drawing.Size(69, 23);
            this.btn_Drank.TabIndex = 3;
            this.btn_Drank.Text = "Dranken";
            this.btn_Drank.UseVisualStyleBackColor = true;
            this.btn_Drank.Click += new System.EventHandler(this.btn_Drank_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personeelszaken";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(463, 575);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.goPersoneel);
            // 
            // VoorraadBeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tabControl1);
            this.Name = "VoorraadBeheer";
            this.Text = "VoorraadBeheer";
            this.Activated += new System.EventHandler(this.VoorraadBeheer_Activated);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_Diner;
        private System.Windows.Forms.Button btn_Lunch;
        private System.Windows.Forms.Button btn_Drank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btn_Verwijder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox list_Prijs;
        private System.Windows.Forms.ListBox list_Aantal;
        private System.Windows.Forms.ListBox list_Producten;
        private System.Windows.Forms.Button btn_Toevoeg;
        private System.Windows.Forms.Label label_prijs;
    }
}