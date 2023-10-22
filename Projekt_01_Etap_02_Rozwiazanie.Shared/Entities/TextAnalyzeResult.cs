namespace Projekt_01_Etap_02_Rozwiazanie.Shared.Entities
{
    public class TextAnalyzeResult
    {
        public int TextLength { get; set; }

        public bool ContainsLetters { get; set; }
        
        public bool ContainsDigits { get; set; }
        
        public bool ContainsSpecial { get; set; }
    }
}
