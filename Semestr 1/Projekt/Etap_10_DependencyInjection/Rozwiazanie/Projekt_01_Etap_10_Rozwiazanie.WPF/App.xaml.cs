using Microsoft.Extensions.DependencyInjection;
using Projekt_01_Etap_10_Rozwiazanie.Core.Configuration;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using Projekt_01_Etap_10_Rozwiazanie.WPF.Configuration;
using System.Text;
using System.Windows;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;


        public App()
        {
            ServiceCollection services = new ServiceCollection();
            new DefaultUIModule().Register(services);
            new MicrosoftDefaultCoreModule().Register(services);
            serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var mainWindow = serviceProvider.GetService<IMainWindow>() as Window;
            if (mainWindow != null)
            {
                mainWindow.Closed += OnMainWindowClosing;
                mainWindow.Show();
            }
        }

        private void OnMainWindowClosing(object? sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

}
