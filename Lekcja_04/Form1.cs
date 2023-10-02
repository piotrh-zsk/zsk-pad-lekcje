using System.Windows.Forms;

namespace Lekcja_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Text = "Program otworzy okno i zatrzyma si� z dalszymi dzia�aniami. Dalsza cz�� kodu b�dzie wykonywana w zale�no�ci od wyniku.";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                richTextBox1.Text += "\n\nWybrano plik - klikni�to przycisk OK";

                richTextBox1.Text += "\n\nWybrany plik: " + openFileDialog1.FileName;
            }
            else
            {
                richTextBox1.Text += "\n\nKlikni�to przycisk Auluj";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            openFileDialog1.InitialDirectory = @"C:\";
            DialogResult result = openFileDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            DialogResult result = openFileDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            openFileDialog1.Multiselect = true;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    richTextBox1.Text += "\n" + file;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] linieTekstu = File.ReadAllLines(openFileDialog1.FileName);
                foreach (string line in linieTekstu)
                {
                    richTextBox1.Text += "\n" + line;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string linieTekstu = File.ReadAllText(openFileDialog1.FileName);
                richTextBox1.Text = linieTekstu;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string imie = "Ala";
            string nazwisko = "MaKota";
            int wiek = 23;

            richTextBox1.Text = "Przyk�ad - string.Format \n\n";

            var wynik = string.Format("Ta linia tekstu dotyczy osoby o nazwisku {1} i imieniu {0}, kt�rej wiek to {2}", imie, nazwisko, wiek);
            richTextBox1.Text += wynik;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string imie = "Ala";
            string nazwisko = "MaKota";
            int wiek = 23;

            richTextBox1.Text = "Przyk�ad - formattable string \n\n";

            string wynik = $"Ta linia tekstu dotyczy osoby o imieniu {imie} i nazwisku {nazwisko}, kt�rej wiek to {wiek}";
            richTextBox1.Text += wynik;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double pi = 3.14159265359;
            DateTime now = DateTime.Now;

            richTextBox1.Text = "Przyk�ad - formatowanie argument�w \n\n";

            var wynik = string.Format("Liczba PI w og�lno�ci to: {0:0.##} a dok�adniej {0:0.######} - wygenerowano ten tekst o {1:HH:mm:ss}", pi, now);
            var wynik2 = $"Liczba PI w og�lno�ci to: {pi:0.##} a dok�adniej {pi:0.######} - wygenerowano ten tekst o {now:HH:mm:ss}";
            richTextBox1.Text += wynik + "\n\n" + wynik2;

            // wi�cej mo�liwo�ci formatowania znajdziesz pod adresem:
            // https://dzone.com/articles/c-string-format-examples
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int wartosc1 = 10;
            int wartosc2 = 1210;
            int wartosc3 = 56;
            int wartosc4 = 123;

            int szerokosc1 = 20;
            char znak1 = '_';
            int szerokosc2 = 6;
            char znak2 = '#';

            richTextBox1.Text = "Przyk�ad - wyr�wnywanie tekstu \n\n";

            var wynik =
                string.Format("\n|{0}|{1}|", wartosc1.ToString().PadLeft(szerokosc1, znak1), wartosc2.ToString().PadLeft(szerokosc2, znak2)) +
                string.Format("\n|{0}|{1}|", wartosc3.ToString().PadRight(szerokosc1, znak1), wartosc4.ToString().PadRight(szerokosc2, znak2));

            richTextBox1.Text += wynik;
        }
    }
}