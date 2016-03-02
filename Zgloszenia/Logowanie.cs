using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zgloszenia.Properties;

namespace Zgloszenia
{
    public partial class Logowanie : Form
    {
        Settings ustawienia = new Settings();
        public static Logowanie refOkno;

        public Logowanie()
        {
            InitializeComponent();
            refOkno = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxHaslo.Text) )
            {
                MessageBox.Show("Podaj login i haslo!", "Błąd logowania!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DBConnect logowanie = new DBConnect();
                if(logowanie.Zaloguj(textBoxLogin.Text, textBoxHaslo.Text))
                {
                    ustawienia.zapamietaj_haslo = checkBox1Zapamietaj.Checked;
                    ustawienia.loguj_auto = checkBox2LogAuto.Checked;
                    if (!checkBox1Zapamietaj.Checked)
                    {
                        ustawienia.Login = "";
                        ustawienia.Haslo = "";
                    }
                    else
                    {
                        ustawienia.Login = textBoxLogin.Text;
                        ustawienia.Haslo = textBoxHaslo.Text;
                    }
                    ustawienia.Save();

                    this.Hide();

                    User.zalogowany = true;

                    PanelZgloszen ss = new PanelZgloszen();
                    ss.Show();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1Zapamietaj.Checked = ustawienia.zapamietaj_haslo;
            checkBox2LogAuto.Checked = ustawienia.loguj_auto;
            if(checkBox1Zapamietaj.Checked)
            {
                textBoxLogin.Text = ustawienia.Login;
                textBoxHaslo.Text = ustawienia.Haslo;
            }
        }

        private void checkBox1Zapamietaj_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1Zapamietaj.Checked)
                checkBox2LogAuto.Checked = false;
        }

        private void checkBox2LogAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1Zapamietaj.Checked == false && checkBox2LogAuto.Checked == true)
            {
                checkBox2LogAuto.Checked = false;
                MessageBox.Show("Przed zaznaczeniem tej opcji zaznacz opcję zapamiętania danych.", "Ustawienia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Logowanie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                button1_Click(null, null);
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.CSnajper.eu");
        }

        private void oAutorzeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OAutorze ss = new OAutorze();
            ss.Show();
        }

        private void Logowanie_Shown(object sender, EventArgs e)
        {
            string sciezka_do_pliku = Directory.GetCurrentDirectory();
            sciezka_do_pliku += @"\config.cz";
            if (!File.Exists(sciezka_do_pliku))
            {
                this.Hide();
                Konfiguracja_1 ss = new Konfiguracja_1();
                ss.Show();
                return;
            }
            else
            {
                Encrypt.odszyfrujPlik("iujgb6u)(*ijb", @sciezka_do_pliku);
            }
            
            if (checkBox2LogAuto.Checked)
            {
                this.Hide();
                button1_Click(null, null);
            }
        }

        private void kontaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kontakt ss = new Kontakt();
            ss.Show();
        }
    }
    static class User
    {
        public static string id;
        public static string login;
        public static string haslo;
        public static bool zalogowany;
        public static int poziom;
        public static int czas_online;
        public static int czas_online_w_sesji;
        public static int ilosc_zatwierdzonych_zgloszen;
        public static int ilosc_zatwierdzonych_zgloszen_w_sesji;
    }
}
