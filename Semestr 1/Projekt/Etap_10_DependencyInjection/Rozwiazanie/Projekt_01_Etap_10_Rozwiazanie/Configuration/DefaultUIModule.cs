using Autofac;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_10_Rozwiazanie.Configuration
{
    public class DefaultUIModule : Module
    {
        public DefaultUIModule()
        {
        }


        protected override void Load(ContainerBuilder builder)
        {
            // SINGLE
            //builder.RegisterType<MainWIndowRTB>().As<IMainWindow>().SingleInstance();
            builder.RegisterType<MainWindowDGV>().As<IMainWindow>().SingleInstance();

            builder.RegisterType<CompressForm>().SingleInstance();
            builder.RegisterType<DecompressForm>().SingleInstance();

            // SCOPE
            // ...
        }
    }
}
