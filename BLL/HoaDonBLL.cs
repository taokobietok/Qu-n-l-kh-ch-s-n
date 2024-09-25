using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class HoaDonBLL
    {
        //hoadon
        #region
        HoaDonDAL dal_hd = new HoaDonDAL();

        public string CapNhatMaHoaDon(string mahdcu)
        {
            string MaHD = mahdcu;
            string strstt = "";

            int STT = int.Parse(MaHD.Substring(2).ToString()) + 1;
            if (STT < 10)
            {
                strstt = "00000" + STT;
            }
            else if (STT < 100)
            {
                strstt = "0000" + STT;
            }
            else if (STT < 1000)
            {
                strstt = "000" + STT;
            }
            else if (STT < 10000)
            {
                strstt = "00" + STT;
            }
            else if (STT < 100000)
            {
                strstt = "0" + STT;
            }
            return "HD" + strstt;
        }
        public DataTable LayDuLieu_AllHD()
        {
            return dal_hd.LayDuLieu_All();
        }
        /*public DataTable LayDuLieu_AllHD_ngay(DateTime checkIn, DateTime checkOut)
        {
            return dal_hd.Instance.LayDuLieu_HD_ngay(checkIn, checkOut);
        }*/
        public DataSet LayDuLieu_AllHD_ngay(DateTime checkIn, DateTime checkOut)
        {
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(HoaDonDAL.Instance.LayDuLieu_HD_ngay(checkIn, checkOut));
            return dataSet;
        }

        public int InsertHD(HoaDonDTO obj)
        {
            return dal_hd.Insert(obj);
        }

        public int DeleteHD(string ID)
        {
            return dal_hd.Delete(ID);
        }

        public DataTable LayDuLieu_Qua_MaKH(string ID)
        {
            return dal_hd.LayDuLieu_Qua_MaKH(ID);
        }

        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            return dal_hd.LayDuLieu_Qua_MaPhong(maP);
        }

        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            return dal_hd.XoaDuLieu_Qua_MaPhong(maP);
        }
        #endregion
        //tienichhoadon
        #region
        TienIchInHoaDonDAL dal = new TienIchInHoaDonDAL();
        public string mahd;
        public string tientra;
        public string date;
        public void InHoaDon(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dal.InHoaDon(date, tientra, mahd, sender, e);
        }
        public DataTable LayDuLieuChiTietHoaDon(string ID)
        {
            return dal.LayDuLieuChiTietHoaDon(ID);
        }
        #endregion
    }
}
