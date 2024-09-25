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
    public class ChiTietVatTuDAL
    {
        connect conn = new connect();
        public int Insert(ChiTietVatTuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", obj.MaVT),
                new SqlParameter("maLP", obj.MaLPhong),
                new SqlParameter("sl", obj.SoLuong)
            };
            return conn.SuaDuLieu("sp_chitietvattu_insert", para);
        }

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_vattu_select_all", null);
        }

        public int Update(ChiTietVatTuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", obj.MaVT),
                new SqlParameter("maLP", obj.MaLPhong),
                new SqlParameter("sl", obj.SoLuong)
            };
            return conn.SuaDuLieu("sp_chitietvattu_update", para);
        }
        
        public int Delete(ChiTietVatTuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", obj.MaVT),
                new SqlParameter("maLP", obj.MaLPhong)
            };
            return conn.SuaDuLieu("sp_chitietvattu_delete", para);
        }

        public int DeleteVT(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", ID)
            };
            return conn.SuaDuLieu("sp_vattu_delete", para);
        }



        public int KiemTraSoLuongbanGhi(ChiTietVatTuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", obj.MaVT),
                new SqlParameter("maLP", obj.MaLPhong)
            };
            return conn.KiemTraSoLuongBanGhi("sp_chitietvattu", para);

        }

        //xem các bản ghi theo mã vật tư
        public DataTable LayDuLieu_Qua_MaVatTu(string maVT)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mavt", maVT)
            };
            return conn.LayDuLieu("sp_select_ctvt_by_mavt", para);
        }

        //xóa dữ liệu qua mã vật tư
        public int XoaDuLieu_Qua_MaVatTu(string maVT)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mavt", maVT)
            };
            return conn.SuaDuLieu("sp_delete_ctvt_by_mavt", para);
        }
    }
}
