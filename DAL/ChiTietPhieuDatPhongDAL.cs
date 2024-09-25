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
    public class ChiTietPhieuDatPhongDAL
    {
        connect conn = new connect();

        public int Insert(ChiTietPhieuDatPhongDTO obj)
        {
            SqlParameter[] para =
           {
                new SqlParameter("maPD", obj.MaPD),
                new SqlParameter("maP", obj.MaP)
            };
            return conn.SuaDuLieu("sp_chitietdatphong_insert", para);
        }
        public DataTable LayDuLieu(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maPD", ID)
            };
            return conn.LayDuLieu("sp_chitietdatphong_select_by_id", null);
        }

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_chitietdatphong_select_all", null);
        }

        public int Delete(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaPD", ID)
            };
            return conn.SuaDuLieu("sp_chitietdatphong_delete", para);
        }

        public int Update(ChiTietPhieuDatPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("MaPD", obj.MaPD),
                new SqlParameter("MaP", obj.MaP)
            };
            return conn.SuaDuLieu("sp_chitietdatphong_update", para);
        }

        //xem các bản ghi qua mã phòng
        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.LayDuLieu("sp_select_ctpdp_by_maphong", para);
        }


        //xóa dữ liệu qua mã phòng
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            SqlParameter[] para =
            {
                new SqlParameter("map", maP)
            };
            return conn.SuaDuLieu("sp_delete_ctpdp_by_maphong", para);
        }
    }
}
