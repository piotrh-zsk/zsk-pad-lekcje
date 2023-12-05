using Projekt_01_Etap_07_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_07_Rozwiazanie.Shared.Interfaces
{
    public interface ITextStatisticsService
    {
        TextStatisticsData CountStatistics(string text);

        TextPrintingData FillPrintingData(TextStatisticsData statistics);
    }
}
