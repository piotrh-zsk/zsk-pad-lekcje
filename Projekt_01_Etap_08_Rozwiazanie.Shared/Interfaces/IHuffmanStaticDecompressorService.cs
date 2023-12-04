﻿using Projekt_01_Etap_08_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_08_Rozwiazanie.Shared.Interfaces
{
    public interface IHuffmanStaticDecompressorService
    {
        string DecompressFile(byte[] fileContent, out List<HuffmanNode> dictionary, out TimeSpan codeTimes);
    }
}
