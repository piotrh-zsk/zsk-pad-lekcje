using Projekt_01_Etap_03_Rozwiazanie.Core.Services;
using Projekt_01_Etap_03_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_03_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Projekt_01_Etap_03_Rozwiazanie.Presenters
{
    public class TextAnalyzerDataPresenter
    {
        // ustawienie pól jako prywatne, nie chcemy by były one widoczne z zewnątrz klasy TextAnalyzerDataPresenter
        // pola te są wewnętrzną sprawą tej klasy, wartości tych pól przekazujemy lub inicjalizujemy w konstruktorze
        private TextBox _tb_AllSymbols;
        private TextBox _tb_UniqueItems;
        private TextBox _tb_Entropy;
        private TextBox _tb_Time;
        private RichTextBox _rtb_Statistics;

        private ITextStatisticsService _myTextService;


        public TextAnalyzerDataPresenter(TextBox tb_AllSymbols, TextBox tb_UniqueItems, TextBox tb_Entropy,
            TextBox tb_Time, RichTextBox rtb_Statistics)
        {
            // rapisanie sobie referencji do kontrolek, by móc się do nich odwoływać w innych miejscach w kodzie
            _tb_AllSymbols = tb_AllSymbols;
            _tb_UniqueItems = tb_UniqueItems;
            _tb_Entropy = tb_Entropy;
            _tb_Time = tb_Time;
            _rtb_Statistics = rtb_Statistics;

            // aktywacja serwisów - tutaj dokonujemy wyboru, które implementacja serwisu będzie tą, z której
            // chcemy korzystać
            _myTextService = new TextStatisticsSevice();
        }


        public void PerformTextAnalysis(string text)
        {
            // rozpoczęcie pomiaru czasu
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // przeprowadzenie analizy
            TextStatisticsData textStatisticsData = _myTextService.CountStatistics(text);

            // zakończenie pomiaru czasu
            sw.Stop();

            // przygotowanie tekstu do drukowania
            TextPrintingData textPrintingData = _myTextService.FillPrintingData(textStatisticsData);

            // drukowanie wyników
            _tb_AllSymbols.Text = textPrintingData.AllSymbolCount;
            _tb_UniqueItems.Text = textPrintingData.UniqueSymbolCount;
            _tb_Entropy.Text = textPrintingData.Entropy;
            _tb_Time.Text = sw.Elapsed.ToString();
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
            for (int i = 0; i < textPrintingData?.SymbolStatistics?.Count; i++)
            {
                sb.AppendLine(string.Format(mask,
                    textPrintingData.SymbolStatistics[i].BinaryNotation?.PadRight(colWidth, ' '),
                    textPrintingData.SymbolStatistics[i].DecimalNotation?.ToString().PadRight(colWidth, ' '),
                    textPrintingData.SymbolStatistics[i].Symbol?.PadRight(colWidth, ' '),
                    textPrintingData.SymbolStatistics[i].Frequency?.ToString().PadRight(colWidth, ' '),
                    textPrintingData.SymbolStatistics[i].Probability?.ToString().PadRight(colWidth, ' '),
                    textPrintingData.SymbolStatistics[i].InformationQuantity?.ToString().PadRight(colWidth, ' ')));
            }
            _rtb_Statistics.Text = sb.ToString();
        }
    }
}
