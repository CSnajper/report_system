using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zgloszenia.Properties;

namespace Zgloszenia
{
    public partial class PanelZgloszen : Form
    {
        public static PanelZgloszen refOknoZgloszenia;
        public static int najwyzsze_id = 0;
        public static bool pierwszeUruchomienie = true;
        Settings ustawienia = new Settings();
        public PanelZgloszen()
        {
            InitializeComponent();
            refOknoZgloszenia = this;
            timer1_Tick(null, null);
            labelWitaj.Text = "Witaj, " + User.login + ".";
            if(User.poziom < 2)
            {
                button2.Visible = false;
            }
        }

        //zamykanie okna glownego po wyjsciu z aplikacji;
        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int id = 0;
            DBConnect zgloszenia = new DBConnect();
            String[][] lista_zgloszen = zgloszenia.PobierzZgloszenia();

            dataGridView1.Rows.Clear();

            //pozniej do dynamicznego ladowania obrazow
            //String strAppDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            //Bitmap img;
            //img = new Bitmap(@"C:\Users\CHUCKNORRIS\Desktop\cs16.ico");

            String[] zgloszenie = new String[10];
            for (int i = 0; i < lista_zgloszen.Length; i++)
            {
                if (string.IsNullOrEmpty(lista_zgloszen[i][0]))
                    break;
                zgloszenie[0] = lista_zgloszen[i][0];
                zgloszenie[1] = lista_zgloszen[i][1];
                zgloszenie[2] = lista_zgloszen[i][2];
                zgloszenie[3] = lista_zgloszen[i][3];
                zgloszenie[4] = lista_zgloszen[i][4];
                zgloszenie[5] = lista_zgloszen[i][5];
                zgloszenie[6] = lista_zgloszen[i][6];
                DateTime data_nadania = DateTime.Parse(lista_zgloszen[i][7]);
                DateTime teraz = DateTime.Now;
                TimeSpan roznica_czasu = data_nadania - teraz;
                string output = roznica_czasu.ToString(@"hh\:mm\:ss");
                zgloszenie[7] = output;
                zgloszenie[8] = lista_zgloszen[i][8];
                zgloszenie[9] = lista_zgloszen[i][9];

                dataGridView1.Rows.Insert(0, zgloszenie);
                dataGridView1.Rows[0].Cells[11].Value = "Zatwierdź";
                switch(dataGridView1.Rows[0].Cells[8].Value.ToString())
                {
                    case "10":
                        dataGridView1.Rows[0].Cells[10].Value = Image.FromFile(@"img/cs_1.6.jpg");
                        break;
                    case "730":
                        dataGridView1.Rows[0].Cells[10].Value = Image.FromFile(@"img/cs_go.jpg");
                        break;
                }

                id = Int32.Parse(zgloszenie[0]);
            }
            if (!pierwszeUruchomienie)
            {
                if(najwyzsze_id < id)
                {
                    if(ustawienia.dymki_powiadomien)
                    {
                        notifyIcon1.BalloonTipText = "Pojawilo sie nowe zgloszenie";
                        notifyIcon1.ShowBalloonTip(20 * 1000);
                    }
                    if(ustawienia.dzwiek_powiadomien)
                    {
                        switch(ustawienia.nr_dzwieku_powiadomien)
                        {
                            case 0:
                                (new System.Media.SoundPlayer(@"sound/nowe_zgloszenie_0.wav")).Play();
                                break;
                            case  1:
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
                    
                    najwyzsze_id = id;
                }
            }
            else if(id > 0)
            {
                if (ustawienia.dymki_powiadomien)
                {
                    notifyIcon1.BalloonTipText = "Nowe zgloszenia oczekuja na rozpatrzenie";
                    notifyIcon1.ShowBalloonTip(10 * 1000);
                }

                najwyzsze_id = id;
            }
            pierwszeUruchomienie = false;
            dataGridView1.ClearSelection();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            User.czas_online += 1;
            User.czas_online_w_sesji += 1;
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refOknoZgloszenia.Show();
        }

        private void zamknijToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) //lub dowolna inna przyczyna
                e.Cancel = true;
            Hide();
            //notifyIcon1.BalloonTipText = "Nadal czuwam :)";
            //notifyIcon1.ShowBalloonTip(10 * 1000);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                DialogResult wybor = new DialogResult();
                wybor = MessageBox.Show("Wejść na serwer?", "Zatwierdzanie zgłoszeń", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (wybor == DialogResult.Yes)
                {
                    switch(ustawienia.wersja_steam)
                    {
                        case 1:
                            MessageBox.Show(senderGrid.Rows[0].Cells[9].Value.ToString());
                            string www = "steam://connect/" + senderGrid.Rows[0].Cells[9].Value.ToString();
                            webBrowser1.Navigate(www);
                            break;
                        case 2:
                            try
                            {
                                //string windir = ustawienia.lokalizacja_cs16;
                                //var pinfo = new ProcessStartInfo(windir);
                                //pinfo.Arguments = string.Format(" +connect {0}", dataGridView1.Rows[0].Cells[7].Value.ToString());
                                //string komenda = string.Format(@"{0}"/* +connect {1}"*/, ustawienia.lokalizacja_cs16/*, dataGridView1.Rows[0].Cells[7].Value.ToString()*/);
                                //MessageBox.Show(dataGridView1.Rows[0].Cells[7].Value.ToString());
                                //System.Diagnostics.Process.Start(pinfo);
                                ProcessStartInfo startInfo = new ProcessStartInfo(ustawienia.lokalizacja_cs16);
                                startInfo.Arguments = string.Format("+connect {0}", senderGrid.Rows[e.RowIndex].Cells[9].Value.ToString());
                                Process.Start(startInfo);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            break;
                        default:
                            MessageBox.Show("Skonfiguruj werjse klienta w ustawieniach aby polaczyc sie z serwerem", "Zgłoszenia", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            break;
                    }
                    ZatwierdzZgloszenie(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                else if (wybor == DialogResult.No)
                {
                    ZatwierdzZgloszenie(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
        }

        public void ZatwierdzZgloszenie(string id)
        {
            DBConnect pol = new DBConnect();
            if (pol.ZatwierdzZgloszenie(id))
            {
                if (ustawienia.dymki_powiadomien)
                {
                    notifyIcon1.BalloonTipText = "Zgłoszenie zostało zatwierdzone :)";
                    notifyIcon1.ShowBalloonTip(10 * 1000);
                }

                DBConnect roz = new DBConnect();
                roz.DodajZatwierdzenieZgloszenia(User.id);

                timer1_Tick(null, null);
            }
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            notifyIcon1.Text = "System zgłoszeń v1.0 by CSnajper\nZalogowany jako: " + User.login;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            refOknoZgloszenia.Show();
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

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon1.Visible = false;
            DBConnect polaczenie = new DBConnect();
            polaczenie.DodajCzasOnline(User.id, User.czas_online);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                ZgloszenieInfo zgoszenieInfo = new ZgloszenieInfo(dataGridView1, e.RowIndex);
                zgoszenieInfo.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZmianaHasla zmianaHasla = new ZmianaHasla();
            zmianaHasla.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (User.poziom > 1)
            {
                PanelUzytkownikow panel = new PanelUzytkownikow();
                panel.Show();
            }
            else
            {
                MessageBox.Show("Nie masz dostępu do tych zasobów", "Panel użytkowników", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ustawienia ust = new Ustawienia();
            ust.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StatystykiUzytkownika ss = new StatystykiUzytkownika();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string info = "Zgłoszenie: " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "\n" +
                    "Serwer: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "\n" +
                    "Zgłoszony: " + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "\n" +
                    "IP zgłoszonego: " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + "\n" +
                    "Zgłaszający: " + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + "\n" +
                    "IP zgłaszającego: " + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + "\n" +
                    "Kliknij 2-krotnie aby wygodnie kopiować";
                cell.ToolTipText = info;
            }
        }
    }
}
