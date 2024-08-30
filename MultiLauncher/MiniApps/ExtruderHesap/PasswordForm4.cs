using System;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.ExtruderHesap
{
    public partial class PasswordForm4 : Form
    {
        public PasswordForm4()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string password = "Nexans2024*"; // Belirlediğiniz şifre

            if (txtPassword.Text == password)
            {
                this.DialogResult = DialogResult.OK;
                this.Close(); // Formun kapanmasını sağla
            }
            else
            {
                MessageBox.Show("Hatalı şifre!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
