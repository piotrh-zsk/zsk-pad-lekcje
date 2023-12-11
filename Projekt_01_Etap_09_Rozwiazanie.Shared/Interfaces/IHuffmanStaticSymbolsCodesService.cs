using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces
{
    public interface IHuffmanStaticSymbolsCodesService
    {
        List<HuffmanNode> GenerateCodesDictionary(TextStatisticsData statistics);

        byte[] GetDictionaryBytes(List<HuffmanNode> dictionary);

        List<HuffmanNode> GetDictionaryObject(byte[] dictionaryData);
    }
}
