using Projekt_01_Etap_06_Rozwiazanie.Presenters;

namespace Projekt_01_Etap_06_Rozwiazanie
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
    }
}
