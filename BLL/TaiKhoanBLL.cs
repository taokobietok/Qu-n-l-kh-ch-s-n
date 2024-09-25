using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TaiKhoanBLL
    {
        //ChiTietTaiKhoan 
        #region
        ChiTietTaiKhoanDAL dal_cttk = new ChiTietTaiKhoanDAL();
        public DataTable LayDuLieuCoTaiKhoan()
        {
            return dal_cttk.LayDuLieuCoTaiKhoan();
        }
        public DataTable LayDuLieuChuaCoTaiKhoan()
        {
            return dal_cttk.LayDuLieuChuaCoTaiKhoan();
        }
        #endregion
        //TaiKhoanHeThong
        #region
        TaiKhoanDangNhapDAL dal_tkdn = new TaiKhoanDangNhapDAL();
        public DataTable LayDuLieuTKDN()
        {
            return dal_tkdn.LayDuLieu();
        }

        public DataTable LayDuLieuQuaID(string ID)
        {
            return dal_tkdn.LayDuLieuQuaID(ID);
        }

        public int InsertTKDN(TaiKhoanDangNhapDTO obj)
        {
            return dal_tkdn.Insert(obj);
        }

        public int UpdateTKDN(TaiKhoanDangNhapDTO obj)
        {
            return dal_tkdn.Update(obj);
        }

        public int DeleteTKDN(String ID)
        {
            return dal_tkdn.Delete(ID);
        }
        #endregion
        //LichSuDangNhap
        #region
        LichSuDangNhapDAL dal_lsdn = new LichSuDangNhapDAL();
        public DataTable LayDuLieuLSDN()
        {
            return dal_lsdn.LayDuLieu();
        }
        public int XoaLichSuDN()
        {
            return dal_lsdn.XoaLichSuDN();
        }

        public int InsertLSDN(LichSuDangNhapDTO obj)
        {
            return dal_lsdn.Insert(obj);
        }
        #endregion
        //DangNhap
        #region
        DangNhapDAL dal_dn = new DangNhapDAL();
        public int KiemTraSoLuongBanGhi(DangNhapDTO obj)
        {
            return dal_dn.KiemTraSoLuongbanGhi(obj);
        }
        public DataTable ChiTietTaiKhoan(DangNhapDTO obj)
        {
            return dal_dn.ChiTietTaiKhoan(obj);
        }
        #endregion
        //DoiMatKhau
        #region
        DoiMatKhauDAL dal_dmk = new DoiMatKhauDAL();
        public int DoiMatkhau(DoiMatKhauDTO obj)
        {
            return dal_dmk.DoiMatKhau(obj);
        }
        #endregion
    }
}
