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
    public partial class ManHinhThongKe : UngDungDesktop.ManHinhCoBan
    {
        private XuLiNghiepVu xuLiNghiepVu = new XuLiNghiepVu();
        private int offset = 0;
        private int limit = 5;

        private int idThuChiChung;

        private static int left = 0;
        public ManHinhThongKe()
        {
            InitializeComponent();           
            idThuChiChung = xuLiNghiepVu.layIdThuChiChung(idGiaDinh);
            XmlElement duLieuThongKeNam = xuLiNghiepVu.layDanhSachThongKeNam(offset, limit);
            if (duLieuThongKeNam != null)
            {
                hienThiThongKeNam(duLieuThongKeNam);
            }
            else
            {
                resetButtonNam();
                resetButtonThang();                
            }
        }
        
        // hien thi click mac đinh
        private void ManHinhThongKe_Load(object sender, EventArgs e)
        {
            btnFirst.PerformClick();
        }


        #region các hàm hiển thi
        // thong ke nam
        private void hienThiThongKeNam(XmlElement duLieu)
        {
            resetButtonNam();
            XmlNodeList listNode = duLieu.ChildNodes;
            int i = 0;
            foreach (Control control in panelNam.Controls)
            {
                if (control.GetType() == typeof(Button) && control.Tag.ToString() != "arrow")
                {
                    if (listNode[i] != null)
                    {
                        string nam = listNode[i].Attributes["Nam"].Value;
                        string soTienThu = listNode[i].Attributes["SoTienThu"].Value;
                        string soTienChi = listNode[i].Attributes["SoTienChi"].Value;
                        int chenhLech = Convert.ToInt32(soTienThu) - Convert.ToInt32(soTienChi);
                        control.Text = nam + "\r\n+ " + soTienThu + "\r\n-  " + soTienChi + "\r\n⇒" + chenhLech.ToString();
                        control.Tag = nam;
                        control.Enabled = true;
                        control.Click += xuLiSuKienClickNam;
                        i++;
                    }
                }
            }
        }
        
        // thong ke thanh vien theo nam
        private void hienThiThongKeChungRiengTheoNam(XmlElement duLieu, string nam, int idThuChiChung)
        {
            lblHinhThucThongKe.Text = "Năm " + nam;
            removeButtonThongKeChungRieng();
            XmlNodeList list = duLieu.ChildNodes;
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                if (list[i].Attributes["ID"].Value == idThuChiChung.ToString())
                {
                    string thu = list[i].Attributes["SoTienThu"].Value;
                    string chi = list[i].Attributes["SoTienChi"].Value;
                    string chenhLech = xuLiNghiepVu.tinhChenhLech(thu, chi);
                    lblChung.Text = "+ " + thu + "     - " + chi + "     ⇒ " + chenhLech;
                }else
                {
                    panelThuChiThanhVien.Controls.Add(taoNutThanhVien((XmlElement)list[i]));
                }
            }        
        }

        // thong ke thanh vien theo thang
        private void hienThiThongKeChungRiengTheoThang(XmlElement duLieu, string nam,string thang, int idThuChiChung)
        {
            lblHinhThucThongKe.Text = "Tháng " + thang + "/" + nam;
            removeButtonThongKeChungRieng();
            XmlNodeList list = duLieu.ChildNodes;
            int length = list.Count;
            for (int i = 0; i < length; i++)
            {
                if (list[i].Attributes["ID"].Value == idThuChiChung.ToString())
                {
                    string thu = list[i].Attributes["SoTienThu"].Value;
                    string chi = list[i].Attributes["SoTienChi"].Value;
                    string chenhLech = xuLiNghiepVu.tinhChenhLech(thu, chi);
                    lblChung.Text = "+ " + thu + "     - " + chi + "     ⇒ " + chenhLech;
                }
                else
                {
                    panelThuChiThanhVien.Controls.Add(taoNutThanhVien((XmlElement)list[i]));
                }
            }
        }

        // thong ke thang
        private void hienThiThongKeThang(XmlElement duLieu)
        {          
            resetButtonThang();
            XmlNodeList listNode = duLieu.ChildNodes;
            int doDaiNode = listNode.Count;
            int i = 0;
            foreach (Control control in panelThangDoc.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    if (listNode[i] != null)
                    {
                        string thang = listNode[i].Attributes["Thang"].Value;
                        string nam = listNode[i].Attributes["Nam"].Value;
                        string soTienThu = listNode[i].Attributes["SoTienThu"].Value;
                        string soTienChi = listNode[i].Attributes["SoTienChi"].Value;
                        string chenhLech = xuLiNghiepVu.tinhChenhLech(soTienThu, soTienChi);
                        control.Text = "Tháng " + thang + "\r\n+ " + soTienThu + "\r\n-  " + soTienChi + "\r\n⇒" + chenhLech;
                        control.Tag = thang + ":" + nam;
                        control.Enabled = true;
                        control.Visible = true;
                        control.Click += xuLiSuKienClickThongKeThang;
                        i++;
                    }
                }
            }
            // hien thi tren panel ngang  
            foreach (Control control in panelThangNgang.Controls)
            {       
                if (control.GetType() == typeof(Button))
                {
                    if (listNode[i] != null)
                    {
                        string nam = listNode[i].Attributes["Nam"].Value;
                        string thang = listNode[i].Attributes["Thang"].Value;
                        string soTienThu = listNode[i].Attributes["SoTienThu"].Value;
                        string soTienChi = listNode[i].Attributes["SoTienChi"].Value;
                        int chenhLech = Convert.ToInt32(soTienThu) - Convert.ToInt32(soTienChi);
                        control.Text = "Tháng " + thang + "\r\n+ " + soTienThu + "\r\n-  " + soTienChi + "\r\n⇒" + chenhLech.ToString();
                        control.Tag = thang + ":" + nam;
                        control.Enabled = true;
                        control.Visible = true;
                        control.Click += xuLiSuKienClickThongKeThang;
                        i++;
                    }
 
                }
            }

        }

        // nut thanh vien
        private Control taoNutThanhVien(XmlElement duLieu)
        {
            Button btn = new Button();
            btn.BackColor = Color.FromArgb(255, 192, 192);
            
            string thu = duLieu.Attributes["SoTienThu"].Value;
            string chi = duLieu.Attributes["SoTienChi"].Value;
            string chechLech = xuLiNghiepVu.tinhChenhLech(thu, chi);
            string thanhVien = duLieu.Attributes["HoTen"].Value;

            string content = " " + thanhVien + "\r\n+ " + thu + "\r\n-  " + chi + "\r\n⇒" + chechLech.ToString();
            btn.Text = content;
            btn.Name = btn.Name = "btn" + thanhVien;
            btn.Width = 115;
            btn.Height = 100;
            btn.Location = new Point(left, 0);
            left += btn.Width + 20;
            btn.TextAlign = ContentAlignment.TopLeft;
            btn.Enabled = false;

            return btn;
        }
        #endregion

        #region các hàm reset 
        private void removeButtonThongKeChungRieng()
        {
            panelThuChiThanhVien.Controls.Clear();
        }
        private void resetButtonNam()
        {
            foreach (Control control in panelNam.Controls)
            {
                if (control.GetType() == typeof(Button) && control.Tag.ToString() != "arrow")
                {
                    control.Text = "";
                    control.Tag = "";
                    control.Enabled = false;
                }
            }
        }

        private void resetButtonThang()
        {
            foreach (Control control in panelThangDoc.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Text = "";
                    control.Tag = "";
                    control.Enabled = false;
                    control.Visible = false;
                }
            }

            foreach (Control control in panelThangNgang.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.Text = "";
                    control.Tag = "";
                    control.Enabled = false;
                    control.Visible = false;
                }
            }
        }

        private void resetColorButtonNam()
        {
            foreach (Control control in panelNam.Controls)
            {
                if (control.GetType() == typeof(Button) && control.Tag.ToString() != "arrow")
                {
                    control.BackColor = Color.White;
                }
            }
        }

        private void resetColorButtonThang()
        {
            foreach (Control control in panelThangDoc.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.BackColor = Color.FromArgb(192, 255, 255);
                }
            }

            foreach (Control control in panelThangNgang.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    control.BackColor = Color.FromArgb(192, 255, 255);
                }
            }
        }
        #endregion

        #region xử lí sự kiện click 

        // hien thi tung thang thang va thong ke thanh vien theo nam
        private void xuLiSuKienClickNam(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.BackColor == Color.Red)
            {
                return;
            }
            //rest lai loction cua button thu chi ca nhan
            left = 0;
            resetColorButtonNam();
            resetColorButtonThang();
            control.BackColor = Color.Red;
            string nam = control.Tag.ToString();

            // hien thi thong tin thu chung chung rieng
            XmlElement thongKeChungRieng = xuLiNghiepVu.layThongKeThanhVienTheoNam(nam, idGiaDinh);
            // khong can kiem tra vi du lieu da dung
            hienThiThongKeChungRiengTheoNam(thongKeChungRieng, nam, idThuChiChung);

            XmlElement thongKeThang = xuLiNghiepVu.layDanhSachThongKeThangTheoNam(nam);
            if (thongKeThang != null)
            {
                hienThiThongKeThang(thongKeThang);
            }

        }

        // hien thi thong ke chung va thanh vien theo thang
        private void xuLiSuKienClickThongKeThang(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (control.BackColor == Color.Red)
            {
                return;
            }
            //rest lai loction cua button thu chi ca nhan
            left = 0;
            resetColorButtonThang();
            control.BackColor = Color.Red;
            string thangTemp = control.Tag.ToString();
            string[] temp = thangTemp.Split(':');
            string thang = temp[0];
            string nam = temp[1];
            XmlElement duLieuThongKe = xuLiNghiepVu.layThongKeThanhVienTheoThang(nam, thang, idGiaDinh);
            hienThiThongKeChungRiengTheoThang(duLieuThongKe, nam, thang, idThuChiChung);
        }
        #endregion

    }
}
