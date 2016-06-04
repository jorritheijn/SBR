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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLunch = new System.Windows.Forms.TabPage();
            this.tabPageDiner = new System.Windows.Forms.TabPage();
            this.tabPageFris = new System.Windows.Forms.TabPage();
            this.tabPageDrank = new System.Windows.Forms.TabPage();
            this.tabPageKoffieThee = new System.Windows.Forms.TabPage();
            this.lstProducten = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLunch);
            this.tabControl1.Controls.Add(this.tabPageDiner);
            this.tabControl1.Controls.Add(this.tabPageFris);
            this.tabControl1.Controls.Add(this.tabPageDrank);
            this.tabControl1.Controls.Add(this.tabPageKoffieThee);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 339);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageLunch
            // 
            this.tabPageLunch.Location = new System.Drawing.Point(4, 22);
            this.tabPageLunch.Name = "tabPageLunch";
            this.tabPageLunch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLunch.Size = new System.Drawing.Size(550, 313);
            this.tabPageLunch.TabIndex = 0;
            this.tabPageLunch.Text = "Lunch";
            this.tabPageLunch.UseVisualStyleBackColor = true;
            // 
            // tabPageDiner
            // 
            this.tabPageDiner.AutoScroll = true;
            this.tabPageDiner.Location = new System.Drawing.Point(4, 22);
            this.tabPageDiner.Name = "tabPageDiner";
            this.tabPageDiner.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDiner.Size = new System.Drawing.Size(550, 313);
            this.tabPageDiner.TabIndex = 1;
            this.tabPageDiner.Text = "Diner";
            this.tabPageDiner.UseVisualStyleBackColor = true;
            // 
            // tabPageFris
            // 
            this.tabPageFris.Location = new System.Drawing.Point(4, 22);
            this.tabPageFris.Name = "tabPageFris";
            this.tabPageFris.Size = new System.Drawing.Size(550, 313);
            this.tabPageFris.TabIndex = 2;
            this.tabPageFris.Text = "Frisdranken";
            this.tabPageFris.UseVisualStyleBackColor = true;
            // 
            // tabPageDrank
            // 
            this.tabPageDrank.Location = new System.Drawing.Point(4, 22);
            this.tabPageDrank.Name = "tabPageDrank";
            this.tabPageDrank.Size = new System.Drawing.Size(550, 313);
            this.tabPageDrank.TabIndex = 3;
            this.tabPageDrank.Text = "Alcoholhoudend";
            this.tabPageDrank.UseVisualStyleBackColor = true;
            // 
            // tabPageKoffieThee
            // 
            this.tabPageKoffieThee.Location = new System.Drawing.Point(4, 22);
            this.tabPageKoffieThee.Name = "tabPageKoffieThee";
            this.tabPageKoffieThee.Size = new System.Drawing.Size(550, 313);
            this.tabPageKoffieThee.TabIndex = 4;
            this.tabPageKoffieThee.Text = "Warme dranken";
            this.tabPageKoffieThee.UseVisualStyleBackColor = true;
            // 
            // lstProducten
            // 
            this.lstProducten.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colNum});
            this.lstProducten.Location = new System.Drawing.Point(17, 358);
            this.lstProducten.Name = "lstProducten";
            this.lstProducten.Size = new System.Drawing.Size(394, 243);
            this.lstProducten.TabIndex = 1;
            this.lstProducten.UseCompatibleStateImageBehavior = false;
            // 
            // colName
            // 
            this.colName.Text = "Producten";
            this.colName.Width = 250;
            // 
            // colNum
            // 
            this.colNum.Text = "Aantal";
            this.colNum.Width = 50;
            // 
            // BestelScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 613);
            this.Controls.Add(this.lstProducten);
            this.Controls.Add(this.tabControl1);
            this.Name = "BestelScherm";
            this.Text = "BestelScherm";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLunch;
        private System.Windows.Forms.TabPage tabPageDiner;
        private System.Windows.Forms.TabPage tabPageFris;
        private System.Windows.Forms.TabPage tabPageDrank;
        private System.Windows.Forms.TabPage tabPageKoffieThee;
        private System.Windows.Forms.ListView lstProducten;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colNum;
    }
}