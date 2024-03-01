using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using Projekt_01_Etap_10_Rozwiazanie.WPF.ViewModels;
using System.Windows;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowRTB : Window, IMainWindow
    {
        public MainWindowRTB(RichTextBoxFormViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}