namespace UngDungDesktop
{
    partial class ManHinhTimKiem
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
            this.HoTen = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SoTien = new System.Windows.Forms.TextBox();
            this.Ngay = new System.Windows.Forms.TextBox();
            this.Thang = new System.Windows.Forms.TextBox();
            this.grdTimKiem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThuChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dawd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChungRieng = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.lblThang = new System.Windows.Forms.Label();
            this.lblThuChi = new System.Windows.Forms.Label();
            this.btnResetTimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdTimKiem)).BeginInit();
            this.panelTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // HoTen
            // 
            this.HoTen.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoTen.Location = new System.Drawing.Point(3, 3);
            this.HoTen.Name = "HoTen";
            this.HoTen.Size = new System.Drawing.Size(226, 43);
            this.HoTen.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(402, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 54);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Tag = "thongKe";
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SoTien
            // 
            this.SoTien.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoTien.Location = new System.Drawing.Point(237, 3);
            this.SoTien.Name = "SoTien";
            this.SoTien.Size = new System.Drawing.Size(155, 43);
            this.SoTien.TabIndex = 2;
            // 
            // Ngay
            // 
            this.Ngay.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ngay.Location = new System.Drawing.Point(400, 3);
            this.Ngay.Name = "Ngay";
            this.Ngay.Size = new System.Drawing.Size(138, 43);
            this.Ngay.TabIndex = 3;
            // 
            // Thang
            // 
            this.Thang.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Thang.Location = new System.Drawing.Point(546, 3);
            this.Thang.Name = "Thang";
            this.Thang.Size = new System.Drawing.Size(138, 43);
            this.Thang.TabIndex = 4;
            // 
            // grdTimKiem
            // 
            this.grdTimKiem.AllowUserToAddRows = false;
            this.grdTimKiem.AllowUserToDeleteRows = false;
            this.grdTimKiem.AllowUserToResizeColumns = false;
            this.grdTimKiem.AllowUserToResizeRows = false;
            this.grdTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTimKiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTimKiem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grdTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTimKiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.NgayThuChi,
            this.dawd});
            this.grdTimKiem.Location = new System.Drawing.Point(82, 431);
            this.grdTimKiem.Name = "grdTimKiem";
            this.grdTimKiem.ReadOnly = true;
            this.grdTimKiem.Size = new System.Drawing.Size(928, 242);
            this.grdTimKiem.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "HoTen";
            this.Column1.HeaderText = "Họ Tên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "SoTien";
            this.Column2.HeaderText = "Số Tiền";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // NgayThuChi
            // 
            this.NgayThuChi.DataPropertyName = "NgayThuChi";
            this.NgayThuChi.HeaderText = "Ngày Thu Chi";
            this.NgayThuChi.Name = "NgayThuChi";
            this.NgayThuChi.ReadOnly = true;
            // 
            // dawd
            // 
            this.dawd.DataPropertyName = "GhiChu";
            this.dawd.HeaderText = "Ghi chú";
            this.dawd.Name = "dawd";
            this.dawd.ReadOnly = true;
            // 
            // ChungRieng
            // 
            this.ChungRieng.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChungRieng.Location = new System.Drawing.Point(692, 3);
            this.ChungRieng.Name = "ChungRieng";
            this.ChungRieng.Size = new System.Drawing.Size(102, 43);
            this.ChungRieng.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(140, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(383, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Số tiền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(537, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(683, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tháng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(829, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Loại thu chi";
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.Controls.Add(this.HoTen);
            this.panelTimKiem.Controls.Add(this.SoTien);
            this.panelTimKiem.Controls.Add(this.Ngay);
            this.panelTimKiem.Controls.Add(this.Thang);
            this.panelTimKiem.Controls.Add(this.ChungRieng);
            this.panelTimKiem.Location = new System.Drawing.Point(141, 212);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(797, 51);
            this.panelTimKiem.TabIndex = 7;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.ForeColor = System.Drawing.Color.Red;
            this.lblHoTen.Location = new System.Drawing.Point(141, 266);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(0, 17);
            this.lblHoTen.TabIndex = 8;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTien.ForeColor = System.Drawing.Color.Red;
            this.lblSoTien.Location = new System.Drawing.Point(375, 266);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(0, 17);
            this.lblSoTien.TabIndex = 8;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgay.ForeColor = System.Drawing.Color.Red;
            this.lblNgay.Location = new System.Drawing.Point(538, 266);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(0, 17);
            this.lblNgay.TabIndex = 8;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.ForeColor = System.Drawing.Color.Red;
            this.lblThang.Location = new System.Drawing.Point(684, 266);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(0, 17);
            this.lblThang.TabIndex = 8;
            // 
            // lblThuChi
            // 
            this.lblThuChi.AutoSize = true;
            this.lblThuChi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThuChi.ForeColor = System.Drawing.Color.Red;
            this.lblThuChi.Location = new System.Drawing.Point(830, 266);
            this.lblThuChi.Name = "lblThuChi";
            this.lblThuChi.Size = new System.Drawing.Size(0, 17);
            this.lblThuChi.TabIndex = 8;
            // 
            // btnResetTimKiem
            // 
            this.btnResetTimKiem.BackColor = System.Drawing.Color.LimeGreen;
            this.btnResetTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetTimKiem.FlatAppearance.BorderSize = 0;
            this.btnResetTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetTimKiem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnResetTimKiem.Location = new System.Drawing.Point(570, 317);
            this.btnResetTimKiem.Name = "btnResetTimKiem";
            this.btnResetTimKiem.Size = new System.Drawing.Size(150, 54);
            this.btnResetTimKiem.TabIndex = 5;
            this.btnResetTimKiem.TabStop = false;
            this.btnResetTimKiem.Tag = "";
            this.btnResetTimKiem.Text = "Reset";
            this.btnResetTimKiem.UseVisualStyleBackColor = false;
            this.btnResetTimKiem.Click += new System.EventHandler(this.btnResetTimKiem_Click);
            // 
            // ManHinhTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1081, 665);
            this.Controls.Add(this.lblThuChi);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblNgay);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.panelTimKiem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdTimKiem);
            this.Controls.Add(this.btnResetTimKiem);
            this.Controls.Add(this.button1);
            this.Name = "ManHinhTimKiem";
            this.Tag = "timkiem";
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.btnResetTimKiem, 0);
            this.Controls.SetChildIndex(this.grdTimKiem, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panelTimKiem, 0);
            this.Controls.SetChildIndex(this.lblHoTen, 0);
            this.Controls.SetChildIndex(this.lblSoTien, 0);
            this.Controls.SetChildIndex(this.lblNgay, 0);
            this.Controls.SetChildIndex(this.lblThang, 0);
            this.Controls.SetChildIndex(this.lblThuChi, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdTimKiem)).EndInit();
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HoTen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox SoTien;
        private System.Windows.Forms.TextBox Ngay;
        private System.Windows.Forms.TextBox Thang;
        private System.Windows.Forms.DataGridView grdTimKiem;
        private System.Windows.Forms.TextBox ChungRieng;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThuChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dawd;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label lblThuChi;
        private System.Windows.Forms.Button btnResetTimKiem;
    }
}
