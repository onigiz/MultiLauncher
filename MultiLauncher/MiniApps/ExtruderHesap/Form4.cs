using System;
using System.IO;
using System.Windows.Forms;

namespace MultiLauncher.MiniApps.ExtruderHesap
{
    public partial class Form4 : Form
    {
        private static Form4 instance;
        private const string MatrixFilePath = "matrix_ExtruderHesap.txt";
        private const string ColumnWidthsFilePath = "column_widths_ExtruderHesap.txt";

        private Form4()
        {
            InitializeComponent();
        }

        public static Form4 GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Form4();
            }
            return instance;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            LoadMatrixFromFile(MatrixFilePath);
            LoadColumnWidths(ColumnWidthsFilePath);
            AutoResizeRowHeadersWidth();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ConfirmationForm.Show("Emin misiniz?", "Kaydet"))
            {
                SaveMatrixToFile(MatrixFilePath);
                SaveColumnWidths(ColumnWidthsFilePath);
                MessageBox.Show("Kayıt Başarılı!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewColumn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteSelectedColumn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;

            dataGridView1.RowHeadersWidth = 300;

            dataGridView1.CellMouseDoubleClick += DataGridView1_CellMouseDoubleClick;
            dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;

            // Yeni sütunlar eklendiğinde genişliklerini 300 olarak ayarla ve sıralamayı kapat
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 300;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void DataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    string currentHeaderText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                    string newHeaderText = Prompt.ShowDialog("Sütun Başlığını Düzenle", currentHeaderText);
                    if (!string.IsNullOrEmpty(newHeaderText))
                    {
                        dataGridView1.Columns[e.ColumnIndex].HeaderText = newHeaderText;
                    }
                }
                else if (e.ColumnIndex == -1)
                {
                    string currentHeaderText = dataGridView1.Rows[e.RowIndex].HeaderCell.Value?.ToString();
                    string newHeaderText = Prompt.ShowDialog("Satır Başlığını Düzenle", currentHeaderText);
                    if (!string.IsNullOrEmpty(newHeaderText))
                    {
                        dataGridView1.Rows[e.RowIndex].HeaderCell.Value = newHeaderText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Başlık düzenlenirken bir hata oluştu: {ex.Message}");
            }
        }

        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= TextBox_KeyPress;
                tb.KeyPress += TextBox_KeyPress;
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == '.')
            {
                if (e.KeyChar == '.')
                {
                    TextBox tb = sender as TextBox;
                    if (tb != null && tb.Text.Contains("."))
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (e.KeyChar == ',')
            {
                MessageBox.Show("Lütfen ',' yerine '.' kullanın!", "Geçersiz Karakter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AddNewColumn()
        {
            int newColIndex = dataGridView1.ColumnCount;
            string columnName = $"Column {newColIndex + 1}";
            dataGridView1.Columns.Add(columnName, columnName);
            dataGridView1.Columns[newColIndex].Width = 300;
            dataGridView1.Columns[newColIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void AddNewRow()
        {
            dataGridView1.Rows.Add();
            int newRowIndex = dataGridView1.Rows.Count - 1;
            dataGridView1.Rows[newRowIndex].HeaderCell.Value = $"Row {newRowIndex + 1}";
            AutoResizeRowHeadersWidth();
        }

        private void DeleteSelectedColumn()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedColumnIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                if (selectedColumnIndex >= 0 && selectedColumnIndex < dataGridView1.ColumnCount)
                {
                    dataGridView1.Columns.RemoveAt(selectedColumnIndex);
                }
            }
        }

        private void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView1.RowCount && !dataGridView1.Rows[selectedRowIndex].IsNewRow)
                {
                    dataGridView1.Rows.RemoveAt(selectedRowIndex);
                    AutoResizeRowHeadersWidth();
                }
            }
        }

        private void SaveMatrixToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Sütun başlıklarını yaz
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    sw.Write(dataGridView1.Columns[col].HeaderText);
                    if (col < dataGridView1.ColumnCount - 1)
                        sw.Write(",");
                }
                sw.WriteLine();

                // Satır verilerini yaz
                for (int row = 0; row < dataGridView1.RowCount; row++)
                {
                    if (!dataGridView1.Rows[row].IsNewRow)
                    {
                        sw.Write(dataGridView1.Rows[row].HeaderCell.Value);
                        for (int col = 0; col < dataGridView1.ColumnCount; col++)
                        {
                            sw.Write("," + (dataGridView1[col, row].Value?.ToString() ?? ""));
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        private void LoadMatrixFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string headerLine = sr.ReadLine();
                    if (headerLine != null)
                    {
                        string[] headers = headerLine.Split(',');
                        dataGridView1.ColumnCount = headers.Length;
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataGridView1.Columns[i].HeaderText = headers[i];
                            dataGridView1.Columns[i].Width = 300;
                            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    }

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        if (values.Length > 0)
                        {
                            int rowIndex = dataGridView1.Rows.Add();
                            dataGridView1.Rows[rowIndex].HeaderCell.Value = values[0];
                            for (int col = 1; col < values.Length; col++)
                            {
                                dataGridView1[col - 1, rowIndex].Value = values[col];
                            }
                        }
                    }
                }
                AutoResizeRowHeadersWidth();
            }
        }

        private void SaveColumnWidths(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int col = 0; col < dataGridView1.ColumnCount; col++)
                {
                    sw.Write(dataGridView1.Columns[col].Width);
                    if (col < dataGridView1.ColumnCount - 1)
                        sw.Write(",");
                }
            }
        }

        private void LoadColumnWidths(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        string[] widths = line.Split(',');
                        for (int col = 0; col < widths.Length && col < dataGridView1.ColumnCount; col++)
                        {
                            if (int.TryParse(widths[col], out int width))
                            {
                                dataGridView1.Columns[col].Width = width;
                            }
                        }
                    }
                }
            }
        }

        private void AutoResizeRowHeadersWidth()
        {
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "OK", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
        }
    }

    public static class ConfirmationForm
    {
        public static bool Show(string text, string caption)
        {
            Form confirmation = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            Button okButton = new Button() { Text = "OK", Left = 250, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            Button cancelButton = new Button() { Text = "İPTAL", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.Cancel };
            confirmation.Controls.Add(textLabel);
            confirmation.Controls.Add(okButton);
            confirmation.Controls.Add(cancelButton);
            confirmation.AcceptButton = okButton;
            confirmation.CancelButton = cancelButton;

            return confirmation.ShowDialog() == DialogResult.OK;
        }
    }
}
