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
    public class PhieuNhanPhongDAL
    {
        connect conn = new connect();
        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_phieuthuephong_select_all", null);
        }

        public int Insert(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPT", obj.MaPNP),
                new SqlParameter("MaPD", obj.MaPDP),
                new SqlParameter("tendnhap", obj.MaNV)
            };
            return conn.SuaDuLieu("sp_phieuthuephong_insert", para);
        }

        public DataTable LayDuLieu_Add_MaPhong()
        {
            return conn.LayDuLieu("sp_ptp_add_maphong", null);
        }

        public DataTable LayDuLieu_Add_MaPhong_DangHoatDong()
        {
            return conn.LayDuLieu("sp_ptp_add_maphong_danghoatdong", null);
        }

        public DataTable LayDuLieu_ChiTietThuePhong(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", ID)
            };
            return conn.LayDuLieu("sp_chitietthuephong_select_all", para);
        }

        public int Insert_ChiTietThuePhong(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", obj.MaPNP),
                new SqlParameter("madv", obj.MaDV),
                new SqlParameter("lansd", obj.LanSD)
            };
            return conn.SuaDuLieu("sp_chitietthuephong_insert", para);
        }

        public DataTable LayDuLieu_ChiTietThuePhong_TheoMaPhieuThue_And_MaDV(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", obj.MaPNP),
                new SqlParameter("madv", obj.MaDV),
            };
            return conn.LayDuLieu("sp_chitietthuephong_select_by_maphieu_and_madv", para);
        }

        public int Update_LuotDungDichVu(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", obj.MaPNP),
                new SqlParameter("madv", obj.MaDV),
            };
            return conn.SuaDuLieu("sp_chitietthuephong_update_luotdung", para);
        }

        public int Xoa_LuotDungDichVu(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", obj.MaPNP),
                new SqlParameter("madv", obj.MaDV),
            };
            return conn.SuaDuLieu("sp_chitietthuephong_update_xoa_luotdung", para);
        }
        public int Xoa_SuDungDichVu(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", obj.MaPNP),
                new SqlParameter("madv", obj.MaDV),
            };
            return conn.SuaDuLieu("sp_chitietthuephong_xoa_sudungdv", para);
        }

        public DataTable LoadMaKhachHang(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", ID)
            };
            return conn.LayDuLieu("sp_loadmakhach_from_phieuthue", para);
        }
        public int Delete(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPT", ID)
            };
            return conn.SuaDuLieu("sp_phieuthuephong_delete", para);
        }

        public int Delete_By_maPDP(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mapd", ID)
            };
            return conn.SuaDuLieu("sp_phieuthuephong_delete_by_mapdp", para);
        }

        public DataTable LayDuLieu_QuaMaPDP(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mapd", ID)
            };
            return conn.LayDuLieu("sp_phieuthuephong_select_by_mapdp", para);
        }


        public int KhoiTaoLuotDung(PhieuNhanPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maptp", obj.MaPNP),
                new SqlParameter("madv", obj.MaDV),
            };
            return conn.SuaDuLieu("sp_chitietthuephong_khoitao_luotdung", para);
        }


        //xem các bản ghi qua mã phòng
        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.LayDuLieu("sp_select_ptp_by_maphong", para);
        }


        //xóa các bản ghi qua mã phòng
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)

            };
            return conn.SuaDuLieu("sp_delete_ptp_by_maphong", para);
        }
    }
}
