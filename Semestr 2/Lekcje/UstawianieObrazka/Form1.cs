namespace UstawianieObrazka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ustawienie dla obrazków Properties -> Copy to output Directory

            string local = AppDomain.CurrentDomain.BaseDirectory;
            local += @"Content\\paczka.png";
            Image bmp = Bitmap.FromFile(local);
            pictureBox1.Image = bmp;
        }
    }
}
