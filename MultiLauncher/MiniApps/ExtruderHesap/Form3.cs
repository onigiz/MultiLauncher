using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.ExtruderHesap
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }

        private void LoadComboboxes()
        {
            try
            {
                string[] lines = File.ReadAllLines("matrix_ExtruderHesap.txt");
                if (lines.Length > 0)
                {
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();

                    // Add first line's comma-separated items to comboBox2
                    string firstLine = lines[0];
                    string[] firstLineItems = firstLine.Split(',');
                    comboBox2.Items.AddRange(firstLineItems);

                    // Add the first element of each line (skipping the first line) to comboBox1
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] items = lines[i].Split(',');
                        if (items.Length > 0)
                        {
                            comboBox1.Items.Add(items[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okunamad�: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PasswordForm4 passwordForm = new PasswordForm4();
            if (passwordForm.ShowDialog() == DialogResult.OK)
            {
                Form4 Form4 = Form4.GetInstance();
                Form4.Show();
                Form4.BringToFront(); // Bring Form4 to the front
                Form4.WindowState = FormWindowState.Normal; // Restore if minimized
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateExtruderPlastikKapasite();
        }

        private void CalculateExtruderPlastikKapasite()
        {
            var selectedHatNo = comboBox1.SelectedItem?.ToString();
            var selectedHammaddeTipi = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedHatNo) || string.IsNullOrEmpty(selectedHammaddeTipi))
            {
                MessageBox.Show("L�tfen ge�erli bir Hat No ve Hammadde Tipi se�iniz.");
                return;
            }

            var kapasite = GetValueFromMatrix(selectedHatNo, selectedHammaddeTipi);

            if (kapasite == 0)
            {
                MessageBox.Show("L�tfen ge�erli bir hammadde girin!");
                return;
            }

            textBox5.Text = kapasite.ToString();

            // Yeni hesaplamalar
            if (double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double toplamHammaddeAgirlik) &&
                double.TryParse(textBox2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double toplamBoy) &&
                double.TryParse(textBox5.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double extruderPlastikKapasite) &&
                double.TryParse(textBox3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double payOffKabloBoyu))
            {
                double metreBasinaAgirlik = toplamHammaddeAgirlik / toplamBoy;
                double extruderPlastikKapasiteMetre = extruderPlastikKapasite / metreBasinaAgirlik;
                double plastikKesmeMetraj = payOffKabloBoyu - extruderPlastikKapasiteMetre;

                textBox4.Text = metreBasinaAgirlik.ToString("F5", CultureInfo.InvariantCulture);
                textBox6.Text = extruderPlastikKapasiteMetre.ToString("F5", CultureInfo.InvariantCulture);
                textBox7.Text = plastikKesmeMetraj.ToString("F5", CultureInfo.InvariantCulture);
            }
            else
            {
                MessageBox.Show("L�tfen t�m alanlara ge�erli de�erler giriniz.");
            }
        }

        private double GetValueFromMatrix(string hatNo, string hammaddeTipi)
        {
            try
            {
                string[] lines = File.ReadAllLines("matrix_ExtruderHesap.txt");
                if (lines.Length > 0)
                {
                    string[] headers = lines[0].Split(',');

                    // Hammadde tipinin bulundu�u s�tun indeksini al
                    int columnIndex = Array.IndexOf(headers, hammaddeTipi) + 1;
                    if (columnIndex == 0)
                    {
                        MessageBox.Show("Hammadde Tipi bulunamad�.");
                        return 0;
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] items = lines[i].Split(',');
                        if (items[0] == hatNo)
                        {
                            // Se�ilen hat no sat�r�n�n do�ru s�tununu kontrol et, debug i�in kullanabilirsin
                            if (items.Length > columnIndex)
                            {
                                if (double.TryParse(items[columnIndex], NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                                {
                                    //MessageBox.Show($"Hat No: {hatNo}, Hammadde Tipi: {hammaddeTipi}, De�er: {result}");
                                    return result;
                                }
                                else
                                {
                                    MessageBox.Show("Hatal� veri.");
                                    return 0; // Bo� h�creler veya hatal� de�erler i�in 0 d�nd�r
                                }
                            }
                        }
                    }

                    MessageBox.Show("Hat No bulunamad�.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okunamad�: " + ex.Message);
            }

            return 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

            // Clear combobox selections
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }
    }
}
