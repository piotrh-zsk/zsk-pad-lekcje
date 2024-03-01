namespace Projekt_01_Etap_10_Rozwiazanie
{
    partial class DecompressForm
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
            label9 = new Label();
            label10 = new Label();
            tb_Dekompresowanie_CzasDekompresji = new TextBox();
            tb_Dekompresowanie_CzasWyznaczeniaKodow = new TextBox();
            dgv_Dekompresowanie_Kody = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            bt_RozpakujPlik = new Button();
            rtb_Dekompresowanie_Zawartosc = new RichTextBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgv_Dekompresowanie_Kody).BeginInit();
            SuspendLayout();
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(802, 473);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(142, 15);
            label9.TabIndex = 21;
            label9.Text = "Czas wyznaczania kodów:";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(802, 530);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(102, 15);
            label10.TabIndex = 22;
            label10.Text = "Czas dekompresji:";
            // 
            // tb_Dekompresowanie_CzasDekompresji
            // 
            tb_Dekompresowanie_CzasDekompresji.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Dekompresowanie_CzasDekompresji.Location = new Point(802, 548);
            tb_Dekompresowanie_CzasDekompresji.Margin = new Padding(4, 3, 4, 3);
            tb_Dekompresowanie_CzasDekompresji.Name = "tb_Dekompresowanie_CzasDekompresji";
            tb_Dekompresowanie_CzasDekompresji.Size = new Size(210, 23);
            tb_Dekompresowanie_CzasDekompresji.TabIndex = 24;
            // 
            // tb_Dekompresowanie_CzasWyznaczeniaKodow
            // 
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Location = new Point(802, 492);
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Margin = new Padding(4, 3, 4, 3);
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Name = "tb_Dekompresowanie_CzasWyznaczeniaKodow";
            tb_Dekompresowanie_CzasWyznaczeniaKodow.Size = new Size(210, 23);
            tb_Dekompresowanie_CzasWyznaczeniaKodow.TabIndex = 23;
            // 
            // dgv_Dekompresowanie_Kody
            // 
            dgv_Dekompresowanie_Kody.AllowUserToAddRows = false;
            dgv_Dekompresowanie_Kody.AllowUserToDeleteRows = false;
            dgv_Dekompresowanie_Kody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgv_Dekompresowanie_Kody.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Dekompresowanie_Kody.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgv_Dekompresowanie_Kody.Location = new Point(12, 12);
            dgv_Dekompresowanie_Kody.Name = "dgv_Dekompresowanie_Kody";
            dgv_Dekompresowanie_Kody.RowHeadersVisible = false;
            dgv_Dekompresowanie_Kody.RowTemplate.Height = 25;
            dgv_Dekompresowanie_Kody.Size = new Size(412, 455);
            dgv_Dekompresowanie_Kody.TabIndex = 20;
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
            bt_RozpakujPlik.Location = new Point(12, 473);
            bt_RozpakujPlik.Name = "bt_RozpakujPlik";
            bt_RozpakujPlik.Size = new Size(783, 98);
            bt_RozpakujPlik.TabIndex = 19;
            bt_RozpakujPlik.Text = "Rozpakuj plik";
            bt_RozpakujPlik.UseVisualStyleBackColor = true;
            bt_RozpakujPlik.Click += bt_RozpakujPlik_Click;
            // 
            // rtb_Dekompresowanie_Zawartosc
            // 
            rtb_Dekompresowanie_Zawartosc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtb_Dekompresowanie_Zawartosc.Location = new Point(430, 12);
            rtb_Dekompresowanie_Zawartosc.Name = "rtb_Dekompresowanie_Zawartosc";
            rtb_Dekompresowanie_Zawartosc.Size = new Size(365, 455);
            rtb_Dekompresowanie_Zawartosc.TabIndex = 18;
            rtb_Dekompresowanie_Zawartosc.Text = "";
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.BackColor = Color.Silver;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(802, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(210, 455);
            panel1.TabIndex = 25;
            panel1.DragDrop += panel1_DragDrop;
            panel1.DragEnter += panel1_DragEnter;
            // 
            // DecompressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1025, 583);
            Controls.Add(panel1);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(tb_Dekompresowanie_CzasDekompresji);
            Controls.Add(tb_Dekompresowanie_CzasWyznaczeniaKodow);
            Controls.Add(dgv_Dekompresowanie_Kody);
            Controls.Add(bt_RozpakujPlik);
            Controls.Add(rtb_Dekompresowanie_Zawartosc);
            Name = "DecompressForm";
            Text = "DecompressForm";
            ((System.ComponentModel.ISupportInitialize)dgv_Dekompresowanie_Kody).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label9;
        private Label label10;
        private TextBox tb_Dekompresowanie_CzasDekompresji;
        private TextBox tb_Dekompresowanie_CzasWyznaczeniaKodow;
        private DataGridView dgv_Dekompresowanie_Kody;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Button bt_RozpakujPlik;
        private RichTextBox rtb_Dekompresowanie_Zawartosc;
        private Panel panel1;
    }
}