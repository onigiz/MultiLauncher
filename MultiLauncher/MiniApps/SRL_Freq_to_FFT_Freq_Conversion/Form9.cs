using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.SRL_Freq_to_FFT_Freq_Conversion
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Hesapla_btn_click(object sender, EventArgs e)
        {
            try
            {
                // Girdi verilerini al
                double Fsrl = Convert.ToDouble(box1.Text);
                double Vp = Convert.ToDouble(box2.Text);
                double Line_Speed_m_min = Convert.ToDouble(box3.Text);
                double Light_Speed = 300000000;

                // ft/sec conversion
                double Line_Speed_m_sec = Line_Speed_m_min / 60;
                box5.Text = Line_Speed_m_sec.ToString("0.00");


                double Line_Speed_ft_sec = Line_Speed_m_min * 0.0546806649;
                box6.Text = Line_Speed_ft_sec.ToString("0.00");

                double Wavelength = (0.5 * Vp * Light_Speed) / (Fsrl * 10000000);
                box7.Text = Wavelength.ToString("0.00000");

                double Frequency = Line_Speed_m_sec / Wavelength;
                box8.Text = Frequency.ToString("0.00");

                double Period = 1 / Frequency;
                box9.Text = Period.ToString("0.00000000");
                
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lütfen geçerli bir sayı girin!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
