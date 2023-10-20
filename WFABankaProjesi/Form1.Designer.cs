namespace WFABankaProjesi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbMusteriler = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            btnEkleVeSirayaGir = new Button();
            label3 = new Label();
            dvgBekleyenler = new DataGridView();
            lblIslem = new Label();
            btnSiradaki = new Button();
            label5 = new Label();
            txtMusteriTCKimlikNo = new TextBox();
            label4 = new Label();
            label6 = new Label();
            lblTumIstatislik = new Label();
            cmbİstatistikTürü = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dvgBekleyenler).BeginInit();
            SuspendLayout();
            // 
            // cmbMusteriler
            // 
            cmbMusteriler.FormattingEnabled = true;
            cmbMusteriler.Location = new Point(204, 108);
            cmbMusteriler.Name = "cmbMusteriler";
            cmbMusteriler.Size = new Size(215, 33);
            cmbMusteriler.TabIndex = 0;
            cmbMusteriler.SelectedIndexChanged += cmbMusteriler_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 116);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 1;
            label1.Text = "Müşteri Tür:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 204);
            label2.Name = "label2";
            label2.Size = new Size(154, 25);
            label2.TabIndex = 2;
            label2.Text = "TC Kimli Numarası";
            // 
            // btnEkleVeSirayaGir
            // 
            btnEkleVeSirayaGir.Enabled = false;
            btnEkleVeSirayaGir.Location = new Point(44, 329);
            btnEkleVeSirayaGir.Name = "btnEkleVeSirayaGir";
            btnEkleVeSirayaGir.Size = new Size(375, 58);
            btnEkleVeSirayaGir.TabIndex = 3;
            btnEkleVeSirayaGir.Text = "Ekle ve Sıraya Gir";
            btnEkleVeSirayaGir.UseVisualStyleBackColor = true;
            btnEkleVeSirayaGir.Click += btnEkleVeSirayaGir_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(629, 62);
            label3.Name = "label3";
            label3.Size = new Size(219, 30);
            label3.TabIndex = 4;
            label3.Text = "Bekleyen Müşteriler";
            // 
            // dvgBekleyenler
            // 
            dvgBekleyenler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgBekleyenler.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dvgBekleyenler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgBekleyenler.Location = new Point(458, 108);
            dvgBekleyenler.Name = "dvgBekleyenler";
            dvgBekleyenler.RowHeadersWidth = 62;
            dvgBekleyenler.RowTemplate.Height = 33;
            dvgBekleyenler.Size = new Size(563, 362);
            dvgBekleyenler.TabIndex = 5;
            // 
            // lblIslem
            // 
            lblIslem.BackColor = SystemColors.ControlLight;
            lblIslem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblIslem.Location = new Point(458, 546);
            lblIslem.Name = "lblIslem";
            lblIslem.Size = new Size(563, 51);
            lblIslem.TabIndex = 7;
            lblIslem.Text = "SIRADAKİ";
            lblIslem.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSiradaki
            // 
            btnSiradaki.Enabled = false;
            btnSiradaki.Location = new Point(44, 407);
            btnSiradaki.Name = "btnSiradaki";
            btnSiradaki.Size = new Size(375, 63);
            btnSiradaki.TabIndex = 8;
            btnSiradaki.Text = "Sıradaki";
            btnSiradaki.UseVisualStyleBackColor = true;
            btnSiradaki.Click += btnSiradaki_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(73, 567);
            label5.Name = "label5";
            label5.Size = new Size(287, 30);
            label5.TabIndex = 9;
            label5.Text = "Sıradaki İşlemdeki Müşteri";
            // 
            // txtMusteriTCKimlikNo
            // 
            txtMusteriTCKimlikNo.Location = new Point(204, 204);
            txtMusteriTCKimlikNo.Name = "txtMusteriTCKimlikNo";
            txtMusteriTCKimlikNo.Size = new Size(215, 31);
            txtMusteriTCKimlikNo.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(366, 629);
            label4.Name = "label4";
            label4.Size = new Size(222, 30);
            label4.TabIndex = 11;
            label4.Text = "Müşteri İstatistikleri\r\n";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(73, 676);
            label6.Name = "label6";
            label6.Size = new Size(0, 25);
            label6.TabIndex = 12;
            // 
            // lblTumIstatislik
            // 
            lblTumIstatislik.BackColor = SystemColors.ControlLight;
            lblTumIstatislik.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTumIstatislik.Location = new Point(468, 676);
            lblTumIstatislik.Name = "lblTumIstatislik";
            lblTumIstatislik.Size = new Size(553, 208);
            lblTumIstatislik.TabIndex = 13;
            lblTumIstatislik.Text = "SIRADAKİ";
            lblTumIstatislik.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbİstatistikTürü
            // 
            cmbİstatistikTürü.FormattingEnabled = true;
            cmbİstatistikTürü.Location = new Point(44, 765);
            cmbİstatistikTürü.Name = "cmbİstatistikTürü";
            cmbİstatistikTürü.Size = new Size(375, 33);
            cmbİstatistikTürü.TabIndex = 14;
            cmbİstatistikTürü.SelectedIndexChanged += cmbİstatistikTürü_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1140, 941);
            Controls.Add(cmbİstatistikTürü);
            Controls.Add(lblTumIstatislik);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(txtMusteriTCKimlikNo);
            Controls.Add(label5);
            Controls.Add(btnSiradaki);
            Controls.Add(lblIslem);
            Controls.Add(dvgBekleyenler);
            Controls.Add(label3);
            Controls.Add(btnEkleVeSirayaGir);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbMusteriler);
            Name = "Form1";
            Text = "Banka";
            ((System.ComponentModel.ISupportInitialize)dvgBekleyenler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMusteriler;
        private Label label1;
        private Label label2;
        private Button btnEkleVeSirayaGir;
        private Label label3;
        private DataGridView dvgBekleyenler;
        private Label lblIslem;
        private Button btnSiradaki;
        private Label label5;
        private TextBox txtMusteriTCKimlikNo;
        private Label label4;
        private Label label6;
        private Label lblTumIstatislik;
        private ComboBox cmbİstatistikTürü;
    }
}