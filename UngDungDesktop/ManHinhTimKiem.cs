using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace UngDungDesktop
{
    public partial class ManHinhTimKiem : UngDungDesktop.ManHinhCoBan
    {
        private XuLiNghiepVu xuLiNghiepVu = new XuLiNghiepVu();       
        private int idChungRieng;
        public ManHinhTimKiem()
        {
            InitializeComponent();
            idChungRieng = xuLiNghiepVu.layIdThuChiChung(idGiaDinh);

            /** 
             * ấn enter nếu muốn tìm kiếm riêng lẽ
             * click tìm kiếm cho các điều kiện tổng hợp
             * */
            ganSuKienTimKiem();
        }

        public void ganSuKienTimKiem()
        {
            foreach(Control control in panelTimKiem.Controls)
            {
                if(control.GetType() == typeof(TextBox))
                {
                    control.KeyPress += xuLiSuKienKeyPress;
                }
            }
        }

        // xu li khu an enter
        private void xuLiSuKienKeyPress(object sender, KeyPressEventArgs e)
        {
            resetGridView();
            resetLabelMessage();
            if (e.KeyChar == (char)Keys.Enter)
            {
                Control control = (Control)sender;
                string keyNoiDung = control.Name;
                string noiDung =  xuLiHienThi.nhapChuoi(control);
                Dictionary<string, string> duLieu = new Dictionary<string, string>();
                duLieu.Add("IdChungRieng", idChungRieng.ToString());
                duLieu.Add("IdGiaDinh", idGiaDinh.ToString());
                switch (keyNoiDung)
                {
                    case "SoTien":
                        {
                            if (xuLiHienThi.kiemTraLaSo(noiDung))
                            {
                                duLieu.Add(keyNoiDung, noiDung);
                            }
                            else
                            {
                                MessageBox.Show(thongBao[2]);
                                return;
                            }
                        }
                        break;
                    case "ChungRieng":
                        {
                            string[] data = { "Chung", "Riêng" };
                            if (xuLiHienThi.kiemTraInputInData(data, noiDung))
                            {
                                duLieu.Add(keyNoiDung, noiDung);
                            }
                            else
                            {
                                MessageBox.Show(thongBao[3]);
                                return;
                            }
                        }
                        break;
                    case "Ngay":
                        {
                            DateTime ngayThuChi = xuLiHienThi.stringToDateTime(noiDung);
                            if (!xuLiHienThi.kiemTraNgayNull(ngayThuChi))
                            {
                                duLieu.Add(keyNoiDung, ngayThuChi.ToShortDateString());
                            }
                            else
                            {
                                MessageBox.Show(thongBao[4]);
                                return;
                            }
                        }break;
                    case "Thang":
                        {
                            DateTime thangThuChi = xuLiHienThi.stringToDateTime(noiDung);
                            if (!xuLiHienThi.kiemTraNgayNull(thangThuChi))
                            {
                                duLieu.Add(keyNoiDung, thangThuChi.ToString("MM:yyyy"));
                            }
                            else
                            {
                                MessageBox.Show(thongBao[5]);
                                return;
                            }
                        }
                        break;
                    default:
                        {
                            duLieu.Add(keyNoiDung, noiDung);
                        }break;
                }

                XmlElement duLieuTimKiem = xuLiNghiepVu.taoElementTimKiem(duLieu);
                XmlElement kq = xuLiNghiepVu.timKiem(duLieuTimKiem);

                if (kq != null)
                {
                    DataTable tableKetQua = xuLiNghiepVu.xmlToDataTable(kq, idChungRieng);
                    grdTimKiem.AutoGenerateColumns = false;
                    grdTimKiem.DataSource = tableKetQua;

                }
                else
                {
                    MessageBox.Show(thongBao[6]);
                }
            }
        }

        // reset data grid view ve rong
        private void resetGridView()
        {
            grdTimKiem.DataSource = null;
        }

        private void resetLabelMessage()
        {
            lblHoTen.Text = "";
            lblSoTien.Text = "";
            lblNgay.Text = "";
            lblThang.Text = "";
            lblThuChi.Text = "";
        }

        private void resetTxtTimKiem()
        {
            HoTen.Text = "";
            Ngay.Text = "";
            Thang.Text = "";
            SoTien.Text = "";
            ChungRieng.Text = "";
        }

        // khi click vao button tim kiem
        private void button1_Click(object sender, EventArgs e)
        {
            resetLabelMessage();
            string hoTen = xuLiHienThi.nhapChuoi(HoTen);
            string soTien = xuLiHienThi.nhapChuoi(SoTien);
            string ngay = xuLiHienThi.nhapChuoi(Ngay);
            string thang = xuLiHienThi.nhapChuoi(Thang);
            string loaiThuChi = xuLiHienThi.nhapChuoi(ChungRieng);

            bool flag = true;

            // co tim so tien
            if(soTien != "")
            {
                // neu khong la thi thong bao va gan flag = false
                if (!xuLiHienThi.kiemTraLaSo(soTien))
                {
                    flag = false;
                    lblSoTien.Text = "Vui lòng nhập số";
                }
            }

            if (ngay != "")
            {
                DateTime ngayThuChi = xuLiHienThi.stringToDateTime(ngay);
                if (xuLiHienThi.kiemTraNgayNull(ngayThuChi))
                {
                    flag = false;
                    lblNgay.Text = "Định dạng dd/MM/yyyy \n hoặc dd-MM-yyyy";
                }else
                {
                    ngay = ngayThuChi.ToShortDateString();
                }
            }

            if (thang != "")
            {
                DateTime ngayThuChi = xuLiHienThi.stringToDateTime(thang);
                if (xuLiHienThi.kiemTraNgayNull(ngayThuChi))
                {
                    flag = false;
                    lblThang.Text = "Định dạng MM/yyyy \n hoặc MM-yyyy";
                }
                else
                {
                    thang = ngayThuChi.ToString("MM:yyyy");
                }
            }

            if(loaiThuChi != "")
            {
                string[] data = { "Chung", "Riêng" };
                if (!xuLiHienThi.kiemTraInputInData(data, loaiThuChi))
                {
                    flag = false;
                    lblThuChi.Text = "Vui lòng nhập Chung hoặc Riêng";
                }
            }

            if(ngay == "" && soTien == "" && thang == "" && hoTen == "" && loaiThuChi == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu !");
                return;
            }

            // tat cac cac dieu kien dung thi thuc hien
            if (flag)
            {
                Dictionary<string, string> duLieu = new Dictionary<string, string>();
                duLieu.Add("IdChungRieng", idChungRieng.ToString());
                duLieu.Add("IdGiaDinh", idGiaDinh.ToString());
                duLieu.Add("HoTen", hoTen);
                duLieu.Add("SoTien", soTien);
                duLieu.Add("Ngay", ngay);
                duLieu.Add("Thang", thang);
                duLieu.Add("ChungRieng", loaiThuChi);

                XmlElement duLieuTimKiem = xuLiNghiepVu.taoElementTimKiem(duLieu);
                XmlElement kq = xuLiNghiepVu.timKiem(duLieuTimKiem);

                if (kq != null)
                {
                    DataTable tableKetQua = xuLiNghiepVu.xmlToDataTable(kq, idChungRieng);
                    grdTimKiem.AutoGenerateColumns = false;
                    grdTimKiem.DataSource = tableKetQua;

                }
                else
                {
                    MessageBox.Show("Không tìm thấy dữ liệu");
                }

            }

        }

        // reset tim kiem
        private void btnResetTimKiem_Click(object sender, EventArgs e)
        {
            resetTxtTimKiem();
            resetLabelMessage();
            resetGridView();
        }
    }
}
