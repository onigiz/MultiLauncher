using System;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.KangalMaxHizHesaplama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Hesapla_Click(object sender, EventArgs e)
        {
            try
            {
                // Girdi verilerini al
                double T1 = Convert.ToDouble(txt_BaslangicHizlanmaSure.Text);
                double T2 = Convert.ToDouble(txt_BitisYavaslamaSure.Text);
                double T = Convert.ToDouble(txt_ToplamSure.Text);
                double L = Convert.ToDouble(txt_ToplamBoy.Text);

                // Hesaplamayý yap
                double V = HesaplaMaxHiz(T1, T2, T, L);

                // Sonucu label'a yaz
                lbl_MaximumHiz.Text = V.ToString("0.0");
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Lütfen geçerli bir sayý girin: " + ex.Message);
            }
        }

        private double HesaplaMaxHiz(double T1, double T2, double T, double L)
        {
            double V = (L / ((T - (T1 + T2) / 60) + (T1 / 60) + (T2 / 60)));
            return V * 60; // m/s -> m/dk çevrimi
        }
    }
}
