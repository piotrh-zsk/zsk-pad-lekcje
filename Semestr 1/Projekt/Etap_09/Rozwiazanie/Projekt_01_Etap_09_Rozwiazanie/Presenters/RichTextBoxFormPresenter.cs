using Projekt_01_Etap_09_Rozwiazanie.Core.Services;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces;
using System.Text;

namespace Projekt_01_Etap_09_Rozwiazanie.Presenters
{
    public class RichTextBoxFormPresenter : IFormPresenter
    {
        // zakładka Statystyka
        private TextBox _tb_Statistics_AllSymbols;
        private TextBox _tb_Statistics_UniqueItems;
        private TextBox _tb_Statistics_Entropy;
        private TextBox _tb_Statistics_Time;
        private RichTextBox _rtb_Statistics_Statistics;
        // zakładka Kompresowanie
        private TextBox _tb_Compression_CodesTime;
        private TextBox _tb_Compression_CompressionTime;
        private DataGridView _dgv_Compression_Codes;
        // zakładka Dekompresowanie
        private TextBox _tb_Decompression_CodesTime;
        private TextBox _tb_Decpression_DecompressionTime;
        private DataGridView _dgv_Decpression_Codes;
        private RichTextBox _rtb_Decompression_CileContents;

        public RichTextBoxFormPresenter(
            TextBox tb_Statistics_AllSymbols, TextBox tb_Statistics_UniqueItems, TextBox tb_Statistics_Entropy, TextBox tb_Statistics_Time, RichTextBox rtb_Statistics_Statistics,
            TextBox tb_Compression_CodesTime, TextBox tb_Compression_CompressionTime, DataGridView dgv_Compression_Codes,
            TextBox tb_Decompression_CodesTime, TextBox tb_Decpression_DecompressionTime, DataGridView dgv_Decpression_Codes, RichTextBox rtb_Decompression_CileContents)
        {
            _tb_Statistics_AllSymbols = tb_Statistics_AllSymbols;
            _tb_Statistics_UniqueItems = tb_Statistics_UniqueItems;
            _tb_Statistics_Entropy = tb_Statistics_Entropy;
            _tb_Statistics_Time = tb_Statistics_Time;
            _rtb_Statistics_Statistics = rtb_Statistics_Statistics;
            _tb_Compression_CodesTime = tb_Compression_CodesTime;
            _tb_Compression_CompressionTime = tb_Compression_CompressionTime;
            _dgv_Compression_Codes = dgv_Compression_Codes;
            _tb_Decompression_CodesTime = tb_Decompression_CodesTime;
            _tb_Decpression_DecompressionTime = tb_Decpression_DecompressionTime;
            _dgv_Decpression_Codes = dgv_Decpression_Codes;
            _rtb_Decompression_CileContents = rtb_Decompression_CileContents;
        }

        public void PerformTextAnalysis(string text)
        {
            // Singleton - Krok 5
            // Zmieniamy sposób powoływania klasy. Sigleton zapewnia nam, że utworzona zostanie maksymalnie jedna
            // instancja tej klasy, dlatego możemy przenieść jej inicjalizację do metody PerformTextAnalysis,
            // która jest wielokrotnie wywoływana.
            // aktywacja serwisów - korzystamy z metody GetInstance
            BaseTextStatisticsService _textStatisticsService = TextStatisticsService.GetInstance(); // .08
                                                                                                    //BaseTextStatisticsService _textStatisticsService = Array_TextStatisticsService.GetInstance(); // .002
                                                                                                    //BaseTextStatisticsService _textStatisticsService = Dictionary_TextStatisticsService.GetInstance(); // .006

            // przeprowadzenie analizy tekstu
            TextPrintingData _textPrintingData = _textStatisticsService.TemplateMethod(text);

            // drukowanie wyników
            _tb_Statistics_AllSymbols.Text = _textPrintingData.AllSymbolCount;
            _tb_Statistics_UniqueItems.Text = _textPrintingData.UniqueSymbolCount;
            _tb_Statistics_Entropy.Text = _textPrintingData.Entropy;
            _tb_Statistics_Time.Text = _textPrintingData.ExecutionTime.ToString();
            StringBuilder sb = new StringBuilder();
            string mask = "{0} | {1} | {2} | {3} | {4} | {5}";
            int colWidth = 25;
            sb.AppendLine(string.Format(mask,
                    "Zapis binarny".PadRight(colWidth, ' '),
                    "Zapis dziesiętny".PadRight(colWidth, ' '),
                    "Symbol".PadRight(colWidth, ' '),
                    "Częstość".PadRight(colWidth, ' '),
                    "Prawdopodobieństwo".PadRight(colWidth, ' '),
                    "Ilość informacji".PadRight(colWidth, ' ')));
            for (int i = 0; i < _textPrintingData?.SymbolStatistics?.Count; i++)
            {
                sb.AppendLine(string.Format("{0} | {1} | {2} | {3} | {4} | {5}",
                    _textPrintingData.SymbolStatistics[i].BinaryNotation?.PadRight(colWidth, ' '),
                    _textPrintingData.SymbolStatistics[i].DecimalNotation?.ToString().PadRight(colWidth, ' '),
                    _textPrintingData.SymbolStatistics[i].Symbol?.PadRight(colWidth, ' '),
                    _textPrintingData.SymbolStatistics[i].Frequency?.ToString().PadRight(colWidth, ' '),
                    _textPrintingData.SymbolStatistics[i].Probability?.ToString().PadRight(colWidth, ' '),
                    _textPrintingData.SymbolStatistics[i].InformationQuantity?.ToString().PadRight(colWidth, ' ')));
            }
            _rtb_Statistics_Statistics.Text = sb.ToString();
        }

        public void PerformTextCompression(string filename, string text)
        {
        }

        public void PerformTextDecompression(string filename, byte[] fileContents)
        {
        }
    }
}
