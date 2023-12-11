using Projekt_01_Etap_09_Rozwiazanie.Core.Services;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Projekt_01_Etap_09_Rozwiazanie.Presenters
{
    public class DecompressFormPresenter
    {
        // zakładka Dekompresowanie
        private TextBox _tb_Decompression_CodesTime;
        private TextBox _tb_Decpression_DecompressionTime;
        private DataGridView _dgv_Decpression_Codes;
        private RichTextBox _rtb_Decompression_CileContents;

        public DecompressFormPresenter(TextBox tb_Decompression_CodesTime, TextBox tb_Decpression_DecompressionTime, DataGridView dgv_Decpression_Codes, RichTextBox rtb_Decompression_CileContents)
        {
            _tb_Decompression_CodesTime = tb_Decompression_CodesTime;
            _tb_Decpression_DecompressionTime = tb_Decpression_DecompressionTime;
            _dgv_Decpression_Codes = dgv_Decpression_Codes;
            _rtb_Decompression_CileContents = rtb_Decompression_CileContents;
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
                    sfd.FileName = Path.GetFileNameWithoutExtension(filename) + "_rozpakowany";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        // Po poprawnym rozpakowaniu można zapisać plik na dysku
                        //File.WriteAllText(sfd.FileName, fileText);
                        try
                        {
                            FileStream fs = (FileStream)sfd.OpenFile();
                            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("Windows-1250"));
                            for (int i = 0; i < fileText.Length; i++)
                                sw.Write(fileText[i]);
                            sw.Close();
                            sw.Dispose();
                            fs.Dispose();
                        }
                        catch (IOException fe)
                        {
                            Console.WriteLine(fe.Message);
                            throw;
                        }
                    }
                }
            }
        }
    }
}
