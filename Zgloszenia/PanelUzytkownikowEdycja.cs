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
    public partial class PanelUzytkownikowEdycja : Form
    {
        public string id_uzytkownika;
        public PanelUzytkownikowEdycja(DataGridView dataGridView, int id)
        {
            InitializeComponent();
            label6.Text = "Informacje o poziomach:\n1 - Tylko zatwierdzanie zgłoszeń\n2 - Zatwierdzanie zgłoszeń oraz\n     dodawanie/edycja/usuwanie uzytkownikow\n     z poziomu 1\n3 - Główny administrator";
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "1");
            if (User.poziom == 3)
            {
                test.Add("2", "2");
                test.Add("3", "3");
            }
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedIndex = Int32.Parse(dataGridView.Rows[id].Cells[3].Value.ToString())-1;

            id_uzytkownika = dataGridView.Rows[id].Cells[0].Value.ToString();
            textBoxNick.Text = dataGridView.Rows[id].Cells[1].Value.ToString();
            textBoxHaslo.Text = dataGridView.Rows[id].Cells[2].Value.ToString();
            textBoxZatwierdzonych.Text = dataGridView.Rows[id].Cells[4].Value.ToString();
            textBoxOnline.Text = dataGridView.Rows[id].Cells[5].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult wybor = new DialogResult();
            wybor = MessageBox.Show("Zmienić dane użytkownika?", "Edycja użytkownika", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (wybor == DialogResult.Yes)
            {
                string[] tab = new String[6];
                tab[0] = id_uzytkownika;
                tab[1] = textBoxNick.Text;
                tab[2] = textBoxHaslo.Text;
                tab[3] = textBoxZatwierdzonych.Text;
                tab[4] = textBoxOnline.Text;
                string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;
                tab[5] = value.ToString();
                
                DBConnect edycja = new DBConnect();
                if (edycja.AtkualizujUzytkownika(tab))
                {
                    MessageBox.Show("Dane użytkownika zaktualizowane.", "Edycja użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                    PanelUzytkownikow.refOnko.PobierzUzytkownikow();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult wybor = new DialogResult();
            wybor = MessageBox.Show("Usunąć użytkownika?", "Usuwanie użytkownika", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (wybor == DialogResult.Yes)
            {
                DBConnect pol = new DBConnect();
                if (pol.UsunUzytkownika(id_uzytkownika))
                {
                    MessageBox.Show("Użytkownik został usunięty.", "Usuwanie użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.Close();
                    PanelUzytkownikow.refOnko.PobierzUzytkownikow();
                }
            }
        }
    }
}
