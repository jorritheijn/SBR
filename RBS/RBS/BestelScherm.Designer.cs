namespace RBS
{
    partial class BestelScherm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLunch = new System.Windows.Forms.TabPage();
            this.tabPageDiner = new System.Windows.Forms.TabPage();
            this.tabPageFris = new System.Windows.Forms.TabPage();
            this.tabPageDrank = new System.Windows.Forms.TabPage();
            this.tabPageKoffieThee = new System.Windows.Forms.TabPage();
            this.btnVerwerkBestelling = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageLunch);
            this.tabControl.Controls.Add(this.tabPageDiner);
            this.tabControl.Controls.Add(this.tabPageFris);
            this.tabControl.Controls.Add(this.tabPageDrank);
            this.tabControl.Controls.Add(this.tabPageKoffieThee);
            this.tabControl.Location = new System.Drawing.Point(17, 48);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(585, 557);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageLunch
            // 
            this.tabPageLunch.AutoScroll = true;
            this.tabPageLunch.Location = new System.Drawing.Point(4, 25);
            this.tabPageLunch.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageLunch.Name = "tabPageLunch";
            this.tabPageLunch.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageLunch.Size = new System.Drawing.Size(577, 528);
            this.tabPageLunch.TabIndex = 0;
            this.tabPageLunch.Text = "Lunch";
            this.tabPageLunch.UseVisualStyleBackColor = true;
            // 
            // tabPageDiner
            // 
            this.tabPageDiner.AutoScroll = true;
            this.tabPageDiner.Location = new System.Drawing.Point(4, 25);
            this.tabPageDiner.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDiner.Name = "tabPageDiner";
            this.tabPageDiner.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageDiner.Size = new System.Drawing.Size(577, 560);
            this.tabPageDiner.TabIndex = 1;
            this.tabPageDiner.Text = "Diner";
            this.tabPageDiner.UseVisualStyleBackColor = true;
            // 
            // tabPageFris
            // 
            this.tabPageFris.AutoScroll = true;
            this.tabPageFris.Location = new System.Drawing.Point(4, 25);
            this.tabPageFris.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageFris.Name = "tabPageFris";
            this.tabPageFris.Size = new System.Drawing.Size(577, 560);
            this.tabPageFris.TabIndex = 2;
            this.tabPageFris.Text = "Frisdranken";
            this.tabPageFris.UseVisualStyleBackColor = true;
            // 
            // tabPageDrank
            // 
            this.tabPageDrank.AutoScroll = true;
            this.tabPageDrank.Location = new System.Drawing.Point(4, 25);
            this.tabPageDrank.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageDrank.Name = "tabPageDrank";
            this.tabPageDrank.Size = new System.Drawing.Size(577, 560);
            this.tabPageDrank.TabIndex = 3;
            this.tabPageDrank.Text = "Alcoholhoudend";
            this.tabPageDrank.UseVisualStyleBackColor = true;
            // 
            // tabPageKoffieThee
            // 
            this.tabPageKoffieThee.AutoScroll = true;
            this.tabPageKoffieThee.Location = new System.Drawing.Point(4, 25);
            this.tabPageKoffieThee.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageKoffieThee.Name = "tabPageKoffieThee";
            this.tabPageKoffieThee.Size = new System.Drawing.Size(577, 560);
            this.tabPageKoffieThee.TabIndex = 4;
            this.tabPageKoffieThee.Text = "Warme dranken";
            this.tabPageKoffieThee.UseVisualStyleBackColor = true;
            // 
            // btnVerwerkBestelling
            // 
            this.btnVerwerkBestelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerwerkBestelling.Location = new System.Drawing.Point(17, 613);
            this.btnVerwerkBestelling.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerwerkBestelling.Name = "btnVerwerkBestelling";
            this.btnVerwerkBestelling.Size = new System.Drawing.Size(585, 114);
            this.btnVerwerkBestelling.TabIndex = 2;
            this.btnVerwerkBestelling.Text = "Bestelling gereed";
            this.btnVerwerkBestelling.UseVisualStyleBackColor = true;
            this.btnVerwerkBestelling.Click += new System.EventHandler(this.btnVerwerkBestelling_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Crimson;
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(479, 13);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 12;
            this.button3.Text = "Log uit";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // BestelScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 740);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnVerwerkBestelling);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BestelScherm";
            this.Text = "Bestelling opnemen";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLunch;
        private System.Windows.Forms.TabPage tabPageDiner;
        private System.Windows.Forms.TabPage tabPageFris;
        private System.Windows.Forms.TabPage tabPageDrank;
        private System.Windows.Forms.TabPage tabPageKoffieThee;
        private System.Windows.Forms.Button btnVerwerkBestelling;
        private System.Windows.Forms.Button button3;
    }
}