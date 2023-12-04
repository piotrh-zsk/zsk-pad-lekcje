using Projekt_01_Etap_08_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_08_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Projekt_01_Etap_08_Rozwiazanie.Core.Services
{
    public class HuffmanStaticDecompressorService : IHuffmanStaticDecompressorService
    {
        private IHuffmanStaticSymbolsCodesService _huffmanStaticService;

        public HuffmanStaticDecompressorService(IHuffmanStaticSymbolsCodesService huffmanStaticService)
        {
            _huffmanStaticService = huffmanStaticService;
        }

        public string DecompressFile(byte[] fileContent, out List<HuffmanNode> dictionary, out TimeSpan codeTimes)
        {
            int index = 0;

            // pierwsza 4 bajty to int mówiący o tym ile kolejnych bajtów to słownik
            int dictionaryBytesCount = BitConverter.ToInt32(fileContent, index);
            index = 4;

            // trzeba oddzielić zadaną liczbe bajtów
            byte[] dictionaryBytes = fileContent.Skip(index).Take(dictionaryBytesCount).ToArray();
            index += dictionaryBytes.Length;

            // odczytanie słownika kodów
            Stopwatch sw_dictionary = new Stopwatch();
            sw_dictionary.Start();
            dictionary = _huffmanStaticService.GetDictionaryObject(dictionaryBytes);
            sw_dictionary.Stop();
            codeTimes = sw_dictionary.Elapsed;

            // oddzielenie bajtów zawierających zawartość pliku
            byte[] originalFileContent = fileContent.Skip(index).ToArray();

            // pierwsze 4 bajty to informacja o ilości znaczących bitów
            index = 0;
            int fileBitsCount = BitConverter.ToInt32(originalFileContent, index);
            index = 4;

            // przerobienie bajtów na listę bitów
            byte[] compressedBits = originalFileContent.Skip(index).ToArray();
            List<bool> originalFileContentBits = ToBoolList(compressedBits);

            // przepisanie słownika do wydajniejszej formy
            Dictionary<string, HuffmanNode> codesDict = new Dictionary<string, HuffmanNode>();
            for (int i = 0; i < dictionary.Count; i++)
                codesDict.Add(dictionary[i].Code!, dictionary[i]);

            // pętla po bitach i przywrócenie tekstu
            StringBuilder resultText = new StringBuilder();
            string buffer = "";
            for (int i = 0; i < fileBitsCount; i++)
            {
                if (originalFileContentBits[i])
                    buffer += "1";
                else
                    buffer += "0";
                if (codesDict.TryGetValue(buffer, out HuffmanNode? value))
                {
                    resultText.Append(value!.Symbol);
                    buffer = "";
                }
            }

            string result = resultText.ToString();
            return result;
        }



        private List<bool> ToBoolList(byte[] input)
        {
            List<bool> result = new List<bool>();
            for (int i = 0; i < input.Length; i++)
            {
                bool[] bytes = new bool[8];
                for (int j = 0; j < 8; j++)
                {
                    bool bit = (input[i] & (1 << j)) != 0;
                    bytes[j] = bit;
                }
                result.AddRange(bytes.Reverse());
            }
            return result;
        }
    }
}
