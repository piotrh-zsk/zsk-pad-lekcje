using Projekt_01_Etap_10_Rozwiazanie.WPF.ViewModels;
using System.Windows;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF
{
    /// <summary>
    /// Interaction logic for DecompressForm.xaml
    /// </summary>
    public partial class DecompressForm : Window
    {
        public DecompressForm(DecompressFormViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
