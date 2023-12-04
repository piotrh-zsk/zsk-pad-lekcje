using Projekt_01_Etap_08_Rozwiazanie.Presenters;
using System.DirectoryServices.ActiveDirectory;

namespace Projekt_01_Etap_08_Rozwiazanie
{
    public partial class CompressForm : Form
    {
        private CompressFormPresenter? compressFormPresenter;

        public CompressForm()
        {
            InitializeComponent();
        }

        private void CompressForm_Load(object sender, EventArgs e)
        {
            compressFormPresenter = new CompressFormPresenter(
               tb_Kompresowanie_CzasWyznaczeniaKodow,
               tb_Kompresowanie_CzasKompresji,
               dgv_Kompresowanie_Kody);
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
                    var fileText = File.ReadAllText(ofd.FileName);
                    compressFormPresenter?.PerformTextCompression(ofd.SafeFileName, fileText);
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
                    var fileText = File.ReadAllText(sciezkiDoPlikow[0]);
                    compressFormPresenter?.PerformTextCompression(sciezkiDoPlikow[0], fileText);
                }
            }
        }
    }
}
