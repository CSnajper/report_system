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
    public partial class PanelUzytkownikow : Form
    {
        public static PanelUzytkownikow refOnko;
        public PanelUzytkownikow()
        {
            InitializeComponent();
            PobierzUzytkownikow();
            refOnko = this;
        }

        public void PobierzUzytkownikow()
        {
            DBConnect DBUsers = new DBConnect();
            String[][] lista_uzytkownikow = DBUsers.PobierzUzytkownikow();

            dataGridView1.Rows.Clear();

            String[] user = new String[7];
            for (int i = 0; i < lista_uzytkownikow.Length; i++)
            {
                if (string.IsNullOrEmpty(lista_uzytkownikow[i][0]))
                    break;
                user[0] = lista_uzytkownikow[i][0];
                user[1] = lista_uzytkownikow[i][1];
                user[2] = lista_uzytkownikow[i][2];
                user[3] = lista_uzytkownikow[i][3];
                user[4] = lista_uzytkownikow[i][4];
                int czas = Int32.Parse(lista_uzytkownikow[i][5]);
                user[5] = CzasNaString(czas);
                int zatwierdzonych_zgloszen = Int32.Parse(lista_uzytkownikow[i][4]);
                float srednio, czass;
                if(czas / 60 == 0)
                {
                    srednio = zatwierdzonych_zgloszen;
                }
                else
                {
                    czass = czas / 60;
                    srednio = zatwierdzonych_zgloszen / czass;
                }
                user[6] = Math.Round(srednio, 1).ToString() + " zgłoszeń/minute";

                dataGridView1.Rows.Add(user);
            }
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                PanelUzytkownikowEdycja zgoszenieInfo = new PanelUzytkownikowEdycja(dataGridView1, e.RowIndex);
                zgoszenieInfo.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajUzytkownika ss = new DodajUzytkownika();
            ss.Show();
        }
    }
}
