namespace Lekcja_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = "ksjdfh";
            dataGridView1.Rows[index].Cells[1].Value = 6573.4;
            dataGridView1.Rows[index].Cells[2].Value = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = "abc";
            row.Cells[1].Value = 123.4;
            row.Cells[2].Value = false;
            dataGridView1.Rows.Add(row);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add("ala", "makota", true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Insert(0, "www", "eee", true);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // SprawdŸ obs³ugê zdarzenia poni¿ej
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string typKolumny = "";
            string wartosc = "";
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn)
            {
                typKolumny = "TextBox";
                wartosc = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                typKolumny = "Button";
                wartosc = "-";
            }
            else if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                typKolumny = "CheckBox";
                wartosc = ((bool)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) ? "true" : "false";
            }
            else if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                typKolumny = "ComboBox";
                wartosc = "-";
            }

            MessageBox.Show("Klikniêto w wiersz " + e.RowIndex + ", kolumna " + e.ColumnIndex + " typu " + typKolumny + " zawartoœæ: " + wartosc);
        }
    }
}