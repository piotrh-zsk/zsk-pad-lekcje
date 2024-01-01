using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces
{
    public interface IHuffmanStaticCompressorService
    {
        byte[] CompressFile(TextStatisticsData statistics, string fileContent);
    }
}
