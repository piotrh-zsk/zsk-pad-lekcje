using Projekt_01_Etap_04_Rozwiazanie.Presenters;

namespace Projekt_01_Etap_04_Rozwiazanie
{
    public partial class Form1 : Form
    {
        // deklarujemy presentera, jest to klasa poœrednicz¹ca miêdzy naszym interfejsem graficznym
        // a nasz¹ logik¹ biznesow¹ osadzon¹ w serwisach (w projekcie Core). Klasa ta posiada wiedzê zarówno
        // o kontrolkach, bo przeka¿emy jej kontrolki jako parametry w konstruktorze. Klasa ta posiada te¿
        // wiedze o logice biznesowej, bo to w niej nastêpuje inicjalizacja serwisu
        TextAnalyzerDataPresenter textAnalyzerDataPresenter;


        public Form1()
        {
            // metoda poni¿ej jest to domyœlnie generowana metoda, odpowiedzialna za inicjalizacjê kontrolek
            // na formatce
            InitializeComponent();

            // inicjalizacja obiektu textAnalyzerDataPresenter mog³aby nast¹piæ te¿ w konstruktorze, ale
            // przy takim rozwiazaniu nale¿y pamiêtaæ, by nast¹pi³a ona dopiero PO metodzie InitializeComponent
            // w przeciwnym razie nie moglibyœmy przekazaæ kontrolek, gdy¿ jeszcze by one nie istnia³y

            // my jednak do inicjalizacji obiektu textAnalyzerDataPresenter wykorzystamy zdarzenie Form1_Load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // inicjalizacja obiektu textAnalyzerDataPresenter
            textAnalyzerDataPresenter = new TextAnalyzerDataPresenter(textBox1, textBox2, textBox3, textBox4, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ustawienie pocz¹tkowej œcie¿ki dla okienka wyboru plików
            string currentPath = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = currentPath;
            // ustawienie filtrów
            openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            // wyœwietlenie okienka wyboru plików
            var result = openFileDialog1.ShowDialog(this);
            // oczekiwanie na dzia³anie u¿ytkownika, dalsze dzia³ania podejmowane, je¿eli u¿ytkownik wybra³ plik
            if (result == DialogResult.OK)
            {
                // wczytanie zawartoœci pliku do osobnej zmiennej
                string fileText = File.ReadAllText(openFileDialog1.FileName);
                // osobne wrzucenie tekstu do kontrolki richTextBox1. Jak siê okaza³o, kontrolka "psuje" tekst usuwaj¹c
                // z niego znaki specjalne CR. Nie mo¿emy na to pozwoliæ, dlatego etap ten wykonywany jest osobno.
                richTextBox1.Text = fileText;
                // wywo³anie odpowiedniej metody w presenterze
                textAnalyzerDataPresenter.PerformTextAnalysis(fileText);
            }
        }
    }
}