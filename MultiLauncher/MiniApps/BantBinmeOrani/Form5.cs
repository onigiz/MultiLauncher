using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace MultiLauncher.MiniApps.BantBinmeOrani
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Baslik_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kullanıcının girdiği değerleri al ve float olarak dönüştür
                float value1 = float.Parse(textBox1.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                float value2 = float.Parse(textBox2.Text.Replace(",", "."), CultureInfo.InvariantCulture);

                // Hesaplama yap
                float result = (value1 / value2) * 100;

                // Sonucu textbox3'e yaz
                textBox3.Text = result.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen sayı giriniz!");
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Yalnızca sayı ve ondalık ayraç girişine izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Yalnızca bir adet ondalık ayraç girilmesine izin ver
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
