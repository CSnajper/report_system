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
    public partial class StatystykiUzytkownika : Form
    {
        public StatystykiUzytkownika()
        {
            InitializeComponent();

            labelLogin.Text = "Nick: " + User.login;
            labelZgloszeniaDane.Text = "- łącznie:     " + User.ilosc_zatwierdzonych_zgloszen + "\n- w tej sesji: " + User.ilosc_zatwierdzonych_zgloszen_w_sesji;
            AktualizujCzasOnline();
            float srednio, czass;
            if (User.czas_online / 60 == 0)
            {
                srednio = User.ilosc_zatwierdzonych_zgloszen;
            }
            else
            {
                czass = User.czas_online / 60;
                srednio = User.ilosc_zatwierdzonych_zgloszen / czass;
            }
            labelSrednioDane.Text = Math.Round(srednio, 1).ToString() + " zgłoszeń na minute";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AktualizujCzasOnline();
        }

        public void AktualizujCzasOnline()
        {
            labelCzasOnlineDane.Text = "- łącznie:     " + CzasNaString(User.czas_online) + "\n- w tej sesji: " + CzasNaString(User.czas_online_w_sesji);
        }

        public string CzasNaString(int cz)
        {
            string czas = "";
            int godz, min, sek;
            sek = cz % 60;
            godz = cz / 3600;
            min = (cz / 60) - (godz * 60);

            czas = godz.ToString() + "g. ";
            czas += min.ToString() + "m. ";
            czas += sek.ToString() + "s. ";

            return czas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
