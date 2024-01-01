namespace Projekt_01_Etap_09_Rozwiazanie.Core.Helpers
{
    public static class BitHelpers
    {
        /// <summary>
        /// Metoda pozwalająca odczytać stan wskazanego bitu w liczbie
        /// </summary>
        /// <param name="source">Źródłowa liczba</param>
        /// <param name="bitNumber">Pozycja odyczytywanego bitu</param>
        /// <returns>Stan bitu, true jeśli ustaiowny na 1, false jeśli ustawiony na 0</returns>
        public static bool GetBit(int source, int bitNumber)
        {
            return (source & (1 << bitNumber)) != 0;
        }

        /// <summary>
        /// Metoda ustaiwająca bit na wskazanej pozycji na wartość true
        /// </summary>
        /// <param name="intValue">Liczba int, na której zmieniany będzie bit</param>
        /// <param name="bitPosition">Pozycja zmienianego bitu</param>
        /// <returns>Nowa wartość uzyskana po zmianie bitu</returns>
        public static int SetBit(int intValue, int bitPosition)
        {
            return intValue | (1 << bitPosition);
        }

        /// <summary>
        /// Przekształcenie listy elementów bool na tablicę bajtów
        /// </summary>
        /// <param name="input">Lista elementów typu bool</param>
        /// <returns>Tablica bajtów uzupełniona zerami</returns>
        public static byte[] ToByteArray(List<bool> input)
        {
            if (input.Count % 8 != 0)
            {
                int lackingBits = 8 - (input.Count % 8);
                for (int i = 0; i < lackingBits; i++)
                    input.Add(false);
            }
            byte[] ret = new byte[input.Count / 8];
            for (int i = 0; i < input.Count; i += 8)
            {
                int value = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (input[i + j])
                    {
                        value += 1 << (7 - j);
                    }
                }
                ret[i / 8] = (byte)value;
            }

            return ret;
        }

        /// <summary>
        /// Przekształcenie tablicy bajtów w listę elementów typu bool
        /// </summary>
        /// <param name="input">Tablica bajtów</param>
        /// <returns>Lista elementów typu bool</returns>
        public static List<bool> ToBoolList(byte[] input)
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
