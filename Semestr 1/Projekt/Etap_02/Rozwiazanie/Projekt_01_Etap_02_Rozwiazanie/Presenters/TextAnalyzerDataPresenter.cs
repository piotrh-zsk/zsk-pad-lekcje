using Projekt_01_Etap_02_Rozwiazanie.Core.Services;
using Projekt_01_Etap_02_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;

namespace Projekt_01_Etap_02_Rozwiazanie.Presenters
{
    public class TextAnalyzerDataPresenter
    {
        // ustawienie pól jako prywatne, nie chcemy by były one widoczne z zewnątrz klasy TextAnalyzerDataPresenter
        // pola te są wewnętrzną sprawą tej klasy, wartości tych pól przekazujemy lub inicjalizujemy w konstruktorze
        private TextBox _tb_Length;
        private TextBox _tb_Letters;
        private TextBox _tb_Digits;
        private TextBox _tb_Special;
        private TextBox _tb_Time;

        private ITextAnalyzerService _textAnalyzerService;


        public TextAnalyzerDataPresenter(TextBox tb_Length, TextBox tb_Letters, TextBox tb_Digits,
            TextBox tb_Special, TextBox tb_Time)
        {
            // rapisanie sobie referencji do kontrolek, by móc się do nich odwoływać w innych miejscach w kodzie
            _tb_Length = tb_Length;
            _tb_Letters = tb_Letters;
            _tb_Digits = tb_Digits;
            _tb_Special = tb_Special;
            _tb_Time = tb_Time;

            // aktywacja serwisów - tutaj dokonujemy wyboru, które implementacja serwisu będzie tą, z której
            // chcemy korzystać
            _textAnalyzerService = new TextAnalyzerService();
        }


        public void PerformTextAnalysis(string text)
        {
            // rozpoczęcie pomiaru czasu
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // przeprowadzenie analizy
            var result = _textAnalyzerService.PerformAnalysis(text);

            // zakończenie pomiaru czasu
            sw.Stop();

            // drukowanie wyników
            _tb_Length.Text = result.TextLength.ToString();
            _tb_Letters.Text = result.ContainsLetters ? "TAK" : "NIE";
            _tb_Digits.Text = result.ContainsDigits ? "TAK" : "NIE";
            _tb_Special.Text = result.ContainsSpecial ? "TAK" : "NIE";
            _tb_Time.Text = sw.Elapsed.ToString();
        }
    }
}
