namespace UngDungDesktop
{
    partial class ManHinhChi
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
            this.cbbDanhSachThanhVien = new System.Windows.Forms.ComboBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNgayThang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThu = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lblNgayThang = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbbDanhSachThanhVien
            // 
            this.cbbDanhSachThanhVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDanhSachThanhVien.FormattingEnabled = true;
            this.cbbDanhSachThanhVien.Location = new System.Drawing.Point(355, 238);
            this.cbbDanhSachThanhVien.Name = "cbbDanhSachThanhVien";
            this.cbbDanhSachThanhVien.Size = new System.Drawing.Size(266, 29);
            this.cbbDanhSachThanhVien.TabIndex = 1;
            this.cbbDanhSachThanhVien.Tag = "IdThanhVien";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(355, 320);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(266, 29);
            this.txtSoTien.TabIndex = 2;
            this.txtSoTien.Tag = "SoTien";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thành viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 323);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số tiền";
            // 
            // txtNgayThang
            // 
            this.txtNgayThang.Location = new System.Drawing.Point(355, 402);
            this.txtNgayThang.Name = "txtNgayThang";
            this.txtNgayThang.Size = new System.Drawing.Size(266, 29);
            this.txtNgayThang.TabIndex = 3;
            this.txtNgayThang.Tag = "NgayThang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày tháng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ghi chú";
            // 
            // btnThu
            // 
            this.btnThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(208)))), ((int)(((byte)(94)))));
            this.btnThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThu.FlatAppearance.BorderSize = 0;
            this.btnThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThu.ForeColor = System.Drawing.Color.Black;
            this.btnThu.Location = new System.Drawing.Point(355, 583);
            this.btnThu.Name = "btnThu";
            this.btnThu.Size = new System.Drawing.Size(130, 43);
            this.btnThu.TabIndex = 5;
            this.btnThu.TabStop = false;
            this.btnThu.Tag = "";
            this.btnThu.Text = "Xác nhận";
            this.btnThu.UseVisualStyleBackColor = false;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(355, 484);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(266, 76);
            this.txtGhiChu.TabIndex = 4;
            this.txtGhiChu.Tag = "GhiChu";
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTien.ForeColor = System.Drawing.Color.Red;
            this.lblSoTien.Location = new System.Drawing.Point(355, 356);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(0, 17);
            this.lblSoTien.TabIndex = 6;
            // 
            // lblNgayThang
            // 
            this.lblNgayThang.AutoSize = true;
            this.lblNgayThang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayThang.ForeColor = System.Drawing.Color.Red;
            this.lblNgayThang.Location = new System.Drawing.Point(355, 434);
            this.lblNgayThang.Name = "lblNgayThang";
            this.lblNgayThang.Size = new System.Drawing.Size(0, 17);
            this.lblNgayThang.TabIndex = 6;
            // 
            // ManHinhChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(955, 665);
            this.Controls.Add(this.lblNgayThang);
            this.Controls.Add(this.lblSoTien);
            this.Controls.Add(this.btnThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNgayThang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.cbbDanhSachThanhVien);
            this.Name = "ManHinhChi";
            this.Controls.SetChildIndex(this.cbbDanhSachThanhVien, 0);
            this.Controls.SetChildIndex(this.txtSoTien, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtNgayThang, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.btnThu, 0);
            this.Controls.SetChildIndex(this.lblSoTien, 0);
            this.Controls.SetChildIndex(this.lblNgayThang, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbDanhSachThanhVien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNgayThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.Label lblNgayThang;
    }
}
