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
    public class PhieuDatPhongDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_phieudatphong_select_all", null);
        }

        public DataTable TatCaPhieuDatPhong()
        {
            return conn.LayDuLieu("sp_phieudatphong_all", null);
        }

        public int Insert(PhieuDatPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPD", obj.MaPD),
                new SqlParameter("maKH", obj.MaKH),
                new SqlParameter("ngayden", obj.NgayDen),
                new SqlParameter("ngaydi", obj.NgayDi),
                new SqlParameter("tiendatcoc", obj.TienCoc),
                new SqlParameter("tendnhap", obj.TenDN),
                new SqlParameter("tinhtrang", obj.TinhTrang),
                new SqlParameter("songuoi", obj.SoNguoi),
                new SqlParameter("ngayLap", obj.NgayLap),
                new SqlParameter("songuoilon", obj.SoNguoiLon),
                new SqlParameter("sotreem", obj.SoTreEm)

            };
            return conn.SuaDuLieu("sp_phieudatphong_insert", para);
        }

        public int Update(PhieuDatPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPD", obj.MaPD),
                new SqlParameter("maKH", obj.MaKH),
                new SqlParameter("ngayden", obj.NgayDen),
                new SqlParameter("ngaydi", obj.NgayDi),
                new SqlParameter("tiendatcoc", obj.TienCoc),
                new SqlParameter("tendnhap", obj.TenDN),
                new SqlParameter("tinhtrang", obj.TinhTrang),
                new SqlParameter("songuoi", obj.SoNguoi),
                new SqlParameter("ngayLap", obj.NgayLap),
                new SqlParameter("songuoilon", obj.SoNguoiLon),
                new SqlParameter("sotreem", obj.SoTreEm)
            };
            return conn.SuaDuLieu("sp_phieudatphong_update", para);
        }

        public int Delete(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPD", ID)
            };
            return conn.SuaDuLieu("sp_phieudatphong_delete", para);
        }

        public int KiemTraPhongThoaMan(PhieuDatPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("namDen", conn.TachNam(obj.NgayDen).ToString()),
                new SqlParameter("namDi", conn.TachNam(obj.NgayDi).ToString()),
                new SqlParameter("thangDen", conn.TachThang(obj.NgayDen).ToString()),
                new SqlParameter("thangDi", conn.TachThang(obj.NgayDi).ToString()),
                new SqlParameter("ngayDen", conn.TachNgay(obj.NgayDen).ToString()),
                new SqlParameter("ngayDi", conn.TachNgay(obj.NgayDi).ToString()),
                new SqlParameter("maP", obj.MaPhong)
            };
            return conn.KiemTraSoLuongBanGhi("sp_kiemtra_theolp_maphong", para);
        }

        public int KiemTraPhongThoaManRanhRoi(string MaP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maP", MaP)
            };
            return conn.KiemTraSoLuongBanGhi("sp_phong_ranhroi_theomp", para);
        }



        ////tesst

        public DataTable LayDL(string MaP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maP", MaP)
            };
            return conn.LayDuLieu("sp_phong_ranhroi_theomp", para);
        }

        public DataTable CheckPhieu(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("homnay", ID)
            };
            return conn.LayDuLieu("sp_check_phieudat", para);
        }
        public int HuyPhieuDatPhong(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("homnay", ID)
            };
            return conn.SuaDuLieu("sp_huy_phieu_datphong", para);
        }


        //load ds phòng rảnh rỗi theo loại phòng
        public DataTable DSPhongRRTheoLP(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tenLP", ID)
            };
            return conn.LayDuLieu("sp_phong_ranhroi_theolp", para);
        }

        public DataTable LayDL_ThepMaPhieu(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPD", ID)
            };
            return conn.LayDuLieu("sp_phieudatphong_select_by_id", para);
        }


        public DataTable LayDuLieu_QuaIMaKH(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maKH", ID)
            };
            return conn.LayDuLieu("sp_phieudatphong_select_by_makh", para);
        }

        public DataTable Delete_QuaIMaKH(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("makh", ID)
            };
            return conn.LayDuLieu("sp_phieudatphong_delete_by_makh", para);
        }

        //Xem bản ghi qua mã phòng
        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.LayDuLieu("sp_select_pdp_by_maphong", para);
        }


        //xóa dữ liệu qua mã phòng
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.SuaDuLieu("sp_delete_pdp_by_maphong", para);
        }
    }
}
