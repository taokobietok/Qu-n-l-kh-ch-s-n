using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    public class HoaDonDAL
    {
        connect conn = new connect();

        private static HoaDonDAL instance;

        public static HoaDonDAL Instance
        {
            get { if (instance == null) instance = new HoaDonDAL(); return HoaDonDAL.instance; }
            private set { HoaDonDAL.instance = value; }
        }
        public DataTable LayDuLieu_All()
        {
            return conn.LayDuLieu("sp_hoadon_select_all", null);
        }
        public DataTable LayDuLieu_HD_ngay(DateTime checkIn, DateTime checkOut)
        {
            return connect.Instance.Test("sp_hoadon_select_ngay @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public int Insert(HoaDonDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mahd",obj.MaHD),
                new SqlParameter("maptp",obj.MaPTP),
                new SqlParameter("makh",obj.MaKH),
                new SqlParameter("ngaytra",obj.NgayTra),
                new SqlParameter("nhanvien",obj.NhanVien),
            };
            return conn.SuaDuLieu("sp_hoadon_insert", para);
        }

        public int Delete(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mahd", ID)
            };
            return conn.SuaDuLieu("sp_hoadon_delete", para);
        }

        public DataTable LayDuLieu_Qua_MaKH(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("makh", ID)
            };
            return conn.LayDuLieu("sp_hoadon_select_by_makh", para);
        }

        //Lấy dữ liệu hóa đơn qua mã phòng
        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.LayDuLieu("sp_select_hd_by_maphong", para);
        }

        //Xóa các bản ghi qua mã phòng
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.SuaDuLieu("sp_delete_hd_by_maphong", para);
        }
    }
}
