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
    public partial class DodajUzytkownika : Form
    {
        public DodajUzytkownika()
        {
            InitializeComponent();
            label6.Text = "Informacje o poziomach:\n1 - Tylko zatwierdzanie zgłoszeń\n2 - Zatwierdzanie zgłoszeń oraz\n     dodawanie/edycja/usuwanie uzytkownikow\n     z poziomu 1\n3 - Główny administrator";
            // Bind combobox to dictionary
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "1");
            if(User.poziom == 3)
            {
                test.Add("2", "2");
                test.Add("3", "3");
            }
            comboBox1.DataSource = new BindingSource(test, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxNick.Text) || string.IsNullOrEmpty(textBoxHaslo.Text))
            {
                MessageBox.Show("Podaj wszystkie wymagane informacje", "Dodawanie użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] tab = new String[3];
            tab[0] = textBoxNick.Text;
            tab[1] = textBoxHaslo.Text;
            tab[2] = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;

            DBConnect pol = new DBConnect();
            if(pol.DodajUzytkownika(tab))
            {
                MessageBox.Show("Użytkownik został dodany", "Dodawanie użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                PanelUzytkownikow.refOnko.PobierzUzytkownikow();
            }
        }
    }
}
