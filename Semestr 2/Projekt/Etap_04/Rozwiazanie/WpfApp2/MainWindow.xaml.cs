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

namespace WpfApp2
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

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }

        private void RadioButton_Light_Checked(object sender, RoutedEventArgs e)
        {
            // SPOSOB 1
            //var app = (App)Application.Current;
            //app.ChangeTheme("Light");

            // SPOSOB 2
            var newDict = new ResourceDictionary();
            newDict.Source = new Uri("Themes/LightTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newDict);
        }

        private void RadioButton_Dark_Checked(object sender, RoutedEventArgs e)
        {
            // SPOSOB 1
            //var app = (App)Application.Current;
            //app.ChangeTheme("Dark");

            // SPOSOB 2
            var newDict = new ResourceDictionary();
            newDict.Source = new Uri("Themes/HighContrastTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(newDict);
        }
    }
}