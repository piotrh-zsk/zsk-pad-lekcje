using System.Diagnostics;

namespace Projekt_01_Etap_01_Rozwiazanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;

            // rozpoczêcie pomiaru czasu
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // przeprowadzenie analizy
            bool containsLetters = false;
            bool containsNumbers = false;
            bool containsSpecial = false;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (letter >= '0' && letter <= '9')
                    containsNumbers = true;
                else if ((letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z'))
                    containsLetters = true;
                else
                    containsSpecial = true;
                if (containsLetters && containsNumbers && containsSpecial)
                    break;
            }

            // zakoñczenie pomiaru czasu
            sw.Stop();

            // drukowanie wyników
            textBox1.Text = text.Length.ToString();
            textBox2.Text = containsLetters ? "TAK" : "NIE";
            textBox3.Text = containsNumbers ? "TAK" : "NIE";
            textBox4.Text = containsSpecial ? "TAK" : "NIE";
            textBox5.Text = sw.Elapsed.ToString();
        }
    }
}