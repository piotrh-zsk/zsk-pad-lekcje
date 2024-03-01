using Projekt_01_Etap_10_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Projekt_01_Etap_10_Rozwiazanie
{
    public partial class CompressForm : Form
    {
        private readonly ITextStatisticsService _textStatisticsService;
        private readonly IHuffmanStaticSymbolsCodesService _huffmanStaticSymbolsCodesService;
        private readonly IHuffmanStaticCompressorService _huffmanStaticCompressorService;


        public CompressForm(ITextStatisticsService textStatisticsService,
            IHuffmanStaticSymbolsCodesService huffmanStaticSymbolsCodesService,
            IHuffmanStaticCompressorService huffmanStaticCompressorService)
        {
            _textStatisticsService = textStatisticsService;
            _huffmanStaticSymbolsCodesService = huffmanStaticSymbolsCodesService;
            _huffmanStaticCompressorService = huffmanStaticCompressorService;
            InitializeComponent();
        }


        private void bt_SpakujPlik_Click(object sender, EventArgs e)
        {
            string currentPath = Environment.CurrentDirectory;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = currentPath;
                //ofd.Filter = "Pliki tekstowe|*.txt";
                var result = ofd.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var fileText = File.ReadAllText(ofd.FileName, Encoding.GetEncoding("Windows-1250"));
                    PerformTextCompression(ofd.FileName, fileText);
                }
            }
        }

        private void pnl_DragDrop_DragEnter(object sender, DragEventArgs e)
        {
            // zmiana stylu kursora
            e.Effect = DragDropEffects.All;
        }

        private void pnl_DragDrop_DragDrop(object sender, DragEventArgs e)
        {
            // odczytanie przeciągniętych plików
            var pliki = e.Data?.GetData(DataFormats.FileDrop, false);
            if (pliki != null)
            {
                string[] sciezkiDoPlikow = (string[])pliki;
                // sprawdzenie czy nie przeciągnięto wielu plików
                if (sciezkiDoPlikow.Length > 1)
                {
                    MessageBox.Show("Przeciągnij tylko jeden plik!");
                }
                else
                {
                    var fileText = File.ReadAllText(sciezkiDoPlikow[0], Encoding.GetEncoding("Windows-1250"));
                    PerformTextCompression(sciezkiDoPlikow[0], fileText);
                }
            }
        }


        private void PerformTextCompression(string fileName, string fileText)
        {
            TextStatisticsData textStatisticsData = _textStatisticsService.CountStatistics(fileText);

            // Wyznaczenie kodów poszczególnych symboli
            Stopwatch sw_Codes = new Stopwatch();
            sw_Codes.Start();
            //IHuffmanStaticSymbolsCodesService huffmanStaticService = new HuffmanStaticSymbolsCodesService();
            List<HuffmanNode> compressionCodes = _huffmanStaticSymbolsCodesService.GenerateCodesDictionary(textStatisticsData);
            sw_Codes.Stop();

            // Przeprowadzenie kodowania pliku
            Stopwatch sw_Compression = new Stopwatch();
            sw_Compression.Start();
            //IHuffmanStaticCompressorService huffmanStaticCompressorService = new HuffmanStaticCompressorService(huffmanStaticService);
            //byte[] fileContentBytes = huffmanStaticCompressorService.CompressFile(textStatisticsData, fileText);
            byte[] fileContentBytes = _huffmanStaticCompressorService.CompressFile(textStatisticsData, fileText);
            sw_Compression.Stop();

            // Prezentacja struktury słownika kodów na ekranie
            tb_Kompresowanie_CzasWyznaczeniaKodow.Text = sw_Codes.Elapsed.ToString();
            tb_Kompresowanie_CzasKompresji.Text = sw_Compression.Elapsed.ToString();
            dgv_Kompresowanie_Kody.Rows.Clear();
            for (int i = 0; i < compressionCodes.Count; i++)
            {
                int index = dgv_Kompresowanie_Kody.Rows.Add();
                dgv_Kompresowanie_Kody.Rows[index].Cells[0].Value = compressionCodes[i].Symbol;
                dgv_Kompresowanie_Kody.Rows[index].Cells[1].Value = compressionCodes[i].Code;
            }

            // Zapis danych do pliku
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                sfd.Filter = "ZSK Compressed File file|*.zcf"; // możemy wymyśleć swój własny typ pliku
                sfd.FileName = filenameWithoutExtension + ".zcf";
                DialogResult result = sfd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Kiedy będziemy mieli już bajty skompresowanego pliku możemy je zapisać
                    //File.WriteAllBytes(sfd.FileName, fileContentBytes);
                    try
                    {
                        FileStream fs = File.Create(sfd.FileName, fileContentBytes.Length, FileOptions.None);
                        BinaryWriter bw = new BinaryWriter(fs);
                        bw.Write(fileContentBytes);
                        bw.Close();
                        fs.Close();
                        bw.Dispose();
                        fs.Dispose();
                    }
                    catch (IOException fe)
                    {
                        Console.WriteLine(fe.Message);
                        throw;
                    }
                }
            }

            // Prezentacja wykresu
            var originalnBytes = File.ReadAllBytes(fileName);
            Wykres wykres = new Wykres(originalnBytes.Length, fileContentBytes.Length);
            wykres.Show();
        }
    }
}
