using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ChiTietTaiKhoanDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieuCoTaiKhoan()
        {
            return conn.LayDuLieu("sp_cotaikhoan_select_all", null);
        }
        public DataTable LayDuLieuChuaCoTaiKhoan()
        {
            return conn.LayDuLieu("sp_chuacotaikhoan_select_all", null);
        }
    }
}
