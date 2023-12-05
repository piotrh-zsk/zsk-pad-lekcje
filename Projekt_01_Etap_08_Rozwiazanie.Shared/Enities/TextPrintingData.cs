namespace Projekt_01_Etap_08_Rozwiazanie.Shared.Enities
{
    public class TextPrintingData
    {
        public string? AllSymbolCount { get; set; }

        public string? UniqueSymbolCount { get; set; }

        public string? Entropy { get; set; }

        public List<SymbolPrintingData>? SymbolStatistics { get; set; }

        public TimeSpan? ExecutionTime { get; set; }
    }
}
