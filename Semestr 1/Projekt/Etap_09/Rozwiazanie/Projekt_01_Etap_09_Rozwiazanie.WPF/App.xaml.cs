using System.Configuration;
using System.Data;
using System.Text;
using System.Windows;

namespace Projekt_01_Etap_09_Rozwiazanie.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }

}
