using System.Diagnostics;
using System.Text;

namespace Lekcja_02_Przyklady
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = !textBox2.Enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Klikniêto przycisk!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string textBoxValue = textBox1.Text;

            MessageBox.Show(textBoxValue);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox1.Text + "\n" + textBox2.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            string linia = "Moja linia tekstu nr: ";

            sw.Start();
            for (int i = 0; i < 3000; i++)
            {
                richTextBox1.Text += "\n" + linia + i;
            }
            sw.Stop();
            textBox2.Text = (sw.ElapsedMilliseconds).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            string linia = "Moja linia tekstu nr: ";

            sw.Start();
            string wynik = "";
            //for (int i = 0; i < 3000; i++)
            for (int i = 0; i < 45000; i++)
            {
                wynik += "\n" + linia + i;
            }
            richTextBox1.Text = wynik;
            sw.Stop();
            textBox2.Text = (sw.ElapsedMilliseconds).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            string linia = "Moja linia tekstu nr: ";

            sw.Start();
            StringBuilder wynik = new StringBuilder();
            //for (int i = 0; i < 3000; i++)
            //for (int i = 0; i < 45000; i++)
            for (int i = 0; i < 3000000; i++)
            {
                wynik.Append('\n');
                wynik.Append(linia);
                wynik.Append(i);
            }
            richTextBox1.Text = wynik.ToString();
            sw.Stop();
            textBox2.Text = (sw.ElapsedMilliseconds).ToString();
        }
    }
}