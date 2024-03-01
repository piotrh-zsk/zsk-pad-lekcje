using Projekt_01_Etap_10_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Projekt_01_Etap_10_Rozwiazanie
{
    public partial class MainWIndowRTB : Form, IMainWindow
    {
        private readonly ITextStatisticsService _textStatisticsService;
        private readonly CompressForm _compressForm;
        private readonly DecompressForm _decompressForm;


        public MainWIndowRTB(ITextStatisticsService textStatisticsService, CompressForm compressForm, DecompressForm decompressForm)
        {
            _textStatisticsService = textStatisticsService;
            _compressForm = compressForm;
            _decompressForm = decompressForm;

            InitializeComponent();
        }


        private void bt_PrzeprowadzAnalize_Click(object sender, EventArgs e)
        {
            string currentPath = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = currentPath;
            //openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileText = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding("Windows-1250"));
                rtb_Statystyka_TekstWejsciowy.Text = fileText;

                Stopwatch sw = new Stopwatch();
                sw.Start();
                TextStatisticsData statisticsData = _textStatisticsService.CountStatistics(fileText);
                sw.Stop();
                TextPrintingData printingData = _textStatisticsService.FillPrintingData(statisticsData);
                printingData.ExecutionTime = sw.Elapsed;

                // drukowanie wyników
                ShowStats(printingData);
            }
        }

        private void bt_SkompresujPlik_Click(object sender, EventArgs e)
        {
            _compressForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _compressForm.MaximizeBox = false;
            _compressForm.MinimizeBox = false;
            _compressForm.StartPosition = FormStartPosition.CenterParent;
            _compressForm.Text = "Kompresowanie pliku...";
            _compressForm.Opacity = 0.95;
            _compressForm.ShowDialog();
        }

        private void bt_DekompresujPlik_Click(object sender, EventArgs e)
        {
            _decompressForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            _decompressForm.MaximizeBox = false;
            _decompressForm.MinimizeBox = false;
            _decompressForm.StartPosition = FormStartPosition.CenterParent;
            _decompressForm.Text = "Dekompresowanie pliku...";
            _decompressForm.Opacity = 0.92;
            _decompressForm.ShowDialog();
        }


        private void bt_SpakujPlik_Click(object sender, EventArgs e)
        {
            //    string currentPath = Environment.CurrentDirectory;
            //    openFileDialog1.InitialDirectory = currentPath;
            //    openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            //    var result = openFileDialog1.ShowDialog(this);
            //    if (result == DialogResult.OK)
            //    {
            //        var fileText = File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding("Windows-1250"));
            //        rtb_Statystyka_TekstWejsciowy.Text = fileText;
            //        //textAnalyzerDataPresenter?.PerformTextCompression(openFileDialog1.SafeFileName, fileText);
            //    }
        }

        private void bt_RozpakujPlik_Click(object sender, EventArgs e)
        {
            //    string filename = "";
            //    byte[]? fileContents = null;
            //    using (OpenFileDialog ofd = new OpenFileDialog())
            //    {
            //        ofd.Filter = "ZSK Compressed File file|*.zcf";
            //        DialogResult result = ofd.ShowDialog();
            //        if (result == DialogResult.OK)
            //        {
            //            filename = ofd.SafeFileName;
            //            fileContents = File.ReadAllBytes(ofd.FileName);
            //        }
            //    }
            //    if (fileContents != null)
            //    {
            //        //textAnalyzerDataPresenter?.PerformTextDecompression(filename, fileContents);
            //    }
        }


        private void ShowStats(TextPrintingData printingData)
        {
            tb_Statystyka_LiczbaWszystkichZnakow.Text = printingData.AllSymbolCount;
            tb_Statystyka_LiczbaUnikatowychZnakow.Text = printingData.UniqueSymbolCount;
            tb_Statystyka_Entropia.Text = printingData.Entropy;
            tb_Statystyka_CzasWykonania.Text = printingData.ExecutionTime.ToString();

            StringBuilder sb = new StringBuilder();
            string mask = "{0}|{1}|{2}|{3}|{4}|{5}";
            int colWidth = 25;
            sb.AppendLine(string.Format(mask,
                    "Zapis binarny".PadRight(colWidth, ' '),
                    "Zapis dziesiętny".PadRight(colWidth, ' '),
                    "Symbol".PadRight(colWidth, ' '),
                    "Częstość".PadRight(colWidth, ' '),
                    "Prawdopodobieństwo".PadRight(colWidth, ' '),
                    "Ilość informacji".PadRight(colWidth, ' ')));
            for (int i = 0; i < printingData?.SymbolStatistics?.Count; i++)
            {
                sb.AppendLine(string.Format(mask,
                    printingData.SymbolStatistics[i].BinaryNotation?.PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].DecimalNotation?.ToString().PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].Symbol?.PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].Frequency?.ToString().PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].Probability?.ToString().PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].InformationQuantity?.ToString().PadRight(colWidth, ' ')));
            }
            rtb_Statystyka_StatystykaSymboli.Text = sb.ToString();
        }
    }
}
