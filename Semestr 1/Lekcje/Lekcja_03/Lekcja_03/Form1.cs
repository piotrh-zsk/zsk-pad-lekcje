using Lekcja_03.Adapters;

namespace Lekcja_03
{
    public partial class Form1 : Form
    {
        private Form1Adapter _form1Adapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _form1Adapter = new Form1Adapter(richTextBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _form1Adapter.PerformAction(richTextBox1.Text);
        }
    }
}