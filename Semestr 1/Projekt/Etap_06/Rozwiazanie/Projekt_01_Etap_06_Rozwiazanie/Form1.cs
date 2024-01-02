using Projekt_01_Etap_06_Rozwiazanie.Presenters;
using Projekt_01_Etap_06_Rozwiazanie.Shared.Interfaces;
using System.Windows.Forms;

namespace Projekt_01_Etap_06_Rozwiazanie
{
    public partial class Form1 : Form
    {
        // Metoda wytwórcza - kork 4
        // Nastêpnym krokiem jest zmiana konkretnego tupu Presentera na bardziej ogólny, przy wykorzystaniu interfejsu.
        private IFormPresenter? textAnalyzerDataPresenter;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Metoda wytwórcza - kork 5
            // Ostatnim krokiem jest utworzenie klasy presentera wykorzystuj¹c do tego odpowiedni¹ metodê wytwórcz¹.
            textAnalyzerDataPresenter = (new DataGridViewFormPresenterCreator()).FactoryMethod(
                // zak³adka Statystyka
                tb_Statystyka_LiczbaWszystkichZnakow,
                tb_Statystyka_LiczbaUnikatowychZnakow,
                tb_Statystyka_Entropia,
                tb_Statystyka_CzasWykonania,
                dgv_Statystyka_StatystykaSymboli,
                // zak³adka Kompresowanie
                tb_Kompresowanie_CzasWyznaczeniaKodow,
                tb_Kompresowanie_CzasKompresji,
                dgv_Kompresowanie_Kody,
                // zak³adka Dekompresowanie
                tb_Dekompresowanie_CzasWyznaczeniaKodow,
                tb_Dekompresowanie_CzasDekompresji,
                dgv_Dekompresowanie_Kody,
                rtb_Dekompresowanie_Zawartosc);
        }

        private void bt_PrzeprowadzAnalize_Click(object sender, EventArgs e)
        {
            string currentPath = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = currentPath;
            openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileText = File.ReadAllText(openFileDialog1.FileName);
                rtb_Statystyka_TekstWejsciowy.Text = fileText;
                textAnalyzerDataPresenter?.PerformTextAnalysis(fileText);
            }
        }

        private void bt_SpakujPlik_Click(object sender, EventArgs e)
        {
            string currentPath = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = currentPath;
            openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileText = File.ReadAllText(openFileDialog1.FileName);
                rtb_Statystyka_TekstWejsciowy.Text = fileText;
                textAnalyzerDataPresenter?.PerformTextCompression(openFileDialog1.SafeFileName, fileText);
            }
        }

        private void bt_RozpakujPlik_Click(object sender, EventArgs e)
        {
            string filename = "";
            byte[]? fileContents = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "ZSK Compressed File file|*.zcf";
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filename = ofd.SafeFileName;
                    fileContents = File.ReadAllBytes(ofd.FileName);
                }
            }
            if (fileContents != null)
            {
                textAnalyzerDataPresenter?.PerformTextDecompression(filename, fileContents);
            }
        }
    }
}