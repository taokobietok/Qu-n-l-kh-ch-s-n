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
    public partial class PhieuDatPhong : Form
    {
        #region
        TienIch ti = new TienIch();
        ThuePhongBLL bll = new ThuePhongBLL();
        CheckPhongDTO cpobj = new CheckPhongDTO();
        PhieuDatPhongDTO obj = new PhieuDatPhongDTO();
        ChiTietPhieuDatPhongDTO ctobj = new ChiTietPhieuDatPhongDTO();

        private bool doiphong = false;
        #endregion
        //sao lưu dữ liệu phiếu muốn sửa đổi để xóa và tự khôi phục
        private string maphieu = "";
        private string makhach = "";
        private string ngayden = "";
        private string ngaydi = "";
        private string tiencoc = "";
        private string tendn = "";
        private string tinhtrang = "";
        private string songuoi = "";
        private string ngaylap = "";
        private string songuoilon = "";
        private string sotreem = "";
        private bool checkphieu = false;
        public string maNV;

        public PhieuDatPhong()
        {
            InitializeComponent();
        }
        public PhieuDatPhong(string manv)
        {
            maNV = manv;
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            cbmapdp.Enabled = false;
            cbmakh.Enabled = false;
            cbmaphong.Enabled = false;
            txttiencoc.Enabled = false;
            datengayden.Enabled = false;
            datengaydi.Enabled = false;
            cbtentk.Enabled = false;
            cbsonguoi.Enabled = false;
            cbtinhtrang.Enabled = false;
            cbloaip.Enabled = false;

            bthuy.Enabled = false;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btdoip.Enabled = true;
            btlappnp.Enabled = false;

            btcheckp.Enabled = true;
            bthuytonbo.Enabled = false;
        }

        private void MoKhoaCheckPhieu()
        {
            cbmapdp.Enabled = false;
            cbmakh.Enabled = false;
            cbmaphong.Enabled = false;
            txttiencoc.Enabled = false;
            datengayden.Enabled = false;
            datengaydi.Enabled = false;
            cbtentk.Enabled = false;
            cbsonguoi.Enabled = false;
            cbtinhtrang.Enabled = false;
            cbloaip.Enabled = false;

            bthuy.Enabled = false;
            btluu.Enabled = false;
            btsua.Enabled = false;
            btdoip.Enabled = false;
            btlappnp.Enabled = true;

            btcheckp.Enabled = false;
            bthuytonbo.Enabled = true;
        }

        private void MoDieuKhienSuaNgay()
        {
            cbmapdp.Enabled = false;
            cbmakh.Enabled = false;
            cbmaphong.Enabled = false;
            txttiencoc.Enabled = false;
            datengayden.Enabled = true;
            datengaydi.Enabled = true;
            cbtentk.Enabled = false;
            cbsonguoi.Enabled = false;
            cbtinhtrang.Enabled = false;
            cbloaip.Enabled = false;

            bthuy.Enabled = true;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btdoip.Enabled = false;
            btlappnp.Enabled = false;
            btcheckp.Enabled = false;
        }

        private void MoDieuKhienDoiPhong()
        {
            cbmapdp.Enabled = false;
            cbmakh.Enabled = false;
            cbmaphong.Enabled = true;
            txttiencoc.Enabled = false;
            datengayden.Enabled = false;
            datengaydi.Enabled = false;
            cbtentk.Enabled = false;
            cbsonguoi.Enabled = false;
            cbtinhtrang.Enabled = false;
            cbloaip.Enabled = true;

            bthuy.Enabled = true;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btdoip.Enabled = false;
            btlappnp.Enabled = false;
            btcheckp.Enabled = false;
        }
        private void XoaText()
        {
            cbmapdp.Text = String.Empty;
            cbmakh.Text = String.Empty;
            cbmaphong.Text = String.Empty;
            txttiencoc.Text = String.Empty;
            datengayden.Text = String.Empty;
            datengaydi.Text = String.Empty;
            cbtentk.Text = String.Empty;
            cbsonguoi.Text = String.Empty;
            cbtinhtrang.Text = String.Empty;
            cbloaip.Text = String.Empty;
        }

        private void HienThi()
        {
            if (checkphieu == false)
            {
                gridctdp.DataSource = bll.TatCaPhieuDatPhong();

            }
            else
            {
                gridctdp.DataSource = bll.CheckPhieuPDP(ti.XuLyNgayCheckPhieu(DateTime.Today).ToString());

            }
        }



        //load mã phòng
        private void LoadComboboxMaPhongRTheoLP()
        {

            cpobj.NgayDen = ti.TachNgay(datengayden.Text).ToString();
            cpobj.NgayDi = ti.TachNgay(datengaydi.Text).ToString();
            cpobj.ThangDen = ti.TachThang(datengayden.Text).ToString();
            cpobj.ThangDi = ti.TachThang(datengaydi.Text).ToString();
            cpobj.NamDen = ti.TachNam(datengayden.Text).ToString();
            cpobj.NamDi = ti.TachNam(datengaydi.Text).ToString();
            cpobj.tenLP = cbloaip.Text;


            DataTable dtTable = bll.DSPhongRRTheoLPPDP(cbloaip.Text);

            if (dtTable.Rows.Count > 0)
            {
                if (cbloaip.Text.Length != 0)
                {

                    cbmaphong.DataSource = dtTable;
                    cbmaphong.DisplayMember = "MAPHONG";
                    cbmaphong.ValueMember = "MAPHONG";
                }
            }
            else
            {
                DataTable dt = bll.LayDuLieuPhongDaDatThoaMan(cpobj);
                if (dt.Rows.Count >= 0)
                {
                    if (cbloaip.Text.Length != 0)
                    {
                        cbmaphong.DataSource = dtTable;
                        cbmaphong.DisplayMember = "MAPHONG";
                        cbmaphong.ValueMember = "MAPHONG";
                    }
                }
                else
                {
                    DataTable pdntmTable = bll.LayDuLieuPhongDaNhanThoaMan(cpobj);

                    if (pdntmTable.Rows.Count >= 0)
                    {
                        if (cbloaip.Text.Length != 0)
                        {
                            cbmaphong.DataSource = dtTable;
                            cbmaphong.DisplayMember = "MAPHONG";
                            cbmaphong.ValueMember = "MAPHONG";
                        }
                    }
                }
            }
        }
        private void CheckNgay()
        {
            if (ti.TachNam(datengaydi.Text) > ti.TachNam(datengayden.Text))
            {
                //ok
                SuaNgayBanGhi();
                XtraMessageBox.Show("Đã cập nhật lại ngày của phiếu: " + maphieu, "Thông báo");
                HienThi();
                KhoaDieuKhien();
                XoaText();
            }
            else
            {
                if (ti.TachNam(datengaydi.Text) < ti.TachNam(datengayden.Text))
                {
                    XtraMessageBox.Show("Ngày đi phải sau ngày đến", "Thông báo");
                }
                else
                {
                    if (ti.TachThang(datengaydi.Text) > ti.TachThang(datengayden.Text))
                    {
                        //ok
                        SuaNgayBanGhi();
                        XtraMessageBox.Show("Đã cập nhật lại ngày của phiếu: " + maphieu, "Thông báo");
                        HienThi();
                        KhoaDieuKhien();
                        XoaText();
                    }
                    else
                    {
                        if (ti.TachThang(datengaydi.Text) < ti.TachThang(datengayden.Text))
                        {
                            XtraMessageBox.Show("Ngày đi phải sau ngày đến", "Thông báo");
                        }
                        else
                        {
                            if (ti.TachNgay(datengaydi.Text) > ti.TachNgay(datengayden.Text))
                            {
                                //ok
                                SuaNgayBanGhi();
                                XtraMessageBox.Show("Đã cập nhật lại ngày của phiếu: " + maphieu, "Thông báo");
                                HienThi();
                                KhoaDieuKhien();
                                XoaText();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ngày đi phải sau ngày đến", "Thông báo");
                            }
                        }
                    }
                }
            }
        }

        private void CheckNgayDen()
        {
            if (ti.TachNam(datengayden.Text) > ti.TachNam(ti.XuLyNgay(DateTime.Today)))
            {
                //ok
                CheckNgay();
            }
            else
            {
                if (ti.TachNam(datengayden.Text) < ti.TachNam(ti.XuLyNgay(DateTime.Today)))
                {
                    XtraMessageBox.Show("Ngày đến phải sau hoặc cùng ngày hôm nay", "Thông báo");

                }
                else
                {
                    if (ti.TachThang(datengayden.Text) > ti.TachThang(ti.XuLyNgay(DateTime.Today)))
                    {
                        //ok
                        CheckNgay();
                    }
                    else
                    {
                        if (ti.TachThang(datengayden.Text) < ti.TachThang(ti.XuLyNgay(DateTime.Today)))
                        {
                            XtraMessageBox.Show("Ngày đến phải sau hoặc cùng ngày hôm nay", "Thông báo");

                        }
                        else
                        {
                            if (ti.TachNgay(datengayden.Text) >= ti.TachNgay(ti.XuLyNgay(DateTime.Today)))
                            {
                                //ok
                                CheckNgay();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ngày đến phải sau hoặc cùng ngày hôm nay", "Thông báo");

                            }
                        }
                    }
                }
            }
        }

        private void VoHieuBanGhi()
        {
            obj.NgayDen = ngayden;
            obj.NgayDi = ngaydi;
            obj.MaPD = maphieu;
            obj.MaKH = makhach;
            obj.TienCoc = tiencoc;
            obj.TenDN = tendn;
            obj.TinhTrang = "Đã trả";
            obj.SoNguoi = songuoi;
            obj.NgayLap = ngaylap;
            obj.SoTreEm = sotreem;
            obj.SoNguoiLon = songuoilon;

            bll.UpdatePDP(obj);
        }

        private void KhoiPhucBanGhi()
        {
            obj.NgayDen = ngayden;
            obj.NgayDi = ngaydi;
            obj.MaPD = maphieu;
            obj.MaKH = makhach;
            obj.TienCoc = tiencoc;
            obj.TenDN = tendn;
            obj.TinhTrang = tinhtrang;
            obj.SoNguoi = songuoi;
            obj.NgayLap = ngaylap;
            obj.SoTreEm = sotreem;
            obj.SoNguoiLon = songuoilon;

            bll.UpdatePDP(obj);
        }

        private void SuaNgayBanGhi()
        {
            if (cbloaip.Text == "Phòng đơn")
            {
                obj.TienCoc = "30";
            }
            if (cbloaip.Text == "Phòng đôi")
            {
                obj.TienCoc = "70";
            }
            if (cbloaip.Text == "Phòng thượng hạng")
            {
                obj.TienCoc = "90";
            }
            obj.NgayDen = ti.XuLyNgay1(datengayden.Text);
            obj.NgayDi = ti.XuLyNgay1(datengaydi.Text);
            obj.MaPD = maphieu;
            obj.MaKH = makhach;
            obj.TenDN = tendn;
            obj.TinhTrang = tinhtrang;
            obj.SoNguoi = songuoi;
            obj.NgayLap = ngaylap;
            obj.SoTreEm = sotreem;
            obj.SoNguoiLon = songuoilon;

            bll.UpdatePDP(obj);
        }

        private void SuaPhongBanGhi()
        {
            //sửa từ bảng chi tiết phiếu đặt phòng
            ctobj.MaPD = maphieu;
            ctobj.MaP = cbmaphong.Text;

            bll.UpdateCTPDP(ctobj);
        }
        /*private void LoadComboboxMaPhong()
        {
            DataTable dt = new DataTable();
            if()
            dt = bll.LoadComboboxMaVT();
            cbmavt.DataSource = dt;
            cbmavt.DisplayMember = "Mã Vật Tư";
            cbmavt.ValueMember = "Tên Vật Tư";
        }
        */

        private void PhieuDatPhong_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();


            HienThi();

        }

        private void cbtentk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (cbmapdp.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo");
                KhoaDieuKhien();
                HienThi();
                XoaText();
            }
            else
            {
                doiphong = false;
                MoDieuKhienSuaNgay();

            }
        }

        private void btdoip_Click(object sender, EventArgs e)
        {
            if (cbmapdp.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", " Thông báo");
                KhoaDieuKhien();
                HienThi();
                XoaText();
            }
            else
            {
                doiphong = true;
                //tương tự nút đổi ngày, có thể đổi qua lại giữa các loại phòng yêu cầu đặt cọc thêm theo từng loại phòng
                MoDieuKhienDoiPhong();
                if (cbloaip.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn phải chọn loại phòng trước", "Thông báo");
                }
                else
                {

                    this.LoadComboboxMaPhongRTheoLP();
                }
            }
        }

        private void btlappnp_Click(object sender, EventArgs e)
        {
            if (cbmapdp.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo");
            }
            else
            {
                LapPhieuNhanPhong frlpnp = new LapPhieuNhanPhong(cbmapdp.Text, maNV);
                frlpnp.ShowDialog();
                PhieuDatPhong_Load(sender, e);
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            //đổi ngày
            if (doiphong == false)
            {

                //Xóa tạm thời vô hiệu phiếu này
                VoHieuBanGhi();
                DataTable dtTable = bll.LayDLPDP(cbmaphong.Text);
                int i = dtTable.Rows.Count; obj.NgayDen = ti.XuLyNgay1(datengayden.Text); // Kiểm tra có bản ghi trong view rảnh rỗi không
                obj.NgayDi = ti.XuLyNgay1(datengaydi.Text);
                obj.NgayDen = ti.XuLyNgay1(datengayden.Text);
                obj.MaPhong = cbmaphong.Text;
                //XtraMessageBox.Show(bll.KiemTraPhongThoaMan(obj).ToString());
                if (bll.KiemTraPhongThoaManPDP(obj) > 0 || i == 1)
                {

                    //ok, dùng lệnh sửa lại bản ghi, việc nhẹ lương cao. Hihi
                    CheckNgayDen();


                }
                else
                {
                    if (MessageBox.Show("Phòng " + cbmaphong.Text + " đã bận trong khoảng thời gian bạn vừa chọn. \n Bạn muốn đổi sang phòng khác không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        XtraMessageBox.Show("Hihi");
                        //Mở cbmaphong, hiện tại các mục lựa chọn của cb đã được kiểm tra và các phòng trong cb đều thỏa mãn
                        KhoaDieuKhien();
                        cbmaphong.Enabled = true;
                        btluu.Enabled = true;
                        bthuy.Enabled = true;
                        this.LoadComboboxMaPhongRTheoLP();
                        //sửa lại phòng trước
                        SuaPhongBanGhi();
                        //sửa lại ngày
                        SuaNgayBanGhi();
                        XtraMessageBox.Show("Đã chuyển sang phòng " + cbmaphong.Text + " và đổi ngày phiếu " + maphieu + " thành công!", "Thông báo");
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                    else
                    {
                        //trả về trạng thái cũ
                        KhoiPhucBanGhi();
                        HienThi();
                        KhoaDieuKhien();
                        XoaText();
                        XtraMessageBox.Show("Bản ghi không được sửa đổi", "Thông báo");
                    }
                }
            }
            // đổi phòng
            else
            {
                if (cbmaphong.Text.Length == 0 || cbloaip.Text.Length == 0)
                {
                    XtraMessageBox.Show("Chưa đủ thông tin", "Thông báo");

                }
                else
                {
                    SuaPhongBanGhi();
                    SuaNgayBanGhi();
                    XtraMessageBox.Show("Đã đổi phòng thành công", "Thông báo");
                    KhoaDieuKhien();
                    HienThi();
                    XoaText();
                }
            }

        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (doiphong == false)
            {
                KhoiPhucBanGhi();
                HienThi();
                KhoaDieuKhien();
                XoaText();
                XtraMessageBox.Show("Đã hủy sửa ngày phiếu đặt " + maphieu, "Thông báo");
            }
            else
            {
                if (doiphong == true)
                {
                    XtraMessageBox.Show("Đã hủy đổi phòng", "Thông báo");
                    KhoaDieuKhien();
                    XoaText();
                    HienThi();
                }
                else
                {
                    XtraMessageBox.Show("Đã hủy", "Thông báo");
                    KhoaDieuKhien();
                    XoaText();
                    HienThi();
                }
            }
        }

        private void btcheckp_Click(object sender, EventArgs e)
        {
            checkphieu = true;
            MoKhoaCheckPhieu();
            btlappnp.Enabled = true;
            HienThi();
        }

        private void bthuytonbo_Click(object sender, EventArgs e)
        {
            checkphieu = false;
            bll.HuyPhieuDatPhong(ti.XuLyNgayCheckPhieu(DateTime.Today));
            XtraMessageBox.Show("Đã hủy tất cả phiếu đặt vào ngày " + ti.XuLyNgay(DateTime.Today), "Thông báo");
            KhoaDieuKhien();
            HienThi();
            XoaText();
        }

        private void gridctdp_Click(object sender, EventArgs e)
        {
            try
            {

                cbmapdp.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                cbmaphong.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[1]).ToString();
                cbloaip.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[2]).ToString();
                cbtentk.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[3]).ToString();
                cbmakh.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[5]).ToString();
                cbsonguoi.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[6]).ToString();
                datengayden.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[9]).ToString();
                datengaydi.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[10]).ToString();
                txttiencoc.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[11]).ToString();
                cbtinhtrang.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[13]).ToString();

                //Đổ dữ liệu cho các biến sao lưu
                maphieu = cbmapdp.Text;
                makhach = cbmakh.Text;
                ngayden = ti.XuLyNgay1(datengayden.Text);
                ngaydi = ti.XuLyNgay1(datengaydi.Text);
                tiencoc = txttiencoc.Text;
                tendn = cbtentk.Text;
                tinhtrang = cbtinhtrang.Text;
                songuoilon = cbsonguoi.Text;

                sotreem = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[7]).ToString();
                songuoi = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[8]).ToString();
                ngaylap = ti.XuLyNgay1(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[4]).ToString());

                // XtraMessageBox.Show(maphieu + "\n" + makhach + "\n" + ngayden + "\n" + ngaydi + "\n" + tiencoc + "\n" + 
                // tendn + "\n" + tinhtrang + "\n" + songuoi + "\n" + ngaylap, "Thông báo");
            }
            catch
            {
                XtraMessageBox.Show("Không có bản ghi nào", "Thông báo");
            }
        }

        private void cbloaip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (doiphong == true)
            {
                this.LoadComboboxMaPhongRTheoLP();
            }
            if (cbsonguoi.Text != "1")
            {
                if (cbloaip.Text == "Phòng đơn")
                {
                    XtraMessageBox.Show("Phòng đơn chỉ dành cho 1 người lớn", "Thông báo");
                    cbloaip.Text = string.Empty;
                    cbmaphong.Text = string.Empty;
                    cbloaip.Focus();
                }
            }
        }
    }
}
