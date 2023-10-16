namespace Etap3.UI
{
    public partial class Form1 : Form
    {
        // deklaracja klasy poœrednicz¹cej


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // inicjalizacja klasy poœrednicz¹cej
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
                // wywo³anie odpowiedniej logiki poprzez klasê poœrednicz¹c¹
            }
        }
    }
}