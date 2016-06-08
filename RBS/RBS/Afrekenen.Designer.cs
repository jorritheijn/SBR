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
            this.label5 = new System.Windows.Forms.Label();
            this.pin = new System.Windows.Forms.Button();
            this.cash = new System.Windows.Forms.Button();
            this.creditcard = new System.Windows.Forms.Button();
            this.printBon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(-1, 24);
            this.label1.MinimumSize = new System.Drawing.Size(800, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.label1.Size = new System.Drawing.Size(800, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tafel";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Aantal";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Prijs";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(16, 57);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(173, 95);
            this.listBox1.TabIndex = 5;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(199, 57);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(32, 95);
            this.listBox2.TabIndex = 6;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(238, 57);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(51, 95);
            this.listBox3.TabIndex = 7;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.Location = new System.Drawing.Point(197, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Totaal: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pin
            // 
            this.pin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pin.Enabled = false;
            this.pin.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.pin.FlatAppearance.BorderSize = 4;
            this.pin.Location = new System.Drawing.Point(10, 407);
            this.pin.Name = "pin";
            this.pin.Size = new System.Drawing.Size(93, 54);
            this.pin.TabIndex = 9;
            this.pin.Text = "Pin";
            this.pin.UseVisualStyleBackColor = true;
            this.pin.Click += new System.EventHandler(this.afronding_Click);
            // 
            // cash
            // 
            this.cash.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cash.Enabled = false;
            this.cash.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.cash.FlatAppearance.BorderSize = 4;
            this.cash.Location = new System.Drawing.Point(125, 407);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(93, 54);
            this.cash.TabIndex = 10;
            this.cash.Text = "Cash";
            this.cash.UseVisualStyleBackColor = true;
            this.cash.Click += new System.EventHandler(this.afronding_Click);
            // 
            // creditcard
            // 
            this.creditcard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.creditcard.Enabled = false;
            this.creditcard.FlatAppearance.BorderColor = System.Drawing.Color.DarkOliveGreen;
            this.creditcard.FlatAppearance.BorderSize = 4;
            this.creditcard.Location = new System.Drawing.Point(240, 407);
            this.creditcard.Name = "creditcard";
            this.creditcard.Size = new System.Drawing.Size(93, 54);
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
            this.printBon.Location = new System.Drawing.Point(125, 337);
            this.printBon.Name = "printBon";
            this.printBon.Size = new System.Drawing.Size(93, 54);
            this.printBon.TabIndex = 12;
            this.printBon.Text = "Print bon";
            this.printBon.UseVisualStyleBackColor = false;
            this.printBon.Click += new System.EventHandler(this.printBon_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.Location = new System.Drawing.Point(196, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "BTW: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Afrekenen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 473);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.printBon);
            this.Controls.Add(this.creditcard);
            this.Controls.Add(this.cash);
            this.Controls.Add(this.pin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Afrekenen";
            this.Text = "Afrekenen";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button pin;
        private System.Windows.Forms.Button cash;
        private System.Windows.Forms.Button creditcard;
        private System.Windows.Forms.Button printBon;
        private System.Windows.Forms.Label label6;
    }
}