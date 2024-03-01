using Microsoft.Win32;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using Projekt_01_Etap_10_Rozwiazanie.WPF.Commands;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF.ViewModels
{
    public class CompressFormViewModel : INotifyPropertyChanged
    {
        private readonly ITextStatisticsService _textStatisticsService;
        private readonly IHuffmanStaticSymbolsCodesService _huffmanStaticSymbolsCodesService;
        private readonly IHuffmanStaticCompressorService _huffmanStaticCompressorService;


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #region Polecenia
        public ICommand CompressFileCommand { get; set; }
        #endregion Polecenia

        #region Pola tekstowe
        private string compression_Codes;
        public string Compression_Codes
        {
            get => compression_Codes;
            set
            {
                compression_Codes = value;
                OnPropertyChanged(nameof(Compression_Codes));
            }
        }

        private string compression_CodesTime;
        public string Compression_CodesTime
        {
            get => compression_CodesTime;
            set
            {
                compression_CodesTime = value;
                OnPropertyChanged(nameof(Compression_CodesTime));
            }
        }

        private string compression_CompressionTime;
        public string Compression_CompressionTime
        {
            get => compression_CompressionTime;
            set
            {
                compression_CompressionTime = value;
                OnPropertyChanged(nameof(Compression_CompressionTime));
            }
        }
        #endregion Pola tekstowe


        public CompressFormViewModel(ITextStatisticsService textStatisticsService,
            IHuffmanStaticSymbolsCodesService huffmanStaticSymbolsCodesService,
            IHuffmanStaticCompressorService huffmanStaticCompressorService)
        {
            _textStatisticsService = textStatisticsService;
            _huffmanStaticSymbolsCodesService = huffmanStaticSymbolsCodesService;
            _huffmanStaticCompressorService = huffmanStaticCompressorService;

            CompressFileCommand = new RelayCommand(ExecuteCompressFileCommand);
        }


        private void ExecuteCompressFileCommand(object obj)
        {
            string currentPath = Environment.CurrentDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = currentPath;
            if (openFileDialog.ShowDialog() == true)
            {
                var fileText = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding("Windows-1250"));
                PerformTextCompression(openFileDialog.FileName, fileText);
            }
        }
        public void PerformTextCompression(string filename, string text)
        {
            TextStatisticsData textStatisticsData = _textStatisticsService.CountStatistics(text);
        
            // Wyznaczenie kodów poszczególnych symboli
            Stopwatch sw_Codes = new Stopwatch();
            sw_Codes.Start();
            List<HuffmanNode> compressionCodes = _huffmanStaticSymbolsCodesService.GenerateCodesDictionary(textStatisticsData);
            sw_Codes.Stop();
        
            // Przeprowadzenie kodowania pliku
            Stopwatch sw_Compression = new Stopwatch();
            sw_Compression.Start();
            byte[] fileContentBytes = _huffmanStaticCompressorService.CompressFile(textStatisticsData, text);
            sw_Compression.Stop();
        
            // Prezentacja struktury słownika kodów na ekranie
            Compression_CodesTime = sw_Codes.Elapsed.ToString();
            Compression_CompressionTime = sw_Compression.Elapsed.ToString();
            StringBuilder sb = new StringBuilder();
            string mask = "{0} | {1}";
            int col1 = 20, col2 = 50;
            sb.AppendLine(string.Format(mask,
                    "Znak".PadRight(col1, ' '),
                    "Ciąg kodowy".PadRight(col2, ' ')));
            for (int i = 0; i < compressionCodes.Count; i++)
            {
                sb.AppendLine(string.Format("{0} | {1}",
                    compressionCodes[i].Symbol.ToString().PadRight(col1, ' '),
                    compressionCodes[i].Code.PadRight(col2, ' ')));
            }
            Compression_Codes = sb.ToString();
        
            // Zapis danych do pliku
            SaveFileDialog sfd = new SaveFileDialog();
            string filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
            sfd.Filter = "ZSK Compressed File file|*.zcf"; // możemy wymyśleć swój własny typ pliku
            sfd.FileName = filenameWithoutExtension + ".zcf";
            if (sfd.ShowDialog() == true)
            {
                // Kiedy będziemy mieli już bajty skompresowanego pliku możemy je zapisać
                try
                {
                    FileStream fs = File.Create(sfd.FileName, fileContentBytes.Length, FileOptions.None);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(fileContentBytes);
                    bw.Close();
                    fs.Close();
                    bw.Dispose();
                    fs.Dispose();
                }
                catch (IOException fe)
                {
                    Console.WriteLine(fe.Message);
                    throw;
                }
            }
        
            // Prezentacja wykresu
            //var originalnBytes = File.ReadAllBytes(filename);
            //Wykres wykres = new Wykres(originalnBytes.Length, fileContentBytes.Length);
            //wykres.Show();
        }
    }
}
