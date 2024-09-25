using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL dal = new KhachHangDAL();

        public string CapNhatMaKhachHang(string makhcu)
        {
            string MaKH = makhcu;
            string strstt = "";

            int STT = int.Parse(MaKH.Substring(2).ToString()) + 1;
            if (STT < 10)
            {
                strstt = "00000" + STT;
            }
            else if (STT < 100)
            {
                strstt = "0000" + STT;
            }
            else if (STT < 1000)
            {
                strstt = "000" + STT;
            }
            else if (STT < 10000)
            {
                strstt = "00" + STT;
            }
            else if (STT < 100000)
            {
                strstt = "0" + STT;
            }
            return "KH" + strstt;
        }

        public DataTable LayDuLieu()
        {
            return dal.LayDuLieu();
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            return dal.LayDuLieuQuaID(ID);
        }

        public int Insert(KhachHangDTO obj)
        {
            return dal.Insert(obj);
        }

        public int Update(KhachHangDTO obj)
        {
            return dal.Update(obj);
        }

        public int Delete(String ID)
        {
            return dal.Delete(ID);
        }

        public DataTable LoadDuLieuKH(string socmnd)
        {
            return dal.LoadDuLieuKH(socmnd);
        }
    }
}
