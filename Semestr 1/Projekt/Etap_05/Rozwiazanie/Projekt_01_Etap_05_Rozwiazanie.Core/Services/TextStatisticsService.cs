using Projekt_01_Etap_05_Rozwiazanie.Shared.Enities;

namespace Projekt_01_Etap_05_Rozwiazanie.Core.Services
{
    // Singleton - Krok 1
    // Wzorzec Singleton sugeruje, by klasę oznaczyć słowem kluczowym "sealed". Zabroni to
    // dziedziczenia tej klasy, a co za tym idzie, nie dodatkowo zabezpieczy przed tworzeniem
    // wielu instancji klas.
    public sealed class TextStatisticsService : BaseTextStatisticsService
    {
        // Singleton - Krok 2
        // Musimy zabronić ręcznego tworzenia tej klasy poprzez operator "new". W tym celu
        // musimy zapewnić, by konstruktor tej klasy był prywatny.
        private TextStatisticsService() { }

        // Singleton - Krok 3
        // Tworzymy statyczne prywatne pole w którym przechowywać będziemy instancję klasy
        private static TextStatisticsService instance;

        // Singleton - Krok 4
        // Tworzymy metodę, której zadaniem będzie zwrócenie klasy tego serwisu. Metoda sprawdza
        // czy klasa została już stworzona. Jeżeli nie, tworzy jej instancję. W przeciwnym razie
        // zwraca już istniejącą.
        public static TextStatisticsService GetInstance()
        {
            if (instance == null)
                instance = new TextStatisticsService();
            return instance;
        }


        // -----------------------------------------------------
        // Dotychczasowa implementacja serwisu
        // -----------------------------------------------------
        public override TextStatisticsData CountStatistics(string text)
        {
            // Utworzenie obiektu wyników
            TextStatisticsData result = new TextStatisticsData();
            result.AllSymbolCount = text.Length;
            result.UniqueSymbolCount = 0;
            result.Entropy = 0;
            result.SymbolStatistics = new List<SymbolStatisticsData>();

            // Obliczanie statystyk
            // przeglądamy po kolei cały tekst, tworzymy sobie zbiór unikatowych znaków
            // liczymy ile razy każdy znak wystąpił
            Dictionary<char, SymbolStatisticsData> stats = new Dictionary<char, SymbolStatisticsData>();
            for (int i = 0; i < text.Length; i++)
            {
                // zastosowanie słownika daje nam stały, dość szybki czas dostępu do każdego elementu
                // w naszej kolekcji, jest to przydatne, ponieważ nasza kolekcja jest nieuporządkowana
                // każdorazowe wyszukiwanie w takiej kolekcji mogłoby zabierać dużo czasu
                SymbolStatisticsData? symbol;
                if (!stats.TryGetValue(text[i], out symbol))
                {
                    // jeżeli w słowniku nie występuje dany symbol tworzymy nowy obiekt statystyk tego symbolu
                    // i dodajemy go do słownika
                    symbol = new SymbolStatisticsData();
                    symbol.Symbol = text[i];
                    symbol.Frequency = 0;
                    // korzystamy przy okazji z faktu, że obiekt SymbolStatisticsData jest typem referencyjnym
                    // zatem dodajemy go (a raczej wskaźnik na niego) również do naszej wynikowej listy
                    // unikatowych znaków
                    result.SymbolStatistics.Add(symbol);
                    stats.Add(text[i], symbol);
                }
                // modyfikujemy statystykę danego znaku, zwróćcie uwage na fakt, że modyfikując obiekt
                // w słowniku modyfikujemy go również na liście result.SymbolStatistics
                // dzieje się tak, ponieważ jesto to obiekt referencyjny, zatem zarówno słownik jak i ta lista
                // wskazują fizycznie na tę samą instację tego obiektu
                symbol.Frequency++;
            }
            // kiedy mamy już kolekcję unikatowych znaków wraz z czestością występowania poszczególnych znaków
            // możemy przejść do obliczania głównych wzorów
            result.UniqueSymbolCount = result.SymbolStatistics.Count;
            for (int i = 0; i < result.SymbolStatistics.Count; i++)
            {
                result.SymbolStatistics[i].Probability = 
                    (double)result.SymbolStatistics[i].Frequency / 
                    (double)result.AllSymbolCount;

                result.SymbolStatistics[i].InformationQuantity = 
                    Math.Log((1d / result.SymbolStatistics[i].Probability), 2);

                result.Entropy += 
                    result.SymbolStatistics[i].Probability *
                    result.SymbolStatistics[i].InformationQuantity;
            }

            return result;
        }
    }
}
