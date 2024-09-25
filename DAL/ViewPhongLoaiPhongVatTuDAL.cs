using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ViewPhongLoaiPhongVatTuDAL
    {
        connect conn = new connect();

        public DataTable LayDuLieuPhongDon()
        {
            return conn.LayDuLieu("sp_lp_p_select_pdon", null);
        }
        public DataTable LayDuLieuPhongDoi()
        {
            return conn.LayDuLieu("sp_lp_p_select_pdoi", null);
        }
        public DataTable LayDuLieuPhongThuongHang()
        {
            return conn.LayDuLieu("sp_lp_p_select_pth", null);
        }

        public DataTable LayDuLieuVTPhongDon()
        {
            return conn.LayDuLieu("sp_lpvt_select_pdon", null);
        }
        public DataTable LayDuLieuVTPhongDoi()
        {
            return conn.LayDuLieu("sp_lpvt_select_pdoi", null);
        }
        public DataTable LayDuLieuVTPhongThuongHang()
        {
            return conn.LayDuLieu("sp_lpvt_select_pth", null);
        }
        public DataTable LoadComboboxMaVT()
        {
            return conn.LayDuLieu("sp_vattu_select_all", null);
        }
        
        
    }
}
