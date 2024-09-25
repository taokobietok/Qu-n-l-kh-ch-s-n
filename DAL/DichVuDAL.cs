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
    public class DichVuDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_dichvu_select_all", null);
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            DataTable data = new DataTable();
            SqlParameter[] para =
            {
                new SqlParameter("maDV", ID)
            };
            data = conn.LayDuLieu("sp_dichvu_select_by_id", para);
            return data;
        }

        public int Insert(DichVuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maDV", obj.MaDV),
                new SqlParameter("tenDV", obj.TenDV),
                new SqlParameter("giaDV", obj.GiaDV),
                new SqlParameter("dvitinh", obj.DVT)
            };
            return conn.SuaDuLieu("sp_dichvu_insert", para);
        }

        public int Update(DichVuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maDV", obj.MaDV),
                new SqlParameter("tenDV", obj.TenDV),
                new SqlParameter("giaDV", obj.GiaDV),
                new SqlParameter("dvitinh", obj.DVT)
            };
            return conn.SuaDuLieu("sp_dichvu_update", para);
        }

        public int Delete(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maDV", ID)
            };
            return conn.SuaDuLieu("sp_dichvu_delete", para);
        }
    }
}
