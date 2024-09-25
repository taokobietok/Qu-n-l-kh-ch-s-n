using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ChiTietThuePhongDAL
    {
        connect conn = new connect();

        //xóa
        public int Delete(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", ID)
            };
            return conn.SuaDuLieu("sp_chitietthuephong_delete", para);
        }

        //xem các bản ghi qua mã phòng
        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.LayDuLieu("sp_select_ctptp_by_maphong", para);
        }

        //xóa bản ghi qua mã phòng
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.SuaDuLieu("sp_delete_ctptp_by_maphong", para);
        }
    }
}
