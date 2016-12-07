using System.Xml;
using UngDungDesktop.QuanLiThuChiService;

namespace UngDungDesktop
{
    public class XuLiLuuTruClient
    {
        private XuLiDichVuSoapClient dichVu = new XuLiDichVuSoapClient();
        private XuLiXml xuLiXml = new XuLiXml();

        // goi service lay danh sach thanh vien
        public XmlElement layDanhSachThanhVien()
        {
            XmlElement kq = null;
            string dsThanhVien = dichVu.layDanhSachThanhVien();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(dsThanhVien);
            kq = doc.DocumentElement;
            return kq;
        }

        // goi service thu chi
        public string themThuChi(XmlElement duLieuThuChi)
        {
            string kq = "";
            string chuoiThuChi = xuLiXml.taoChuoiXmlTuElement(duLieuThuChi);
            kq = dichVu.themKhoanThuChi(chuoiThuChi);
            return kq;
        }

        // goi service lay thong ke nam
        public string layThongKeNam(int offset,int limit)
        {
            string kq = "";
            kq = dichVu.thongKeTheoNam(offset, limit);
            return kq;
        }

        // goi service lay thong ke thang
        public string layThongKeThangTheoNam(string nam)
        {
            string kq = "";
            kq = dichVu.thongKeTheoThang(nam);
            return kq;
        }

        // goi service lay thong ke thanh vien theo nam
        public string layThongKeThanhVienTheoNam(string nam,int idGiaDinh)
        {
            string kq = "";
            kq = dichVu.thongKeThanhVienTheoNam(nam, idGiaDinh);
            return kq;
        }

        // service thong ke thanh vien theo thang
        public string layThongKeThanhVienTheoThang(string nam,string thang, int idGiaDinh)
        {
            string kq = "";
            kq = dichVu.thongKeThanhVienTheoThang(nam, thang,idGiaDinh);
            return kq;
        }

        // goi service tim kiem
        public string timKiem(string duLieuTimKiem)
        {
            string kq = "";
            kq = dichVu.timKiem(duLieuTimKiem);
            return kq;
        }

        // dung trong truong hop nhieu gia dinh (khong sử dụng)
        public string layIdThuChiChung(int idGiaDinh)
        {
            string kq = "";
            kq = dichVu.layIdThuChiChung(idGiaDinh);
            return kq;
        }

    }
}
