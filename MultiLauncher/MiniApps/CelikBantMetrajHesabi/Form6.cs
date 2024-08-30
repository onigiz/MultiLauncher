using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.CelikBantMetrajHesabi
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Baslik_Click(object sender, EventArgs e)
        {

        }

        private void Sifirla_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Hesapla_Click(object sender, EventArgs e)
        {
            try
            {
                double disCap = Convert.ToDouble(textBox1.Text.Replace(",", "."));
                double icCap = Convert.ToDouble(textBox2.Text.Replace(",", "."));
                double en = Convert.ToDouble(textBox3.Text.Replace(",", "."));
                double kalinlik = Convert.ToDouble(textBox6.Text.Replace(",", "."));

                double K = (disCap * disCap * en * 7850 * 7850) / 1000000000000;
                double L = (icCap * icCap * en * 7850 * 7850) / 1000000000000;
                double M = (7.85 * en * kalinlik) / 1000;


                double metraj = (K -L) / M;
                double agirlik = K -L; 

                textBox4.Text = metraj.ToString("0.00");
                textBox5.Text = agirlik.ToString("0.00");
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen sayı türünde değer giriniz!");
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("Lütfen sayı türünde değer giriniz!");
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
