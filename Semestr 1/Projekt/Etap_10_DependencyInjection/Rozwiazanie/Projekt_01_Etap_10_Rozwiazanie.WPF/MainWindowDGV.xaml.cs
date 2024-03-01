using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using Projekt_01_Etap_10_Rozwiazanie.WPF.ViewModels;
using System.Windows;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow2.xaml
    /// </summary>
    public partial class MainWindowDGV : Window, IMainWindow
    {
        public MainWindowDGV(DataGridFormViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
