using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; //khai báo đối tượng đọc md5

namespace BLL
{
    public class TienIch
    {

        public int TachNam(string ngay)
        {
            int year = 0;
            if (ngay.Length == 0)
            {
                return year;
            }
            else
            {
                if (ngay.Substring(5, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(6, 4).ToString());
                }
                if (ngay.Substring(1, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(5, 4).ToString());
                }
                if (ngay.Substring(3, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(4, 4).ToString());
                }
                if (ngay.Substring(2, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(5, 4).ToString());
                }
            }

            return year;
        }
        public int TachThang(string ngay)
        {
            int month = 0;
            if (ngay.Length == 0)
            {
                return month;
            }
            else
            {
                if (ngay.Substring(1, 1).ToString() == "/")
                {
                    month = int.Parse(ngay.Substring(0, 1).ToString());
                }
                if (ngay.Substring(2, 1).ToString() == "/")
                {
                    month = int.Parse(ngay.Substring(0, 2).ToString());
                }
            }
            return month;
        }
        public int TachNgay(string ngay)
        {
            int day = 0;
            if (ngay.Length == 0)
            {
                return day;
            }
            else
            {
                if (ngay.Substring(5, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(3, 2).ToString());
                }
                if (ngay.Substring(1, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(2, 2).ToString());
                }
                if (ngay.Substring(3, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(2, 1).ToString());
                }
                if (ngay.Substring(2, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(2, 1).ToString());
                }
            }

            return day;
        }
        public string XuLyNgay(DateTime dt)
        {
            int ngay = dt.Day, thang = dt.Month, nam = dt.Year;
            string strngay = ngay.ToString();
            string strthang = thang.ToString();
            string strnam = nam.ToString();
            return strthang + '/' + strngay + '/'  + strnam;
        }
        public string XuLyNgayCheckPhieu(DateTime dt)
        {
            int ngay = dt.Day, thang = dt.Month, nam = dt.Year;
            string strngay = ngay.ToString();
            string strthang = thang.ToString();
            string strnam = nam.ToString();
            return strnam + '/' +strthang + '/' + strngay;
        }

        //Xử lý ngày theo chuỗi
        public string XuLyNgay1(string ngay)
        {
            string day = TachNgay(ngay).ToString();
            string month = TachThang(ngay).ToString();
            string year = TachNam(ngay).ToString();
            return month + '/' + day + '/' + year;

        }
        public string XuLyNgayVietLien(DateTime dt)
        {
            int ngay = dt.Day, thang = dt.Month, nam = dt.Year;
            string strngay = ngay.ToString();
            string strthang = thang.ToString();
            string strnam = nam.ToString();
            if (ngay < 10) strngay = '0' + strngay;
            if (thang < 10) strthang = '0' + strthang;
            return strngay + strthang + strnam;
        }
        public string GetMD5(string chuoi)
        {
            string str_md5 = "";
            //chuyển chuỗi text thành mang byte
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }

            return str_md5;
        }
        public string LoadTimeHienTai()
        {
            DateTime time = DateTime.Now;
            String tgian = time.ToString("hh:mm:ss");
            return tgian;
        }
        
    }
}
