using System;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.HatveyeGoreUzamaKatsayisi
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

            // KeyPress olaylarını kutulara bağla
            box1.KeyPress += new KeyPressEventHandler(box_KeyPress);
            box2.KeyPress += new KeyPressEventHandler(box_KeyPress);
        }

        private void box_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayı ve tek bir ',' veya '.' karakterine izin ver
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Eğer ',' veya '.' karakteri girilmişse, sadece bir kez girilmesine izin ver
            TextBox textBox = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (textBox.Text.Contains(",") || textBox.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox'lardaki '.' karakterini ',' olarak değiştir
                box1.Text = box1.Text.Replace('.', ',');
                box2.Text = box2.Text.Replace('.', ',');

                // Kullanıcı inputlarını al
                double input1 = double.Parse(box1.Text);
                double input2 = double.Parse(box2.Text);

                // Hesaplamayı yap
                double output = Math.Sqrt(input1 * input1 + input2 * input2 * Math.PI * Math.PI) / input1;
                box3.Text = output.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama sırasında bir hata oluştu: " + ex.Message);
            }
        }
    }
}
