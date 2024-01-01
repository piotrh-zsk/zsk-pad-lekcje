using Projekt_01_Etap_06_Rozwiazanie.Core.Services;
using Projekt_01_Etap_06_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_06_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;

namespace Projekt_01_Etap_06_Rozwiazanie.Presenters
{
    public class CompressFormPresenter
    {
        // zakładka Kompresowanie
        private TextBox _tb_Compression_CodesTime;
        private TextBox _tb_Compression_CompressionTime;
        private DataGridView _dgv_Compression_Codes;

        public CompressFormPresenter(TextBox tb_Compression_CodesTime, TextBox tb_Compression_CompressionTime, DataGridView dgv_Compression_Codes)
        {
            _tb_Compression_CodesTime = tb_Compression_CodesTime;
            _tb_Compression_CompressionTime = tb_Compression_CompressionTime;
            _dgv_Compression_Codes = dgv_Compression_Codes;
        }


        public void PerformTextCompression(string filename, string text)
        {
            BaseTextStatisticsService textStatisticsService = TextStatisticsService.GetInstance();
            TextStatisticsData textStatisticsData = textStatisticsService.CountStatistics(text);

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
    }
}
