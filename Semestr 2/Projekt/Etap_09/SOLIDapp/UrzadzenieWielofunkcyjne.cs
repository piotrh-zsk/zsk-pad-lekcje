using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDapp
{
    public class UrzadzenieWielofunkcyjne : IDrukarka
    {
        public void Drukuj(string zawartoscDoDruku)
        {
            // kod odpowiedzialny za drukowanie
        }

        public void DrukujDwustronnie(string zawartoscDoDruku)
        {
            throw new NotImplementedException();
        }

        public void Skanuj(int szerokoscObszaruSkanowania, int wysokoscObszaruSkanowania)
        {
            // kod odpowiedzialny za skanowanie

            // Po zeskanowaniu wysyła zawartość na email
            WyslijEmail("moj@email.pl", "ciąg danych do przesłania", TypMaila.SMTP);
        }

        public void WyslijEmail(string adres, string zeskanowanaZawartosc, TypMaila typMaila)
        {
            // kod odpowiedzialny za wysyłanie emaila
            switch (typMaila)
            {
                case TypMaila.SMTP:
                    // obsługa wysyłania poprzez SMTP
                    break;
                case TypMaila.POP:
                    // obsługa wysyłania poprzez POP
                    break;
            }
        }

        public void Fax(string zawartoscDoPrzefaksowania)
        {
            // kod odpowiedzialny za faksowanie
        }

        public void Kseruj(string zawartoscDoKserowania)
        {
            // kod odpowiedzialny za kserowanie
        }
    }
}
