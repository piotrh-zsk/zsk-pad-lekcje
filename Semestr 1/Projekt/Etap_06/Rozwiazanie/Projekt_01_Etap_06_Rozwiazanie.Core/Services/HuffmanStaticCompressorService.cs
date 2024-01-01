using Projekt_01_Etap_06_Rozwiazanie.Core.Helpers;
using Projekt_01_Etap_06_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_06_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_06_Rozwiazanie.Core.Services
{
    public class HuffmanStaticCompressorService : IHuffmanStaticCompressorService
    {
        private IHuffmanStaticSymbolsCodesService _huffmanStaticService;

        public HuffmanStaticCompressorService(IHuffmanStaticSymbolsCodesService huffmanStaticService)
        {
            _huffmanStaticService = huffmanStaticService;
        }


        public byte[] CompressFile(TextStatisticsData statistics, string fileContent)
        {
            // przygotowanie słownika kodów
            List<HuffmanNode> compressionCodes = _huffmanStaticService.GenerateCodesDictionary(statistics);

            // przepisanie kodów do bardziej wydajnej struktury
            Dictionary<char, HuffmanNode> codesDict = new Dictionary<char, HuffmanNode>();
            for (int i = 0; i < compressionCodes.Count; i++)
                codesDict.Add(compressionCodes[i].Symbol!.Value, compressionCodes[i]);

            // budowa tablicy bajtów z zawartością pliku
            List<bool> fileContents = new List<bool>();
            for (int i = 0; i < fileContent.Length; i++)
            {
                var code = codesDict[fileContent[i]];
                fileContents.AddRange(code.BitCode!);
            }
            byte[] compressedFile = BitHelpers.ToByteArray(fileContents);

            // bity opisujące ilość znaczących bitów
            byte[] fileContentLength = BitConverter.GetBytes(fileContents.Count);

            // sklejenie wynikowej struktury i przepisanie do tablicy bajtów
            byte[] summaryContentBytes = fileContentLength.Concat(compressedFile).ToArray();

            // przepisanie słownika do bajtowej struktury
            byte[] dictionaryBytes = _huffmanStaticService.GetDictionaryBytes(compressionCodes);

            // wyznaczenie bajtów opisujących długość słownika
            byte[] dictionaryBytesCount = BitConverter.GetBytes(dictionaryBytes.Length);

            // sklejenie wynikowej struktury
            byte[] result = dictionaryBytesCount.Concat(dictionaryBytes).Concat(summaryContentBytes).ToArray();

            return result;
        }
    }
}
