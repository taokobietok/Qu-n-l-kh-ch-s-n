using BLL;
using DevExpress.XtraEditors;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Khách_Sạn
{
    public partial class LapPhieuDatPhong : Form
    {
        #region
        DanhSachPhongBLL pbll = new DanhSachPhongBLL();
        KhachHangBLL khbll = new KhachHangBLL();
        ThuePhongBLL tpbll = new ThuePhongBLL();
        TienIch ti = new TienIch();
        DanhSachPhongDTO pobj = new DanhSachPhongDTO();
        KhachHangDTO obj = new KhachHangDTO();
        PhieuDatPhongDTO pdpobj = new PhieuDatPhongDTO();
        ChiTietPhieuDatPhongDTO ctobj = new ChiTietPhieuDatPhongDTO();
        #endregion
        public string TenDN;
        public string NgayDen;
        public string NgayDi;
        public string SoNguoi;
        public string maPhong;
        public string Acc;
        public string LoaiP;
        public string SoNL;
        public string SoTE;
        public LapPhieuDatPhong(string ten, string manv, string ngayden, string ngaydi, string songuoilon, string sotreem, string songuoi, string map, string loaip)
        {
            NgayDen = ngayden;
            NgayDi = ngaydi;
            SoNguoi = songuoi;
            TenDN = ten;
            maPhong = map;
            Acc = manv;
            LoaiP = loaip;
            SoNL = songuoilon;
            SoTE = sotreem;
            InitializeComponent();
        }
        public LapPhieuDatPhong()
        {
            InitializeComponent();
        }

        private string LayNgayHienTai()
        {
            return ti.XuLyNgay(DateTime.Today);
        }

        private void TienDatCoc()
        {
            if (LoaiP == "LP1")
            {
                txttiencoc.Text = "50";
            }
            else
            {
                if (LoaiP == "LP2")
                {
                    txttiencoc.Text = "70";
                }
                else
                {
                    txttiencoc.Text = "100";
                }
            }
        }

        private void KhoaDieuKhien()
        {
            //phiếu đặt
            txttennv.Enabled = false;
            datengaylap.Enabled = false;
            datengayden.Enabled = false;
            datengaydi.Enabled = false;
            cbsonguoi.Enabled = false;
            cbmap.Enabled = false;
            txttiencoc.Enabled = false;
            cbtinhtrang.Enabled = false;
            txtmapdp.Enabled = false;
            cbnguoilon.Enabled = false;
            cbtreem.Enabled = false;

            //khách hàng
            txtmakh.Enabled = false;

        }

        private void CheckTinhTrangPhieu()
        {
            cbtinhtrang.Text = "Đã nhận";
        }


        private void HienThi()
        {
            DataTable dt = khbll.LayDuLieu();
            DataTable dtpdp = tpbll.TatCaPhieuDatPhong();
            txttennv.Text = TenDN;
            datengaylap.Text = LayNgayHienTai();
            datengayden.Text = NgayDen;
            datengaydi.Text = NgayDi;
            cbsonguoi.Text = SoNguoi;
            cbmap.Text = maPhong;
            cbnguoilon.Text = SoNL;
            cbtreem.Text = SoTE;
            txtmapdp.Text = dtpdp.Rows.Count > 0 ? tpbll.CapNhatMaPhieuDatPhong(dtpdp.Rows[dtpdp.Rows.Count - 1][0].ToString()) : "PDP000001";


            TienDatCoc();
            CheckTinhTrangPhieu();

            //Khách hàng
            txtmakh.Text = dt.Rows.Count > 0 ? khbll.CapNhatMaKhachHang(dt.Rows[dt.Rows.Count - 1][0].ToString()) : "KH000001";
        }
        private void InsertKhachHang()
        {
            obj.MaKH = txtmakh.Text;
            obj.TenKH = txttenkh.Text;
            obj.GioiTinh = cbgioitinh.Text;
            obj.CMND = txtcmnd.Text;
            obj.DiaChi = txtdiachi.Text;
            obj.SDT = txtsdt.Text;
            obj.Email = txtemail.Text;
            obj.Fax = txtfax.Text;
            obj.CoQuan = txtcoquan.Text;

            khbll.Insert(obj);
        }

        private void InsertPhieuDatPhong()
        {
            pdpobj.MaPD = txtmapdp.Text;
            pdpobj.TenDN = Acc;
            pdpobj.NgayLap = datengaylap.Text;
            pdpobj.NgayDen = datengayden.Text;
            pdpobj.NgayDi = datengaydi.Text;
            pdpobj.TinhTrang = cbtinhtrang.Text;
            pdpobj.TienCoc = txttiencoc.Text;
            pdpobj.MaKH = txtmakh.Text;
            pdpobj.SoNguoiLon = SoNL;
            pdpobj.SoTreEm = SoTE;
            pdpobj.SoNguoi = cbsonguoi.Text;

            tpbll.InsertPDP(pdpobj);
        }

        private void InsertChiTietPDP()
        {
            ctobj.MaPD = txtmapdp.Text;
            ctobj.MaP = cbmap.Text;

            tpbll.InsertCTPDP(ctobj);
        }

        private void UpdatePhong()
        {
            pobj.MaPhong = cbmap.Text;
            pobj.MaLPhong = LoaiP;
            if (cbtinhtrang.Text == "Đang chờ")
            {
                pobj.DaDat = "1";
                pobj.DaNhan = "0";
            }
            else
            {
                pobj.DaDat = "0";
                pobj.DaNhan = "1";
            }
            pbll.Update(pobj);


        }

        private void formlapphieudatphong_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        private void txttenkh_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 122) || e.KeyChar == 8 || e.KeyChar == 32);
        }

        private void txtfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtcmnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                DataTable dt = khbll.LoadDuLieuKH(txtcmnd.Text);

                if (dt.Rows.Count >= 1)
                {
                    txtmakh.Text = dt.Rows[0][0].ToString();
                    txttenkh.Text = dt.Rows[0][1].ToString();
                    cbgioitinh.Text = dt.Rows[0][2].ToString();
                    txtdiachi.Text = dt.Rows[0][4].ToString();
                    txtcoquan.Text = dt.Rows[0][5].ToString();
                    txtsdt.Text = dt.Rows[0][6].ToString();
                    txtemail.Text = dt.Rows[0][7].ToString();
                    txtfax.Text = dt.Rows[0][8].ToString();

                }
            }
        }

        private void btlapphieu_Click(object sender, EventArgs e)
        {
            if (txttenkh.Text.Length == 0 || cbgioitinh.Text.Length == 0 || txtcmnd.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo");
            }
            else
            {
                try
                {
                    DataTable kh = khbll.LayDuLieuQuaID(txtmakh.Text);

                    if (kh.Rows.Count <= 0)
                    {
                        InsertKhachHang();
                        InsertPhieuDatPhong();
                        InsertChiTietPDP();
                        XtraMessageBox.Show("Đã tạo phiếu đặt phòng thành công", "Thông báo");
                        if (cbtinhtrang.Text == "Đã nhận")
                        {
                            //Vì tình trạn là đã nhận nên cần phải lập luôn phiếu nhận phòng
                            if (XtraMessageBox.Show("Bạn có muốn lập phiếu nhận phòng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                pdpobj.MaPD = txtmapdp.Text;
                                pdpobj.TenDN = Acc;
                                pdpobj.NgayLap = datengaylap.Text;
                                pdpobj.NgayDen = datengayden.Text;
                                pdpobj.NgayDi = datengaydi.Text;
                                pdpobj.TinhTrang = "Đang chờ";
                                pdpobj.TienCoc = txttiencoc.Text;
                                pdpobj.MaKH = txtmakh.Text;
                                pdpobj.SoNguoi = cbsonguoi.Text;
                                pdpobj.SoNguoiLon = SoNL;
                                pdpobj.SoTreEm = SoTE;

                                tpbll.UpdatePDP(pdpobj);
                                XtraMessageBox.Show("Phiếu đặt đã chuyển về trạng thái chờ", "Thông báo");

                            }
                            else
                            {
                                LapPhieuNhanPhong frpnp = new LapPhieuNhanPhong(txtmapdp.Text, Acc);
                                frpnp.ShowDialog();
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        InsertPhieuDatPhong();
                        InsertChiTietPDP();
                        XtraMessageBox.Show("Đã tạo phiếu đặt phòng thành công", "Thông báo");
                        if (cbtinhtrang.Text == "Đã nhận")
                        {
                            //Vì tình trạn là đã nhận nên cần phải lập luôn phiếu nhận phòng
                            if (XtraMessageBox.Show("Bạn có muốn lập phiếu nhận phòng?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                pdpobj.MaPD = txtmapdp.Text;
                                pdpobj.TenDN = Acc;
                                pdpobj.NgayLap = datengaylap.Text;
                                pdpobj.NgayDen = datengayden.Text;
                                pdpobj.NgayDi = datengaydi.Text;
                                pdpobj.TinhTrang = "Đang chờ";
                                pdpobj.TienCoc = txttiencoc.Text;
                                pdpobj.MaKH = txtmakh.Text;
                                pdpobj.SoNguoi = cbsonguoi.Text;
                                pdpobj.SoNguoiLon = SoNL;
                                pdpobj.SoTreEm = SoTE;

                                tpbll.UpdatePDP(pdpobj);
                                XtraMessageBox.Show("Phiếu đặt đã chuyển về trạng thái chờ", "Thông báo");

                            }
                            else
                            {
                                LapPhieuNhanPhong frpnp = new LapPhieuNhanPhong(txtmapdp.Text, Acc);
                                frpnp.ShowDialog();
                            }
                        }
                        this.Close();
                    }

                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra, thử lại", "thông báo");
                }

            }
        }

        private void bthuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
