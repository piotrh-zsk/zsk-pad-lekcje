using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ZadanieDomowe1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSprawdzCene_Click(object sender, RoutedEventArgs e)
        {
            if (rbPocztowka.IsChecked == true)
            {
                lbCena.Content = "Cena: 1 zł";
                imgIkona.Source = new BitmapImage(new Uri("pack://application:,,,/Content/pocztowka.png"));
            }
            else if (rbList.IsChecked == true)
            {
                lbCena.Content = "Cena: 1,5 zł";
                imgIkona.Source = new BitmapImage(new Uri("pack://application:,,,/Content/list.png"));
            }
            else if (rbPaczka.IsChecked == true)
            {
                lbCena.Content = "Cena: 10 zł";
                imgIkona.Source = new BitmapImage(new Uri("pack://application:,,,/Content/paczka.png"));
            }
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string kod = tbKod.Text;
            if (kod.Length != 5)
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie");
            else if (!int.TryParse(kod, out int paredCode))
                MessageBox.Show("Kod powiniene się składać z samych cyfr");
            else
                MessageBox.Show("Dane przesyłki zostały wprowadzone");
        }
    }
}