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
    public class DangNhapDAL
    {
        connect conn = new connect();
        public int KiemTraSoLuongbanGhi(DangNhapDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tenDN", obj.TenDN),
                new SqlParameter("matKhau", obj.MatKhau)
            };
            return conn.KiemTraSoLuongBanGhi("sp_login", para);

        }

        public DataTable ChiTietTaiKhoan(DangNhapDTO obj)
        {
            DataTable data = new DataTable();
            SqlParameter[] para =
            {
                new SqlParameter("tenDN", obj.TenDN),
                new SqlParameter("matKhau", obj.MatKhau)
            };
            data = conn.ChiTietTaiKhoan("sp_login", para);
            return data;
        }
    }
}
