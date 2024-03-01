using Autofac;
using Projekt_01_Etap_10_Rozwiazanie.Configuration;
using Projekt_01_Etap_10_Rozwiazanie.Core.Configuration;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using System.Text;

namespace Projekt_01_Etap_10_Rozwiazanie
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new DefaultUIModule());
            builder.RegisterModule(new AutofacDefaultCoreModule());
            var Container = builder.Build();
            using (var scope = Container.BeginLifetimeScope())
            {
                Application.Run((Form)scope.Resolve<IMainWindow>());
            }

            //Application.Run(new Form1());
        }
    }
}