namespace Etap3.UI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label6 = new Label();
            openFileDialog1 = new OpenFileDialog();
            label7 = new Label();
            richTextBox2 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 22);
            label1.TabIndex = 0;
            label1.Text = "Tekst wejściowy:";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(14, 39);
            richTextBox1.Margin = new Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(948, 85);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(970, 466);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(211, 68);
            button1.TabIndex = 2;
            button1.Text = "Przeprowadź analizę";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(970, 39);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(145, 15);
            label2.TabIndex = 3;
            label2.Text = "Liczba wszystkich znaków:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(970, 96);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(157, 15);
            label3.TabIndex = 4;
            label3.Text = "Liczba unikatowych znaków:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(970, 152);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 5;
            label4.Text = "Entropia:";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.Location = new Point(970, 58);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(210, 23);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.Location = new Point(970, 114);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(210, 23);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox3.Location = new Point(970, 171);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(210, 23);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox4.Location = new Point(970, 436);
            textBox4.Margin = new Padding(4, 3, 4, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(210, 23);
            textBox4.TabIndex = 13;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(970, 418);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(94, 15);
            label6.TabIndex = 14;
            label6.Text = "Czas wykonania:";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(14, 127);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(131, 22);
            label7.TabIndex = 15;
            label7.Text = "Statystyka:";
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox2.Location = new Point(14, 152);
            richTextBox2.Margin = new Padding(4, 3, 4, 3);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(948, 382);
            richTextBox2.TabIndex = 16;
            richTextBox2.Text = "";
            richTextBox2.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 548);
            Controls.Add(richTextBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private OpenFileDialog openFileDialog1;
        private Label label7;
        private RichTextBox richTextBox2;
    }
}