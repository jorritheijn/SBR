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
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLunch);
            this.tabControl1.Controls.Add(this.tabPageDiner);
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
            this.tabPageLunch.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
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
            this.tabPageDiner.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageDiner.Size = new System.Drawing.Size(550, 313);
            this.tabPageDiner.TabIndex = 1;
            this.tabPageDiner.Text = "Diner";
            this.tabPageDiner.UseVisualStyleBackColor = true;
            // 
            // BestelScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 613);
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
    }
}