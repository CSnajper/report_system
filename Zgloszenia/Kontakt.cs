using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zgloszenia
{
    public partial class Kontakt : Form
    {
        private static string nazwaSieci;
        private static string nickHA;
        private static string kontaktSteam;
        private static string kontaktMail;
        public Kontakt()
        {
            InitializeComponent();
            int polozenie;
            linkLabelNazwaSieci.Text = nazwaSieci;
            polozenie = (this.Size.Width - linkLabelNazwaSieci.Size.Width) / 2;
            linkLabelNazwaSieci.Location = new System.Drawing.Point(polozenie, linkLabelNazwaSieci.Location.Y);
            labelNickHA.Text = "Kontakt z " + nickHA + ":";
            polozenie = (this.Size.Width - labelNickHA.Size.Width) / 2;
            labelNickHA.Location = new System.Drawing.Point(polozenie, labelNickHA.Location.Y);
            linkLabelKontaktSteam.Text = "Steam: " + kontaktSteam;
            polozenie = (this.Size.Width - linkLabelKontaktSteam.Size.Width) / 2;
            linkLabelKontaktSteam.Location = new System.Drawing.Point(polozenie, linkLabelKontaktSteam.Location.Y);
            linkLabelKontaktMail.Text = "Mail: " + kontaktMail;
            polozenie = (this.Size.Width - linkLabelKontaktMail.Size.Width) / 2;
            linkLabelKontaktMail.Location = new System.Drawing.Point(polozenie, linkLabelKontaktMail.Location.Y);
            
        }

        public static void UzupelnijDaneKontaktowe(string nazwasieci, string nickha, string kontaktsteam, string kontaktmail)
        {
            nazwaSieci = nazwasieci;
            nickHA = nickha;
            kontaktSteam = kontaktsteam;
            kontaktMail = kontaktmail;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OAutorze ss = new OAutorze();
            ss.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string adres = "http://" + linkLabelNazwaSieci.Text;
            try
            {
                System.Diagnostics.Process.Start(adres);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabelKontaktSteam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string adres = "http://" + linkLabelKontaktSteam.Text;
            try
            {
                System.Diagnostics.Process.Start(adres);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabelKontaktMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string adres = "mailto:" + linkLabelKontaktMail.Text;
            try
            {
                System.Diagnostics.Process.Start(adres);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
