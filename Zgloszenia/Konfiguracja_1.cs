using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zgloszenia
{
    public partial class Konfiguracja_1 : Form
    {
        public static int aktualnyPanel = 0;
        private static bool konfiguracja_zakonczona_sukcesem = false;
        private static bool tabeleUtworzone = false;
        private static bool administratorUtworzony = false;

        public static Konfiguracja_1 refOkno;
        public Konfiguracja_1()
        {
            InitializeComponent();
            progressBar1.Maximum = 100;
            refOkno = this;
            labelWarning.Text = "Uwaga!\nJeżeli nie jesteś administratorem skontaktuj się z nim w celu uzyskania pliku konfiguracyjnego aplikacji.";
            labelBazaWarning.Text = "Uwaga!\nPołączenie z bazą nie jest idealnie szyfrowane, dlatego proszę o:\n1.Używanie losowego hasła (najlepiej z generatora),\n2.Nie współdzielenie bazy aplikacji z innymi aplikacjami/skryptami.";
            AktualnyEtap(0);
            ZmienPanel(1);
        }

        public void ZmienPanel(int nextPanel)
        {
            aktualnyPanel = nextPanel;

            switch(nextPanel)
            {
                case 1:
                    labelInfo.Text = "1. Konfiguracja bazy danych (Etap: 1/3)";
                    panelBaza.Visible = true;
                    buttonDalej.Visible = true;
                    buttonZakoncz.Visible = false;
                    buttonWroc.Visible = false;
                    panelStworzUzytkownika.Visible = false;
                    panelUstawienia.Visible = false;
                    break;
                case 2:
                    if(tabeleUtworzone)
                        buttonWroc.Visible = false;
                    else
                        buttonWroc.Visible = true;
                    labelInfo.Text = "2. Konto administratora (Etap: 2/3)";
                    panelStworzUzytkownika.Visible = true;
                    buttonZakoncz.Visible = false;
                    panelBaza.Visible = false;
                    panelUstawienia.Visible = false;
                    break;
                case 3:
                    if(administratorUtworzony)
                        buttonWroc.Visible = false;
                    else
                        buttonWroc.Visible = true;
                    labelInfo.Text = "2. Informacje dodatkowe (Etap: 3/3)";
                    panelUstawienia.Visible = true;
                    buttonZakoncz.Visible = true;
                    buttonDalej.Visible = false;
                    panelBaza.Visible = false;
                    panelStworzUzytkownika.Visible = false;
                    break;
            }
        }

        private void Konfiguracja_1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!konfiguracja_zakonczona_sukcesem)
            {
                DialogResult wybor = MessageBox.Show("Nie ukończyłeś wszystkich etapów konfiguracji.\nNa pewno chcesz wyjść?", "Konfiguracja",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (wybor == DialogResult.Yes)
                {
                    konfiguracja_zakonczona_sukcesem = true;
                    Application.Exit();
                }
            }
        }

        private void buttonDalej_Click(object sender, EventArgs e)
        {
            switch(aktualnyPanel)
            {
                case 1:
                    if (!tabeleUtworzone)
                    {
                        MessageBox.Show("Aby kontynuowac uzupełnij wszystkie pola i kliknij \"Połącz z bazą\".", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    break;
                case 2:
                    if (string.IsNullOrEmpty(textBoxKontoLogin.Text) || string.IsNullOrEmpty(textBoxKontoHaslo1.Text) || string.IsNullOrEmpty(textBoxKontoHaslo2.Text))
                    {
                        MessageBox.Show("Podaj wszystkie wymagane informacje.", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (string.Compare(textBoxKontoHaslo1.Text, textBoxKontoHaslo2.Text) != 0)
                    {
                        MessageBox.Show("Podane hasła nie są identyczne!", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(!administratorUtworzony)
                    {
                        string[] dane = new string[3];
                        dane[0] = textBoxKontoLogin.Text;
                        dane[1] = textBoxKontoHaslo1.Text;
                        dane[2] = "3";

                        DBConnect pol = new DBConnect();
                        if (!pol.DodajUzytkownika(dane))
                            return;
                        MessageBox.Show("Użytkownik z uprawnieniami administratora został dodany.", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        administratorUtworzony = true;
                    }
                    break;
            }
            ZmienPanel(++aktualnyPanel);
        }

        private void buttonWroc_Click(object sender, EventArgs e)
        {
            ZmienPanel(--aktualnyPanel);
        }

        private void buttonPolaczzBaza_Click(object sender, EventArgs e)
        {
            if (tabeleUtworzone)
            {
                MessageBox.Show("Tabele zostały już utworzone.\nPrzejdź dalej.", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (string.IsNullOrEmpty(textBoxBazaHost.Text) || string.IsNullOrEmpty(textBoxBazaBaza.Text) || string.IsNullOrEmpty(textBoxBazaUzytkownik.Text) || string.IsNullOrEmpty(textBoxBazaHaslo.Text))
            {
                MessageBox.Show("Aby kontynuowac uzupełnij wszystkie pola", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DBConnect.SetDataBase(textBoxBazaHost.Text, textBoxBazaBaza.Text, textBoxBazaUzytkownik.Text, textBoxBazaHaslo.Text);
            DBConnect tworzTabele = new DBConnect();
            if (tworzTabele.TworzStruktureTabel())
            {
                tabeleUtworzone = true;
                buttonDalej.Visible = true;
            }
        }

        public static void AktualnyEtap(int etap)
        {
            switch(etap)
            {
                case 0:
                    refOkno.labelBazaProgresInfo.Text = "Wprawadź dane bazy danych i kliknij \"Połącz z bazą\"";
                    refOkno.progressBar1.Value = 0;
                    break;
                case 1:
                    refOkno.labelBazaProgresInfo.Text = "Łączenie z bazą danych...";
                    refOkno.progressBar1.Value = 5;
                    break;
                case 2:
                    refOkno.labelBazaProgresInfo.Text = "Połączenie z bazą powiodło się...";
                    refOkno.progressBar1.Value = 10;
                    break;
                case 3:
                    refOkno.labelBazaProgresInfo.Text = "Tworzenie tabeli: użytkownicy...";
                    refOkno.progressBar1.Value = 35;
                    break;
                case 4:
                    refOkno.labelBazaProgresInfo.Text = "Tworzenie tabeli: zgłoszenia...";
                    refOkno.progressBar1.Value = 60;
                    break;
                case 5:
                    refOkno.labelBazaProgresInfo.Text = "Tworzenie tabeli: logi...";
                    refOkno.progressBar1.Value = 85;
                    break;
                case 6:
                    refOkno.labelBazaProgresInfo.Text = "Łączenie z bazą danych i tworzenie struktur tabel zakończone powodzeniem. Możesz przejść dalej.";
                    refOkno.progressBar1.Value = 100;
                    break;
            }
        }

        private void buttonZakoncz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNazwaSieci.Text) || string.IsNullOrEmpty(textBoxNickHeadAdmina.Text) || string.IsNullOrEmpty(textBoxKontaktSteam.Text) || string.IsNullOrEmpty(textBoxKontaktMail.Text))
            {
                MessageBox.Show("Podaj wszystkie wymagane informacje aby kontynuowac", "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(UtworzPlikKonfiguracyjny())
            {
                string wiadomosc = "Plik konfiguracyjny zostal prawidlowo skomponowany.\n" +
                    "Mozesz zalogowac sie loginem i haslem ktore podales w trakcie konfiguracji.\n" +
                    "Teraz przekaz swoim pomocnikom pliki programu oraz nowo utworzony plik konfiguracyjny " +
                    "o nazwie config.cz (jest w katalogu aplikacji) oraz utworz im konta (opcja dostepna w programie po zalogowaniu.\n" +
                    "Mam nadzieję że mój projekt będzie ci służył :)";
                MessageBox.Show(wiadomosc, "Konfiguracja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                konfiguracja_zakonczona_sukcesem = true;
                this.Close();
                Logowanie.refOkno.Show();
            }
        }
        private bool UtworzPlikKonfiguracyjny()
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] enter = {13};
            string enter_string = ascii.GetString(enter);
            string ciagDoZaszyfrowania = textBoxBazaHost.Text + enter_string + textBoxBazaBaza.Text + enter_string + textBoxBazaUzytkownik.Text + enter_string + textBoxBazaHaslo.Text + enter_string + textBoxNazwaSieci.Text + enter_string + textBoxNickHeadAdmina.Text + enter_string + textBoxKontaktSteam.Text + enter_string + textBoxKontaktMail.Text;
            string sciezka_do_pliku = Directory.GetCurrentDirectory();
            sciezka_do_pliku += @"\config.cz";
            if(Encrypt.zaszyfrujPlik("iujgb6u)(*ijb", ciagDoZaszyfrowania, @sciezka_do_pliku))
                return true;
            return false;
        }
    }
}
