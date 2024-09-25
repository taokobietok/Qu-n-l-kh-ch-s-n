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
    public class DanhSachPhongBLL
    {
        DanhSachPhongDAL dal = new DanhSachPhongDAL();


        public string CapNhatMaPhong(string mapcu)
        {
            string MaP = mapcu;
            string strstt = "";

            int STT = int.Parse(MaP.Substring(4).ToString()) + 1;
            int tang = int.Parse(MaP.Substring(3, 1).ToString());
            while (true)
            {
                if (STT < 10)
                {
                    strstt = "0" + STT;
                    break;
                }
                if (STT == 10)
                {
                    strstt = "10";
                    break;
                }
                if (STT > 10)
                {
                    STT = 1;
                    tang = tang + 1;
                }
            }
            return "KSA" + tang + strstt;
        }
        public DataTable LayDuLieu()
        {
            return dal.LayDuLieu();
        }
        public int Insert(DanhSachPhongDTO obj)
        {
            return dal.Insert(obj);
        }
        public int Update(DanhSachPhongDTO obj)
        {
            return dal.Update(obj);
        }
        public int Delete(String ID)
        {
            return dal.Delete(ID);
        }


        //cập nhật tình trạng phòng

        public int CapNhatPhongRR()
        {
            return dal.CapNhatPhongRR();
        }
        public int CapNhatPhongDD()
        {
            return dal.CapNhatPhongDD();
        }
        public int CapNhatPhongDN()
        {
            return dal.CapNhatPhongDN();
        }
    }
}
