namespace Etap3.UI
{
    public partial class Form1 : Form
    {
        // deklaracja klasy po�rednicz�cej


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // inicjalizacja klasy po�rednicz�cej
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentPath = Environment.CurrentDirectory;
            openFileDialog1.InitialDirectory = currentPath;
            openFileDialog1.Filter = "Pliki tekstowe|*.txt";
            var result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileText = File.ReadAllText(openFileDialog1.FileName);
                richTextBox1.Text = fileText;
                // wywo�anie odpowiedniej logiki poprzez klas� po�rednicz�c�
            }
        }
    }
}