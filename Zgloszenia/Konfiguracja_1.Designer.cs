namespace Zgloszenia
{
    partial class Konfiguracja_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Konfiguracja_1));
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelBaza = new System.Windows.Forms.Panel();
            this.labelBazaWarning = new System.Windows.Forms.Label();
            this.buttonPolaczzBaza = new System.Windows.Forms.Button();
            this.labelBazaProgresInfo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxBazaHaslo = new System.Windows.Forms.TextBox();
            this.textBoxBazaUzytkownik = new System.Windows.Forms.TextBox();
            this.textBoxBazaBaza = new System.Windows.Forms.TextBox();
            this.labelBazaHaslo = new System.Windows.Forms.Label();
            this.labelBazaUzytkownik = new System.Windows.Forms.Label();
            this.labelBazaBaza = new System.Windows.Forms.Label();
            this.textBoxBazaHost = new System.Windows.Forms.TextBox();
            this.labelBazaHost = new System.Windows.Forms.Label();
            this.labelWarning = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.buttonDalej = new System.Windows.Forms.Button();
            this.buttonWroc = new System.Windows.Forms.Button();
            this.panelStworzUzytkownika = new System.Windows.Forms.Panel();
            this.textBoxKontoHaslo2 = new System.Windows.Forms.TextBox();
            this.labelKontoHaslo2 = new System.Windows.Forms.Label();
            this.textBoxKontoHaslo1 = new System.Windows.Forms.TextBox();
            this.labelKontoHaslo1 = new System.Windows.Forms.Label();
            this.textBoxKontoLogin = new System.Windows.Forms.TextBox();
            this.labelKontoLogin = new System.Windows.Forms.Label();
            this.panelUstawienia = new System.Windows.Forms.Panel();
            this.textBoxKontaktMail = new System.Windows.Forms.TextBox();
            this.labelKontaktMail = new System.Windows.Forms.Label();
            this.labelInfoWymagane = new System.Windows.Forms.Label();
            this.textBoxKontaktSteam = new System.Windows.Forms.TextBox();
            this.labelKontaktSteam = new System.Windows.Forms.Label();
            this.textBoxNickHeadAdmina = new System.Windows.Forms.TextBox();
            this.labelNickHeadAdmina = new System.Windows.Forms.Label();
            this.textBoxNazwaSieci = new System.Windows.Forms.TextBox();
            this.labelNazwaSieci = new System.Windows.Forms.Label();
            this.buttonZakoncz = new System.Windows.Forms.Button();
            this.panelBaza.SuspendLayout();
            this.panelStworzUzytkownika.SuspendLayout();
            this.panelUstawienia.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHeader.Location = new System.Drawing.Point(125, 9);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(284, 24);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Konfiguracja systemu zgłoszeń";
            // 
            // panelBaza
            // 
            this.panelBaza.Controls.Add(this.labelBazaWarning);
            this.panelBaza.Controls.Add(this.buttonPolaczzBaza);
            this.panelBaza.Controls.Add(this.labelBazaProgresInfo);
            this.panelBaza.Controls.Add(this.progressBar1);
            this.panelBaza.Controls.Add(this.textBoxBazaHaslo);
            this.panelBaza.Controls.Add(this.textBoxBazaUzytkownik);
            this.panelBaza.Controls.Add(this.textBoxBazaBaza);
            this.panelBaza.Controls.Add(this.labelBazaHaslo);
            this.panelBaza.Controls.Add(this.labelBazaUzytkownik);
            this.panelBaza.Controls.Add(this.labelBazaBaza);
            this.panelBaza.Controls.Add(this.textBoxBazaHost);
            this.panelBaza.Controls.Add(this.labelBazaHost);
            this.panelBaza.Location = new System.Drawing.Point(12, 92);
            this.panelBaza.Name = "panelBaza";
            this.panelBaza.Size = new System.Drawing.Size(517, 264);
            this.panelBaza.TabIndex = 1;
            // 
            // labelBazaWarning
            // 
            this.labelBazaWarning.AutoSize = true;
            this.labelBazaWarning.Location = new System.Drawing.Point(186, 25);
            this.labelBazaWarning.Name = "labelBazaWarning";
            this.labelBazaWarning.Size = new System.Drawing.Size(35, 13);
            this.labelBazaWarning.TabIndex = 14;
            this.labelBazaWarning.Text = "label1";
            // 
            // buttonPolaczzBaza
            // 
            this.buttonPolaczzBaza.Location = new System.Drawing.Point(9, 167);
            this.buttonPolaczzBaza.Name = "buttonPolaczzBaza";
            this.buttonPolaczzBaza.Size = new System.Drawing.Size(84, 23);
            this.buttonPolaczzBaza.TabIndex = 13;
            this.buttonPolaczzBaza.Text = "Połącz z bazą";
            this.buttonPolaczzBaza.UseVisualStyleBackColor = true;
            this.buttonPolaczzBaza.Click += new System.EventHandler(this.buttonPolaczzBaza_Click);
            // 
            // labelBazaProgresInfo
            // 
            this.labelBazaProgresInfo.AutoSize = true;
            this.labelBazaProgresInfo.Location = new System.Drawing.Point(3, 212);
            this.labelBazaProgresInfo.Name = "labelBazaProgresInfo";
            this.labelBazaProgresInfo.Size = new System.Drawing.Size(35, 13);
            this.labelBazaProgresInfo.TabIndex = 12;
            this.labelBazaProgresInfo.Text = "label1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 228);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(495, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // textBoxBazaHaslo
            // 
            this.textBoxBazaHaslo.Location = new System.Drawing.Point(9, 141);
            this.textBoxBazaHaslo.Name = "textBoxBazaHaslo";
            this.textBoxBazaHaslo.Size = new System.Drawing.Size(149, 20);
            this.textBoxBazaHaslo.TabIndex = 10;
            this.textBoxBazaHaslo.UseSystemPasswordChar = true;
            // 
            // textBoxBazaUzytkownik
            // 
            this.textBoxBazaUzytkownik.Location = new System.Drawing.Point(9, 100);
            this.textBoxBazaUzytkownik.Name = "textBoxBazaUzytkownik";
            this.textBoxBazaUzytkownik.Size = new System.Drawing.Size(149, 20);
            this.textBoxBazaUzytkownik.TabIndex = 9;
            // 
            // textBoxBazaBaza
            // 
            this.textBoxBazaBaza.Location = new System.Drawing.Point(9, 59);
            this.textBoxBazaBaza.Name = "textBoxBazaBaza";
            this.textBoxBazaBaza.Size = new System.Drawing.Size(149, 20);
            this.textBoxBazaBaza.TabIndex = 8;
            // 
            // labelBazaHaslo
            // 
            this.labelBazaHaslo.AutoSize = true;
            this.labelBazaHaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBazaHaslo.Location = new System.Drawing.Point(6, 123);
            this.labelBazaHaslo.Name = "labelBazaHaslo";
            this.labelBazaHaslo.Size = new System.Drawing.Size(42, 15);
            this.labelBazaHaslo.TabIndex = 7;
            this.labelBazaHaslo.Text = "Hasło:";
            // 
            // labelBazaUzytkownik
            // 
            this.labelBazaUzytkownik.AutoSize = true;
            this.labelBazaUzytkownik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBazaUzytkownik.Location = new System.Drawing.Point(6, 82);
            this.labelBazaUzytkownik.Name = "labelBazaUzytkownik";
            this.labelBazaUzytkownik.Size = new System.Drawing.Size(144, 15);
            this.labelBazaUzytkownik.TabIndex = 6;
            this.labelBazaUzytkownik.Text = "Użytkownik bazy danych::";
            // 
            // labelBazaBaza
            // 
            this.labelBazaBaza.AutoSize = true;
            this.labelBazaBaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBazaBaza.Location = new System.Drawing.Point(6, 41);
            this.labelBazaBaza.Name = "labelBazaBaza";
            this.labelBazaBaza.Size = new System.Drawing.Size(118, 15);
            this.labelBazaBaza.TabIndex = 5;
            this.labelBazaBaza.Text = "Nazwa bazy danych:";
            // 
            // textBoxBazaHost
            // 
            this.textBoxBazaHost.Location = new System.Drawing.Point(9, 18);
            this.textBoxBazaHost.Name = "textBoxBazaHost";
            this.textBoxBazaHost.Size = new System.Drawing.Size(149, 20);
            this.textBoxBazaHost.TabIndex = 4;
            // 
            // labelBazaHost
            // 
            this.labelBazaHost.AutoSize = true;
            this.labelBazaHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelBazaHost.Location = new System.Drawing.Point(6, 0);
            this.labelBazaHost.Name = "labelBazaHost";
            this.labelBazaHost.Size = new System.Drawing.Size(35, 15);
            this.labelBazaHost.TabIndex = 3;
            this.labelBazaHost.Text = "Host:";
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWarning.Location = new System.Drawing.Point(12, 390);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(35, 13);
            this.labelWarning.TabIndex = 1;
            this.labelWarning.Text = "label1";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfo.Location = new System.Drawing.Point(8, 52);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(45, 19);
            this.labelInfo.TabIndex = 2;
            this.labelInfo.Text = "label2";
            // 
            // buttonDalej
            // 
            this.buttonDalej.Location = new System.Drawing.Point(447, 466);
            this.buttonDalej.Name = "buttonDalej";
            this.buttonDalej.Size = new System.Drawing.Size(75, 23);
            this.buttonDalej.TabIndex = 0;
            this.buttonDalej.Text = "Dalej";
            this.buttonDalej.UseVisualStyleBackColor = true;
            this.buttonDalej.Visible = false;
            this.buttonDalej.Click += new System.EventHandler(this.buttonDalej_Click);
            // 
            // buttonWroc
            // 
            this.buttonWroc.Location = new System.Drawing.Point(366, 466);
            this.buttonWroc.Name = "buttonWroc";
            this.buttonWroc.Size = new System.Drawing.Size(75, 23);
            this.buttonWroc.TabIndex = 1;
            this.buttonWroc.Text = "Wróć";
            this.buttonWroc.UseVisualStyleBackColor = true;
            this.buttonWroc.Click += new System.EventHandler(this.buttonWroc_Click);
            // 
            // panelStworzUzytkownika
            // 
            this.panelStworzUzytkownika.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelStworzUzytkownika.Controls.Add(this.textBoxKontoHaslo2);
            this.panelStworzUzytkownika.Controls.Add(this.labelKontoHaslo2);
            this.panelStworzUzytkownika.Controls.Add(this.textBoxKontoHaslo1);
            this.panelStworzUzytkownika.Controls.Add(this.labelKontoHaslo1);
            this.panelStworzUzytkownika.Controls.Add(this.textBoxKontoLogin);
            this.panelStworzUzytkownika.Controls.Add(this.labelKontoLogin);
            this.panelStworzUzytkownika.Location = new System.Drawing.Point(12, 89);
            this.panelStworzUzytkownika.Name = "panelStworzUzytkownika";
            this.panelStworzUzytkownika.Size = new System.Drawing.Size(501, 280);
            this.panelStworzUzytkownika.TabIndex = 5;
            // 
            // textBoxKontoHaslo2
            // 
            this.textBoxKontoHaslo2.Location = new System.Drawing.Point(9, 103);
            this.textBoxKontoHaslo2.Name = "textBoxKontoHaslo2";
            this.textBoxKontoHaslo2.Size = new System.Drawing.Size(149, 20);
            this.textBoxKontoHaslo2.TabIndex = 18;
            this.textBoxKontoHaslo2.UseSystemPasswordChar = true;
            // 
            // labelKontoHaslo2
            // 
            this.labelKontoHaslo2.AutoSize = true;
            this.labelKontoHaslo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKontoHaslo2.Location = new System.Drawing.Point(6, 85);
            this.labelKontoHaslo2.Name = "labelKontoHaslo2";
            this.labelKontoHaslo2.Size = new System.Drawing.Size(87, 15);
            this.labelKontoHaslo2.TabIndex = 17;
            this.labelKontoHaslo2.Text = "Powtórz hasło:";
            // 
            // textBoxKontoHaslo1
            // 
            this.textBoxKontoHaslo1.Location = new System.Drawing.Point(9, 62);
            this.textBoxKontoHaslo1.Name = "textBoxKontoHaslo1";
            this.textBoxKontoHaslo1.Size = new System.Drawing.Size(149, 20);
            this.textBoxKontoHaslo1.TabIndex = 16;
            this.textBoxKontoHaslo1.UseSystemPasswordChar = true;
            // 
            // labelKontoHaslo1
            // 
            this.labelKontoHaslo1.AutoSize = true;
            this.labelKontoHaslo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKontoHaslo1.Location = new System.Drawing.Point(6, 44);
            this.labelKontoHaslo1.Name = "labelKontoHaslo1";
            this.labelKontoHaslo1.Size = new System.Drawing.Size(42, 15);
            this.labelKontoHaslo1.TabIndex = 15;
            this.labelKontoHaslo1.Text = "Hasło:";
            // 
            // textBoxKontoLogin
            // 
            this.textBoxKontoLogin.Location = new System.Drawing.Point(9, 21);
            this.textBoxKontoLogin.Name = "textBoxKontoLogin";
            this.textBoxKontoLogin.Size = new System.Drawing.Size(149, 20);
            this.textBoxKontoLogin.TabIndex = 14;
            // 
            // labelKontoLogin
            // 
            this.labelKontoLogin.AutoSize = true;
            this.labelKontoLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKontoLogin.Location = new System.Drawing.Point(6, 3);
            this.labelKontoLogin.Name = "labelKontoLogin";
            this.labelKontoLogin.Size = new System.Drawing.Size(41, 15);
            this.labelKontoLogin.TabIndex = 13;
            this.labelKontoLogin.Text = "Login:";
            // 
            // panelUstawienia
            // 
            this.panelUstawienia.Controls.Add(this.textBoxKontaktMail);
            this.panelUstawienia.Controls.Add(this.labelKontaktMail);
            this.panelUstawienia.Controls.Add(this.labelInfoWymagane);
            this.panelUstawienia.Controls.Add(this.textBoxKontaktSteam);
            this.panelUstawienia.Controls.Add(this.labelKontaktSteam);
            this.panelUstawienia.Controls.Add(this.textBoxNickHeadAdmina);
            this.panelUstawienia.Controls.Add(this.labelNickHeadAdmina);
            this.panelUstawienia.Controls.Add(this.textBoxNazwaSieci);
            this.panelUstawienia.Controls.Add(this.labelNazwaSieci);
            this.panelUstawienia.Location = new System.Drawing.Point(12, 86);
            this.panelUstawienia.Name = "panelUstawienia";
            this.panelUstawienia.Size = new System.Drawing.Size(486, 301);
            this.panelUstawienia.TabIndex = 6;
            // 
            // textBoxKontaktMail
            // 
            this.textBoxKontaktMail.Location = new System.Drawing.Point(18, 147);
            this.textBoxKontaktMail.Name = "textBoxKontaktMail";
            this.textBoxKontaktMail.Size = new System.Drawing.Size(149, 20);
            this.textBoxKontaktMail.TabIndex = 23;
            // 
            // labelKontaktMail
            // 
            this.labelKontaktMail.AutoSize = true;
            this.labelKontaktMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKontaktMail.Location = new System.Drawing.Point(12, 129);
            this.labelKontaktMail.Name = "labelKontaktMail";
            this.labelKontaktMail.Size = new System.Drawing.Size(75, 15);
            this.labelKontaktMail.TabIndex = 22;
            this.labelKontaktMail.Text = "Adres email:";
            // 
            // labelInfoWymagane
            // 
            this.labelInfoWymagane.AutoSize = true;
            this.labelInfoWymagane.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfoWymagane.Location = new System.Drawing.Point(3, 194);
            this.labelInfoWymagane.Name = "labelInfoWymagane";
            this.labelInfoWymagane.Size = new System.Drawing.Size(0, 15);
            this.labelInfoWymagane.TabIndex = 21;
            // 
            // textBoxKontaktSteam
            // 
            this.textBoxKontaktSteam.Location = new System.Drawing.Point(18, 106);
            this.textBoxKontaktSteam.Name = "textBoxKontaktSteam";
            this.textBoxKontaktSteam.Size = new System.Drawing.Size(149, 20);
            this.textBoxKontaktSteam.TabIndex = 20;
            // 
            // labelKontaktSteam
            // 
            this.labelKontaktSteam.AutoSize = true;
            this.labelKontaktSteam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelKontaktSteam.Location = new System.Drawing.Point(12, 88);
            this.labelKontaktSteam.Name = "labelKontaktSteam";
            this.labelKontaktSteam.Size = new System.Drawing.Size(397, 15);
            this.labelKontaktSteam.TabIndex = 19;
            this.labelKontaktSteam.Text = "Link do profilu Steam (bez http:// np. steamcommunity.com/id/CSnajper)";
            // 
            // textBoxNickHeadAdmina
            // 
            this.textBoxNickHeadAdmina.Location = new System.Drawing.Point(15, 65);
            this.textBoxNickHeadAdmina.Name = "textBoxNickHeadAdmina";
            this.textBoxNickHeadAdmina.Size = new System.Drawing.Size(149, 20);
            this.textBoxNickHeadAdmina.TabIndex = 18;
            // 
            // labelNickHeadAdmina
            // 
            this.labelNickHeadAdmina.AutoSize = true;
            this.labelNickHeadAdmina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNickHeadAdmina.Location = new System.Drawing.Point(9, 47);
            this.labelNickHeadAdmina.Name = "labelNickHeadAdmina";
            this.labelNickHeadAdmina.Size = new System.Drawing.Size(61, 15);
            this.labelNickHeadAdmina.TabIndex = 17;
            this.labelNickHeadAdmina.Text = "Twój nick:";
            // 
            // textBoxNazwaSieci
            // 
            this.textBoxNazwaSieci.Location = new System.Drawing.Point(15, 24);
            this.textBoxNazwaSieci.Name = "textBoxNazwaSieci";
            this.textBoxNazwaSieci.Size = new System.Drawing.Size(149, 20);
            this.textBoxNazwaSieci.TabIndex = 16;
            // 
            // labelNazwaSieci
            // 
            this.labelNazwaSieci.AutoSize = true;
            this.labelNazwaSieci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNazwaSieci.Location = new System.Drawing.Point(9, 6);
            this.labelNazwaSieci.Name = "labelNazwaSieci";
            this.labelNazwaSieci.Size = new System.Drawing.Size(226, 15);
            this.labelNazwaSieci.TabIndex = 15;
            this.labelNazwaSieci.Text = "Strona sieci (bez www np. CSnajper.eu):";
            // 
            // buttonZakoncz
            // 
            this.buttonZakoncz.Location = new System.Drawing.Point(447, 466);
            this.buttonZakoncz.Name = "buttonZakoncz";
            this.buttonZakoncz.Size = new System.Drawing.Size(75, 23);
            this.buttonZakoncz.TabIndex = 0;
            this.buttonZakoncz.Text = "Zakończ";
            this.buttonZakoncz.UseVisualStyleBackColor = true;
            this.buttonZakoncz.Click += new System.EventHandler(this.buttonZakoncz_Click);
            // 
            // Konfiguracja_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.panelUstawienia);
            this.Controls.Add(this.panelBaza);
            this.Controls.Add(this.panelStworzUzytkownika);
            this.Controls.Add(this.buttonZakoncz);
            this.Controls.Add(this.buttonWroc);
            this.Controls.Add(this.buttonDalej);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelWarning);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "Konfiguracja_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja systemu zgłoszeń";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Konfiguracja_1_FormClosing);
            this.panelBaza.ResumeLayout(false);
            this.panelBaza.PerformLayout();
            this.panelStworzUzytkownika.ResumeLayout(false);
            this.panelStworzUzytkownika.PerformLayout();
            this.panelUstawienia.ResumeLayout(false);
            this.panelUstawienia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelBaza;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Button buttonDalej;
        private System.Windows.Forms.Button buttonWroc;
        private System.Windows.Forms.TextBox textBoxBazaHaslo;
        private System.Windows.Forms.TextBox textBoxBazaUzytkownik;
        private System.Windows.Forms.TextBox textBoxBazaBaza;
        private System.Windows.Forms.Label labelBazaHaslo;
        private System.Windows.Forms.Label labelBazaUzytkownik;
        private System.Windows.Forms.Label labelBazaBaza;
        private System.Windows.Forms.TextBox textBoxBazaHost;
        private System.Windows.Forms.Label labelBazaHost;
        private System.Windows.Forms.Label labelBazaProgresInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panelStworzUzytkownika;
        private System.Windows.Forms.TextBox textBoxKontoHaslo2;
        private System.Windows.Forms.Label labelKontoHaslo2;
        private System.Windows.Forms.TextBox textBoxKontoHaslo1;
        private System.Windows.Forms.Label labelKontoHaslo1;
        private System.Windows.Forms.TextBox textBoxKontoLogin;
        private System.Windows.Forms.Label labelKontoLogin;
        private System.Windows.Forms.Panel panelUstawienia;
        private System.Windows.Forms.TextBox textBoxKontaktSteam;
        private System.Windows.Forms.Label labelKontaktSteam;
        private System.Windows.Forms.TextBox textBoxNickHeadAdmina;
        private System.Windows.Forms.Label labelNickHeadAdmina;
        private System.Windows.Forms.TextBox textBoxNazwaSieci;
        private System.Windows.Forms.Label labelNazwaSieci;
        private System.Windows.Forms.Label labelInfoWymagane;
        private System.Windows.Forms.Button buttonZakoncz;
        private System.Windows.Forms.Button buttonPolaczzBaza;
        private System.Windows.Forms.TextBox textBoxKontaktMail;
        private System.Windows.Forms.Label labelKontaktMail;
        private System.Windows.Forms.Label labelBazaWarning;
    }
}