using Lekcja_03.Core.Services;
using Lekcja_03.Shared.Interfaces;

namespace Lekcja_03.Adapters
{
    public class Form1Adapter
    {
        private RichTextBox _rtb_Text;

        private IMyService _myService;                                              // pole typu inerfejs pod które podstawimy faktyczną implementację serwisu
        private MyOtherServiceWithoutInterface _myOtherServiceWithoutInterface;     // pole deklarujacy konkretną implementację serwisu


        public Form1Adapter(RichTextBox rtb_Text)
        {
            _rtb_Text = rtb_Text;

            // konfiguracja tego, która implementacja usługi ma być wykorzystywana
            _myService = new MyService();                       // jeżeli chcemy przełączyć usługę na inną jej implementację możemy zakomentować
            //_myService = new MyBetterService();               // jedną linię i odkomentować inną. Dzięki temu, że wszystkie one implementują
            //_myService = new MyAbsolutelyAwesomeService();    // interfejs IMyService

            _myOtherServiceWithoutInterface = new MyOtherServiceWithoutInterface(); // jedyna dostępna inicjalizacja obiektu
            //_myOtherServiceWithoutInterface = new MyBetterOtherServiceWithoutInterface(); // odkomentowanie tej linii rozpocznie cały szereg błędów
                                                                                            // i miejsc, w których trzeba będzie dokonać zmian
                                                                                            // 1. najpierw trzeba będzie zmodyfikować linię 12 i nadać nowy typ
                                                                                            // 2. to z kolei wymusi modyfikację metody SetSomeDefaultConfigInOthrService
                                                                                            // 3. itd.

            // konfiguracja serwisu
            SetSomeDefaultConfig(_myService, "ABC");
            SetSomeDefaultConfigInOthrService(_myOtherServiceWithoutInterface, "ABC");
        }


        public void PerformAction(string text)
        {
            // przeprowadzenie analizy
            var result = _myService.MyMethod(text);
            var result2 = _myOtherServiceWithoutInterface.MyOtherMethod(text);  // ta linijka zadziała bez zmian nawet gdy zmienimy MyOtherServiceWithoutInterface na
                                                                                // MyBetterOtherServiceWithoutInterface, warto jednak pamiętać, że zadziała to tylko
                                                                                // dlatego, że metoda dziwnym zbiegiem okoliczności nazywa się dokładnie tak samo,
                                                                                // przyjmuje takie same parametry i zwraca wynik tego samego typu.
                                                                                // Jest tak prawdopodobnie dlatego, bo sami tworzyliśmy obydwie implementacje usługi.
                                                                                // W dużym projekcie inną implementację tej usługi może robić ktoś inny, kto inaczej
                                                                                // nazwie sobie tę metodę. Będzie mógł tak zrobić, ponieważ nie będzie żadnego interfejsu
                                                                                // który wymusi "dopasowanie się" do narzuconego standardu.

            // drukowanie wyników
            _rtb_Text.Text = result.MyText;
        }

        // Bezsensowny przykład (w tym kontekście), ale można sobie wyobrazić, setki tego typu metod rozsianych po różnych plikach w projekcie
        private void SetSomeDefaultConfig(IMyService srv, string configValue)
        {
            // jakaś tam przykładowa konfiguracja
            srv.SetSomeConfig(configValue);
        }
        private void SetSomeDefaultConfigInOthrService(MyOtherServiceWithoutInterface srv, string configValue)
        {
            // jakaś tam przykładowa konfiguracja
            srv.SetSomeConfig(configValue);
        }
    }
}
