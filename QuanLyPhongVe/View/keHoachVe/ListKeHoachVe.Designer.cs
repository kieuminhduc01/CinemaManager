namespace QuanLyPhongVe.View.KeHoachVe
{
    partial class listVe
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
            this.dgvListKeHoachVe = new System.Windows.Forms.DataGridView();
            this.mcNgayChieu = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKhungGio = new System.Windows.Forms.ComboBox();
            this.cbKhanDai = new System.Windows.Forms.ComboBox();
            this.tatCaNgay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListKeHoachVe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListKeHoachVe
            // 
            this.dgvListKeHoachVe.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvListKeHoachVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListKeHoachVe.Location = new System.Drawing.Point(12, 12);
            this.dgvListKeHoachVe.Name = "dgvListKeHoachVe";
            this.dgvListKeHoachVe.RowHeadersWidth = 51;
            this.dgvListKeHoachVe.RowTemplate.Height = 24;
            this.dgvListKeHoachVe.Size = new System.Drawing.Size(802, 568);
            this.dgvListKeHoachVe.TabIndex = 0;
            this.dgvListKeHoachVe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // mcNgayChieu
            // 
            this.mcNgayChieu.Location = new System.Drawing.Point(867, 12);
            this.mcNgayChieu.Name = "mcNgayChieu";
            this.mcNgayChieu.TabIndex = 0;
            this.mcNgayChieu.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(71)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(863, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Suất chiếu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(71)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(860, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khán đài";
            // 
            // cbKhungGio
            // 
            this.cbKhungGio.FormattingEnabled = true;
            this.cbKhungGio.Items.AddRange(new object[] {
            "ALL",
            "8-10",
            "10-12",
            "12-14",
            "14-16",
            "16-18",
            "18-20",
            "20-22",
            "22-24"});
            this.cbKhungGio.Location = new System.Drawing.Point(867, 334);
            this.cbKhungGio.Name = "cbKhungGio";
            this.cbKhungGio.Size = new System.Drawing.Size(262, 24);
            this.cbKhungGio.TabIndex = 2;
            this.cbKhungGio.SelectedIndexChanged += new System.EventHandler(this.cbKhungGio_SelectedIndexChanged);
            // 
            // cbKhanDai
            // 
            this.cbKhanDai.FormattingEnabled = true;
            this.cbKhanDai.Items.AddRange(new object[] {
            "ALL",
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.cbKhanDai.Location = new System.Drawing.Point(867, 418);
            this.cbKhanDai.Name = "cbKhanDai";
            this.cbKhanDai.Size = new System.Drawing.Size(262, 24);
            this.cbKhanDai.TabIndex = 3;
            this.cbKhanDai.SelectedIndexChanged += new System.EventHandler(this.cbKhanDai_SelectedIndexChanged);
            // 
            // tatCaNgay
            // 
            this.tatCaNgay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(205)))), ((int)(((byte)(182)))));
            this.tatCaNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.tatCaNgay.Location = new System.Drawing.Point(867, 232);
            this.tatCaNgay.Name = "tatCaNgay";
            this.tatCaNgay.Size = new System.Drawing.Size(143, 32);
            this.tatCaNgay.TabIndex = 1;
            this.tatCaNgay.Text = "Tất cả ngày";
            this.tatCaNgay.UseVisualStyleBackColor = false;
            this.tatCaNgay.Click += new System.EventHandler(this.button1_Click);
            // 
            // listVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 592);
            this.Controls.Add(this.tatCaNgay);
            this.Controls.Add(this.cbKhungGio);
            this.Controls.Add(this.cbKhanDai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mcNgayChieu);
            this.Controls.Add(this.dgvListKeHoachVe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "listVe";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.listVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListKeHoachVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListKeHoachVe;
        private System.Windows.Forms.MonthCalendar mcNgayChieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbKhungGio;
        private System.Windows.Forms.ComboBox cbKhanDai;
        private System.Windows.Forms.Button tatCaNgay;
    }
}