using Autofac;
using Projekt_01_Etap_10_Rozwiazanie.Core.Services;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_10_Rozwiazanie.Core.Configuration
{
    public class AutofacDefaultCoreModule : Module
    {
        public AutofacDefaultCoreModule()
        {
        }


        protected override void Load(ContainerBuilder builder)
        {
            // SINGLE
            builder.RegisterType<TextStatisticsService>()
                .As<ITextStatisticsService>()
                .SingleInstance();

            builder.RegisterType<HuffmanStaticSymbolsCodesService>()
                .As<IHuffmanStaticSymbolsCodesService>()
                .SingleInstance();

            builder.RegisterType<HuffmanStaticCompressorService>()
                .As<IHuffmanStaticCompressorService>()
                .SingleInstance();

            builder.RegisterType<HuffmanStaticDecompressorService>()
                .As<IHuffmanStaticDecompressorService>()
                .SingleInstance();


            // SCOPE
            // ...
        }
    }
}
