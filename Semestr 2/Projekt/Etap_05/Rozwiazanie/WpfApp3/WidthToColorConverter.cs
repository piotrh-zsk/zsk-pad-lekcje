using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp3
{
    public class WidthToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double width = (double)value;

            // Przykładowa logika: Im szersza elipsa, tym bardziej zielona
            byte greenComponent = (byte)(width / 2);

            return new SolidColorBrush(Color.FromRgb(0, greenComponent, 0));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
