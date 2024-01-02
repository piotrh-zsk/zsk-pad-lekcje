namespace Projekt_01_Etap_07_Rozwiazanie
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
            rtb_Statystyka_TekstWejsciowy = new RichTextBox();
            bt_PrzeprowadzAnalize = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tb_Statystyka_LiczbaWszystkichZnakow = new TextBox();
            tb_Statystyka_LiczbaUnikatowychZnakow = new TextBox();
            tb_Statystyka_Entropia = new TextBox();
            tb_Statystyka_CzasWykonania = new TextBox();
            label6 = new Label();
            openFileDialog1 = new OpenFileDialog();
            label7 = new Label();
            dgv_Statystyka_StatystykaSymboli = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            bt_DekompresujPlik = new Button();
            bt_SkompresujPlik = new Button();
            tabPage2 = new TabPage();
            label5 = new Label();
            label8 = new Label();
            tb_Kompresowanie_CzasKompresji = new TextBox();
            tb_Kompresowanie_CzasWyznaczeniaKodow = new TextBox();
            bt_SpakujPlik = new Button();
            dgv_Kompresowanie_Kody = new DataGridView();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            label9 = new Label();
            label10 = new Label();
            tb_Dekompresowanie_CzasDekompresji = new TextBox();
            tb_Dekompresowanie_CzasWyznaczeniaKodow = new TextBox();
            dgv_Dekompresowanie_Kody = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            bt_RozpakujPlik = new Button();
            rtb_Dekompresowanie_Zawartosc = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgv_Statystyka_StatystykaSymboli).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Kompresowanie_Kody).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Dekompresowanie_Kody).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(4, 3);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 22);
            label1.TabIndex = 0;
            label1.Text = "Tekst wejściowy:";
            // 
            // rtb_Statystyka_TekstWejsciowy
            // 
            rtb_Statystyka_TekstWejsciowy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtb_Statystyka_TekstWejsciowy.Location = new Point(4, 32);
            rtb_Statystyka_TekstWejsciowy.Margin = new Padding(4, 3, 4, 3);
            rtb_Statystyka_TekstWejsciowy.Name = "rtb_Statystyka_TekstWejsciowy";
            rtb_Statystyka_TekstWejsciowy.Size = new Size(777, 85);
            rtb_Statystyka_TekstWejsciowy.TabIndex = 1;
            rtb_Statystyka_TekstWejsciowy.Text = "";
            // 
            // bt_PrzeprowadzAnalize
            // 
            bt_PrzeprowadzAnalize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_PrzeprowadzAnalize.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bt_PrzeprowadzAnalize.ForeColor = Color.Red;
            bt_PrzeprowadzAnalize.Location = new Point(789, 311);
            bt_PrzeprowadzAnalize.Margin = new Padding(4, 3, 4, 3);
            bt_PrzeprowadzAnalize.Name = "bt_PrzeprowadzAnalize";
            bt_PrzeprowadzAnalize.Size = new Size(211, 68);
            bt_PrzeprowadzAnalize.TabIndex = 2;
            bt_PrzeprowadzAnalize.Text = "Przeprowadź analizę";
            bt_PrzeprowadzAnalize.UseVisualStyleBackColor = true;
            bt_PrzeprowadzAnalize.Click += bt_PrzeprowadzAnalize_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(789, 32);
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
            label3.Location = new Point(789, 89);
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
            label4.Location = new Point(789, 145);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 5;
            label4.Text = "Entropia:";
            // 
            // tb_Statystyka_LiczbaWszystkichZnakow
            // 
            tb_Statystyka_LiczbaWszystkichZnakow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_Statystyka_LiczbaWszystkichZnakow.Location = new Point(789, 51);
            tb_Statystyka_LiczbaWszystkichZnakow.Margin = new Padding(4, 3, 4, 3);
            tb_Statystyka_LiczbaWszystkichZnakow.Name = "tb_Statystyka_LiczbaWszystkichZnakow";
            tb_Statystyka_LiczbaWszystkichZnakow.Size = new Size(210, 23);
            tb_Statystyka_LiczbaWszystkichZnakow.TabIndex = 8;
            // 
            // tb_Statystyka_LiczbaUnikatowychZnakow
            // 
            tb_Statystyka_LiczbaUnikatowychZnakow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_Statystyka_LiczbaUnikatowychZnakow.Location = new Point(789, 107);
            tb_Statystyka_LiczbaUnikatowychZnakow.Margin = new Padding(4, 3, 4, 3);
            tb_Statystyka_LiczbaUnikatowychZnakow.Name = "tb_Statystyka_LiczbaUnikatowychZnakow";
            tb_Statystyka_LiczbaUnikatowychZnakow.Size = new Size(210, 23);
            tb_Statystyka_LiczbaUnikatowychZnakow.TabIndex = 9;
            // 
            // tb_Statystyka_Entropia
            // 
            tb_Statystyka_Entropia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tb_Statystyka_Entropia.Location = new Point(789, 164);
            tb_Statystyka_Entropia.Margin = new Padding(4, 3, 4, 3);
            tb_Statystyka_Entropia.Name = "tb_Statystyka_Entropia";
            tb_Statystyka_Entropia.Size = new Size(210, 23);
            tb_Statystyka_Entropia.TabIndex = 10;
            // 
            // tb_Statystyka_CzasWykonania
            // 
            tb_Statystyka_CzasWykonania.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Statystyka_CzasWykonania.Location = new Point(789, 245);
            tb_Statystyka_CzasWykonania.Margin = new Padding(4, 3, 4, 3);
            tb_Statystyka_CzasWykonania.Name = "tb_Statystyka_CzasWykonania";
            tb_Statystyka_CzasWykonania.Size = new Size(210, 23);
            tb_Statystyka_CzasWykonania.TabIndex = 13;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(789, 227);
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
            label7.Location = new Point(4, 120);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(131, 22);
            label7.TabIndex = 15;
            label7.Text = "Statystyka:";
            // 
            // dgv_Statystyka_StatystykaSymboli
            // 
            dgv_Statystyka_StatystykaSymboli.AllowUserToAddRows = false;
            dgv_Statystyka_StatystykaSymboli.AllowUserToDeleteRows = false;
            dgv_Statystyka_StatystykaSymboli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Statystyka_StatystykaSymboli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Statystyka_StatystykaSymboli.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6 });
            dgv_Statystyka_StatystykaSymboli.Location = new Point(4, 145);
            dgv_Statystyka_StatystykaSymboli.Name = "dgv_Statystyka_StatystykaSymboli";
            dgv_Statystyka_StatystykaSymboli.RowHeadersVisible = false;
            dgv_Statystyka_StatystykaSymboli.RowTemplate.Height = 25;
            dgv_Statystyka_StatystykaSymboli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Statystyka_StatystykaSymboli.Size = new Size(778, 348);
            dgv_Statystyka_StatystykaSymboli.TabIndex = 16;
            // 
            // Column1
            // 
            Column1.HeaderText = "Zapis binarny";
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Zapis dziesiętny";
            Column2.Name = "Column2";
            Column2.Width = 120;
            // 
            // Column3
            // 
            Column3.HeaderText = "Symbol";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Częstość";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Prawdopodobieństwo";
            Column5.Name = "Column5";
            Column5.Width = 130;
            // 
            // Column6
            // 
            Column6.HeaderText = "Ilość informacji";
            Column6.Name = "Column6";
            Column6.Width = 150;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1017, 529);
            tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(bt_DekompresujPlik);
            tabPage1.Controls.Add(bt_SkompresujPlik);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(dgv_Statystyka_StatystykaSymboli);
            tabPage1.Controls.Add(rtb_Statystyka_TekstWejsciowy);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(bt_PrzeprowadzAnalize);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(tb_Statystyka_CzasWykonania);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(tb_Statystyka_Entropia);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(tb_Statystyka_LiczbaUnikatowychZnakow);
            tabPage1.Controls.Add(tb_Statystyka_LiczbaWszystkichZnakow);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1009, 501);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Statystyka";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // bt_DekompresujPlik
            // 
            bt_DekompresujPlik.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_DekompresujPlik.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bt_DekompresujPlik.ForeColor = Color.Red;
            bt_DekompresujPlik.Location = new Point(788, 449);
            bt_DekompresujPlik.Margin = new Padding(4, 3, 4, 3);
            bt_DekompresujPlik.Name = "bt_DekompresujPlik";
            bt_DekompresujPlik.Size = new Size(211, 44);
            bt_DekompresujPlik.TabIndex = 18;
            bt_DekompresujPlik.Text = "Dekompresuj plik";
            bt_DekompresujPlik.UseVisualStyleBackColor = true;
            bt_DekompresujPlik.Click += bt_DekompresujPlik_Click;
            // 
            // bt_SkompresujPlik
            // 
            bt_SkompresujPlik.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bt_SkompresujPlik.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bt_SkompresujPlik.ForeColor = Color.Red;
            bt_SkompresujPlik.Location = new Point(788, 399);
            bt_SkompresujPlik.Margin = new Padding(4, 3, 4, 3);
            bt_SkompresujPlik.Name = "bt_SkompresujPlik";
            bt_SkompresujPlik.Size = new Size(211, 44);
            bt_SkompresujPlik.TabIndex = 17;
            bt_SkompresujPlik.Text = "Skompresuj plik";
            bt_SkompresujPlik.UseVisualStyleBackColor = true;
            bt_SkompresujPlik.Click += bt_SkompresujPlik_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(tb_Kompresowanie_CzasKompresji);
            tabPage2.Controls.Add(tb_Kompresowanie_CzasWyznaczeniaKodow);
            tabPage2.Controls.Add(bt_SpakujPlik);
            tabPage2.Controls.Add(dgv_Kompresowanie_Kody);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1009, 449);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Kompresowanie";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(795, 348);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(142, 15);
            label5.TabIndex = 10;
            label5.Text = "Czas wyznaczania kodów:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(795, 405);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 11;
            label8.Text = "Czas kompresji:";
            // 
            // tb_Kompresowanie_CzasKompresji
            // 
            tb_Kompresowanie_CzasKompresji.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Kompresowanie_CzasKompresji.Location = new Point(795, 423);
            tb_Kompresowanie_CzasKompresji.Margin = new Padding(4, 3, 4, 3);
            tb_Kompresowanie_CzasKompresji.Name = "tb_Kompresowanie_CzasKompresji";
            tb_Kompresowanie_CzasKompresji.Size = new Size(210, 23);
            tb_Kompresowanie_CzasKompresji.TabIndex = 13;
            // 
            // tb_Kompresowanie_CzasWyznaczeniaKodow
            // 
            tb_Kompresowanie_CzasWyznaczeniaKodow.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Kompresowanie_CzasWyznaczeniaKodow.Location = new Point(795, 367);
            tb_Kompresowanie_CzasWyznaczeniaKodow.Margin = new Padding(4, 3, 4, 3);
            tb_Kompresowanie_CzasWyznaczeniaKodow.Name = "tb_Kompresowanie_CzasWyznaczeniaKodow";
            tb_Kompresowanie_CzasWyznaczeniaKodow.Size = new Size(210, 23);
            tb_Kompresowanie_CzasWyznaczeniaKodow.TabIndex = 12;
            // 
            // bt_SpakujPlik
            // 
            bt_SpakujPlik.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bt_SpakujPlik.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            bt_SpakujPlik.Location = new Point(3, 348);
            bt_SpakujPlik.Name = "bt_SpakujPlik";
            bt_SpakujPlik.Size = new Size(785, 98);
            bt_SpakujPlik.TabIndex = 1;
            bt_SpakujPlik.Text = "Spakuj plik";
            bt_SpakujPlik.UseVisualStyleBackColor = true;
            bt_SpakujPlik.Click += bt_SpakujPlik_Click;
            // 
            // dgv_Kompresowanie_Kody
            // 
            dgv_Kompresowanie_Kody.AllowUserToAddRows = false;
            dgv_Kompresowanie_Kody.AllowUserToDeleteRows = false;
            dgv_Kompresowanie_Kody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_Kompresowanie_Kody.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Kompresowanie_Kody.Columns.AddRange(new DataGridViewColumn[] { Column7, Column8 });
            dgv_Kompresowanie_Kody.Location = new Point(3, 3);
            dgv_Kompresowanie_Kody.Name = "dgv_Kompresowanie_Kody";
            dgv_Kompresowanie_Kody.RowHeadersVisible = false;
            dgv_Kompresowanie_Kody.RowTemplate.Height = 25;
            dgv_Kompresowanie_Kody.Size = new Size(1002, 339);
            dgv_Kompresowanie_Kody.TabIndex = 0;
            // 
            // Column7
            // 
            Column7.HeaderText = "Znak";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "Ciąg kodowy";
            Column8.Name = "Column8";
            Column8.Width = 300;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label9);
            tabPage3.Controls.Add(label10);
            tabPage3.Controls.Add(tb_Dekompresowanie_CzasDekompresji);
            tabPage3.Controls.Add(tb_Dekompresowanie_CzasWyznaczeniaKodow);
            tabPage3.Controls.Add(dgv_Dekompresowanie_Kody);
            tabPage3.Controls.Add(bt_RozpakujPlik);
            tabPage3.Controls.Add(rtb_Dekompresowanie_Zawartosc);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1009, 449);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Dekompresowanie";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(795, 348);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(142, 15);
            label9.TabIndex = 14;
            label9.Text = "Czas wyznaczania kodów:";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(795, 405);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 15;
            label10.Text = "Czas dekompresji:";
            // 
            // tb_Dekompresowanie_CzasDekompresji
            // 
            tb_Dekompresowanie_CzasDekompresji.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Dekompresowanie_CzasDekompresji.Location = new Point(795, 423);
            tb_Dekompresowanie_CzasDekompresji.Margin = new Padding(4, 3, 4, 3);
            tb_Dekompresowanie_CzasDekompresji.Name = "tb_Dekompresowanie_CzasDekompresji";
            tb_Dekompresowanie_CzasDekompresji.Size = new Size(210, 23);
            tb_Dekompresowanie_CzasDekompresji.TabIndex = 17;
            // 
            // tb_Dekompresowanie_CzasWyznaczeniaKodow
            // 
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Location = new Point(795, 367);
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Margin = new Padding(4, 3, 4, 3);
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Name = "tb_Dekompresowanie_CzasWyznaczeniaKodow";
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Size = new Size(210, 23);
            tb_Dekompresowanie_CzasWyznaczeniaKodow.TabIndex = 16;
            // 
            // dgv_Dekompresowanie_Kody
            // 
            dgv_Dekompresowanie_Kody.AllowUserToAddRows = false;
            dgv_Dekompresowanie_Kody.AllowUserToDeleteRows = false;
            dgv_Dekompresowanie_Kody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgv_Dekompresowanie_Kody.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Dekompresowanie_Kody.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgv_Dekompresowanie_Kody.Location = new Point(3, 3);
            dgv_Dekompresowanie_Kody.Name = "dgv_Dekompresowanie_Kody";
            dgv_Dekompresowanie_Kody.RowHeadersVisible = false;
            dgv_Dekompresowanie_Kody.RowTemplate.Height = 25;
            dgv_Dekompresowanie_Kody.Size = new Size(412, 339);
            dgv_Dekompresowanie_Kody.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Znak";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Ciąg kodowy";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 300;
            // 
            // bt_RozpakujPlik
            // 
            bt_RozpakujPlik.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bt_RozpakujPlik.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            bt_RozpakujPlik.Location = new Point(8, 348);
            bt_RozpakujPlik.Name = "bt_RozpakujPlik";
            bt_RozpakujPlik.Size = new Size(780, 98);
            bt_RozpakujPlik.TabIndex = 1;
            bt_RozpakujPlik.Text = "Rozpakuj plik";
            bt_RozpakujPlik.UseVisualStyleBackColor = true;
            bt_RozpakujPlik.Click += bt_RozpakujPlik_Click;
            // 
            // rtb_Dekompresowanie_Zawartosc
            // 
            rtb_Dekompresowanie_Zawartosc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_Dekompresowanie_Zawartosc.Location = new Point(421, 3);
            rtb_Dekompresowanie_Zawartosc.Name = "rtb_Dekompresowanie_Zawartosc";
            rtb_Dekompresowanie_Zawartosc.Size = new Size(585, 339);
            rtb_Dekompresowanie_Zawartosc.TabIndex = 0;
            rtb_Dekompresowanie_Zawartosc.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 529);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Aperture Science heavy utility super-compression SuperProgram";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Statystyka_StatystykaSymboli).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Kompresowanie_Kody).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Dekompresowanie_Kody).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private RichTextBox rtb_Statystyka_TekstWejsciowy;
        private Button bt_PrzeprowadzAnalize;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tb_Statystyka_LiczbaWszystkichZnakow;
        private TextBox tb_Statystyka_LiczbaUnikatowychZnakow;
        private TextBox tb_Statystyka_Entropia;
        private TextBox tb_Statystyka_CzasWykonania;
        private Label label6;
        private OpenFileDialog openFileDialog1;
        private Label label7;
        private DataGridView dgv_Statystyka_StatystykaSymboli;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button bt_SpakujPlik;
        private DataGridView dgv_Kompresowanie_Kody;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private TabPage tabPage3;
        private Button bt_RozpakujPlik;
        private RichTextBox rtb_Dekompresowanie_Zawartosc;
        private DataGridView dgv_Dekompresowanie_Kody;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Label label5;
        private Label label8;
        private TextBox tb_Kompresowanie_CzasKompresji;
        private TextBox tb_Kompresowanie_CzasWyznaczeniaKodow;
        private Label label9;
        private Label label10;
        private TextBox tb_Dekompresowanie_CzasDekompresji;
        private TextBox tb_Dekompresowanie_CzasWyznaczeniaKodow;
        private Button bt_DekompresujPlik;
        private Button bt_SkompresujPlik;
    }
}
