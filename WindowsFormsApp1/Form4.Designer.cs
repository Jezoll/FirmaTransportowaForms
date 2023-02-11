namespace WindowsFormsApp1
{
    partial class Form4
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonWyjdz = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Zarządzaj taborem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(179, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Zarządzaj spedycjami";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonWyjdz
            // 
            this.buttonWyjdz.Location = new System.Drawing.Point(123, 225);
            this.buttonWyjdz.Name = "buttonWyjdz";
            this.buttonWyjdz.Size = new System.Drawing.Size(151, 23);
            this.buttonWyjdz.TabIndex = 2;
            this.buttonWyjdz.Text = "Wyjdź";
            this.buttonWyjdz.UseVisualStyleBackColor = true;
            this.buttonWyjdz.Click += new System.EventHandler(this.buttonWyjdz_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(113, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(179, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Dodaj kierowce";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 349);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonWyjdz);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonWyjdz;
        private System.Windows.Forms.Button button3;
    }
}