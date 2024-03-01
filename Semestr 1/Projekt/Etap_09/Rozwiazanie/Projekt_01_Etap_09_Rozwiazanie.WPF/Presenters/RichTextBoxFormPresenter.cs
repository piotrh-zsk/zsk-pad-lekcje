using Microsoft.Win32;
using Projekt_01_Etap_09_Rozwiazanie.Core.Services;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_09_Rozwiazanie.WPF.Commands;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Projekt_01_Etap_09_Rozwiazanie.WPF.Presenters
{
    public class RichTextBoxFormPresenter : INotifyPropertyChanged
    {
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


        public RichTextBoxFormPresenter()
        {
            // Zwykłe commandy
            //AnalyzeTextCommand = new AnalyzeTextCommand(this);
            //CompressFileCommand = new OpenCompressFileWindowCommand();
            //DecompressFileCommand = new OpenDecompressFileWindowCommand();

            // Relay command
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
            Statistics_AllSymbols = _textPrintingData.AllSymbolCount;
            Statistics_UniqueSymbols = _textPrintingData.UniqueSymbolCount;
            Statistics_Entropy = _textPrintingData.Entropy;
            Statistics_Time = _textPrintingData.ExecutionTime.ToString();
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
            Statistics = sb.ToString();
        }

        private void ExecuteCompressFileCommand(object obj)
        {
            CompressForm comp = new CompressForm();
            comp.ShowDialog();
        }

        private void ExecuteDecompressFileCommand(object obj)
        {
            DecompressForm comp = new DecompressForm();
            comp.ShowDialog();
        }
    }
}