using System.Collections.Generic;
using System.Xml;

namespace UngDungDesktop
{
    public class XuLiXml
    {
        // tao mot element bang du lieu dua vao la dictionary
        public XmlElement taoElementThuChi(Dictionary<string,string> duLieuTho)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement data = doc.CreateElement("Data");
            XmlElement elementKetQua = doc.CreateElement("ThuChi");
            foreach (var item in duLieuTho)
            {
                elementKetQua.SetAttribute(item.Key, item.Value);
            }
            doc.AppendChild(data);
            data.AppendChild(elementKetQua);
            return doc.DocumentElement;
        }
        // tao chuoi khi dua vao mot element
        public string taoChuoiXmlTuElement(XmlElement el)
        {
            return el.OuterXml;
        }

        public XmlElement taoElementXmlTuString(string str)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(str);
            return doc.DocumentElement;
        }

        //kiem tra ket qua rong
        // chuoi nay duoc boc trong xml element o ten la (dataset gui tu server)
        public bool kiemTraChuoiRong(string chuoiXml)
        {
            bool kq = true;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(chuoiXml);
            XmlElement goc = doc.DocumentElement;
            //neu khong co phan tu(co du lieu phia trong data set)
            if(goc.FirstChild == null)
            {
                kq = false;
            }
            else
            {
                XmlElement firstChild = (XmlElement)goc.FirstChild;
                // neu co phan tu nhung khong co thuoc tinh thi van sai
                if (firstChild.Attributes.Count == 0)
                    kq = false;
            }
            return kq;
        }



    }
}
