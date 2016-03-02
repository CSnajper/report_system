namespace Zgloszenia
{
    partial class StatystykiUzytkownika
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatystykiUzytkownika));
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelZgloszeniaInfo = new System.Windows.Forms.Label();
            this.labelZgloszeniaDane = new System.Windows.Forms.Label();
            this.labelCzasOnlineInfo = new System.Windows.Forms.Label();
            this.labelCzasOnlineDane = new System.Windows.Forms.Label();
            this.labelSrednioDane = new System.Windows.Forms.Label();
            this.labelSredniaInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLogin.Location = new System.Drawing.Point(6, 9);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(45, 19);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "label1";
            // 
            // labelZgloszeniaInfo
            // 
            this.labelZgloszeniaInfo.AutoSize = true;
            this.labelZgloszeniaInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZgloszeniaInfo.Location = new System.Drawing.Point(6, 37);
            this.labelZgloszeniaInfo.Name = "labelZgloszeniaInfo";
            this.labelZgloszeniaInfo.Size = new System.Drawing.Size(152, 19);
            this.labelZgloszeniaInfo.TabIndex = 3;
            this.labelZgloszeniaInfo.Text = "Rozpatrzone zgłoszenia:";
            // 
            // labelZgloszeniaDane
            // 
            this.labelZgloszeniaDane.AutoSize = true;
            this.labelZgloszeniaDane.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZgloszeniaDane.Location = new System.Drawing.Point(14, 56);
            this.labelZgloszeniaDane.Name = "labelZgloszeniaDane";
            this.labelZgloszeniaDane.Size = new System.Drawing.Size(42, 17);
            this.labelZgloszeniaDane.TabIndex = 4;
            this.labelZgloszeniaDane.Text = "label1";
            // 
            // labelCzasOnlineInfo
            // 
            this.labelCzasOnlineInfo.AutoSize = true;
            this.labelCzasOnlineInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCzasOnlineInfo.Location = new System.Drawing.Point(6, 96);
            this.labelCzasOnlineInfo.Name = "labelCzasOnlineInfo";
            this.labelCzasOnlineInfo.Size = new System.Drawing.Size(82, 19);
            this.labelCzasOnlineInfo.TabIndex = 5;
            this.labelCzasOnlineInfo.Text = "Czas Online";
            // 
            // labelCzasOnlineDane
            // 
            this.labelCzasOnlineDane.AutoSize = true;
            this.labelCzasOnlineDane.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCzasOnlineDane.Location = new System.Drawing.Point(14, 115);
            this.labelCzasOnlineDane.Name = "labelCzasOnlineDane";
            this.labelCzasOnlineDane.Size = new System.Drawing.Size(42, 17);
            this.labelCzasOnlineDane.TabIndex = 6;
            this.labelCzasOnlineDane.Text = "label1";
            // 
            // labelSrednioDane
            // 
            this.labelSrednioDane.AutoSize = true;
            this.labelSrednioDane.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSrednioDane.Location = new System.Drawing.Point(13, 179);
            this.labelSrednioDane.Name = "labelSrednioDane";
            this.labelSrednioDane.Size = new System.Drawing.Size(42, 17);
            this.labelSrednioDane.TabIndex = 7;
            this.labelSrednioDane.Text = "label1";
            // 
            // labelSredniaInfo
            // 
            this.labelSredniaInfo.AutoSize = true;
            this.labelSredniaInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSredniaInfo.Location = new System.Drawing.Point(6, 160);
            this.labelSredniaInfo.Name = "labelSredniaInfo";
            this.labelSredniaInfo.Size = new System.Drawing.Size(58, 19);
            this.labelSredniaInfo.TabIndex = 8;
            this.labelSredniaInfo.Text = "Średnia:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StatystykiUzytkownika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelSredniaInfo);
            this.Controls.Add(this.labelSrednioDane);
            this.Controls.Add(this.labelCzasOnlineDane);
            this.Controls.Add(this.labelCzasOnlineInfo);
            this.Controls.Add(this.labelZgloszeniaDane);
            this.Controls.Add(this.labelZgloszeniaInfo);
            this.Controls.Add(this.labelLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(286, 300);
            this.MinimumSize = new System.Drawing.Size(286, 300);
            this.Name = "StatystykiUzytkownika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatystykiUzytkownika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelZgloszeniaInfo;
        private System.Windows.Forms.Label labelZgloszeniaDane;
        private System.Windows.Forms.Label labelCzasOnlineInfo;
        private System.Windows.Forms.Label labelCzasOnlineDane;
        private System.Windows.Forms.Label labelSrednioDane;
        private System.Windows.Forms.Label labelSredniaInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}