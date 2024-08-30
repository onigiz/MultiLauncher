using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.Helisel_Bant_Boyu_Hesaplama
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();

            // KeyPress olaylarını kutulara bağla
            box1.KeyPress += new KeyPressEventHandler(box_KeyPress);
            box2.KeyPress += new KeyPressEventHandler(box_KeyPress);
            box3.KeyPress += new KeyPressEventHandler(box_KeyPress);
            box4.KeyPress += new KeyPressEventHandler(box_KeyPress);
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
                box3.Text = box3.Text.Replace('.', ',');
                box4.Text = box4.Text.Replace('.', ',');

                // Kullanıcı inputlarını al
                double kabloBoyu = double.Parse(box1.Text);
                double bantAltıCap = double.Parse(box2.Text);
                double bantKalınlığı = double.Parse(box3.Text);
                double bantEni = double.Parse(box4.Text);

                // Binme hesaplaması
                double binme = bantEni * 0.25;
                box5.Text = binme.ToString();

                // Bant boyu hesaplaması
                double bantBoyu = ((Math.PI * (bantAltıCap + bantKalınlığı)) / ((bantEni) * (1 - binme / 100))) * kabloBoyu;
                box6.Text = bantBoyu.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void Baslik_Click(object sender, EventArgs e)
        {
            //error önlemi
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //error önlemi
        }
    }
}
