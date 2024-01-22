using Projekt_01_Etap_02_Rozwiazanie.Presenters;

namespace Projekt_01_Etap_02_Rozwiazanie
{
    public partial class Form1 : Form
    {
        // deklarujemy presentera, jest to klasa pośrednicząca między naszym interfejsem graficznym
        // a naszą logiką biznesową osadzoną w serwisach (w projekcie Core). Klasa ta posiada wiedzę zarówno
        // o kontrolkach, bo przekażemy jej kontrolki jako parametry w konstruktorze. Klasa ta posiada też
        // wiedze o logice biznesowej, bo to w niej następuje inicjalizacja serwisu
        private TextAnalyzerDataPresenter textAnalyzerDataPresenter;


        public Form1()
        {
            // metoda poniżej jest to domyślnie generowana metoda, odpowiedzialna za inicjalizację kontrolek
            // na formatce
            InitializeComponent();

            // inicjalizacja obiektu textAnalyzerDataPresenter mogłaby nastąpić też w konstruktorze, ale
            // przy takim rozwiazaniu należy pamiętać, by nastąpiła ona dopiero PO metodzie InitializeComponent
            // w przeciwnym razie nie moglibyśmy przekazać kontrolek, gdyż jeszcze by one nie istniały

            // my jednak do inicjalizacji obiektu textAnalyzerDataPresenter wykorzystamy zdarzenie Form1_Load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // inicjalizacja obiektu textAnalyzerDataPresenter
            textAnalyzerDataPresenter = new TextAnalyzerDataPresenter(textBox1, textBox2, textBox3, textBox4, textBox5);

            #region Sztuczne ustawienie tekstu - tylko na potrzeby testów
            //string mainText = "Ala przyniosła do domu 6 jabłek, które kupiła na targu. ";
            //string mainText = "Ala nie przyniosła do domu jabłek, bo ich nie kupiła. ";
            //string mainText = "123456łąść";
            //string mainText = "TEKSTłąśćtekst";
            //string mainText = "AlaPrzynioslaDoDomuSzescJablekKtoreKupilaNaTargu";
            //string mainText = "ĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳĴĵĶķĸĹĺĻļĽľĿŀŁłŃńŅņŇňŉŊŋŌōŎŏŐőŒœŔŕŖŗŘřŚśŜŝŞşŠšŢţŤťŦŧŨũŪūŬŭŮůŰűŲųŴŵŶŷŸŹźŻżŽžſƀƁƂƃƄƅƆƇƈƉƊƋƌƍƎƏƐƑƒƓƔƕƖƗƘƙƚƛƜƝƞƟƠơƢƣƤƥƦƧƨƩƪƫƬƭƮƯưƱƲƳƴƵƶƷƸƹƺƻƼƽƾƿǀǁǂǃǄǅǆǇǈǉǊǋǌǍǎǏǐǑǒǓǔǕǖǗǘǙǚǛǜǝǞǟǠǡǢǣǤǥǦǧǨǩǪǫǬǭǮǯǰǱǲǳǴǵǶǷǸǹǺǻǼǽǾǿ";
            //string mainText = "AlćaPrĄzynioĘslĆaDŁoŃęDośmąuSłzóesńcJablekKtorÓeKuŻżpiŚlaNaTargu";
            //string mainText = "0123456789";

            //richTextBox1.Text = mainText;

            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < 1000000; i++)
            //    sb.Append(mainText);
            //richTextBox1.Text = sb.ToString();
            #endregion Sztuczne ustawienie tekstu - tylko na potrzeby testów
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // wywołanie odpowiedniej metody w presenterze
            textAnalyzerDataPresenter.PerformTextAnalysis(richTextBox1.Text);

            // zwróćcie uwagę na to jak bardzo uprościło nam się to zdarzenie
            // gdybyśmy, przykładowo, chcieli by program dodatkowo przeliczał statystyki w locie
            // gdy tylko tekst się zmieni, możemy dodać kolejne zdarzenie i w nim ponownie wywołać jedynie
            // metodę PerformTextAnalysis - przykład poniżej.

            // jeżeli w trakcie testów odkrylibyśmy, że algorytm badania tektu ma w sobie jakiś błąd
            // mamy tylko jedno miejsce, gdzie musimy go poprawić, kod nie jest niepotrzebnie
            // zwielokrotniany
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // wywołanie odpowiedniej metody w presenterze
            textAnalyzerDataPresenter.PerformTextAnalysis(richTextBox1.Text);
        }
    }
}