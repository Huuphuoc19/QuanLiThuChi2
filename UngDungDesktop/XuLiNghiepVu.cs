using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace UngDungDesktop
{
    public class XuLiNghiepVu
    {
        private XuLiLuuTruClient xuLiLuuTruClient = new XuLiLuuTruClient();
        private XuLiXml xuLiXml = new XuLiXml();
        // lay ds thanh vien hien thi ra combobox thu/chi
        public XmlElement layDanhSachThanhVien()
        {
            return xuLiLuuTruClient.layDanhSachThanhVien();
        }

        // them mot khoan thu chi
        public string themThuChi(XmlElement duLieu)
        {
            string kq = "";
            kq = xuLiLuuTruClient.themThuChi(duLieu);
            return kq;
        }

        // thong ke theo nam
        public XmlElement layDanhSachThongKeNam(int offset,int limit)
        {
            string kq = "";          
            kq = xuLiLuuTruClient.layThongKeNam(offset, limit);
            XmlElement kqXml = null;
            if (xuLiXml.kiemTraChuoiRong(kq))
            {
                kqXml = xuLiXml.taoElementXmlTuString(kq);
            }
            return kqXml;
        }

        // thong ke theo thang
        public XmlElement layDanhSachThongKeThangTheoNam(string nam)
        {
            string kq = "";
            kq = xuLiLuuTruClient.layThongKeThangTheoNam(nam);
            XmlElement kqXml = null;
            if (xuLiXml.kiemTraChuoiRong(kq))
            {
                kqXml = xuLiXml.taoElementXmlTuString(kq);
            }
            return kqXml;
        }

        // xu li thong ke thanh vien theo nam
        public XmlElement layThongKeThanhVienTheoNam(string nam,int idGiaDinh)
        {
            string kq = "";
            kq = xuLiLuuTruClient.layThongKeThanhVienTheoNam(nam, idGiaDinh);
            XmlElement kqXml = null;
            if (xuLiXml.kiemTraChuoiRong(kq))
            {
                kqXml = xuLiXml.taoElementXmlTuString(kq);
            }
            return kqXml;
        }

        // xu li thong ke thanh vien theo thang
        public XmlElement layThongKeThanhVienTheoThang(string nam,string thang, int idGiaDinh)
        {
            string kq = "";
            kq = xuLiLuuTruClient.layThongKeThanhVienTheoThang(nam,thang, idGiaDinh);
            XmlElement kqXml = null;
            if (xuLiXml.kiemTraChuoiRong(kq))
            {
                kqXml = xuLiXml.taoElementXmlTuString(kq);
            }
            return kqXml;
        }

        // goi tim kiem kiem tra rong
        public XmlElement timKiem(XmlElement duLieu)
        {
            string kq = "";
            string duLieuTimKiem = xuLiXml.taoChuoiXmlTuElement(duLieu);
            kq = xuLiLuuTruClient.timKiem(duLieuTimKiem);
            XmlElement kqXml = null;
            if (xuLiXml.kiemTraChuoiRong(kq))
            {
                kqXml = xuLiXml.taoElementXmlTuString(kq);
            }
            return kqXml;
        }

        public int layIdThuChiChung(int idGiaDinh)
        {
            string kq = "";
            kq = xuLiLuuTruClient.layIdThuChiChung(idGiaDinh);
            if(kq == "-1")
            {
                return -1;
            }
            return Convert.ToInt32(kq);
        }

        // tinh chenh lench thu chi
        public string tinhChenhLech(string thu, string chi)
        {
            int thuInt = Convert.ToInt32(thu);
            int chiInt = Convert.ToInt32(chi);
            return (thuInt - chiInt).ToString();
        }

        // tao chuoi tim kiem theo du lieu nhap vao
        public XmlElement taoElementTimKiem(Dictionary<string,string> duLieu)
        {

            string HoTen = duLieu.ContainsKey("HoTen") ? duLieu["HoTen"] : "";
            string SoTien = duLieu.ContainsKey("SoTien") ? duLieu["SoTien"] : "";
            string Ngay = duLieu.ContainsKey("Ngay") ? duLieu["Ngay"] : "";
            string Thang = duLieu.ContainsKey("Thang") ? duLieu["Thang"] : "";
            string ChungRieng = duLieu.ContainsKey("ChungRieng") ? duLieu["ChungRieng"] : "";
            string idChungRieng = duLieu.ContainsKey("IdChungRieng") ? duLieu["IdChungRieng"] : "";
            string idGiaDinh = duLieu.ContainsKey("IdGiaDinh") ? duLieu["IdGiaDinh"] : "";

            XmlElement kq = null;
            XmlDocument doc = new XmlDocument();
            XmlElement data = doc.CreateElement("Data");
            XmlElement el = doc.CreateElement("DuLieuTimKiem");
            // <Data><DuLieuTimKiem HoTen="" SoTien="" Ngay="" Thang="" ChungRieng="" IdChungRieng="" IdGiaDinh="">
            el.SetAttribute("HoTen", HoTen);
            el.SetAttribute("SoTien", SoTien);
            el.SetAttribute("Ngay", Ngay);
            el.SetAttribute("Thang", Thang);
            el.SetAttribute("ChungRieng", ChungRieng);
            el.SetAttribute("IdChungRieng", idChungRieng);
            el.SetAttribute("IdGiaDinh", idGiaDinh);

            data.AppendChild(el);
            doc.AppendChild(data);
            kq = doc.DocumentElement;
            return kq;
        }

        // chuyen mot xml element thanh data table
        // Tai sao khong conver element -> string -> loadstring by data set -> return table of data set ???
        public DataTable xmlToDataTable(XmlElement duLieu, int idThuChiChung)
        {
            DataTable table = new DataTable();
            XmlNodeList list = duLieu.ChildNodes;
            int length = list.Count;
            if(length > 0)
            {
                int soThuocTinh = list[0].Attributes.Count;
                for(int i = 0; i < soThuocTinh; i++)
                {
                    DataColumn col = new DataColumn();
                    col.ColumnName = list[0].Attributes[i].Name;
                    table.Columns.Add(col);
                }

                for(int i = 0; i < length; i++)
                {
                    DataRow row = table.NewRow();

                    /*
                    for(int j = 0; j < soThuocTinh; j++)
                    {
                        var data = list[i].Attributes[j];
                        row[data.Name] = data.Value;
                    }*/

                    var data = list[i].Attributes;
                    row["ID"] = data["ID"].Value;
                    if(data["ID"].Value == idThuChiChung.ToString())
                    {
                        row["HoTen"] = "Thu chi chung";
                    }
                    else
                    {
                        row["HoTen"] = data["HoTen"].Value;
                    }

                    DateTime date;
                    DateTime.TryParse(data["NgayThuChi"].Value, out date);

                    row["SoTien"] = data["SoTien"].Value;
                    row["NgayThuChi"] = date.ToString("MMM dd, yyyy (dd/MM/yyyy)");
                    row["GhiChu"] = data["GhiChu"].Value;
                    table.Rows.Add(row);
                }

            }
            return table;
        }
    }
}