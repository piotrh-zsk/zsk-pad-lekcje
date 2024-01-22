using Projekt_01_Etap_02_Rozwiazanie.Shared.Entities;

namespace Projekt_01_Etap_02_Rozwiazanie.Shared.Interfaces
{
    public interface ITextAnalyzerService
    {
        TextAnalyzeResult PerformAnalysis(string text);
    }
}
