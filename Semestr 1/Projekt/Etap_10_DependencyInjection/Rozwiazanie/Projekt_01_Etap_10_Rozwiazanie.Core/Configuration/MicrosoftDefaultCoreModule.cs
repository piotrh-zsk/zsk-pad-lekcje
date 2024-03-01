using Microsoft.Extensions.DependencyInjection;
using Projekt_01_Etap_10_Rozwiazanie.Core.Services;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_10_Rozwiazanie.Core.Configuration
{
    public class MicrosoftDefaultCoreModule
    {
        public MicrosoftDefaultCoreModule()
        {
        }


        public void Register(IServiceCollection services)
        {
            // SINGLE
            services.AddSingleton<ITextStatisticsService, TextStatisticsService>();
            services.AddSingleton<IHuffmanStaticSymbolsCodesService, HuffmanStaticSymbolsCodesService>();
            services.AddSingleton<IHuffmanStaticCompressorService, HuffmanStaticCompressorService>();
            services.AddSingleton<IHuffmanStaticDecompressorService, HuffmanStaticDecompressorService>();
        }
    }
}
