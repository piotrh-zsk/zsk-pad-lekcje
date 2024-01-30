using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person AAA { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            AAA = new Person { Name = "John Doe" };
            DataContext = this;

            StartAnimation();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(AAA.Name);
        }

        private void StartAnimation()
        {
            // Tworzenie obiektu animacji
            DoubleAnimation animation2 = new DoubleAnimation
            {
                From = 50, // Początkowa wartość (szerokość elipsy)
                To = 500,  // Końcowa wartość (szerokość elipsy)
                Duration = TimeSpan.FromSeconds(2), // Czas trwania animacji
                AutoReverse = true, // Powrót do początkowej wartości po zakończeniu
                RepeatBehavior = RepeatBehavior.Forever // Powtarzanie animacji
            };

            // Tworzenie konwertera danych do zmiany koloru elipsy na podstawie szerokości
            var converter = new WidthToColorConverter();

            // Dodanie konwertera do zasobów okna
            Resources.Add("WidthToColorConverter", converter);

            // Rozpoczęcie animacji
            animatedEllipse.BeginAnimation(Ellipse.WidthProperty, animation2);

            // Użycie konwertera do zmiany koloru elipsy na podstawie jej szerokości
            Binding binding = new Binding("Width")
            {
                Source = animatedEllipse,
                Converter = (IValueConverter)Resources["WidthToColorConverter"]
            };

            animatedEllipse.SetBinding(Ellipse.FillProperty, binding);
        }
    }
}