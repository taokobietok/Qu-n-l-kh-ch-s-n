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
    public class DoiMatKhauDAL
    {
        connect conn = new connect();

        public int DoiMatKhau(DoiMatKhauDTO obj)
        {
            SqlParameter[] para =
            {
                new SqlParameter("tenDN", obj.TenDN),
                new SqlParameter("matKhau", obj.MatKMoi)
            };
            return conn.SuaDuLieu("sp_doimatkhau", para);
        }
    }
}
