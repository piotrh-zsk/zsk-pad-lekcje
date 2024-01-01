using System.Diagnostics;
using System.Drawing;
using System.Timers;

namespace Projekt_01_Etap_09_Rozwiazanie
{
    public partial class Wykres : Form
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        int dlugoscAnimacjiMs = 700;
        int dlugoscAnimacjiMsAkt = 0;
        int oryginalneKilobajtyPom = 0;
        int spakowaneKilobajtyPom = 0;
        float oryginalneKilobajtySkok = 0;
        float spakowaneKilobajtySkok = 0;
        float oryginalneKilobajtyAktualnie = 0;
        float spakowaneKilobajtyAktualnie = 0;
        int frameSleep = 25;

        int oryginalneKilobajty = 18436;
        int spakowaneKilobajty = 1256;
        string jednostka = "";

        int wartoscA = 0;
        int wartoscB = 0;
        int podzialka = 0;
        int liczbaPodzialek = 0;

        Pen selPen;
        Pen blackPenGlowne;
        Pen blackPenPodzialki;
        FontFamily fontFamily;
        Font fontPodzialki;
        SolidBrush solidBrushPodzialki;
        SolidBrush solidBrushLewy;
        SolidBrush solidBrushPrawy;


        public Wykres(long oryginalnyPlik, long spakowanyPlik)
        {
            InitializeComponent();

            var rozmiar = SizeSuffix(oryginalnyPlik, spakowanyPlik);

            oryginalneKilobajty = rozmiar.Item1;
            spakowaneKilobajty = rozmiar.Item2;
            jednostka = rozmiar.Item3;


            selPen = new Pen(Color.Blue);
            blackPenGlowne = new Pen(Color.Black, 4);
            blackPenPodzialki = new Pen(Color.Black, 1);
            fontFamily = new FontFamily("Times New Roman");
            fontPodzialki = new Font(fontFamily, 18, FontStyle.Regular);
            solidBrushPodzialki = new SolidBrush(Color.Black);
            solidBrushLewy = new SolidBrush(Color.Red);
            solidBrushPrawy = new SolidBrush(Color.Green);
        }

