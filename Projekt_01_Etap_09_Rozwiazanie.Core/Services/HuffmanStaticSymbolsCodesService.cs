using Projekt_01_Etap_09_Rozwiazanie.Core.Helpers;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_09_Rozwiazanie.Core.Services
{
    public class HuffmanStaticSymbolsCodesService : IHuffmanStaticSymbolsCodesService
    {
        public List<HuffmanNode> GenerateCodesDictionary(TextStatisticsData statistics)
        {
            List<HuffmanNode> huffmanNodes = new List<HuffmanNode>();

            // wczytanie danych do wezlow i pozadkowanie wzgledem wagi
            for (int i = 0; i < statistics.SymbolStatistics?.Count; i++)
            {
                HuffmanNode temp = new HuffmanNode();
                temp.Symbol = statistics.SymbolStatistics[i].Symbol;
                temp.Importance = statistics.SymbolStatistics[i].Frequency;
                huffmanNodes.Add(temp);
            }
            huffmanNodes = huffmanNodes.OrderByDescending(x => x.Importance).ToList();

            // budowa drzewa
            while (huffmanNodes.Count >= 2)
            {
                HuffmanNode joinNode = new HuffmanNode();
                joinNode._left = huffmanNodes[huffmanNodes.Count - 2];
                joinNode._right = huffmanNodes[huffmanNodes.Count - 1];
                joinNode.Symbol = null;
                joinNode.Importance = joinNode._left.Importance + joinNode._right.Importance;
                huffmanNodes = huffmanNodes.Take(huffmanNodes.Count - 2).ToList();
                huffmanNodes.Add(joinNode);
                huffmanNodes = huffmanNodes.OrderByDescending(x => x.Importance).ToList();
            }

            // organizacja kodowania
            List<HuffmanNode> huffmanCodes = new List<HuffmanNode>();
            HuffPostOrder(huffmanNodes[0], "", huffmanCodes);

            return huffmanCodes;
        }

        public byte[] GetDictionaryBytes(List<HuffmanNode> dictionary)
        {
            // pierwsze bajty będą mówiły o tym ile w ogóle mamy symboli
            byte[] numberOfCodes = BitConverter.GetBytes(dictionary.Count);

            // następnie dla każdego symbolu tworzymy pary opisujące symbol oraz długość kodu
            List<Tuple<byte[], byte[]>> symbolsAndCodeLengths = new();
            for (int i = 0; i < dictionary.Count; i++)
            {
                byte[] symbol = BitConverter.GetBytes(dictionary[i].Symbol!.Value);
                byte[] codeLength = BitConverter.GetBytes(dictionary[i].BitCode!.Length);
                symbolsAndCodeLengths.Add(new Tuple<byte[], byte[]>(symbol, codeLength));
            }

            // następnie jednym ciągiem składamy wszystkie kody po kolei
            List<bool> summaryCodes = new List<bool>();
            for (int i = 0; i < dictionary.Count; i++)
                summaryCodes.AddRange(dictionary[i].BitCode!);
            byte[] codes = BitHelpers.ToByteArray(summaryCodes);

            // sklejenie wynikowej struktury
            byte[] result = numberOfCodes;
            for (int i = 0; i < symbolsAndCodeLengths.Count; i++)
                result = result.Concat(symbolsAndCodeLengths[i].Item1).Concat(symbolsAndCodeLengths[i].Item2).ToArray();
            result = result.Concat(codes).ToArray();

            return result;
        }

        public List<HuffmanNode> GetDictionaryObject(byte[] dictionaryData)
        {
            List<HuffmanNode> result = new List<HuffmanNode>();
            int index = 0;

            // pierwsze bajty (int)  mówią o tym z ilu elementów składa się słownik
            int numberOfCodes = BitConverter.ToInt32(dictionaryData, index);
            index = 4;

            // widząc ile jest symboli rozszyfrowujemy symbole po kolei
            for (int i = 0; i < numberOfCodes; i++)
            {
                char symbol = BitConverter.ToChar(dictionaryData, index);
                index += 2;
                int codeLength = BitConverter.ToInt32(dictionaryData, index);
                index += 4;

                HuffmanNode tmp = new HuffmanNode();
                tmp.Symbol = symbol;
                tmp.BitCode = new bool[codeLength];
                result.Add(tmp);
            }

            // odczytanie kodów
            byte[] codeBytes = dictionaryData.Skip(index).ToArray();
            List<bool> codeBits = BitHelpers.ToBoolList(codeBytes);
            int counter = 0;
            for (int i = 0; i < numberOfCodes; i++)
            {
                for (int j = 0; j < result[i].BitCode!.Length; j++)
                {
                    if (codeBits[counter])
                    {
                        result[i].Code += "1";
                        result[i].BitCode![j] = true;
                    }
                    else
                    {
                        result[i].Code += "0";
                        result[i].BitCode![j] = false;
                    }
                    counter++;
                }
            }

            return result;
        }


        // -- przebieganie drzewa
        private HuffmanNode HuffPostOrder(HuffmanNode node, string code, List<HuffmanNode> huffmanCodes)
        {
            HuffmanNode result = new HuffmanNode();
            if (node._left != null)
                result._left = HuffPostOrder(node._left, code + "0", huffmanCodes);
            if (node._right != null)
                result._right = HuffPostOrder(node._right, code + "1", huffmanCodes);
            if (node.Symbol != null)
            {
                node.Code = code;
                node.BitCode = new bool[code.Length];
                for (int i = 0; i < code.Length; i++)
                {
                    if (code[i] == '0')
                        node.BitCode[i] = false;
                    else
                        node.BitCode[i] |= true;
                }
                result.Symbol = node.Symbol;
                result.Code = code;
                huffmanCodes.Add(node);
            }
            return result;
        }
    }
}
