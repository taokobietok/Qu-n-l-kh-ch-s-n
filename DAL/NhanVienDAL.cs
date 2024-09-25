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
    public class NhanVienDAL
    {
        connect conn = new connect();
        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_nhanvien_select_all", null);
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
           
            SqlParameter[] para =
            {
                new SqlParameter("maNV", ID)
            };
            return conn.LayDuLieu("sp_nhanvien_select_by_id", para);
        }

        public int Insert(NhanVienDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maNV", obj.MaNV),
                new SqlParameter("tenNV", obj.TenNV),
                new SqlParameter("ngaysinh", obj.NgaySinh),
                new SqlParameter("gioitinh", obj.GioiTinh),
                new SqlParameter("diachi", obj.DiaChi),
                new SqlParameter("sdt", obj.SDT),
                new SqlParameter("chucvu", obj.ChucVu)
            };
            return conn.SuaDuLieu("sp_nhanvien_insert", para);
        }

        public int Update(NhanVienDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maNV", obj.MaNV),
                new SqlParameter("tenNV", obj.TenNV),
                new SqlParameter("ngaysinh", obj.NgaySinh),
                new SqlParameter("gioitinh", obj.GioiTinh),
                new SqlParameter("diachi", obj.DiaChi),
                new SqlParameter("sdt", obj.SDT),
                new SqlParameter("chucvu", obj.ChucVu),
            };
            return conn.SuaDuLieu("sp_nhanvien_update", para);
        }

        public int Delete(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maNV", ID)
            };
            return conn.SuaDuLieu("sp_nhanvien_delete", para);
        }


        public DataTable LayDuLieuNV_DiLam()
        {
            return conn.LayDuLieu("sp_nhanvien_danglam", null);
        }

        public DataTable LayDuLieuNV_NghiViec()
        {
            return conn.LayDuLieu("sp_nhanvien_nghiviec", null);
        }

        public int NhanVienNghiViec(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("manv", ID)
            };
            return conn.SuaDuLieu("sp_nhanvien_xin_nghiviec", para);
        }
    }
}