        private void Wykres_Load(object sender, EventArgs e)
        {
            // wyznaczenie podziałki
            if (oryginalneKilobajty > 10000 || spakowaneKilobajty > 10000)
            {
                wartoscA = ((oryginalneKilobajty / 1000) * 1000) + 1000;
                wartoscB = ((spakowaneKilobajty / 1000) * 1000) + 1000;
                podzialka = 1000;
            }
            else if (oryginalneKilobajty > 1000 || spakowaneKilobajty > 1000)
            {
                wartoscA = ((oryginalneKilobajty / 500) * 500) + 1000;
                wartoscB = ((spakowaneKilobajty / 500) * 500) + 1000;
                podzialka = 500;
            }
            else
            {
                wartoscA = ((oryginalneKilobajty / 100) * 100) + 100;
                wartoscB = ((spakowaneKilobajty / 100) * 100) + 100;
                podzialka = 100;
            }
            if (wartoscA > wartoscB)
                liczbaPodzialek = wartoscA / podzialka;
            else
                liczbaPodzialek = wartoscB / podzialka;

            aTimer.SynchronizingObject = this;
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = frameSleep;
            aTimer.Enabled = true;

            oryginalneKilobajtyPom = oryginalneKilobajty;
            spakowaneKilobajtyPom = spakowaneKilobajty;
            oryginalneKilobajty = 1;
            spakowaneKilobajty = 1;

            float liczbaPowtorzen = dlugoscAnimacjiMs / frameSleep;

            oryginalneKilobajtySkok = oryginalneKilobajtyPom / liczbaPowtorzen;
            spakowaneKilobajtySkok = spakowaneKilobajtyPom / liczbaPowtorzen;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //aTimer.Enabled = false;
            if (dlugoscAnimacjiMsAkt < dlugoscAnimacjiMs)
            {
                oryginalneKilobajtyAktualnie += oryginalneKilobajtySkok;
                spakowaneKilobajtyAktualnie += spakowaneKilobajtySkok;
        
                oryginalneKilobajty = (int)oryginalneKilobajtyAktualnie;
                spakowaneKilobajty = (int)spakowaneKilobajtyAktualnie;
                dlugoscAnimacjiMsAkt += frameSleep;
                panel1.Refresh();
                //aTimer.Enabled = true;
                //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "a");
            }
            else
            {
                aTimer.Enabled = false;
                oryginalneKilobajty = oryginalneKilobajtyPom;
                spakowaneKilobajty = spakowaneKilobajtyPom;
                panel1.Refresh();
                //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss:fff") + "b");
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // podstawowe ustawienia
            Size marginesy = new Size(20, 20);
            float procentowaSzerokoscWartosciY = (float)0.1;
            float procentowaWysokoscWartosciX = (float)0.1;
            float procentowaSzerokoscSlupka = (float)0.7;

            // ustalenie obszaru działań
            int lewaKrawedz = marginesy.Width;
            int prawaKrawedz = panel1.Width - marginesy.Width;
            int gornaKrawedz = marginesy.Height;
            int dolnaKrawedz = panel1.Height - marginesy.Height;
            Point canvas_location = new Point(lewaKrawedz, gornaKrawedz);
            Size canvas_size = new Size(panel1.Width - (marginesy.Width * 2), panel1.Height - (marginesy.Height * 2));
            Rectangle canvas = new Rectangle(canvas_location, canvas_size);
            e.Graphics.DrawRectangle(selPen, canvas);

            // obszar wartosci Y
            int obszarWartosciY_szerokosc = (int)(((float)canvas.Width) * procentowaSzerokoscWartosciY);
            int obszarWartosciY_wysokosc = canvas.Height;
            Point obszarWartosciY_location = new Point(lewaKrawedz, gornaKrawedz);
            Size obszarWartosciY_size = new Size(obszarWartosciY_szerokosc, obszarWartosciY_wysokosc);
            Rectangle obszarWartosciY = new Rectangle(obszarWartosciY_location, obszarWartosciY_size);
            e.Graphics.DrawRectangle(selPen, obszarWartosciY);

            // obszar wartosci X
            int obszarWartosciX_szerokosc = canvas.Width;
            int obszarWartosciX_wysokosc = (int)(((float)canvas.Height) * procentowaWysokoscWartosciX);
            Point obszarWartosciX_location = new Point(lewaKrawedz, dolnaKrawedz - obszarWartosciX_wysokosc);
            Size obszarWartosciX_size = new Size(obszarWartosciX_szerokosc, obszarWartosciX_wysokosc);
            Rectangle obszarWartosciX = new Rectangle(obszarWartosciX_location, obszarWartosciX_size);
            e.Graphics.DrawRectangle(selPen, obszarWartosciX);

            // okreslenie punktu (0, 0) wykresu i linii pionowych i poziomych
            Point zeroZero_location = new Point(lewaKrawedz + obszarWartosciY_szerokosc, dolnaKrawedz - obszarWartosciX_wysokosc);
            Point liniaYkonie = new Point(marginesy.Width + obszarWartosciY_szerokosc, marginesy.Height);
            Point liniaXkonie = new Point(panel1.Width - marginesy.Width, marginesy.Height + canvas.Height - obszarWartosciX_wysokosc);
            e.Graphics.DrawLine(blackPenGlowne, zeroZero_location, liniaYkonie);
            e.Graphics.DrawLine(blackPenGlowne, zeroZero_location, liniaXkonie);

            // rysowanie poziomych podziałek
            float wysokoscWykresu = (float)(zeroZero_location.Y - gornaKrawedz);
            float podzialkaWysokosc = (float)wysokoscWykresu / (float)liczbaPodzialek;
            float podzialkaPoziom = 0;
            float fontPodzialkiPolowa = (float)fontPodzialki.Height / (float)2;
            for (int i = 0; i < liczbaPodzialek; i++)
            {
                podzialkaPoziom += podzialkaWysokosc;
                Point p1 = new Point(zeroZero_location.X, (int)(zeroZero_location.Y - podzialkaPoziom));
                Point p2 = new Point(prawaKrawedz, (int)(zeroZero_location.Y - podzialkaPoziom));
                e.Graphics.DrawLine(blackPenPodzialki, p1, p2);
                string wartoscPodzialki = ((i + 1) * (float)podzialka).ToString();
                SizeF szerokoscTekstu = e.Graphics.MeasureString(wartoscPodzialki, fontPodzialki);
                int poczatekTekstu = zeroZero_location.X - (int)szerokoscTekstu.Width - 10;
                e.Graphics.DrawString(wartoscPodzialki, fontPodzialki, solidBrushPodzialki, poczatekTekstu, zeroZero_location.Y - podzialkaPoziom - fontPodzialkiPolowa);
            }
            SizeF jednostka_szerokoscTekstu = e.Graphics.MeasureString(jednostka, fontPodzialki);
            int jednostka_poczatekTekstu = zeroZero_location.X - (int)jednostka_szerokoscTekstu.Width - 10;
            e.Graphics.DrawString(jednostka, fontPodzialki, solidBrushPodzialki, jednostka_poczatekTekstu, zeroZero_location.Y + 5);

            // podział obszaru wykresu na dwa i wyznaczenie środków
            int srodekWykresu = zeroZero_location.X + ((prawaKrawedz - zeroZero_location.X) / 2);
            e.Graphics.DrawLine(selPen, srodekWykresu, marginesy.Height, srodekWykresu, zeroZero_location.Y);
            int srodekLewegoSlupka = zeroZero_location.X + ((srodekWykresu - zeroZero_location.X) / 2);
            int srodekPrawegoSlupka = srodekWykresu + ((prawaKrawedz - srodekWykresu) / 2);
            e.Graphics.DrawLine(selPen, srodekLewegoSlupka, marginesy.Height, srodekLewegoSlupka, zeroZero_location.Y);
            e.Graphics.DrawLine(selPen, srodekPrawegoSlupka, marginesy.Height, srodekPrawegoSlupka, zeroZero_location.Y);

            // obliczenie szerokości słupków
            int szerokoscSlupka = (int)((float)(srodekWykresu - zeroZero_location.X) * procentowaSzerokoscSlupka);
            int polowaSlupka = szerokoscSlupka / 2;

            // obliczenie wysokości słupków z proporcji
            float procentWysokosciLewegoSlupka = 0;
            float procentWysokosciPrawegoSlupka = 0;
            if (wartoscA > wartoscB)
            {
                procentWysokosciLewegoSlupka = (float)oryginalneKilobajty * (float)100 / (float)wartoscA;
                procentWysokosciPrawegoSlupka = (float)spakowaneKilobajty * (float)100 / (float)wartoscA;
            }
            else
            {
                procentWysokosciLewegoSlupka = (float)oryginalneKilobajty * (float)100 / (float)wartoscB;
                procentWysokosciPrawegoSlupka = (float)spakowaneKilobajty * (float)100 / (float)wartoscB;
            }
            float dostepnaWysokoscWykresu = (float)(zeroZero_location.Y - marginesy.Height);
            int wysokoscLewegoSlupka = (int)(dostepnaWysokoscWykresu * procentWysokosciLewegoSlupka / 100f);
            int wysokoscPrawegoSlupka = (int)(dostepnaWysokoscWykresu * procentWysokosciPrawegoSlupka / 100f);

            // rysowanie słupków
            Point slupekLewy_location = new Point(srodekLewegoSlupka - polowaSlupka, zeroZero_location.Y - wysokoscLewegoSlupka);
            Size slupekLewy_size = new Size(szerokoscSlupka, wysokoscLewegoSlupka);
            Rectangle slupekLewy = new Rectangle(slupekLewy_location, slupekLewy_size);
            e.Graphics.FillRectangle(solidBrushLewy, slupekLewy);
            string slupekLewy_podpis = "oryginalny plik";
            SizeF slupekLewy_szerokoscTekstu = e.Graphics.MeasureString(slupekLewy_podpis, fontPodzialki);
            int slupekLewy_poczatekTekstu = (int)(srodekLewegoSlupka - (slupekLewy_szerokoscTekstu.Width / 2));
            e.Graphics.DrawString(slupekLewy_podpis, fontPodzialki, solidBrushPodzialki, slupekLewy_poczatekTekstu, zeroZero_location.Y + 5);

            Point slupekPrawy_location = new Point(srodekPrawegoSlupka - polowaSlupka, zeroZero_location.Y - wysokoscPrawegoSlupka);
            Size slupekPrawy_size = new Size(szerokoscSlupka, wysokoscPrawegoSlupka);
            Rectangle slupekPrawy = new Rectangle(slupekPrawy_location, slupekPrawy_size);
            e.Graphics.FillRectangle(solidBrushPrawy, slupekPrawy);
            string slupekPrawy_podpis = "spakowany plik";
            SizeF slupekPrawy_szerokoscTekstu = e.Graphics.MeasureString(slupekPrawy_podpis, fontPodzialki);
            int slupekPrawy_poczatekTekstu = (int)(srodekPrawegoSlupka - (slupekPrawy_szerokoscTekstu.Width / 2));
            e.Graphics.DrawString(slupekPrawy_podpis, fontPodzialki, solidBrushPodzialki, slupekPrawy_poczatekTekstu, zeroZero_location.Y + 5);

            var tytuł = "Różnica w rozmiarze plików";
            FontFamily fontFamily = new FontFamily("Arial");
            Font myFont = new Font(fontFamily, 18, FontStyle.Regular);
            var tytuldlugosc = e.Graphics.MeasureString(tytuł, myFont);
            var tekstpunkt = new Point((obszarWartosciX_szerokosc/2) - (int)(tytuldlugosc.Width/2), gornaKrawedz + (int)(tytuldlugosc.Height / 2));
            e.Graphics.DrawString(tytuł, myFont, solidBrushPrawy, tekstpunkt.X, tekstpunkt.Y);
        }

        private void Wykres_Resize(object sender, EventArgs e)
        {
            panel1.Refresh();
        }



        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static Tuple<int, int, string> SizeSuffix(long liczbaBajtow1, long liczbaBajtow2)
        {
            int i = 0;
            decimal dValue1 = (decimal)liczbaBajtow1;
            decimal dValue2 = (decimal)liczbaBajtow2;

            while (Math.Round(dValue1, 0) >= 2000 && Math.Round(dValue2, 0) >= 2000)
            {
                dValue1 /= 1024;
                dValue2 /= 1024;
                i++;
            }

            return new Tuple<int, int, string>((int)dValue1, (int)dValue2, SizeSuffixes[i]);
        }
    }

    class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel() : base()
        {
            DoubleBuffered = true;
        }
    }
}
