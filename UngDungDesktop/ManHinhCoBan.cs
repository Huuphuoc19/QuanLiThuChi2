using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungDesktop
{

    public partial class ManHinhCoBan : Form
    {

        protected XuLiHienThi xuLiHienThi = new XuLiHienThi();
        protected XuLiXml xuLiXml = new XuLiXml();
        protected int idGiaDinh = 1;
        protected const string hienThiThuChiChung = "THU CHI CHUNG";

        protected string[] thuocTinhThuChi = new string[]
        {
            "SoTien","NgayThuChi","LoaiThuChi","GhiChu","IdThanhVien"
        };
        protected string[] thongBao = new string[]
        {
            "Thêm thành công",
            "Đã xảy ra lỗi, vui lòng thử lại sau",
            "Vui lòng nhập số !",
            "Vui lòng nhập Chung hoặc Riêng",
            "Ngày không hợp lệ, định dạng dd/MM/YYYY hoặc dd-MM-YYYY",
            "Tháng không hợp lệ, định dạng MM/YYYY hoặc MM-YYYY",
            "Không tìm thấy dữ liệu"
        };

        public ManHinhCoBan()
        {
            InitializeComponent();
            //gan chac nang cho cac button chuc nang da thiet lap
            ganSuKienKhiClickMenu();
        }
        
        // gan su kien click cho cac btn chuc nang
        private void ganSuKienKhiClickMenu()
        {
            foreach(var control in panelDanhSachChucNang.Controls)
            {
                if(control.GetType() == typeof(Button)){
                    Button temp = control as Button;
                    temp.Click += xuLiSuKienClickMenu;
                }
            }
        }

        // click se hien ra form phu hop voi chuc nang do
        private void xuLiSuKienClickMenu(object sender,EventArgs e)
        {
            Control thucHienChucNang = (Control)sender;
            string maSoChucNang = thucHienChucNang.Tag.ToString();
            // neu dang o form voi chuc nang thien tai thi khong cho click
            if(maSoChucNang == this.Name)
            {
                return;
            }
            switch (maSoChucNang)
            {
                case "thu":
                    {
                        ManHinhThu thuForm = new ManHinhThu();
                        thuForm.Show();
                        thuForm.FormClosed += xuLiSuKiemCloseForm;
                        this.Hide();
                    }break;
                case "chi":
                    {
                        ManHinhChi chiForm = new ManHinhChi();
                        chiForm.Show();
                        chiForm.FormClosed += xuLiSuKiemCloseForm;
                        this.Hide();
                    }
                    break;
                case "timkiem":
                    {
                        ManHinhTimKiem chiForm = new ManHinhTimKiem();
                        chiForm.Show();
                        chiForm.FormClosed += xuLiSuKiemCloseForm;
                        this.Hide();
                    }
                    break;
                default:
                    {
                        ManHinhThongKe mainForm = new ManHinhThongKe();
                        mainForm.Show();
                        mainForm.FormClosed += xuLiSuKiemCloseForm;
                        this.Hide();
                    }
                    break;
            }
        }

        // dong 1 form thi dong ca chuong trinh
        private void xuLiSuKiemCloseForm(object sender, EventArgs e)
        {
            Control thucHienChucNang = (Control)sender;
            Application.Exit();
        }
  
    }


    public class comboxItem
    {
        public string Text { set; get; }
        public string Value { set; get; }
    }

}
