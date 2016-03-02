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
    public partial class ZmianaHasla : Form
    {
        public ZmianaHasla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxStareHaslo.Text) || string.IsNullOrEmpty(textBoxNoweHaslo.Text) || string.IsNullOrEmpty(textBoxNoweHaslo2.Text))
            {
                MessageBox.Show("Wypełnij wszystkie pola", "Błąd zmiany hasła!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(textBoxStareHaslo.Text != User.haslo)
            {
                MessageBox.Show("Podałeś złe obecne hasło!", "Błąd zmiany hasła!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(textBoxNoweHaslo.Text != textBoxNoweHaslo2.Text)
            {
                MessageBox.Show("Podane hasła nie są takie same!", "Błąd zmiany hasła!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(textBoxNoweHaslo.Text.Length < 5)
            {
                MessageBox.Show("Hasło powinno zawierać min. 5 znaków!", "Błąd zmiany hasła!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DBConnect pol = new DBConnect();
                if (pol.ZmianaHasla(User.id, textBoxNoweHaslo.Text))
                {
                    this.Close();

                    MessageBox.Show("Hasło do konta zostało zmienione.", "Powodzenie!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
