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
    public class NhanVienBLL
    {
        NhanVienDAL dal = new NhanVienDAL();

        public string CapNhatMaNhanVien(string manvcu)
        {
            string MaNV = manvcu;
            string strstt = "";

            int STT = int.Parse(MaNV.Substring(2).ToString()) + 1;
            if (STT < 10)
            {
                strstt = "00" + STT;
            }
            else if (STT < 100)
            {
                strstt = "0" + STT;
            }
            return "NV" + strstt;
        }

        public DataTable LayDuLieu()
        {
            return dal.LayDuLieu();
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            return dal.LayDuLieuQuaID(ID);
        }

        public int Insert(NhanVienDTO obj)
        {
            return dal.Insert(obj);
        }

        public int Update(NhanVienDTO obj)
        {
            return dal.Update(obj);
        }

        public int Delete(String ID)
        {
            return dal.Delete(ID);
        }

        public DataTable LayDuLieuNV_DiLam()
        {
            return dal.LayDuLieuNV_DiLam();
        }

        public DataTable LayDuLieuNV_NghiViec()
        {
            return dal.LayDuLieuNV_NghiViec();
        }

        public int NhanVienNghiViec(string ID)
        {
            return dal.NhanVienNghiViec(ID);
        }
    }
}
