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
    public class KhachHangDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_khachhang_select_all", null);
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maKH", ID)
            };
            return  conn.LayDuLieu("sp_khachhang_select_by_id", para);
            
        }

        public int Insert(KhachHangDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maKH", obj.MaKH),
                new SqlParameter("tenKH", obj.TenKH),
                new SqlParameter("gioiTinh", obj.GioiTinh),
                new SqlParameter("soCMND", obj.CMND),
                new SqlParameter("diaChi", obj.DiaChi),
                new SqlParameter("coQuan", obj.CoQuan),
                new SqlParameter("sdt", obj.SDT),
                new SqlParameter("email", obj.Email),
                new SqlParameter("fax", obj.Fax)
            };
            return conn.SuaDuLieu("sp_khachhang_insert", para);
        }

        public int Update(KhachHangDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maKH", obj.MaKH),
                new SqlParameter("tenKH", obj.TenKH),
                new SqlParameter("gioiTinh", obj.GioiTinh),
                new SqlParameter("soCMND", obj.CMND),
                new SqlParameter("diaChi", obj.DiaChi),
                new SqlParameter("coQuan", obj.CoQuan),
                new SqlParameter("sdt", obj.SDT),
                new SqlParameter("email", obj.Email),
                new SqlParameter("fax", obj.Fax)
            };
            return conn.SuaDuLieu("sp_khachhang_update", para);
        }

        public int Delete(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maKH", ID)
            };
            return conn.SuaDuLieu("sp_khachhang_delete", para);
        }

        public DataTable LoadDuLieuKH(string socmnd)
        {
            SqlParameter[] para =
            {
                new SqlParameter("socmnd", socmnd)
            };
            return conn.LayDuLieu("sp_kiemtra_khachhang", para);
        }
    }
}
