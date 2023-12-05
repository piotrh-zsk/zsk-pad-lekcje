namespace Projekt_01_Etap_07_Rozwiazanie
{
    partial class CompressForm
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
            label5 = new Label();
            label8 = new Label();
            tb_Kompresowanie_CzasKompresji = new TextBox();
            tb_Kompresowanie_CzasWyznaczeniaKodow = new TextBox();
            bt_SpakujPlik = new Button();
            dgv_Kompresowanie_Kody = new DataGridView();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Kompresowanie_Kody).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(309, 486);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(142, 15);
            label5.TabIndex = 16;
            label5.Text = "Czas wyznaczania kodów:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(309, 543);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(89, 15);
            label8.TabIndex = 17;
            label8.Text = "Czas kompresji:";
            // 
            // tb_Kompresowanie_CzasKompresji
            // 
            tb_Kompresowanie_CzasKompresji.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Kompresowanie_CzasKompresji.Location = new Point(309, 561);
            tb_Kompresowanie_CzasKompresji.Margin = new Padding(4, 3, 4, 3);
            tb_Kompresowanie_CzasKompresji.Name = "tb_Kompresowanie_CzasKompresji";
            tb_Kompresowanie_CzasKompresji.Size = new Size(210, 23);
            tb_Kompresowanie_CzasKompresji.TabIndex = 19;
            // 
            // tb_Kompresowanie_CzasWyznaczeniaKodow
            // 
            tb_Kompresowanie_CzasWyznaczeniaKodow.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tb_Kompresowanie_CzasWyznaczeniaKodow.Location = new Point(309, 505);
            tb_Kompresowanie_CzasWyznaczeniaKodow.Margin = new Padding(4, 3, 4, 3);
            tb_Kompresowanie_CzasWyznaczeniaKodow.Name = "tb_Kompresowanie_CzasWyznaczeniaKodow";
            tb_Kompresowanie_CzasWyznaczeniaKodow.Size = new Size(210, 23);
            tb_Kompresowanie_CzasWyznaczeniaKodow.TabIndex = 18;
            // 
            // bt_SpakujPlik
            // 
            bt_SpakujPlik.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bt_SpakujPlik.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            bt_SpakujPlik.Location = new Point(12, 486);
            bt_SpakujPlik.Name = "bt_SpakujPlik";
            bt_SpakujPlik.Size = new Size(290, 98);
            bt_SpakujPlik.TabIndex = 15;
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
            dgv_Kompresowanie_Kody.Location = new Point(12, 12);
            dgv_Kompresowanie_Kody.Name = "dgv_Kompresowanie_Kody";
            dgv_Kompresowanie_Kody.RowHeadersVisible = false;
            dgv_Kompresowanie_Kody.RowTemplate.Height = 25;
            dgv_Kompresowanie_Kody.Size = new Size(508, 468);
            dgv_Kompresowanie_Kody.TabIndex = 14;
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
            // CompressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 596);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(tb_Kompresowanie_CzasKompresji);
            Controls.Add(tb_Kompresowanie_CzasWyznaczeniaKodow);
            Controls.Add(bt_SpakujPlik);
            Controls.Add(dgv_Kompresowanie_Kody);
            Name = "CompressForm";
            Text = "CompressForm";
            Load += CompressForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgv_Kompresowanie_Kody).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label8;
        private TextBox tb_Kompresowanie_CzasKompresji;
        private TextBox tb_Kompresowanie_CzasWyznaczeniaKodow;
        private Button bt_SpakujPlik;
        private DataGridView dgv_Kompresowanie_Kody;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
    }
}