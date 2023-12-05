using Projekt_01_Etap_08_Rozwiazanie.Core.Services;
using Projekt_01_Etap_08_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_08_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;

namespace Projekt_01_Etap_08_Rozwiazanie.Presenters
{
    public class DataGridViewFormPresenter : IFormPresenter
    {
        // zakładka Statystyka
        private TextBox _tb_Statistics_AllSymbols;
        private TextBox _tb_Statistics_UniqueItems;
        private TextBox _tb_Statistics_Entropy;
        private TextBox _tb_Statistics_Time;
        private DataGridView _dgv_Statistics_Statistics;
        // zakładka Kompresowanie
        private TextBox _tb_Compression_CodesTime;
        private TextBox _tb_Compression_CompressionTime;
        private DataGridView _dgv_Compression_Codes;
        // zakładka Dekompresowanie
        private TextBox _tb_Decompression_CodesTime;
        private TextBox _tb_Decpression_DecompressionTime;
        private DataGridView _dgv_Decpression_Codes;
        private RichTextBox _rtb_Decompression_CileContents;

        public DataGridViewFormPresenter(
            TextBox tb_Statistics_AllSymbols, TextBox tb_Statistics_UniqueItems, TextBox tb_Statistics_Entropy, TextBox tb_Statistics_Time, DataGridView dgv_Statistics_Statistics,
            TextBox tb_Compression_CodesTime, TextBox tb_Compression_CompressionTime, DataGridView dgv_Compression_Codes,
            TextBox tb_Decompression_CodesTime, TextBox tb_Decpression_DecompressionTime, DataGridView dgv_Decpression_Codes, RichTextBox rtb_Decompression_CileContents)
        {
            _tb_Statistics_AllSymbols = tb_Statistics_AllSymbols;
            _tb_Statistics_UniqueItems = tb_Statistics_UniqueItems;
            _tb_Statistics_Entropy = tb_Statistics_Entropy;
            _tb_Statistics_Time = tb_Statistics_Time;
            _dgv_Statistics_Statistics = dgv_Statistics_Statistics;
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
            BaseTextStatisticsService _textStatisticsService = TextStatisticsService.GetInstance();

            // Metoda szablonowa - Krok 2
            // Nasz "skomplikowany, wieloetapowy" proces został w całości zawarty w metodzie szablonowej, dlatego
            // upraszczamy całość operacji jednie do wywołania metody szablonowej.
            // przeprowadzenie analizy tekstu
            TextPrintingData _textPrintingData = _textStatisticsService.TemplateMethod(text);



            // drukowanie wyników
            _tb_Statistics_AllSymbols.Text = _textPrintingData.AllSymbolCount;
            _tb_Statistics_UniqueItems.Text = _textPrintingData.UniqueSymbolCount;
            _tb_Statistics_Entropy.Text = _textPrintingData.Entropy;
            _tb_Statistics_Time.Text = _textPrintingData.ExecutionTime.ToString();

            _dgv_Statistics_Statistics.Rows.Clear();
            _dgv_Statistics_Statistics.Columns[4].DefaultCellStyle.Format = "N7";
            _dgv_Statistics_Statistics.Columns[5].DefaultCellStyle.Format = "N7";
            for (int i = 0; i < _textPrintingData?.SymbolStatistics?.Count; i++)
            {
                int index = _dgv_Statistics_Statistics.Rows.Add();
                _dgv_Statistics_Statistics.Rows[index].Cells[0].Value = _textPrintingData.SymbolStatistics[i].BinaryNotation;
                _dgv_Statistics_Statistics.Rows[index].Cells[1].Value = _textPrintingData.SymbolStatistics[i].DecimalNotation;
                _dgv_Statistics_Statistics.Rows[index].Cells[2].Value = _textPrintingData.SymbolStatistics[i].Symbol;
                _dgv_Statistics_Statistics.Rows[index].Cells[3].Value = int.Parse(_textPrintingData.SymbolStatistics[i].Frequency);
                _dgv_Statistics_Statistics.Rows[index].Cells[4].Value = double.Parse(_textPrintingData.SymbolStatistics[i].Probability);
                _dgv_Statistics_Statistics.Rows[index].Cells[5].Value = double.Parse(_textPrintingData.SymbolStatistics[i].InformationQuantity);
            }
        }

