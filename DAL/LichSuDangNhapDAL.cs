using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class LichSuDangNhapDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_lichsudangnhap_select_all", null);
        }

        public int XoaLichSuDN()
        {
            return conn.SuaDuLieu("sp_lichsudangnhap_delete_all", null);
        }

        public int Insert(LichSuDangNhapDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tendn", obj.TenDN),
                new SqlParameter("tennv", obj.TenNV),
                new SqlParameter("tgian", obj.TGian),
            };
            return conn.SuaDuLieu("sp_lichsudangnhap_insert", para);
        }
    }
}
