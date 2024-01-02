namespace Projekt_01_Etap_06_Rozwiazanie.Shared.Enities
{
    public class HuffmanNode
    {
        public HuffmanNode? _left { get; set; }

        public HuffmanNode? _right { get; set; }

        public char? Symbol { get; set; }

        public int Importance { get; set; }

        public string? Code { get; set; }

        public bool[]? BitCode { get; set; }
    }
}
