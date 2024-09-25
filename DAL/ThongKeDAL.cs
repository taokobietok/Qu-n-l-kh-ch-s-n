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
    public class ThongKeDAL
    {
        connect conn = new connect();
        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_thongke_select_all", null);
        }
        public int Insert(ThongKeDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mahd", obj.MaHD),
                new SqlParameter("tongtien", obj.TongTien)
            };
            return conn.SuaDuLieu("sp_thongke_insert", para);
        }

        //Theo loại phòng
        public DataTable ThongKeTheoLoaiPhong()
        {
            return conn.LayDuLieu("sp_thongke_theo_loaiphong", null);
        }

        //xóa

        public int Delete(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mahd", ID)
            };
            return conn.SuaDuLieu("sp_thongke_delete", para);
        }


        //Xem bản ghi qua mã phòng
        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.LayDuLieu("sp_select_tk_by_maphong", para);
        }


        //Xóa bản ghi theo mã phòng
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.SuaDuLieu("sp_delete_tk_by_maphong", para);
        }
    }
}
