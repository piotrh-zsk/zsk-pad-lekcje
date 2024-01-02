using Projekt_01_Etap_07_Rozwiazanie.Presenters;

namespace Projekt_01_Etap_07_Rozwiazanie
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
    }
}
