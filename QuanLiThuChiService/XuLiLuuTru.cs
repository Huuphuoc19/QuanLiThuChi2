using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using System.Data.OleDb;

namespace QuanLiThuChiService
{

    public enum CONG_NGHE_LUU_TRU
    {
        CSDL,
        XML
    }

    public enum LOAI_CSDL
    {
        Access,SQLServer,Oracle
    }

    public class XuLiLuuTru
    {
        // thu muc chua solution và project
        private static DirectoryInfo thuMucProject = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
        private static DirectoryInfo thuMucSolution = thuMucProject.Parent;

        // thu muc chua database
        private static string thuMucDatabase = thuMucSolution.FullName + @"\Data";
        private static string thuMucCSDL = thuMucDatabase + @"\CSDL";
        private static string thuMucMedia = thuMucDatabase + @"\Media";
        private static string thuMucLog = thuMucDatabase + @"\Log\";

        // thong tin ve phan mem
        private string tenUngDung = "QuanLiThuChiGiaDinh";

        //du lieu 
        private string tenDuLieuLuuTru = "quanlithuchi";
        private string duoiMoRong = ".mdb";
        private CONG_NGHE_LUU_TRU congNgheLuuTru = CONG_NGHE_LUU_TRU.CSDL;
        private LOAI_CSDL loaiCSDL = LOAI_CSDL.Access;
        
        //chuoi ket noi csdl
        private string chuoiKetNoiCSDL = "";
        private string duongDanAccessFile = "";

        // ten thu chi chung 
        private const string THU_CHI_CHUNG = "XXXYYYZZZ";
        private const string ERROR = "ERROR";

        public void LogMessageToFile(string msg)
        {
            msg = thuMucLog;
            StreamWriter sw = File.AppendText(
                thuMucLog + "log.txt");
            try
            {
                string logLine = System.String.Format(
                    "{0:G}: {1}", System.DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }

        public XuLiLuuTru()
        {
            // neu dung co so du lieu de luu tru
            if(congNgheLuuTru == CONG_NGHE_LUU_TRU.CSDL)
            {
                string chuoiMacDinh = @"Provider = Microsoft.Jet.OLEDB.4.0;Data Source = ";
                // xet xem su dung loai csdl nao
                switch (loaiCSDL)
                {
                    case LOAI_CSDL.Access:
                        {                           
                            duongDanAccessFile = thuMucCSDL + @"\" + tenDuLieuLuuTru + duoiMoRong;
                            chuoiKetNoiCSDL = chuoiMacDinh + duongDanAccessFile;
                        }break;
                    default:break;
                }
            }
        }

        #region Xu li doc - ghi du lieu

        // doc tat cac cac bang
        public XmlElement docTatCaBangDuLieu()
        {
            XmlElement kq = null;
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        kq = docTatCaDuLieuTuCSDL();
                    }break;
                default: break;
            }
            return kq;
        }

