using System.Windows.Forms;

namespace UngDungDesktop
{
    partial class ManHinhCoBan
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
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnQuanLiThu = new System.Windows.Forms.Button();
            this.btnQuanLiChi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panelDanhSachChucNang = new System.Windows.Forms.Panel();
            this.panelDanhSachChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(122)))), ((int)(((byte)(94)))));
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatAppearance.BorderSize = 0;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(62, 0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(130, 119);
            this.btnThongKe.TabIndex = 0;
            this.btnThongKe.TabStop = false;
            this.btnThongKe.Tag = "thongKe";
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            // 
            // btnQuanLiThu
            // 
            this.btnQuanLiThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(208)))), ((int)(((byte)(94)))));
            this.btnQuanLiThu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLiThu.FlatAppearance.BorderSize = 0;
            this.btnQuanLiThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLiThu.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLiThu.ForeColor = System.Drawing.Color.White;
            this.btnQuanLiThu.Location = new System.Drawing.Point(246, 0);
            this.btnQuanLiThu.Name = "btnQuanLiThu";
            this.btnQuanLiThu.Size = new System.Drawing.Size(130, 119);
            this.btnQuanLiThu.TabIndex = 0;
            this.btnQuanLiThu.TabStop = false;
            this.btnQuanLiThu.Tag = "thu";
            this.btnQuanLiThu.Text = "Thu";
            this.btnQuanLiThu.UseVisualStyleBackColor = false;
            // 
            // btnQuanLiChi
            // 
            this.btnQuanLiChi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(250)))), ((int)(((byte)(94)))));
            this.btnQuanLiChi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLiChi.FlatAppearance.BorderSize = 0;
            this.btnQuanLiChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLiChi.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLiChi.ForeColor = System.Drawing.Color.White;
            this.btnQuanLiChi.Location = new System.Drawing.Point(430, 3);
            this.btnQuanLiChi.Name = "btnQuanLiChi";
            this.btnQuanLiChi.Size = new System.Drawing.Size(130, 119);
            this.btnQuanLiChi.TabIndex = 0;
            this.btnQuanLiChi.TabStop = false;
            this.btnQuanLiChi.Tag = "chi";
            this.btnQuanLiChi.Text = "Chi";
            this.btnQuanLiChi.UseVisualStyleBackColor = false;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.FlatAppearance.BorderSize = 0;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(614, 3);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(130, 119);
            this.btnTimKiem.TabIndex = 0;
            this.btnTimKiem.TabStop = false;
            this.btnTimKiem.Tag = "timkiem";
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // panelDanhSachChucNang
            // 
            this.panelDanhSachChucNang.Controls.Add(this.btnThongKe);
            this.panelDanhSachChucNang.Controls.Add(this.btnTimKiem);
            this.panelDanhSachChucNang.Controls.Add(this.btnQuanLiThu);
            this.panelDanhSachChucNang.Controls.Add(this.btnQuanLiChi);
            this.panelDanhSachChucNang.Location = new System.Drawing.Point(141, 30);
            this.panelDanhSachChucNang.Name = "panelDanhSachChucNang";
            this.panelDanhSachChucNang.Size = new System.Drawing.Size(797, 125);
            this.panelDanhSachChucNang.TabIndex = 1;
            // 
            // ManHinhCoBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1081, 665);
            this.Controls.Add(this.panelDanhSachChucNang);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManHinhCoBan";
            this.Tag = "thongKe";
            this.Text = "Thống kê";
            this.panelDanhSachChucNang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThongKe;
        private Button btnQuanLiThu;
        private Button btnQuanLiChi;
        private Button btnTimKiem;
        private Panel panelDanhSachChucNang;
    }
}

