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
    public class ThuePhongBLL
    {
        //ChiTietThuePhong
        #region
        ChiTietThuePhongDAL dal_cttp = new ChiTietThuePhongDAL();
        public int DeleteCTTP(string ID)
        {
            return dal_cttp.Delete(ID);
        }

        public DataTable LayDuLieu_Qua_MaPhongCTTP(string maP)
        {
            return dal_cttp.LayDuLieu_Qua_MaPhong(maP);
        }
        public int XoaDuLieu_Qua_MaPhongCTTP(string maP)
        {
            return dal_cttp.XoaDuLieu_Qua_MaPhong(maP);
        }
        #endregion
        //ChiTietPhieuDatPhong
        #region
        ChiTietPhieuDatPhongDAL dal_ctpdp = new ChiTietPhieuDatPhongDAL();

        public DataTable LayDuLieuCTPDP(String ID)
        {
            return dal_ctpdp.LayDuLieu(ID);
        }
        public DataTable LayDuLieuCTPDP()
        {
            return dal_ctpdp.LayDuLieu();
        }
        public int InsertCTPDP(ChiTietPhieuDatPhongDTO obj)
        {
            return dal_ctpdp.Insert(obj);
        }

        public int DeleteCTPDP(string ID)
        {
            return dal_ctpdp.Delete(ID);
        }
        public int UpdateCTPDP(ChiTietPhieuDatPhongDTO obj)
        {
            return dal_ctpdp.Update(obj);
        }

        public DataTable LayDuLieu_Qua_MaPhongCTPDP(string maP)
        {
            return dal_ctpdp.LayDuLieu_Qua_MaPhong(maP);
        }
        public int XoaDuLieu_Qua_MaPhongCTPDP(string maP)
        {
            return dal_ctpdp.XoaDuLieu_Qua_MaPhong(maP);
        }
        #endregion
        //Checkphong
        #region
        CheckPhongDAL dal_cp = new CheckPhongDAL();


        public DataTable LayDuLieuPhongDaNhan()
        {
            return dal_cp.LayDuLieuPhongDaNhan();
        }

        public DataTable LayDuLieuPhongDangCho()
        {
            return dal_cp.LayDuLieuPhongDangCho();
        }

        public DataTable LayDuLieuPhongRanhRoi()
        {
            return dal_cp.LayDuLieuPhongRanhRoi();
        }

        public int KiemTraSoBanGhiPDN()
        {
            return dal_cp.KiemTraSoLuongBanGhiPDN();
        }
        public int KiemTraSoBanGhiPDD()
        {
            return dal_cp.KiemTraSoLuongBanGhiPDD();
        }

        public int KiemTraSoBanGhiPRR()
        {
            return dal_cp.KiemTraSoLuongBanGhiPRR();
        }

        public DataTable LayDuLieuPhongDaNhanThoaMan(CheckPhongDTO obj)
        {
            return dal_cp.LayDuLieuPhongDaNhanThoaMan(obj);
        }

        public DataTable LayDuLieuPhongDaDatThoaMan(CheckPhongDTO obj)
        {
            return dal_cp.LayDuLieuPhongDaDatThoaMan(obj);
        }

        public DataTable LayDuLieuPhongRanhRoiTLP(String ID)
        {
            return dal_cp.LayDuLieuPhongRanhRoiTLP(ID);
        }
        #endregion
        //PhieuNhanPhong
        #region
        PhieuNhanPhongDAL dal_pnp = new PhieuNhanPhongDAL();
        public string CapNhatMaPhieuNhanPhong(string mapncu)
        {
            string MaPN = mapncu;
            string strstt = "";

            int STT = int.Parse(MaPN.Substring(3).ToString()) + 1;
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
            return "PNP" + strstt;
        }
        public DataTable LayDuLieuPNP()
        {
            return dal_pnp.LayDuLieu();
        }

        public int InsertPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.Insert(obj);
        }

        public DataTable LayDuLieu_Add_MaPhongPNP()
        {
            return dal_pnp.LayDuLieu_Add_MaPhong();
        }
        public DataTable LayDuLieu_Add_MaPhong_DangHoatDongPNP()
        {
            return dal_pnp.LayDuLieu_Add_MaPhong_DangHoatDong();
        }

        public DataTable LayDuLieu_ChiTietThuePhongPNP(string ID)
        {
            return dal_pnp.LayDuLieu_ChiTietThuePhong(ID);
        }

        public int Insert_ChiTietThuePhongPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.Insert_ChiTietThuePhong(obj);
        }

        public DataTable LayDuLieu_ChiTietThuePhong_TheoMaPhieuThue_And_MaDVPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.LayDuLieu_ChiTietThuePhong_TheoMaPhieuThue_And_MaDV(obj);
        }

        public int Update_LuotDungDichVuPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.Update_LuotDungDichVu(obj);
        }

        public int Xoa_LuotDungDichVuPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.Xoa_LuotDungDichVu(obj);
        }
        public int Xoa_SuDungDichVuPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.Xoa_SuDungDichVu(obj);
        }
        public DataTable LoadMaKhachHangPNP(string ID)
        {
            return dal_pnp.LoadMaKhachHang(ID);
        }

        public int DeletePNP(string ID)
        {
            return dal_pnp.Delete(ID);
        }

        public int Delete_By_maPDP(string ID)
        {
            return dal_pnp.Delete_By_maPDP(ID);
        }

        public DataTable LayDuLieu_QuaMaPDP(string ID)
        {
            return dal_pnp.LayDuLieu_QuaMaPDP(ID);
        }


        public int KhoiTaoLuotDungPNP(PhieuNhanPhongDTO obj)
        {
            return dal_pnp.KhoiTaoLuotDung(obj);
        }

        public DataTable LayDuLieu_Qua_MaPhongPNP(string maP)
        {
            return dal_pnp.LayDuLieu_Qua_MaPhong(maP);
        }

        public int XoaDuLieu_Qua_MaPhongPNP(string maP)
        {
            return dal_pnp.XoaDuLieu_Qua_MaPhong(maP);
        }
        #endregion
        //PhieuDatPhong
        #region
        PhieuDatPhongDAL dal_pdp = new PhieuDatPhongDAL();

        public string CapNhatMaPhieuDatPhong(string mapdcu)
        {
            string MaPD = mapdcu;
            string strstt = "";

            int STT = int.Parse(MaPD.Substring(3).ToString()) + 1;
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
            return "PDP" + strstt;
        }

        public DataTable LayDuLieuPDP()
        {
            return dal_pdp.LayDuLieu();
        }

        public DataTable TatCaPhieuDatPhong()
        {
            return dal_pdp.TatCaPhieuDatPhong();
        }

        public int InsertPDP(PhieuDatPhongDTO obj)
        {
            return dal_pdp.Insert(obj);
        }

        public int UpdatePDP(PhieuDatPhongDTO obj)
        {
            return dal_pdp.Update(obj);
        }

        public int Delete(string ID)
        {
            return dal_pdp.Delete(ID);
        }

        public int KiemTraPhongThoaManPDP(PhieuDatPhongDTO obj)
        {
            return dal_pdp.KiemTraPhongThoaMan(obj);
        }

        public int KiemTraPhongThoaManRanhRoiPDP(string ID)
        {
            return dal_pdp.KiemTraPhongThoaManRanhRoi(ID);
        }


        //test

        public DataTable LayDLPDP(string MaP)
        {
            return dal_pdp.LayDL(MaP);
        }

        public DataTable CheckPhieuPDP(string ID)
        {
            return dal_pdp.CheckPhieu(ID);
        }

        //hủy phiếu đặt phòng khi khách k đến nhạn phòng
        public int HuyPhieuDatPhong(string ID)
        {
            return dal_pdp.HuyPhieuDatPhong(ID);
        }

        //load ds phòng rảnh rỗi theo loại phòng
        public DataTable DSPhongRRTheoLPPDP(string ID)
        {
            return dal_pdp.DSPhongRRTheoLP(ID);
        }

        public DataTable LayDL_ThepMaPhieuPDP(string ID)
        {
            return dal_pdp.LayDL_ThepMaPhieu(ID);
        }


        public DataTable LayDuLieu_QuaIMaKHPDP(string ID)
        {
            return dal_pdp.LayDuLieu_QuaIMaKH(ID);
        }

        //xóa qua mã kh

        public DataTable Delete_QuaIMaKHPDP(string ID)
        {
            return dal_pdp.Delete_QuaIMaKH(ID);
        }

        public DataTable LayDuLieu_Qua_MaPhongPDP(string maP)
        {
            return dal_pdp.LayDuLieu_Qua_MaPhong(maP);
        }
        public int XoaDuLieu_Qua_MaPhongPDP(string maP)
        {
            return dal_pdp.XoaDuLieu_Qua_MaPhong(maP);
        }
        #endregion
    }
}
