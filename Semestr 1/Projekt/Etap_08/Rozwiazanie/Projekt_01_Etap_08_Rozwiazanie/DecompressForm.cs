using Projekt_01_Etap_08_Rozwiazanie.Presenters;

namespace Projekt_01_Etap_08_Rozwiazanie
{
    public partial class DecompressForm : Form
    {
        private DecompressFormPresenter? decompressFormPresenter;

        public DecompressForm()
        {
            InitializeComponent();
        }

        private void DecompressForm_Load(object sender, EventArgs e)
        {
            decompressFormPresenter = new DecompressFormPresenter(
                tb_Dekompresowanie_CzasWyznaczeniaKodow,
                tb_Dekompresowanie_CzasDekompresji,
                dgv_Dekompresowanie_Kody,
                rtb_Dekompresowanie_Zawartosc);
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
                decompressFormPresenter?.PerformTextDecompression(filename, fileContents);
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
                        decompressFormPresenter?.PerformTextDecompression(filename, fileContents);
                    }
                }
            }
        }
    }
}
