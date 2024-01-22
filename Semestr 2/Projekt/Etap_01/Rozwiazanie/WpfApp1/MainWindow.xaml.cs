using System.Windows;

namespace WpfApp1
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


        private MainWindowDataContext DC => (MainWindowDataContext)DataContext;
        private void OnSubmitClicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DC.UserName))
            {
                return;
            }

            MessageBox.Show($"Hello {DC.UserName}!");

            DC.IsNameNeeded = false;
        }
    }
}