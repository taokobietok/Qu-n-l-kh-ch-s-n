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
    public class DichVuBLL
    {
        DichVuDAL dal = new DichVuDAL();

        public string CapNhatMaDichVu(string madvcu)
        {
            string MaDV = madvcu;
            string strstt = "";

            int STT = int.Parse(MaDV.Substring(2).ToString()) + 1;
            if (STT < 10)
            {
                strstt = "00" + STT;
            }
            else if (STT < 100)
            {
                strstt = "0" + STT;
            }
            return "DV" + strstt;
        }

        public DataTable LayDuLieu()
        {
            return dal.LayDuLieu();
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            return dal.LayDuLieuQuaID(ID);
        }

        public int Insert(DichVuDTO obj)
        {
            return dal.Insert(obj);
        }

        public int Update(DichVuDTO obj)
        {
            return dal.Update(obj);
        }

        public int Delete(String ID)
        {
            return dal.Delete(ID);
        }
    }
}
