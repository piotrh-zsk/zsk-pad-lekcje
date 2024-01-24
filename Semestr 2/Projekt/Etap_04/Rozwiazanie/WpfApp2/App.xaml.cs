using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // SPOSOB 1
        public void ChangeTheme(string themeName)
        {
            if (themeName == "Light")
            {
                var resourceDictionary = Resources.MergedDictionaries[0];
                if (resourceDictionary != null)
                {
                    resourceDictionary.MergedDictionaries.Clear();
                    resourceDictionary.MergedDictionaries.Add(
                        new ResourceDictionary() { 
                            Source = new Uri("pack://application:,,,/Themes/LightTheme.xaml")
                        });
                }
            }
            else if (themeName == "Dark")
            {
                var resourceDictionary = Resources.MergedDictionaries[0];
                if (resourceDictionary != null)
                {
                    resourceDictionary.MergedDictionaries.Clear();
                    resourceDictionary.MergedDictionaries.Add(
                        new ResourceDictionary() { 
                            Source = new Uri("pack://application:,,,/Themes/HighContrastTheme.xaml")
                        });
                }
            }
        }
    }
}
