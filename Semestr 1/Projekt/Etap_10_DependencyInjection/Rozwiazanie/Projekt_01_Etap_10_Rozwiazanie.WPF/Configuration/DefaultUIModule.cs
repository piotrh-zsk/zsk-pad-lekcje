using Microsoft.Extensions.DependencyInjection;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using Projekt_01_Etap_10_Rozwiazanie.WPF.ViewModels;

namespace Projekt_01_Etap_10_Rozwiazanie.WPF.Configuration
{
    public class DefaultUIModule
    {
        public DefaultUIModule()
        {
        }


        public void Register(IServiceCollection services)
        {
            // SINGLE
            //services.AddSingleton<IMainWindow, MainWindowRTB>();
            services.AddSingleton<IMainWindow, MainWindowDGV>();
            services.AddSingleton<CompressForm>();
            services.AddSingleton<DecompressForm>();

            // TRANSIENT
            services.AddTransient<RichTextBoxFormViewModel>();
            services.AddTransient<DataGridFormViewModel>();
            services.AddTransient<CompressFormViewModel>();
            services.AddTransient<DecompressFormViewModel>();
        }
    }
}
