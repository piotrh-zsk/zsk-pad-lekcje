using Projekt_01_Etap_05_Rozwiazanie.Presenters;
using Projekt_01_Etap_05_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_05_Rozwiazanie
{
    public partial class Form1 : Form
    {
        // Metoda wytw�rcza - kork 4
        // Nast�pnym krokiem jest zmiana konkretnego tupu Presentera na bardziej og�lny, przy wykorzystaniu interfejsu.
        private IFormPresenter? textAnalyzerDataPresenter;


        public Form1()
        {
            // metoda poni�ej jest to domy�lnie generowana metoda, odpowiedzialna za inicjalizacj� kontrolek
            // na formatce
            InitializeComponent();

            // inicjalizacja obiektu textAnalyzerDataPresenter mog�aby nast�pi� te� w konstruktorze, ale
            // przy takim rozwiazaniu nale�y pami�ta�, by nast�pi�a ona dopiero PO metodzie InitializeComponent
            // w przeciwnym razie nie mogliby�my przekaza� kontrolek, gdy� jeszcze by one nie istnia�y

            // my jednak do inicjalizacji obiektu textAnalyzerDataPresenter wykorzystamy zdarzenie Form1_Load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Metoda wytw�rcza - kork 5
            // Ostatnim krokiem jest utworzenie klasy presentera wykorzystuj�c do tego odpowiedni� metod� wytw�rcz�.
            textAnalyzerDataPresenter = (new DataGridViewFormPresenterCreator()).FactoryMethod(textBox1, textBox2, textBox3, textBox4, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ustawienie pocz�tkowej �cie�ki dla okienka wyboru plik�w
            string currentPath = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = currentPath;
            // ustawienie filtr�w
            openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            // wy�wietlenie okienka wyboru plik�w
            var result = openFileDialog1.ShowDialog(this);
            // oczekiwanie na dzia�anie u�ytkownika, dalsze dzia�ania podejmowane, je�eli u�ytkownik wybra� plik
            if (result == DialogResult.OK)
            {
                // wczytanie zawarto�ci pliku do osobnej zmiennej
                string fileText = File.ReadAllText(openFileDialog1.FileName);
                // osobne wrzucenie tekstu do kontrolki richTextBox1. Jak si� okaza�o, kontrolka "psuje" tekst usuwaj�c
                // z niego znaki specjalne CR. Nie mo�emy na to pozwoli�, dlatego etap ten wykonywany jest osobno.
                richTextBox1.Text = fileText;
                // wywo�anie odpowiedniej metody w presenterze
                textAnalyzerDataPresenter.PerformTextAnalysis(fileText);
            }
        }
    }
}