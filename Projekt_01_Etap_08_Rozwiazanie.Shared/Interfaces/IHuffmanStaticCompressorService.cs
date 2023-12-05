﻿using Projekt_01_Etap_08_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_08_Rozwiazanie.Shared.Interfaces
{
    public interface IHuffmanStaticCompressorService
    {
        byte[] CompressFile(TextStatisticsData statistics, string fileContent);
    }
}
