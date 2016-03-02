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
    public partial class ZgloszenieInfo : Form
    {
        public ZgloszenieInfo(DataGridView dataGridView, int id)
        {
            InitializeComponent();
            label6.Text = dataGridView.Rows[id].Cells[0].Value.ToString();
            label7.Text = dataGridView.Rows[id].Cells[2].Value.ToString();
            label8.Text = dataGridView.Rows[id].Cells[3].Value.ToString();
            label13.Text = dataGridView.Rows[id].Cells[4].Value.ToString();
            label9.Text = dataGridView.Rows[id].Cells[1].Value.ToString();
            label10.Text = dataGridView.Rows[id].Cells[5].Value.ToString();
            label14.Text = dataGridView.Rows[id].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult wybor = new DialogResult();
                wybor = MessageBox.Show("Wejść na serwer?", "Zatwierdzanie zgłoszeń", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (wybor == DialogResult.Yes)
                {
                    PanelZgloszen.refOknoZgloszenia.ZatwierdzZgloszenie(label6.Text);
                    this.Close();
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCopyNickZgoszonego_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label8.Text);
        }

        private void buttonCopyIpZgloszonego_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label13.Text);
        }

        private void buttonCopyNickZglaszajacego_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label10.Text);
        }

        private void buttonCopyIpZglaszajacego_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label14.Text);
        }

        private void buttonCopyNickZgoszonego_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo.SetToolTip(this.buttonCopyNickZgoszonego, "Kopiuj do schowka");
        }

        private void buttonCopyIpZgloszonego_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo.SetToolTip(this.buttonCopyIpZgloszonego, "Kopiuj do schowka");
        }

        private void buttonCopyNickZglaszajacego_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo.SetToolTip(this.buttonCopyNickZglaszajacego, "Kopiuj do schowka");
        }

        private void buttonCopyIpZglaszajacego_MouseEnter(object sender, EventArgs e)
        {
            toolTipInfo.SetToolTip(this.buttonCopyIpZglaszajacego, "Kopiuj do schowka");
        }
    }
}
