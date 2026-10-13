using System;
using System.Windows.Forms;

namespace gul.magazasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "Toplam gelir: 0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("Zəhmət olmasa bütün xanaları doldurun!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int count) || count <= 0)
                {
                    MessageBox.Show("Satış sayı 0-dan böyük tam rəqəm olmalıdır!", "Format Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(textBox3.Text, out double price) || price <= 0)
                {
                    MessageBox.Show("Qiymət 0-dan böyük rəqəm olmalıdır!", "Format Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double result = count * price;

                dataGridView1.Rows.Add(count.ToString(), price.ToString("F2"), result.ToString("F2"), textBox1.Text);

                ToplamGelirHesabla();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gözlənilməz xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToplamGelirHesabla()
        {
            double toplam = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double val))
                    {
                        toplam += val;
                    }
                }
            }
            label4.Text = "Toplam gelir: " + toplam.ToString("F2");
        }

        private void buttonCixis_Click(object sender, EventArgs e)
        {
            DialogResult netice = MessageBox.Show("Çıxış edilsinmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (netice == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
