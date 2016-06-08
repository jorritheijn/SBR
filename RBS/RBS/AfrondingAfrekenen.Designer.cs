namespace RBS
{
    partial class AfrondingAfrekenen
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.afrondButton = new System.Windows.Forms.Button();
            this.commentaarBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.terugBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(38, 95);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(379, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fooi";
            // 
            // afrondButton
            // 
            this.afrondButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.afrondButton.Location = new System.Drawing.Point(134, 465);
            this.afrondButton.Name = "afrondButton";
            this.afrondButton.Size = new System.Drawing.Size(183, 93);
            this.afrondButton.TabIndex = 2;
            this.afrondButton.Text = "Afronden Rekening";
            this.afrondButton.UseVisualStyleBackColor = true;
            this.afrondButton.Click += new System.EventHandler(this.afrondButton_Click);
            // 
            // commentaarBox
            // 
            this.commentaarBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentaarBox.Location = new System.Drawing.Point(38, 171);
            this.commentaarBox.Multiline = true;
            this.commentaarBox.Name = "commentaarBox";
            this.commentaarBox.Size = new System.Drawing.Size(379, 232);
            this.commentaarBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Commentaar (255 characters)";
            // 
            // terugBtn
            // 
            this.terugBtn.BackColor = System.Drawing.Color.DarkRed;
            this.terugBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terugBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.terugBtn.Location = new System.Drawing.Point(372, 12);
            this.terugBtn.Name = "terugBtn";
            this.terugBtn.Size = new System.Drawing.Size(80, 40);
            this.terugBtn.TabIndex = 5;
            this.terugBtn.Text = "Terug";
            this.terugBtn.UseVisualStyleBackColor = false;
            this.terugBtn.Click += new System.EventHandler(this.terugBtn_Click);
            // 
            // AfrondingAfrekenen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 601);
            this.Controls.Add(this.terugBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commentaarBox);
            this.Controls.Add(this.afrondButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "AfrondingAfrekenen";
            this.Text = "AfrondingAfrekenen";
            this.Load += new System.EventHandler(this.AfrondingAfrekenen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button afrondButton;
        private System.Windows.Forms.TextBox commentaarBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button terugBtn;
    }
}