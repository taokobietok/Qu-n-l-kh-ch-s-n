using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;

namespace BLL
{
    public class ThongKeBLL
    {
        ThongKeDAL dal = new ThongKeDAL();

        public DataTable LayDuLieu()
        {
            return dal.LayDuLieu();
        }

        public int Insert(ThongKeDTO obj)
        {
            return dal.Insert(obj);
        }
        //theo loại phòng
        public DataTable ThongKeTheoLoaiPhong()
        {
            return dal.ThongKeTheoLoaiPhong();
        }

        public int Delete(string ID)
        {
            return dal.Delete(ID);
        }

        public DataTable LayDuLieu_Qua_MaPhong(string maP)
        {
            return dal.LayDuLieu_Qua_MaPhong(maP);
        }
        public int XoaDuLieu_Qua_MaPhong(string maP)
        {
            return dal.XoaDuLieu_Qua_MaPhong(maP);
        }
    }
}
