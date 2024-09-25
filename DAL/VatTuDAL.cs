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
    public class VatTuDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieu()
        {
            return conn.LayDuLieu("sp_vattu_select_all", null);
        }

        public int Insert(VatTuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", obj.MaVT),
                new SqlParameter("tenVT", obj.TenVT)
            };
            return conn.SuaDuLieu("sp_vattu_insert", para);
        }

        public int Update(VatTuDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", obj.MaVT),
                new SqlParameter("tenVT", obj.TenVT)
            };
            return conn.SuaDuLieu("sp_vattu_update", para);
        }

        public int Delete(String ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("maVT", ID)
            };
            return conn.SuaDuLieu("sp_vattu_delete", para);
        }

    }
}
