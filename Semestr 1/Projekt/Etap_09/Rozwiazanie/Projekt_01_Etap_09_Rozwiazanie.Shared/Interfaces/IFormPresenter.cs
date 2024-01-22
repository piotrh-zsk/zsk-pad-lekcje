namespace Projekt_01_Etap_09_Rozwiazanie.Shared.Interfaces
{
    public interface IFormPresenter
    {
        void PerformTextAnalysis(string text);

        void PerformTextCompression(string filename, string text);

        void PerformTextDecompression(string filename, byte[] fileContents);
    }
}