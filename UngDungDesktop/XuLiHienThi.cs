using System;
using System.Globalization;
using System.Windows.Forms;

namespace UngDungDesktop
{
    public class XuLiHienThi
    {
        // xu li chuoi dau vao
        public string nhapChuoi(Control control)
        {
            string kq = "";
            if(control.GetType() == typeof(ComboBox))
            {
                ComboBox cbb = (ComboBox)control;
                kq = cbb.SelectedValue.ToString();
            }else if (control.GetType() == typeof(TextBox))
            {
                kq = control.Text.Trim();
                //escape string sql injection
                kq = kq.Replace("'", @"''");
            }
            return kq;
        }

        // convert chuoi sang ngay thang
        public DateTime stringToDateTime(string input)
        {
            DateTime kq = new DateTime(1970,1,1);

            string[] formats = {"dd/MM/yyyy","d/MM/yyyy","dd/M/yyyy","d/M/yyyy",
                                 "dd-MM-yyyy","d-MM-yyyy","dd-M-yyyy","d-M-yyyy",
                                 "MM/yyyy","M/yyyy",
                                 "MM-yyyy","M-yyyy",
                                };

            DateTime dateValue;
            if (DateTime.TryParseExact(input, formats,new CultureInfo("en-US"),DateTimeStyles.None,out dateValue))
            {
                kq = dateValue;
            }
            return kq;
        }

        // kkiem tra ngay null
        public bool kiemTraNgayNull(DateTime date)
        {
            return (date.ToShortDateString() == "1/1/1970") ? true : false;
        }

        // kiem tran string la so
        public bool kiemTraLaSo(string input)
        {
            int value = -1;
            if (int.TryParse(input,out value))
            {
                return true;
            }
            return false;
        }

        // kiem tra mot string co nam trong mang string
        public bool kiemTraInputInData(string[] data,string input)
        {
            int l = data.Length;
            for(int i = 0; i < l; i++)
            {
                if (data[i].ToUpper() == input.ToUpper())
                    return true;
            }
            return false;
        }
    }
       
}
