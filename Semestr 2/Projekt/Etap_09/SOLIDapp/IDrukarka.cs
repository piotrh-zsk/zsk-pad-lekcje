namespace SOLIDapp
{
    public interface IDrukarka
    {
        // Obsługa drukarki
        void Drukuj(string zawartoscDoDruku);
        void DrukujDwustronnie(string zawartoscDoDruku);

        // Obsługa skanera
        void Skanuj(int szerokoscObszaruSkanowania, int wysokoscObszaruSkanowania);
        void WyslijEmail(string adres, string zeskanowanaZawartosc, TypMaila typMaila);

        // Obsługa faksu
        void Fax(string zawartoscDoPrzefaksowania);

        // Dodatkowe funkcjonalności
        void Kseruj(string zawartoscDoKserowania);
    }
}