        // doc mot bang
        public XmlElement docMotBangDuLieu(string tenBang,string dieuKien = "")
        {
            XmlElement kq = null;
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        kq = docMotBangTuCSDL(tenBang,dieuKien);
                    }
                    break;
                default: break;
            }
            return kq;
        }

        // ghi du lieu theo bang
        public string ghiDuLieuMoiTheoDoiTuong(XmlElement duLieuXML)
        {
            string kq = "";
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    { 
                        kq = ghiMoiDuLieuTheoLoaiCSDL(duLieuXML);
                    }break;
                default: break;
            }
            return kq;
        }

        // cap nhat du lieu theo bang
        public string capNhatDulieuTheoDoiTuong(XmlElement duLieuXML)
        {
            string kq = "";
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        kq = capNhatDuLieuTheoLoaiCSDL(duLieuXML);
                    }
                    break;
                default: break;
            }
            return kq;
        }
        
        // thong ke theo nam, lau du lieu tu dong thu offset va gioi han limit dong
        // tra ve element co cac attri NAM,SoTienThu,SoTienChi

       // thong ke theo nam
        public XmlElement thongKeTheoNam(int offset,int limit)
        {
            XmlElement kq = null;
            DataSet dataSet = new DataSet();
            string flag = "";
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        flag = thongKeTheoNamTheoLoaiCSDL(dataSet,offset, limit);                       
                    }
                    break;
                default: break;
            }
            if (flag == "")
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(dataSet.GetXml());
                kq = doc.DocumentElement;
            }
            return kq;
        }

        // thong ke theo nam, lau du lieu tu dong thu offset va gioi han limit dong
        // tra ve element co cac attri Thang,SoTienThu,SoTienChi
        public XmlElement thongKeTheoThang(string Nam)
        {
            XmlElement kq = null;
            DataSet dataSet = new DataSet();
            string flag = "";
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        flag = thongKeTheoThangMSAccess(dataSet, Nam);
                    }
                    break;
                default: break;
            }
            if (flag == "")
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(dataSet.GetXml());
                kq = doc.DocumentElement;
            }
            return kq;
        }

        // truyen vao nam muon thong ke
        public XmlElement thongKeThuChiThanhVienTheoNam(string Nam,int idGiaDinh)
        {
            XmlElement kq = null;
            DataSet dataSet = new DataSet();
            string flag = "";
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        flag = thongKeThuChiThanhVienTheoNamTheoLoaiCSDL(dataSet, Nam,idGiaDinh);
                    }
                    break;
                default: break;
            }
            if (flag == "")
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(dataSet.GetXml());
                kq = doc.DocumentElement;
            }
            return kq;
        }

        // truyen vao thang va nam nam muon thong ke
        public XmlElement thongKeThuChiThanhVienTheoThang(string Nam,string Thang, int idGiaDinh)
        {
            XmlElement kq = null;
            DataSet dataSet = new DataSet();
            string flag = "";
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        flag = thongKeThuChiThanhVienTheoThangTheoLoaiCSDL(dataSet, Nam, Thang, idGiaDinh);
                    }
                    break;
                default: break;
            }
            if (flag == "")
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(dataSet.GetXml());
                kq = doc.DocumentElement;
            }
            return kq;
        }

        // tim kiem theo cac tieu chi (xml)
        public XmlElement timKiem(XmlElement duLieuDauVao)
        {
            XmlElement kq = null;
            DataSet dataSet = new DataSet();
            string flag = "";
            string HoTen = duLieuDauVao.Attributes["HoTen"].Value;
            string SoTien = duLieuDauVao.Attributes["SoTien"].Value;
            string Ngay = duLieuDauVao.Attributes["Ngay"].Value;
            string Thang = duLieuDauVao.Attributes["Thang"].Value;
            string chungRieng = duLieuDauVao.Attributes["ChungRieng"].Value;
            int idChungRieng = Convert.ToInt32(duLieuDauVao.Attributes["IdChungRieng"].Value);
            int idGiaDinh = Convert.ToInt32(duLieuDauVao.Attributes["IdGiaDinh"].Value);
            switch (congNgheLuuTru)
            {
                case CONG_NGHE_LUU_TRU.CSDL:
                    {
                        flag = timKiemThuChiTheoLoaiCSDL(dataSet, HoTen, SoTien, Ngay, Thang, chungRieng, idChungRieng, idGiaDinh);
                    }
                    break;
                default: break;
            }
            if (flag == "")
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(dataSet.GetXml());
                kq = doc.DocumentElement;
            }
            return kq;
        }

        // lay thong ke t hu chi chung
        public string layIdThuChiChung(int idGiaDinh)
        {
            string kq = "";
            kq = layIDdThuChiChungTheoLoaiCSDL(idGiaDinh);
            if(kq == ERROR)
            {
                kq = "-1";
            }
            return kq;
        }

        #endregion

        #region các hàm hỗ trợ đọc ghi
        // doc tat ca du lieu tu csdl tra ve xml element
        private XmlElement docTatCaDuLieuTuCSDL()
        {
            XmlElement kq = null;

            DataSet dataSet = new DataSet();
            docBangTheoLoaiCSDL(dataSet, "ThanhVien");
            docBangTheoLoaiCSDL(dataSet, "ThuChi");
            string ketQuaXml = dataSet.GetXml();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ketQuaXml);
            kq = doc.DocumentElement;
            return kq;
        }

        // doc mot bang tu csdl tra ve xml element
        private XmlElement docMotBangTuCSDL(string tenBang,string dieuKien = "")
        {
            XmlElement kq = null;

            DataSet dataSet = new DataSet();
            docBangTheoLoaiCSDL(dataSet, tenBang,dieuKien);
            string ketQuaXml = dataSet.GetXml();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ketQuaXml);
            kq = doc.DocumentElement;

            return kq;
        }
        #endregion
        #region ham trung gian goi toi ham xu li du lieu phu hop tuy theo loai du lieu
        // dua vao loai csdl ma goi ham doc du lieu phu hop
        private DataTable docBangTheoLoaiCSDL(DataSet dataSetKetQua,string tenBang,string dieuKien = "")
        {
            DataTable kq = null;
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = docBangMSAccess(dataSetKetQua, tenBang, dieuKien);
                    }break;
                default:
                    break;
            }
            return kq;
        }

        // ghi moi du lieu
        private string ghiMoiDuLieuTheoLoaiCSDL(XmlElement duLieuXml)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = ghiDuLieuAccess(duLieuXml);
                    }break;
                default:
                    {
                    }break;
            }
            return kq;
        }

        private string capNhatDuLieuTheoLoaiCSDL(XmlElement duLieuXml)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = capNhatDuLieuAccess(duLieuXml);
                    }break;
                default:
                    break;
            }
            return kq;
        }

        private string thongKeTheoNamTheoLoaiCSDL(DataSet dataSetKetQua,int offset,int limit)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = thongKeTheoNamMSAccess(dataSetKetQua,offset, limit);
                    }
                    break;
                default:
                    break;
            }
            return kq;
        }

        private string thongKeTheoThangTheoLoaiCSDL(DataSet dataSetKetQua, string Nam)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = thongKeTheoThangMSAccess(dataSetKetQua, Nam);
                    }
                    break;
                default:
                    break;
            }
            return kq;
        }

        private string thongKeThuChiThanhVienTheoNamTheoLoaiCSDL(DataSet dataSetKetQua, string nam,int idGiaDinh)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = thongKeThuChiThanhVienTheoNamMSAccess(dataSetKetQua, nam, idGiaDinh);
                    }
                    break;
                default:
                    break;
            }
            return kq;
        }

        private string thongKeThuChiThanhVienTheoThangTheoLoaiCSDL(DataSet dataSetKetQua, string nam,string thang, int idGiaDinh)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = thongKeThuChiThanhVienTheoThangMSAccess(dataSetKetQua, nam,thang, idGiaDinh);
                    }
                    break;
                default:
                    break;
            }
            return kq;
        }

        private string timKiemThuChiTheoLoaiCSDL(DataSet dataSetKetQua,string hoten, string sotien, string ngay, string thang, string chungRieng,int idChungRieng,int idGiaDinh)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = timKiemMSAccess(dataSetKetQua, hoten,sotien, ngay, thang, chungRieng, idChungRieng, idGiaDinh);
                    }
                    break;
                default:
                    break;
            }
            return kq;
        }

        private string layIDdThuChiChungTheoLoaiCSDL(int idGiaDinh)
        {
            string kq = "";
            switch (loaiCSDL)
            {
                case LOAI_CSDL.Access:
                    {
                        kq = layIdThuChiChungMSAccess(idGiaDinh);
                    }
                    break;
                default:
                    break;
            }
            return kq;
        }

        #endregion

        #region xu li du lieu voi MS Access

        private DataTable docBangMSAccess(DataSet dataSetKetQua, string tenBang,string dieuKien = "")
        {
            DataTable dataTableKetQua = new DataTable();
            // xu li du lieu voi OELDB
            try
            {
                using (OleDbConnection connection = new OleDbConnection(chuoiKetNoiCSDL))
                {
                    
                    string sql = @"SELECT * FROM " + tenBang;
                    // xu li dieu kien
                    if(dieuKien != "")
                    {
                        sql += " WHERE " + dieuKien;
                    }
                    // truy van dien ket quan vao data table
                    OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection);
                    adapter.FillSchema(dataTableKetQua, SchemaType.Source);
                    adapter.Fill(dataTableKetQua);
                    dataTableKetQua.TableName = tenBang;
                    // them vao dataset
                    if (dataSetKetQua != null)
                    {
                        dataSetKetQua.Tables.Add(dataTableKetQua);
                    }

                    // mapping data table den xml theo thuoc tinh
                    dataTableKetQua.Columns[0].ReadOnly = false;
                    foreach(DataColumn col in dataTableKetQua.Columns)
                    {
                        col.ColumnMapping = MappingType.Attribute;
                    }


                }
            }
            catch(Exception ex)
            {
                // thong bao loi
                dataTableKetQua.ExtendedProperties["Error"] = ex.Message;
            }
            return dataTableKetQua;
        }

        private string ghiDuLieuAccess(XmlElement duLieuXml)
        {
            string kq = "";
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                string tenBang = duLieuXml.Name;
                string sql = "INSERT INTO " + tenBang;
                string columns = " (";
                string values = " VALUES (";
                foreach (XmlNode node in duLieuXml.Attributes)
                {
                    if (node.Name != "ID")
                    {
                        values += "'" + node.Value + "',";
                        columns += node.Name + ",";
                    }
                }

                values = values.Substring(0, values.Length - 1);
                columns = columns.Substring(0, columns.Length - 1);
                values += ");";
                columns += ")";

                sql += columns + values;
                
                conn.Open();
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        private string capNhatDuLieuAccess(XmlElement duLieuXml)
        {
            string kq = "";
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                string tenBang = duLieuXml.Name;
                string sql = "UPDATE " + tenBang + " SET ";
               
                foreach (XmlNode node in duLieuXml.Attributes)
                {
                    if (node.Name != "ID")
                    {
                       sql += node.Name + " = '" + node.Value + "',";
                    }
                }
                sql = sql.Substring(0, sql.Length - 1);
                sql += " WHERE ID = " + duLieuXml.Attributes["ID"].Value;
                conn.Open();
                OleDbCommand command = new OleDbCommand(sql, conn);

                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        /*
         * có group by neu truy van khong du lieu -> khong tra du lieu ve
         * ko co group by neu truy van khong du lieu -> van tra ve 
         * */

        // tra ve Dat table gom cac cot Nam,SoTienThu,SoTienChi
        private string thongKeTheoNamMSAccess(DataSet dataSetKetQua,int offset,int limit)
        {
            string kq = "";
            string sql;
            if (offset != 0)
            {
                sql = String.Format(@"SELECT TOP {0}
                                        YEAR(tc.NgayThuChi) AS Nam,
                                        SUM(IIF(tc.LoaiThuChi = 'Thu',tc.SoTien,0)) AS SoTienThu,
                                        SUM(IIF(tc.LoaiThuChi = 'Chi',tc.SoTien,0)) AS SoTienChi
                                        FROM ThuChi AS tc
                                        WHERE YEAR(tc.NgayThuChi) NOT IN (SELECT TOP {1} YEAR(tc1.NgayThuChi) AS Nam FROM ThuChi AS tc1 GROUP BY YEAR(tc1.NgayThuChi) ORDER BY Year(tc1.NgayThuChi) DESC )
                                        GROUP BY YEAR(tc.NgayThuChi)
                                        ORDER BY YEAR(tc.NgayThuChi) DESC",
                                        limit.ToString(), offset.ToString());
            }else
            {
                sql = String.Format(@"SELECT TOP {0}
                                        YEAR(tc.NgayThuChi) AS Nam,
                                        SUM(IIF(tc.LoaiThuChi = 'Thu',tc.SoTien,0)) AS SoTienThu,
                                        SUM(IIF(tc.LoaiThuChi = 'Chi',tc.SoTien,0)) AS SoTienChi
                                        FROM ThuChi AS tc
                                        GROUP BY YEAR(tc.NgayThuChi)
                                        ORDER BY YEAR(tc.NgayThuChi) DESC",
                                        limit.ToString());
            }
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                DataTable ketQuaTruyVan = new DataTable();
                adapter.FillSchema(ketQuaTruyVan, SchemaType.Source);
                adapter.Fill(ketQuaTruyVan);

                dataSetKetQua.Tables.Add(ketQuaTruyVan);
                ketQuaTruyVan.TableName = "ThongKeTheoNam";
                foreach (DataColumn col in ketQuaTruyVan.Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }
               
                
            }
            catch(Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        // tra ve Dat table gom cac cot Nam,SoTienThu,SoTienChi
        private string thongKeTheoThangMSAccess(DataSet dataSetKetQua, string Nam)
        {
            string kq = "";
            string sql = String.Format(@"SELECT 
                                        Year(tc.NgayThuChi) AS Nam,
                                        Month(tc.NgayThuChi) AS Thang, 
                                        Sum(IIF(tc.LoaiThuChi = 'Thu',tc.SoTien,0)) AS SoTienThu, 
                                        Sum(IIF(tc.LoaiThuChi = 'Chi',tc.SoTien,0)) AS SoTienChi
                                        FROM ThuChi AS tc
                                        WHERE Year(tc.NgayThuChi) = {0}
                                        GROUP BY Year(tc.NgayThuChi),Month(tc.NgayThuChi)
                                        ORDER BY Month(tc.NgayThuChi) ASC",
                                        Nam);
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                DataTable ketQuaTruyVan = new DataTable();
                adapter.FillSchema(ketQuaTruyVan, SchemaType.Source);
                adapter.Fill(ketQuaTruyVan);

                dataSetKetQua.Tables.Add(ketQuaTruyVan);
                ketQuaTruyVan.TableName = "ThongKeTheoThang";
                foreach (DataColumn col in ketQuaTruyVan.Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }
             
            }
            catch (Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        private string thongKeThuChiThanhVienTheoNamMSAccess(DataSet dataSetKetQua, string Nam,int idGiaDinh)
        {
            string kq = "";
            string sql = String.Format(@"SELECT 
                                        tv.ID, tv.HoTen,
                                        SUM(IIF(tc.LoaiThuChi = 'Thu',tc.SoTien,0)) AS SoTienThu,
                                        SUM(IIF(tc.LoaiThuChi = 'Chi',tc.SoTien,0)) AS SoTienChi
                                        FROM (SELECT * FROM ThanhVien WHERE IdGiaDinh = {1})  AS tv
                                        LEFT JOIN ThuChi AS tc
                                        ON (tv.ID = tc.IdThanhVien
                                        AND YEAR(tc.NgayThuChi) = {0})
                                        GROUP BY tv.ID, tv.HoTen,YEAR(tc.NgayThuChi)",
                                        Nam,idGiaDinh.ToString());
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                DataTable ketQuaTruyVan = new DataTable();
                adapter.FillSchema(ketQuaTruyVan, SchemaType.Source);
                adapter.Fill(ketQuaTruyVan);

                dataSetKetQua.Tables.Add(ketQuaTruyVan);
                ketQuaTruyVan.TableName = "ThongKeThuChiThanhVienTheoNam";
                foreach (DataColumn col in ketQuaTruyVan.Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }

            }
            catch (Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        private string thongKeThuChiThanhVienTheoThangMSAccess(DataSet dataSetKetQua, string Nam,string Thang, int idGiaDinh)
        {
            string kq = "";
            string sql = String.Format(@"SELECT 
                                        tv.ID, tv.HoTen, YEAR(tc.NgayThuChi) AS Nam, MONTH(tc.NgayThuChi) AS Thang, 
                                        SUM(IIF(tc.LoaiThuChi = 'Thu',tc.SoTien,0)) AS SoTienThu,
                                        SUM(IIF(tc.LoaiThuChi = 'Chi',tc.SoTien,0)) AS SoTienChi
                                        FROM (SELECT * FROM ThanhVien WHERE IdGiaDinh = {2})  AS tv
                                        LEFT JOIN ThuChi AS tc
                                        ON (tv.ID = tc.IdThanhVien
                                        AND YEAR(tc.NgayThuChi) = {0} AND MONTH(tc.NgayThuChi) = {1})
                                        GROUP BY  tv.ID, tv.HoTen, YEAR(tc.NgayThuChi), MONTH(tc.NgayThuChi)",
                                        Nam,Thang, idGiaDinh.ToString());
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                DataTable ketQuaTruyVan = new DataTable();
                adapter.FillSchema(ketQuaTruyVan, SchemaType.Source);
                adapter.Fill(ketQuaTruyVan);

                dataSetKetQua.Tables.Add(ketQuaTruyVan);
                ketQuaTruyVan.TableName = "ThongKeThuChiThanhVienTheoThang";
                foreach (DataColumn col in ketQuaTruyVan.Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }

            }
            catch (Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        
        private string timKiemMSAccess(DataSet dataSetKetQua,string HoTen,string SoTien, string Ngay, string Thang,string chungRieng,int idChungRieng, int idGiaDinh)
        {

            // kiểm tra xem điều kiện nào không có thì không thêm vào
            string sqlHoTen = (HoTen != "") ? "AND tv.HoTen = '" + HoTen + "' " : "";
            string sqlNgay = (Ngay != "") ? "AND tc.NgayThuChi = #" + Ngay + "# " : "";
            string sqlThang = "";
            if(Thang != "")
            {
                string[] temp = Thang.Split(':');
                sqlThang = "AND MONTH(tc.NgayThuChi) = " + temp[0] + " AND YEAR(tc.NgayThuChi) = " + temp[1];
            }
            string sqlChungRieng = "";
            if(chungRieng != "")
            {
                if(chungRieng.ToLower() == "chung")
                {
                    sqlChungRieng = "AND tv.ID = " + idChungRieng.ToString();
                }else
                {
                    sqlChungRieng = "AND tv.ID <> " + idChungRieng.ToString();
                }
            }
            string sqlSoTien = (SoTien != "") ? "AND tc.SoTien = " + SoTien : "";
            string sql = String.Format(@"SELECT tv.ID,tv.HoTen,tc.SoTien,tc.NgayThuChi,tc.GhiChu
                                            FROM ThuChi AS tc
                                            INNER JOIN ThanhVien AS tv
                                            ON (tc.IdThanhVien = tv.ID AND tv.IdGiaDinh = {5})
                                            WHERE 1 = 1 {0} {1} {2} {3} {4}",
                                            sqlHoTen, sqlSoTien, sqlNgay, sqlThang, sqlChungRieng,idGiaDinh.ToString());

            string kq = "";
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
                DataTable ketQuaTruyVan = new DataTable();
                adapter.FillSchema(ketQuaTruyVan, SchemaType.Source);
                adapter.Fill(ketQuaTruyVan);

                dataSetKetQua.Tables.Add(ketQuaTruyVan);
                ketQuaTruyVan.TableName = "ThongKeThuChiThanhVienTheoThang";
                foreach (DataColumn col in ketQuaTruyVan.Columns)
                {
                    col.ColumnMapping = MappingType.Attribute;
                }

            }
            catch (Exception ex)
            {
                kq = ex.Message;
            }
            return kq;
        }

        private string layIdThuChiChungMSAccess(int idGiaDinh)
        {
            string sql = @"SELECT ID FROM ThanhVien WHERE IdGiaDinh = @idGiaDinh AND HoTen = @hoten";
 
            string kq = "";
            try
            {
                OleDbConnection conn = new OleDbConnection(chuoiKetNoiCSDL);
                OleDbCommand command = new OleDbCommand(sql,conn);
                OleDbParameter[] param = new OleDbParameter[]
                {
                    new OleDbParameter()
                    {
                        ParameterName = "@idGiaDinh",
                        Value = idGiaDinh.ToString()
                    },
                    new OleDbParameter()
                    {
                        ParameterName = "@hoten",
                        Value = THU_CHI_CHUNG.ToString()
                    }
                };
                command.Parameters.AddRange(param);
                conn.Open();
                int idThuChiChung = (int)command.ExecuteScalar();
                conn.Close();
                kq = idThuChiChung.ToString();
            }
            catch (Exception ex)
            {
                kq = ERROR;
            }
            return kq;
        }
        #endregion


    }
}