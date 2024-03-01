using Projekt_01_Etap_10_Rozwiazanie.Shared.Enities;
using Projekt_01_Etap_10_Rozwiazanie.Shared.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Projekt_01_Etap_10_Rozwiazanie
{
    public partial class DecompressForm : Form
    {
        private readonly IHuffmanStaticDecompressorService _huffmanStaticDecompressorService;


        public DecompressForm(IHuffmanStaticDecompressorService huffmanStaticDecompressorService)
        {
            _huffmanStaticDecompressorService = huffmanStaticDecompressorService;
            InitializeComponent();
        }


        private void bt_RozpakujPlik_Click(object sender, EventArgs e)
        {
            string filename = "";
            byte[]? fileContents = null;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "ZSK Compressed File file|*.zcf";
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filename = ofd.SafeFileName;
                    fileContents = File.ReadAllBytes(ofd.FileName);
                }
            }
            if (fileContents != null)
            {
                PerformTextDecompression(filename, fileContents);
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            // zmiana stylu kursora
            e.Effect = DragDropEffects.All;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            // pdczytanie przeciągniętych plików
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
                    string filename = Path.GetFileName(sciezkiDoPlikow[0]);
                    byte[]? fileContents = File.ReadAllBytes(sciezkiDoPlikow[0]);
                    if (fileContents != null)
                    {
                        PerformTextDecompression(filename, fileContents);
                    }
                }
            }
        }


        private void PerformTextDecompression(string fileName, byte[] fileContents)
        {
            if (fileContents != null)
            {
                // Utworzenie usługi dekompresującej
                //IHuffmanStaticSymbolsCodesService huffmanStaticSymbolsCodesService = new HuffmanStaticSymbolsCodesService();
                //IHuffmanStaticDecompressorService huffmanStaticDecompressorService = new HuffmanStaticDecompressorService(huffmanStaticSymbolsCodesService);

                // Przeprowadzenie dekompresji pliku
                Stopwatch sw_Decompression = new Stopwatch();
                sw_Decompression.Start();
                string fileText = _huffmanStaticDecompressorService.DecompressFile(fileContents, out List<HuffmanNode> dictionary, out TimeSpan codeTimes);
                sw_Decompression.Stop();

                // Jeżeli usługa zwróciła poza plikiem również strukture słownika kodów to pokazanie go na ekranie
                tb_Dekompresowanie_CzasWyznaczeniaKodow.Text = codeTimes.ToString();
                tb_Dekompresowanie_CzasDekompresji.Text = sw_Decompression.Elapsed.ToString();
                rtb_Dekompresowanie_Zawartosc.Text = fileText;
                dgv_Dekompresowanie_Kody.Rows.Clear();
                for (int i = 0; i < dictionary.Count; i++)
                {
                    int index = dgv_Dekompresowanie_Kody.Rows.Add();
                    dgv_Dekompresowanie_Kody.Rows[index].Cells[0].Value = dictionary[i].Symbol;
                    dgv_Dekompresowanie_Kody.Rows[index].Cells[1].Value = dictionary[i].Code;
                }

                // Zapis danych do pliku
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.FileName = Path.GetFileNameWithoutExtension(fileName) + "_rozpakowany";
                    DialogResult result = sfd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        // Po poprawnym rozpakowaniu można zapisać plik na dysku
                        //File.WriteAllText(sfd.FileName, fileText);
                        try
                        {
                            FileStream fs = (FileStream)sfd.OpenFile();
                            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("Windows-1250"));
                            for (int i = 0; i < fileText.Length; i++)
                                sw.Write(fileText[i]);
                            sw.Close();
                            sw.Dispose();
                            fs.Dispose();
                        }
                        catch (IOException fe)
                        {
                            Console.WriteLine(fe.Message);
                            throw;
                        }
                    }
                }
            }
        }
    }
}
