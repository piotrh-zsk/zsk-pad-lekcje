using Projekt_01_Etap_10_Rozwiazanie.WPF.ViewModels;
using System.Windows;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF
{
    /// <summary>
    /// Interaction logic for CompressForm.xaml
    /// </summary>
    public partial class CompressForm : Window
    {
        public CompressForm(CompressFormViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
