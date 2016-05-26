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
            this.SuspendLayout();
            // 
            // lstAccounts
            // 
            this.lstAccounts.Location = new System.Drawing.Point(22, 161);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(571, 296);
            this.lstAccounts.TabIndex = 0;
            this.lstAccounts.UseCompatibleStateImageBehavior = false;
            // 
            // PersoneelsBeheer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 559);
            this.Controls.Add(this.lstAccounts);
            this.Name = "PersoneelsBeheer";
            this.Text = "PersoneelsBeheer";
            this.Shown += new System.EventHandler(this.PersoneelsBeheer_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstAccounts;
    }
}