        public void PerformTextCompression(string filename, string text)
        {
            TextStatisticsData textStatisticsData = CountAndShowStats(text);

            // Wyznaczenie kodów poszczególnych symboli
            Stopwatch sw_Codes = new Stopwatch();
            sw_Codes.Start();
            IHuffmanStaticSymbolsCodesService huffmanStaticService = new HuffmanStaticSymbolsCodesService();
            List<HuffmanNode> compressionCodes = huffmanStaticService.GenerateCodesDictionary(textStatisticsData);
            sw_Codes.Stop();

            // Przeprowadzenie kodowania pliku
            Stopwatch sw_Compression = new Stopwatch();
            sw_Compression.Start();
            IHuffmanStaticCompressorService huffmanStaticCompressorService = new HuffmanStaticCompressorService(huffmanStaticService);
            byte[] fileContentBytes = huffmanStaticCompressorService.CompressFile(textStatisticsData, text);
            sw_Compression.Stop();

            // Prezentacja struktury słownika kodów na ekranie
            _tb_Compression_CodesTime.Text = sw_Codes.Elapsed.ToString();
            _tb_Compression_CompressionTime.Text = sw_Compression.Elapsed.ToString();
            _dgv_Compression_Codes.Rows.Clear();
            for (int i = 0; i < compressionCodes.Count; i++)
            {
                int index = _dgv_Compression_Codes.Rows.Add();
                _dgv_Compression_Codes.Rows[index].Cells[0].Value = compressionCodes[i].Symbol;
                _dgv_Compression_Codes.Rows[index].Cells[1].Value = compressionCodes[i].Code;
            }

            // Zapis danych do pliku
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string filenameWithoutExtension = filename.Split('.')[0];
                sfd.Filter = "ZSK Compressed File file|*.zcf"; // możemy wymyśleć swój własny typ pliku
                sfd.FileName = filenameWithoutExtension + ".zcf";
                DialogResult result = sfd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Kiedy będziemy mieli już bajty skompresowanego pliku możemy je zapisać
                    File.WriteAllBytes(sfd.FileName, fileContentBytes);
                }
            }
        }

        public void PerformTextDecompression(string filename, byte[] fileContents)
        {
            if (fileContents != null)
            {
                // Utworzenie usługi dekompresującej
                IHuffmanStaticSymbolsCodesService huffmanStaticSymbolsCodesService = new HuffmanStaticSymbolsCodesService();
                IHuffmanStaticDecompressorService huffmanStaticDecompressorService = new HuffmanStaticDecompressorService(huffmanStaticSymbolsCodesService);

                // Przeprowadzenie dekompresji pliku
                Stopwatch sw_Decompression = new Stopwatch();
                sw_Decompression.Start();
                string fileText = huffmanStaticDecompressorService.DecompressFile(fileContents, out List<HuffmanNode> dictionary, out TimeSpan codeTimes);
                sw_Decompression.Stop();

                // Jeżeli usługa zwróciła poza plikiem również strukture słownika kodów to pokazanie go na ekranie
                _tb_Decompression_CodesTime.Text = codeTimes.ToString();
                _tb_Decpression_DecompressionTime.Text = sw_Decompression.Elapsed.ToString();
                _rtb_Decompression_CileContents.Text = fileText;
                _dgv_Decpression_Codes.Rows.Clear();
                for (int i = 0; i < dictionary.Count; i++)
                {
                    int index = _dgv_Decpression_Codes.Rows.Add();
                    _dgv_Decpression_Codes.Rows[index].Cells[0].Value = dictionary[i].Symbol;
                    _dgv_Decpression_Codes.Rows[index].Cells[1].Value = dictionary[i].Code;
                }

                // Zapis danych do pliku
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = filename;
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        // Po poprawnym rozpakowaniu można zapisać plik na dysku
                        File.WriteAllText(sfd.FileName, fileText);
                    }
                }
            }
        }


        private TextStatisticsData CountAndShowStats(string text)
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
            //TextPrintingData _textPrintingData = _textStatisticsService.TemplateMethod(text);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var _textStatisticsData = _textStatisticsService.CountStatistics(text);
            sw.Stop();
            var _textPrintingData = _textStatisticsService.FillPrintingData(_textStatisticsData);
            _textPrintingData.ExecutionTime = sw.Elapsed;

            // drukowanie wyników
            _tb_Statistics_AllSymbols.Text = _textPrintingData.AllSymbolCount;
            _tb_Statistics_UniqueItems.Text = _textPrintingData.UniqueSymbolCount;
            _tb_Statistics_Entropy.Text = _textPrintingData.Entropy;
            _tb_Statistics_Time.Text = _textPrintingData.ExecutionTime.ToString();

            _dgv_Statistics_Statistics.Rows.Clear();
            _dgv_Statistics_Statistics.Columns[4].DefaultCellStyle.Format = "N7";
            _dgv_Statistics_Statistics.Columns[5].DefaultCellStyle.Format = "N7";
            for (int i = 0; i < _textPrintingData?.SymbolStatistics?.Count; i++)
            {
                int index = _dgv_Statistics_Statistics.Rows.Add();
                _dgv_Statistics_Statistics.Rows[index].Cells[0].Value = _textPrintingData.SymbolStatistics[i].BinaryNotation;
                _dgv_Statistics_Statistics.Rows[index].Cells[1].Value = _textPrintingData.SymbolStatistics[i].DecimalNotation;
                _dgv_Statistics_Statistics.Rows[index].Cells[2].Value = _textPrintingData.SymbolStatistics[i].Symbol;
                _dgv_Statistics_Statistics.Rows[index].Cells[3].Value = int.Parse(_textPrintingData.SymbolStatistics[i].Frequency);
                _dgv_Statistics_Statistics.Rows[index].Cells[4].Value = double.Parse(_textPrintingData.SymbolStatistics[i].Probability);
                _dgv_Statistics_Statistics.Rows[index].Cells[5].Value = double.Parse(_textPrintingData.SymbolStatistics[i].InformationQuantity);
            }

            return _textStatisticsData;
        }
    }
}
