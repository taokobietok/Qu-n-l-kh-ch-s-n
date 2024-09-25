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
    public class TaiKhoanDangNhapDAL
    {
        connect conn = new connect();
        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_taikhoanhethong_select_all", null);
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            DataTable data = new DataTable();
            SqlParameter[] para =
            {
                new SqlParameter("tendnhap", ID)
            };
            data = conn.LayDuLieu("sp_taikhoanhethong_select_by_id", para);
            return data;
        }

        public int Insert(TaiKhoanDangNhapDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tendnhap", obj.TenDN),
                new SqlParameter("maNV", obj.MaNV),
                new SqlParameter("pass", obj.MatKhau)
            };
            return conn.SuaDuLieu("sp_taikhoanhethong_insert", para);
        }

        public int Update(TaiKhoanDangNhapDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tendnhap", obj.TenDN),
                new SqlParameter("maNV", obj.MaNV),
                new SqlParameter("pass", obj.MatKhau)
            };
            return conn.SuaDuLieu("sp_taikhoanhethong_update", para);
        }

        public int Delete(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tendnhap", ID)
            };
            return conn.SuaDuLieu("sp_taikhoanhethong_delete", para);
        }
    }
}
