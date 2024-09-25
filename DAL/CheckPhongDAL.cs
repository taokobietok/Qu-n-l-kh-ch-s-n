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
    public class CheckPhongDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieuPhongDaNhan()
        {
            return conn.LayDuLieu("sp_phong_danhan", null);
        }

        public DataTable LayDuLieuPhongDangCho()
        {
            return conn.LayDuLieu("sp_phong_dangcho", null);
        }

        public DataTable LayDuLieuPhongRanhRoi()
        {
            return conn.LayDuLieu("sp_phong_ranhroi", null);
        }

        public int KiemTraSoLuongBanGhiPDN()
        {
            return conn.KiemTraSoLuongBanGhi("sp_phong_danhan", null);
        }

        public int KiemTraSoLuongBanGhiPDD()
        {
            return conn.KiemTraSoLuongBanGhi("sp_phong_dangcho", null);
        }

        public int KiemTraSoLuongBanGhiPRR()
        {
            return conn.KiemTraSoLuongBanGhi("sp_phong_ranhroi", null);
        }


        public DataTable LayDuLieuPhongDaNhanThoaMan(CheckPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("ngayDen", obj.NgayDen),
                new SqlParameter("ngayDi", obj.NgayDi),
                new SqlParameter("thangDen", obj.ThangDen),
                new SqlParameter("thangDi", obj.ThangDi),
                new SqlParameter("namDen", obj.NamDen),
                new SqlParameter("namDi", obj.NamDi),
                new SqlParameter("tenLP", obj.tenLP)
            };
            return conn.LayDuLieu("sp_kiemtra_pdn_theolp", para);

        }
        public DataTable LayDuLieuPhongDaDatThoaMan(CheckPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("ngayDen", obj.NgayDen),
                new SqlParameter("ngayDi", obj.NgayDi),
                new SqlParameter("thangDen", obj.ThangDen),
                new SqlParameter("thangDi", obj.ThangDi),
                new SqlParameter("namDen", obj.NamDen),
                new SqlParameter("namDi", obj.NamDi),
                new SqlParameter("tenLP", obj.tenLP)
            };
            return conn.LayDuLieu("sp_kiemtra_pdd_theolp", para);

        }

        public DataTable LayDuLieuPhongRanhRoiTLP(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tenLP", ID)
            };
            return conn.LayDuLieu("sp_phong_ranhroi_theolp", para);

        }

    }
}
