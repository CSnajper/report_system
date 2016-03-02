using Microsoft.Win32;
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
using Zgloszenia.Properties;

namespace Zgloszenia
{
    public partial class Ustawienia : Form
    {
        Settings ustawienia = new Settings();
        public static bool mozeGrac = false;

        public Ustawienia()
        {
            InitializeComponent();
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "Steam");
            test.Add("2", "Non Steam");
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";

            // Bind combobox to dictionary
            Dictionary<string, string> opcje = new Dictionary<string, string>();
            opcje.Add("0", "Dzwięk 1");
            opcje.Add("1", "Dźwięk 2");
            opcje.Add("2", "Dźwięk 3");
            opcje.Add("3", "Dźwięk 4");
            comboBoxDzwiekPowiadomien.DataSource = new BindingSource(opcje, null);
            comboBoxDzwiekPowiadomien.DisplayMember = "Value";
            comboBoxDzwiekPowiadomien.ValueMember = "Key";

            //ustawianie odpowiednich wartosci
            checkBoxZapamietajHaslo.Checked = ustawienia.zapamietaj_haslo;
            checkBoxLogAuto.Checked = ustawienia.loguj_auto;
            checkBoxDymkiPowiadomien.Checked = ustawienia.dymki_powiadomien;
            checkBoxDzwiekiPowiadomien.Checked = ustawienia.dzwiek_powiadomien;
            if (ustawienia.dzwiek_powiadomien)
            {
                mozeGrac = false;
                comboBoxDzwiekPowiadomien.SelectedIndex = ustawienia.nr_dzwieku_powiadomien;
            }
            else comboBoxDzwiekPowiadomien.Visible = false;
            mozeGrac = true;
            if(ustawienia.wersja_steam <= 0)
                comboBox1.SelectedIndex = 0;
            else comboBox1.SelectedIndex = ustawienia.wersja_steam-1;
            textBoxCS16.Text = ustawienia.lokalizacja_cs16;
            textBoxCSGO.Text = ustawienia.lokalizacja_csgo;
            //checkBoxStartzWin.Checked = ustawienia.uruchamiaj_z_win;
        }

        private void buttonCS16_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sciezkaPliku=openFileDialog1.FileName;
                textBoxCS16.Text = sciezkaPliku;
            }
        }

        private void buttonCSGO_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sciezkaPliku = openFileDialog1.FileName;
                textBoxCSGO.Text = sciezkaPliku;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ustawienia.zapamietaj_haslo = checkBoxZapamietajHaslo.Checked;
            ustawienia.loguj_auto = checkBoxLogAuto.Checked;
            ustawienia.wersja_steam = Int32.Parse(((KeyValuePair<string, string>)comboBox1.SelectedItem).Key);
            ustawienia.lokalizacja_cs16 = textBoxCS16.Text;
            ustawienia.lokalizacja_csgo= textBoxCSGO.Text;
            ustawienia.dymki_powiadomien = checkBoxDymkiPowiadomien.Checked;
            ustawienia.dzwiek_powiadomien = checkBoxDzwiekiPowiadomien.Checked;
            ustawienia.nr_dzwieku_powiadomien = Int32.Parse(((KeyValuePair<string, string>)comboBoxDzwiekPowiadomien.SelectedItem).Key);
            //ustawienia.uruchamiaj_z_win = checkBoxStartzWin.Checked;
            ustawienia.Save();
            /*if(checkBoxStartzWin.Checked)
                DodajWpisAutostartu(true);
            else DodajWpisAutostartu(false);*/
            this.Close();
            MessageBox.Show("Część zmian może wymagać ponownego uruchomienia aplikacji.", "Ustawienia", MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        private void DodajWpisAutostartu(bool startuj_z_win)
        {
            RegistryKey rejestr = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            if (startuj_z_win)
            {
                try
                {
                    string sciezka_aplikacji = Application.ExecutablePath;
                    string sciezka_autostart = string.Format("\"{0}\"", sciezka_aplikacji);
                    sciezka_autostart = sciezka_autostart.Replace("/", "\\");
                    if (rejestr == null)
                    {
                        RegistryKey rejestrNew = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

                        RegistryKey Nowyrejestr = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                        Nowyrejestr.SetValue("Zgloszenia", sciezka_autostart);
                    }
                    else rejestr.SetValue("Zgloszenia", sciezka_autostart);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                if (rejestr == null)
                    return;
                else
                {
                    try
                    {
                        rejestr.DeleteValue("Zgloszenia");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(((KeyValuePair<string, string>)comboBox1.SelectedItem).Key) == 1)
                panelSciezkiCS.Visible = false;
            else
                panelSciezkiCS.Visible = true;
        }

        private void checkBoxZapamietajHaslo_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxZapamietajHaslo.Checked == false)
            {
                checkBoxLogAuto.Checked = false;
                ustawienia.Login = "";
                ustawienia.Haslo = "";
            }
            else
            {
                ustawienia.Login = User.login;
                ustawienia.Haslo = User.haslo;
            }
        }

        private void checkBoxLogAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxZapamietajHaslo.Checked == false && checkBoxLogAuto.Checked == true)
            {
                checkBoxLogAuto.Checked = false;
                MessageBox.Show("Przed zaznaczeniem tej opcji zaznacz opcję zapamiętania danych logowania.", "Ustawienia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxDzwiekiPowiadomien_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDzwiekiPowiadomien.Checked == false)
                comboBoxDzwiekPowiadomien.Visible = false;
            else comboBoxDzwiekPowiadomien.Visible = true;
        }

        private void comboBoxDzwiekPowiadomien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!mozeGrac)
                return;

            switch (Int32.Parse(((KeyValuePair<string, string>)comboBoxDzwiekPowiadomien.SelectedItem).Key))
            {
                case 0:
                    (new System.Media.SoundPlayer(@"sound/nowe_zgloszenie_0.wav")).Play();
                    break;
                case 1:
                    (new System.Media.SoundPlayer(@"sound/nowe_zgloszenie_1.wav")).Play();
                    break;
                case 2:
                    (new System.Media.SoundPlayer(@"sound/nowe_zgloszenie_2.wav")).Play();
                    break;
                case 3:
                    (new System.Media.SoundPlayer(@"sound/nowe_zgloszenie_3.wav")).Play();
                    break;
            }
        }

        private void Ustawienia_FormClosed(object sender, FormClosedEventArgs e)
        {
            mozeGrac = false;
        }
    }
}
