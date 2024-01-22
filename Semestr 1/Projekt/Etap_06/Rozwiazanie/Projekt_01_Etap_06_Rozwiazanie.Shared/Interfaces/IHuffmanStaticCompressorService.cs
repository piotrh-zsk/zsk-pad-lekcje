using Projekt_01_Etap_06_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_06_Rozwiazanie.Shared.Interfaces
{
    public interface IHuffmanStaticCompressorService
    {
        byte[] CompressFile(TextStatisticsData statistics, string fileContent);
    }
}
