using System;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.ExtruderHMKatalizorHesabi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes(this);
        }

        private void ClearAllTextBoxes(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = string.Empty;
                }
                else if (c.HasChildren)
                {
                    ClearAllTextBoxes(c);
                }
            }
        }





        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Geçerli karakter sayýsal, backspace veya nokta olmalý
                bool isNumericOrControl = char.IsDigit(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == '.';
                // Eðer sayýsal bir deðer giriliyorsa ve mevcut text 0'a eþitse giriþe izin verme
                if (isNumericOrControl && textBox.Text == "0" && char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }
                // Ayný zamanda text'in baþýna veya baþka bir yere sýfýr yazýlmasýný önler
                if (isNumericOrControl && e.KeyChar == '0' && string.IsNullOrEmpty(textBox.Text))
                {
                    e.Handled = true;
                    return;
                }
                // Nokta karakteri sadece bir kere girilebilir
                if (e.KeyChar == '.' && textBox.Text.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = !isNumericOrControl;
                }
            }
        }

        private void Baslik_Click(object sender, EventArgs e)
        {

        }
    }
}
