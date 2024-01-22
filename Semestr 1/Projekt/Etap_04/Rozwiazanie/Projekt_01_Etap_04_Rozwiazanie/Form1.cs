using Projekt_01_Etap_04_Rozwiazanie.Presenters;

namespace Projekt_01_Etap_04_Rozwiazanie
{
    public partial class Form1 : Form
    {
        // deklarujemy presentera, jest to klasa po�rednicz�ca mi�dzy naszym interfejsem graficznym
        // a nasz� logik� biznesow� osadzon� w serwisach (w projekcie Core). Klasa ta posiada wiedz� zar�wno
        // o kontrolkach, bo przeka�emy jej kontrolki jako parametry w konstruktorze. Klasa ta posiada te�
        // wiedze o logice biznesowej, bo to w niej nast�puje inicjalizacja serwisu
        TextAnalyzerDataPresenter textAnalyzerDataPresenter;


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
            // inicjalizacja obiektu textAnalyzerDataPresenter
            textAnalyzerDataPresenter = new TextAnalyzerDataPresenter(textBox1, textBox2, textBox3, textBox4, dataGridView1);
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