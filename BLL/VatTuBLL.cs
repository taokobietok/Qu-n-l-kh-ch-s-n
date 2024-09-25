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
    public class VatTuBLL
    {
        //vattu
        #region
        VatTuDAL dal_vt = new VatTuDAL();
        public string CapNhatMaVatTu(string mavtcu)
        {
            string MaVT = mavtcu;
            string strstt = "";

            int STT = int.Parse(MaVT.Substring(2).ToString()) + 1;
            if (STT < 10)
            {
                strstt = "00" + STT;
            }
            else if (STT < 100)
            {
                strstt = "0" + STT;
            }
            return "VT" + strstt;
        }
        public DataTable LayDuLieuVT()
        {
            return dal_vt.LayDuLieu();
        }
        public int InsertVT(VatTuDTO obj)
        {
            return dal_vt.Insert(obj);
        }
        public int UpdateVT(VatTuDTO obj)
        {
            return dal_vt.Update(obj);
        }
        public int DeleteVT(String ID)
        {
            return dal_vt.Delete(ID);
        }
        #endregion
        //ChiTietVatTu
        #region
        ChiTietVatTuDAL dal_ctvt = new ChiTietVatTuDAL();
        public DataTable LayDuLieuCTVT()
        {
            return dal_ctvt.LayDuLieu();
        }
        public int InsertCTVT(ChiTietVatTuDTO obj)
        {
            return dal_ctvt.Insert(obj);
        }
        public int UpdateCTVT(ChiTietVatTuDTO obj)
        {
            return dal_ctvt.Update(obj);
        }
        public int DeleteCTVT(ChiTietVatTuDTO obj)
        {
            return dal_ctvt.Delete(obj);
        }
        public int KiemTraSoLuongBanGhi(ChiTietVatTuDTO obj)
        {
            return dal_ctvt.KiemTraSoLuongbanGhi(obj);
        }
        public DataTable LayDuLieu_Qua_MaVatTu(string maVT)
        {
            return dal_ctvt.LayDuLieu_Qua_MaVatTu(maVT);
        }
        public int XoaDuLieu_Qua_MaVatTu(string maVT)
        {
            return dal_ctvt.XoaDuLieu_Qua_MaVatTu(maVT);
        }
        #endregion
        //ViewPhongLoaiPhongVatTu
        #region
        ViewPhongLoaiPhongVatTuDAL dal = new ViewPhongLoaiPhongVatTuDAL();
        public DataTable LayDuLieuPhongDon()
        {
            return dal.LayDuLieuPhongDon();
        }
        public DataTable LayDuLieuPhongDoi()
        {
            return dal.LayDuLieuPhongDoi();
        }
        public DataTable LayDuLieuPhongThuongHang()
        {
            return dal.LayDuLieuPhongThuongHang();
        }
        public DataTable LayDuLieuVTPhongDon()
        {
            return dal.LayDuLieuVTPhongDon();
        }
        public DataTable LayDuLieuVTPhongDoi()
        {
            return dal.LayDuLieuVTPhongDoi();
        }
        public DataTable LayDuLieuVTPhongThuongHang()
        {
            return dal.LayDuLieuVTPhongThuongHang();
        }
        public DataTable LoadComboboxMaVT()
        {
            return dal.LoadComboboxMaVT();
        }
        #endregion
    }
}
