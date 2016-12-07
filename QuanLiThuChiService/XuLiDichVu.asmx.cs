using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace QuanLiThuChiService
{
    /// <summary>
    /// Summary description for XuLiDichVu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class XuLiDichVu : System.Web.Services.WebService
    {
        protected XuLiLuuTru xuLiLuuTru = new XuLiLuuTru();

        // khong tham so
        [WebMethod]
        public string layDanhSachThanhVien()
        {
            string kq = "";
            XmlElement dsThanhVien = xuLiLuuTru.docMotBangDuLieu("ThanhVien");
            kq = dsThanhVien.OuterXml;
            return kq;
        }

        //<Data><ThuChi SoTien="" NgayThuChi="" LoaiThuChi="" GhiChu="" IdThanhVien="" /></Data>"
        [WebMethod]
        public string themKhoanThuChi(string chuoiDuLieuThuChi)
        {
            // decode string trong truong hop gui bang js
            chuoiDuLieuThuChi = Uri.UnescapeDataString(chuoiDuLieuThuChi);

            string kq = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(chuoiDuLieuThuChi);
            XmlElement doiTuongThuChi = (XmlElement)doc.DocumentElement.FirstChild;
            kq = xuLiLuuTru.ghiDuLieuMoiTheoDoiTuong(doiTuongThuChi);
            return kq;
        }

        [WebMethod]
        public string thongKeTheoNam(int offset,int limit)
        {
            string kq = "";
            XmlElement thongKeNam =  xuLiLuuTru.thongKeTheoNam(offset, limit);
            kq = thongKeNam.OuterXml;
            return kq;
        }

        [WebMethod]
        public string thongKeTheoThang(string nam)
        {
            string kq = "";
            XmlElement thongKeThang = xuLiLuuTru.thongKeTheoThang(nam);
            kq = thongKeThang.OuterXml;
            return kq;
        }

        [WebMethod]
        public string thongKeThanhVienTheoNam(string nam, int idGiaDinh)
        {
            string kq = "";
            XmlElement thongKeThang = xuLiLuuTru.thongKeThuChiThanhVienTheoNam(nam, idGiaDinh);
            kq = thongKeThang.OuterXml;
            return kq;
        }

        [WebMethod]
        public string thongKeThanhVienTheoThang(string nam,string thang, int idGiaDinh)
        {
            string kq = "";
            XmlElement thongKeThang = xuLiLuuTru.thongKeThuChiThanhVienTheoThang(nam, thang, idGiaDinh);
            kq = thongKeThang.OuterXml;
            return kq;
        }

        [WebMethod]
        //<Data><ThuChi SoTien="" NgayThuChi="" LoaiThuChi="" GhiChu="" IdThanhVien="" /></Data>"
        public string timKiem(string chuoiXmlDuLieuTimKiem)
        {

            // decode string trong truong hop gui bang js
            chuoiXmlDuLieuTimKiem = Uri.UnescapeDataString(chuoiXmlDuLieuTimKiem);
            xuLiLuuTru.LogMessageToFile(chuoiXmlDuLieuTimKiem);
            string kq = "";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(chuoiXmlDuLieuTimKiem);
            XmlElement data = (XmlElement)doc.DocumentElement.FirstChild;
            XmlElement kqXml = xuLiLuuTru.timKiem(data);
            kq = kqXml.OuterXml;
            return kq;
        }

        [WebMethod]
        public string layIdThuChiChung(int idGiaDinh)
        {
            string kq = "";
            kq = xuLiLuuTru.layIdThuChiChung(idGiaDinh);
            return kq;
        }

    }
}
