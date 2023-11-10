using Projekt_01_Etap_05_Rozwiazanie.Core.Services;
using Projekt_01_Etap_05_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_05_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_05_Rozwiazanie.Presenters
{
    public class DataGridViewFormPresenter : IFormPresenter
    {
        private TextBox _tb_AllSymbols;
        private TextBox _tb_UniqueItems;
        private TextBox _tb_Entropy;
        private TextBox _tb_Time;
        private DataGridView _dgv_Statistics;

        public DataGridViewFormPresenter(TextBox tb_AllSymbols, TextBox tb_UniqueItems, TextBox tb_Entropy,
            TextBox tb_Time, DataGridView dgv_Statistics)
        {
            _tb_AllSymbols = tb_AllSymbols;
            _tb_UniqueItems = tb_UniqueItems;
            _tb_Entropy = tb_Entropy;
            _tb_Time = tb_Time;
            _dgv_Statistics = dgv_Statistics;
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

            // Metoda szablonowa - Krok 2
            // Nasz "skomplikowany, wieloetapowy" proces został w całości zawarty w metodzie szablonowej, dlatego
            // upraszczamy całość operacji jednie do wywołania metody szablonowej.
            // przeprowadzenie analizy tekstu
            TextPrintingData _textPrintingData = _textStatisticsService.TemplateMethod(text);



            // drukowanie wyników
            _tb_AllSymbols.Text = _textPrintingData.AllSymbolCount;
            _tb_UniqueItems.Text = _textPrintingData.UniqueSymbolCount;
            _tb_Entropy.Text = _textPrintingData.Entropy;
            _tb_Time.Text = _textPrintingData.ExecutionTime.ToString();

            _dgv_Statistics.Rows.Clear();
            _dgv_Statistics.Columns[4].DefaultCellStyle.Format = "N7";
            _dgv_Statistics.Columns[5].DefaultCellStyle.Format = "N7";
            for (int i = 0; i < _textPrintingData?.SymbolStatistics?.Count; i++)
            {
                int index = _dgv_Statistics.Rows.Add();
                _dgv_Statistics.Rows[index].Cells[0].Value = _textPrintingData.SymbolStatistics[i].BinaryNotation;
                _dgv_Statistics.Rows[index].Cells[1].Value = _textPrintingData.SymbolStatistics[i].DecimalNotation;
                _dgv_Statistics.Rows[index].Cells[2].Value = _textPrintingData.SymbolStatistics[i].Symbol;
                _dgv_Statistics.Rows[index].Cells[3].Value = int.Parse(_textPrintingData.SymbolStatistics[i].Frequency);
                _dgv_Statistics.Rows[index].Cells[4].Value = double.Parse(_textPrintingData.SymbolStatistics[i].Probability);
                _dgv_Statistics.Rows[index].Cells[5].Value = double.Parse(_textPrintingData.SymbolStatistics[i].InformationQuantity);
            }
        }
    }
}
