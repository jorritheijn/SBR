namespace RBS
{
    partial class Afrekenen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.totaalTxt = new System.Windows.Forms.Label();
            this.pin = new System.Windows.Forms.Button();
            this.cash = new System.Windows.Forms.Button();
            this.creditcard = new System.Windows.Forms.Button();
            this.printBon = new System.Windows.Forms.Button();
            this.btwTxt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.terugBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(-1, 24);
            this.label1.MinimumSize = new System.Drawing.Size(800, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.label1.Size = new System.Drawing.Size(800, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tafel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aantal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(389, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Prijs";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(6, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 24);
            this.listBox1.TabIndex = 5;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(305, 3);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(51, 24);
            this.listBox2.TabIndex = 6;
            // 
            // listBox3
            // 
            this.listBox3.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(362, 3);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(55, 24);
            this.listBox3.TabIndex = 7;
            // 
            // totaalTxt
            // 
            this.totaalTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.totaalTxt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaalTxt.Location = new System.Drawing.Point(0, 54);
            this.totaalTxt.Name = "totaalTxt";
            this.totaalTxt.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.totaalTxt.Size = new System.Drawing.Size(442, 20);
            this.totaalTxt.TabIndex = 8;
            this.totaalTxt.Text = "Totaal: 0,00";
            this.totaalTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pin
            // 
            this.pin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pin.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.pin.FlatAppearance.BorderSize = 4;
            this.pin.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pin.Location = new System.Drawing.Point(16, 514);
            this.pin.Name = "pin";
            this.pin.Size = new System.Drawing.Size(125, 75);
            this.pin.TabIndex = 9;
            this.pin.Text = "Pin";
            this.pin.UseVisualStyleBackColor = true;
            this.pin.Click += new System.EventHandler(this.afronding_Click);
            // 
            // cash
            // 
            this.cash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cash.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.cash.FlatAppearance.BorderSize = 4;
            this.cash.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cash.Location = new System.Drawing.Point(157, 514);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(125, 75);
            this.cash.TabIndex = 10;
            this.cash.Text = "Cash";
            this.cash.UseVisualStyleBackColor = true;
            this.cash.Click += new System.EventHandler(this.afronding_Click);
            // 
            // creditcard
            // 
            this.creditcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.creditcard.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.creditcard.FlatAppearance.BorderSize = 4;
            this.creditcard.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creditcard.Location = new System.Drawing.Point(302, 514);
            this.creditcard.Name = "creditcard";
            this.creditcard.Size = new System.Drawing.Size(125, 75);
            this.creditcard.TabIndex = 11;
            this.creditcard.Text = "Creditcard";
            this.creditcard.UseVisualStyleBackColor = true;
            this.creditcard.Click += new System.EventHandler(this.afronding_Click);
            // 
            // printBon
            // 
            this.printBon.BackColor = System.Drawing.SystemColors.Control;
            this.printBon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printBon.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.printBon.FlatAppearance.BorderSize = 4;
            this.printBon.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBon.Location = new System.Drawing.Point(157, 420);
            this.printBon.Name = "printBon";
            this.printBon.Size = new System.Drawing.Size(125, 75);
            this.printBon.TabIndex = 12;
            this.printBon.Text = "Print bon";
            this.printBon.UseVisualStyleBackColor = false;
            this.printBon.Click += new System.EventHandler(this.printBon_Click);
            // 
            // btwTxt
            // 
            this.btwTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btwTxt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btwTxt.Location = new System.Drawing.Point(0, 27);
            this.btwTxt.Name = "btwTxt";
            this.btwTxt.Padding = new System.Windows.Forms.Padding(0, 9, 25, 0);
            this.btwTxt.Size = new System.Drawing.Size(442, 27);
            this.btwTxt.TabIndex = 0;
            this.btwTxt.Text = "BTW:  0,00";
            this.btwTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.btwTxt);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.listBox3);
            this.panel1.Controls.Add(this.totaalTxt);
            this.panel1.Location = new System.Drawing.Point(10, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 74);
            this.panel1.TabIndex = 13;
            // 
            // terugBtn
            // 
            this.terugBtn.BackColor = System.Drawing.Color.DarkRed;
            this.terugBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terugBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.terugBtn.Location = new System.Drawing.Point(372, 9);
            this.terugBtn.Name = "terugBtn";
            this.terugBtn.Size = new System.Drawing.Size(80, 40);
            this.terugBtn.TabIndex = 14;
            this.terugBtn.Text = "Terug";
            this.terugBtn.UseVisualStyleBackColor = false;
            this.terugBtn.Click += new System.EventHandler(this.terugBtn_Click);
            // 
            // Afrekenen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.terugBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.printBon);
            this.Controls.Add(this.creditcard);
            this.Controls.Add(this.cash);
            this.Controls.Add(this.pin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Afrekenen";
            this.Text = "Afrekenen";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label totaalTxt;
        private System.Windows.Forms.Button pin;
        private System.Windows.Forms.Button cash;
        private System.Windows.Forms.Button creditcard;
        private System.Windows.Forms.Button printBon;
        private System.Windows.Forms.Label btwTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button terugBtn;
    }
}