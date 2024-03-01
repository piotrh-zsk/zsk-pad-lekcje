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
    public class RichTextBoxFormViewModel : INotifyPropertyChanged
    {
        private readonly ITextStatisticsService _textStatisticsService;
        private readonly CompressForm _compressForm;
        private readonly DecompressForm _decompressForm;


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        #region Polecenia
        public ICommand AnalyzeTextCommand { get; set; }
        public ICommand CompressFileCommand { get; set; }
        public ICommand DecompressFileCommand { get; set; }
        #endregion Polecenia

        #region Pola tekstowe
        private string inputText;
        public string InputText
        {
            get => inputText;
            set
            {
                inputText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        private string statistics;
        public string Statistics
        {
            get => statistics;
            set
            {
                statistics = value;
                OnPropertyChanged(nameof(Statistics));
            }
        }

        private string statistics_AllSymbols;
        public string Statistics_AllSymbols
        {
            get => statistics_AllSymbols;
            set
            {
                statistics_AllSymbols = value;
                OnPropertyChanged(nameof(Statistics_AllSymbols));
            }
        }

        private string statistics_UniqueSymbols;
        public string Statistics_UniqueSymbols
        {
            get => statistics_UniqueSymbols;
            set
            {
                statistics_UniqueSymbols = value;
                OnPropertyChanged(nameof(Statistics_UniqueSymbols));
            }
        }

        private string statistics_Entropy;
        public string Statistics_Entropy
        {
            get => statistics_Entropy;
            set
            {
                statistics_Entropy = value;
                OnPropertyChanged(nameof(Statistics_Entropy));
            }
        }

        private string statistics_Time;
        public string Statistics_Time
        {
            get => statistics_Time;
            set
            {
                statistics_Time = value;
                OnPropertyChanged(nameof(Statistics_Time));
            }
        }
        #endregion Pola tekstowe


        public RichTextBoxFormViewModel(ITextStatisticsService textStatisticsService, CompressForm compressForm, DecompressForm decompressForm)
        {
            _textStatisticsService = textStatisticsService;
            _compressForm = compressForm;
            _decompressForm = decompressForm;

            AnalyzeTextCommand = new RelayCommand(ExecuteAnalyzeTextCommand);
            CompressFileCommand = new RelayCommand(ExecuteCompressFileCommand);
            DecompressFileCommand = new RelayCommand(ExecuteDecompressFileCommand);
        }


        private void ExecuteAnalyzeTextCommand(object obj)
        {
            string currentPath = Environment.CurrentDirectory;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = currentPath;
            if (openFileDialog.ShowDialog() == true)
            {
                var fileText = File.ReadAllText(openFileDialog.FileName, Encoding.GetEncoding("Windows-1250"));
                InputText = fileText;
                PerformTextAnalysis(fileText);
            }
        }
        public void PerformTextAnalysis(string fileText)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            TextStatisticsData statisticsData = _textStatisticsService.CountStatistics(fileText);
            sw.Stop();
            TextPrintingData printingData = _textStatisticsService.FillPrintingData(statisticsData);
            printingData.ExecutionTime = sw.Elapsed;

            // drukowanie wyników
            Statistics_AllSymbols = printingData.AllSymbolCount;
            Statistics_UniqueSymbols = printingData.UniqueSymbolCount;
            Statistics_Entropy = printingData.Entropy;
            Statistics_Time = printingData.ExecutionTime.ToString();
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
            for (int i = 0; i < printingData?.SymbolStatistics?.Count; i++)
            {
                sb.AppendLine(string.Format("{0} | {1} | {2} | {3} | {4} | {5}",
                    printingData.SymbolStatistics[i].BinaryNotation?.PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].DecimalNotation?.ToString().PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].Symbol?.PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].Frequency?.ToString().PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].Probability?.ToString().PadRight(colWidth, ' '),
                    printingData.SymbolStatistics[i].InformationQuantity?.ToString().PadRight(colWidth, ' ')));
            }
            Statistics = sb.ToString();
        }

        private void ExecuteCompressFileCommand(object obj)
        {
            _compressForm.ShowDialog();
        }

        private void ExecuteDecompressFileCommand(object obj)
        {
            _decompressForm.ShowDialog();
        }
    }
}