using Projekt_01_Etap_02_Rozwiazanie.Shared.Entities;
using Projekt_01_Etap_02_Rozwiazanie.Shared.Interfaces;

namespace Projekt_01_Etap_02_Rozwiazanie.Core.Services
{
    public class TextAnalyzerService : ITextAnalyzerService
    {
        public TextAnalyzerService()
        {
        }


        public TextAnalyzeResult PerformAnalysis(string text)
        {
            TextAnalyzeResult result = new TextAnalyzeResult();

            bool containsLetters = false;
            bool containsNumbers = false;
            bool containsSpecial = false;
            for (int i = 0; i < text.Length; i++)
            {
                char letter = text[i];
                if (letter >= '0' && letter <= '9')
                    containsNumbers = true;
                else if ((letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z'))
                    containsLetters = true;
                else
                    containsSpecial = true;
                if (containsLetters && containsNumbers && containsSpecial)
                    break;
            }
            
            result.TextLength = text.Length;
            result.ContainsLetters = containsLetters;
            result.ContainsDigits = containsNumbers;
            result.ContainsSpecial = containsSpecial;

            return result;
        }
    }
}
