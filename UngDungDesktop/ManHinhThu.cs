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
    public partial class ManHinhThu : ManHinhCoBan
    {

        private XuLiNghiepVu xuLiNghiepVu = new XuLiNghiepVu();
        private int idChungRieng;
        public ManHinhThu()
        {
            InitializeComponent();
            idChungRieng = xuLiNghiepVu.layIdThuChiChung(idGiaDinh);
            // lay danh sach thanhv vien them vao cbb 
            XmlElement dsThanhVien = xuLiNghiepVu.layDanhSachThanhVien();
            hienThiDanhSachThanhVienRaCombobox(dsThanhVien, cbbDanhSachThanhVien);
            // gan su kien click de luu du lieu
            btnThu.Click += xuLiSuKienClickQuanLiThu;
        }

        // hien thi danh sach thanh vien ra cbb
        public void hienThiDanhSachThanhVienRaCombobox(XmlElement duLieuThanhVien, ComboBox cbb)
        {
            cbb.Items.Clear();
            cbb.DisplayMember = "text";
            cbb.ValueMember = "value";
            List<comboxItem> items = new List<comboxItem>();
            int i = 0, j = 0;
            foreach (XmlNode node in duLieuThanhVien.ChildNodes)
            {
                comboxItem item = new comboxItem();
                if(node.Attributes["ID"].Value == idChungRieng.ToString())
                {
                    node.Attributes["HoTen"].Value = hienThiThuChiChung;
                    j = i;
                }
                item.Text = node.Attributes["HoTen"].Value;
                item.Value = node.Attributes["ID"].Value;
                items.Add(item);
                i++;
            }
            
            cbb.DataSource = items;
            cbb.SelectedIndex = j;
        }

        // click vao them thu chi
        public void xuLiSuKienClickQuanLiThu(Object sender,EventArgs e)
        {
            resetLableMessage();
            string soTien = xuLiHienThi.nhapChuoi(txtSoTien);
            string ngayThang = xuLiHienThi.nhapChuoi(txtNgayThang);

            bool flag = true;
            if (!xuLiHienThi.kiemTraLaSo(soTien))
            {
                flag = false;
                lblSoTien.Text = thongBao[2];
            }

            DateTime date = xuLiHienThi.stringToDateTime(ngayThang);
            if (xuLiHienThi.kiemTraNgayNull(date))
            {
                flag = false;
                lblNgayThang.Text = thongBao[4];
            }
            if (!flag)
            {
                return;
            }

            Dictionary<string, string> duLieuTho = new Dictionary<string, string>();
            duLieuTho.Add(thuocTinhThuChi[0], soTien);
            duLieuTho.Add(thuocTinhThuChi[1], ngayThang);
            duLieuTho.Add(thuocTinhThuChi[2], "Thu");
            duLieuTho.Add(thuocTinhThuChi[3], xuLiHienThi.nhapChuoi(txtGhiChu));
            duLieuTho.Add(thuocTinhThuChi[4], xuLiHienThi.nhapChuoi(cbbDanhSachThanhVien));

            XmlElement element = xuLiXml.taoElementThuChi(duLieuTho);
            string kq = xuLiNghiepVu.themThuChi(element);
            if(kq == "")
            {
                MessageBox.Show(thongBao[0]);
            }
            else
            {
                MessageBox.Show(thongBao[1]);
            }
        }

        // reset lable message lỗi
        private void resetLableMessage()
        {
            lblNgayThang.Text = "";
            lblSoTien.Text = "";
        }
    }

}
