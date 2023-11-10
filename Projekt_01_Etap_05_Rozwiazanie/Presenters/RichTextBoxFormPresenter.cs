using Projekt_01_Etap_05_Rozwiazanie.Core.Services;
using Projekt_01_Etap_05_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_05_Rozwiazanie.Shared.Interfaces;
using System.Text;

namespace Projekt_01_Etap_05_Rozwiazanie.Presenters
{
    public class RichTextBoxFormPresenter : IFormPresenter
    {
        private TextBox _tb_AllSymbols;
        private TextBox _tb_UniqueItems;
        private TextBox _tb_Entropy;
        private TextBox _tb_Time;
        private RichTextBox _rtb_Statistics;

        public RichTextBoxFormPresenter(TextBox tb_AllSymbols, TextBox tb_UniqueItems, TextBox tb_Entropy,
            TextBox tb_Time, RichTextBox rtb_Statistics)
        {
            _tb_AllSymbols = tb_AllSymbols;
            _tb_UniqueItems = tb_UniqueItems;
            _tb_Entropy = tb_Entropy;
            _tb_Time = tb_Time;
            _rtb_Statistics = rtb_Statistics;
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
            _tb_AllSymbols.Text = _textPrintingData.AllSymbolCount;
            _tb_UniqueItems.Text = _textPrintingData.UniqueSymbolCount;
            _tb_Entropy.Text = _textPrintingData.Entropy;
            _tb_Time.Text = _textPrintingData.ExecutionTime.ToString();
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
            _rtb_Statistics.Text = sb.ToString();
        }
    }
}
