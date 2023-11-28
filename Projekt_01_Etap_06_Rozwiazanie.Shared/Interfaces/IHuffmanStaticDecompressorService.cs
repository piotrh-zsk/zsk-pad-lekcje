using Projekt_01_Etap_06_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_06_Rozwiazanie.Shared.Interfaces
{
    public interface IHuffmanStaticDecompressorService
    {
        string DecompressFile(byte[] fileContent, out List<HuffmanNode> dictionary, out TimeSpan codeTimes);
    }
}
