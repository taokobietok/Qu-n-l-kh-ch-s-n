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
    public class DanhSachPhongDAL
    {
        connect conn = new connect();
        
        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_dsphong_select_all", null);
        }

        public int Insert(DanhSachPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maP", obj.MaPhong),
                new SqlParameter("maLP", obj.MaLPhong),
                new SqlParameter("dadat", obj.DaDat),
                new SqlParameter("danhan", obj.DaNhan),
            };
            return conn.SuaDuLieu("sp_phong_insert", para);
        }

        public int Update(DanhSachPhongDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maP", obj.MaPhong),
                new SqlParameter("maLP", obj.MaLPhong),
                new SqlParameter("dadat", obj.DaDat),
                new SqlParameter("danhan", obj.DaNhan),
            };
            return conn.SuaDuLieu("sp_phong_update", para);
        }

        public int Delete(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maP", ID)
            };
            return conn.SuaDuLieu("sp_phong_delete", para);
        }



        //cập nhật tình trạng phòng
        public int CapNhatPhongRR()
        {
            return conn.SuaDuLieu("sp_capnhat_tinhtrangphong_rr", null);
        }
        public int CapNhatPhongDD()
        {
            return conn.SuaDuLieu("sp_capnhat_tinhtrangphong_dd", null);
        }
        public int CapNhatPhongDN()
        {
            return conn.SuaDuLieu("sp_capnhat_tinhtrangphong_dn", null);
        }
    }
}
