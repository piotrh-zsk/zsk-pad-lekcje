using Microsoft.Win32;
using Projekt_01_Etap_09_Rozwiazanie.Core.Services;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces;
using Projekt_01_Etap_09_Rozwiazanie.WPF.Commands;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Projekt_01_Etap_09_Rozwiazanie.WPF.Presenters
{
    public class DecompressFormPresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #region Polecenia
        public ICommand DecompressFileCommand { get; set; }
        #endregion Polecenia

        #region Pola tekstowe
        private string decompression_CodesTime;
        public string Decompression_CodesTime
        {
            get => decompression_CodesTime;
            set
            {
                decompression_CodesTime = value;
                OnPropertyChanged(nameof(Decompression_CodesTime));
            }
        }

        private string decpression_DecompressionTime;
        public string Decpression_DecompressionTime
        {
            get => decpression_DecompressionTime;
            set
            {
                decpression_DecompressionTime = value;
                OnPropertyChanged(nameof(Decpression_DecompressionTime));
            }
        }

        private string decompression_FileContents;
        public string Decompression_FileContents
        {
            get => decompression_FileContents;
            set
            {
                decompression_FileContents = value;
                OnPropertyChanged(nameof(Decompression_FileContents));
            }
        }

        private string decpression_Codes;
        public string Decpression_Codes
        {
            get => decpression_Codes;
            set
            {
                decpression_Codes = value;
                OnPropertyChanged(nameof(Decpression_Codes));
            }
        }
        #endregion Pola tekstowe


        public DecompressFormPresenter()
        {
            DecompressFileCommand = new DecompressFileCommand(this);
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
                Decompression_CodesTime = codeTimes.ToString();
                Decpression_DecompressionTime = sw_Decompression.Elapsed.ToString();
                Decompression_FileContents = fileText;
                StringBuilder sb = new StringBuilder();
                string mask = "{0} | {1}";
                int col1 = 20, col2 = 50;
                sb.AppendLine(string.Format(mask,
                        "Znak".PadRight(col1, ' '),
                        "Ciąg kodowy".PadRight(col2, ' ')));
                for (int i = 0; i < dictionary.Count; i++)
                {
                    sb.AppendLine(string.Format("{0} | {1}",
                        dictionary[i].Symbol.ToString().PadRight(col1, ' '),
                        dictionary[i].Code.PadRight(col2, ' ')));
                }
                Decpression_Codes = sb.ToString();

                // Zapis danych do pliku
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = Path.GetFileNameWithoutExtension(filename) + "_rozpakowany";
                if (sfd.ShowDialog() == true)
                {
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
