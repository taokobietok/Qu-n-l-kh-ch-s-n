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
    public partial class VatTu : Form
    {
        #region
        VatTuBLL bll = new VatTuBLL();
        ChiTietVatTuDTO obj = new ChiTietVatTuDTO();
        private bool insert = false;
        private string maLoaiPhong;
        #endregion
        public VatTu()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            cbmavt.Visible = true;
            cbmavt.Enabled = false;
            txttenvt.Enabled = false;
            txtsoluong.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;

            btluu.Enabled = false;
            bthuy.Enabled = false;
        }
        private void MoDieuKhien()
        {
            cbmavt.Visible = true;
            cbmavt.Enabled = true;
            txttenvt.Enabled = false;
            txtsoluong.Enabled = true;

            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
        }
        private void XoaText()
        {
            cbmavt.Text = String.Empty;
            txttenvt.Text = String.Empty;
            txtsoluong.Text = String.Empty;
        }

        private void HienThi()
        {
            if (cblp.Text == "Phòng đơn")
            {
                maLoaiPhong = "LP1";
                grouplp.Text = "Danh sách các phòng đơn";
                griddsp.DataSource = bll.LayDuLieuPhongDon();

                groupvt.Text = "Danh sách vật tư trong phòng đơn";
                griddsvt.DataSource = bll.LayDuLieuVTPhongDon();
            }
            else
            {
                if (cblp.Text == "Phòng đôi")
                {
                    maLoaiPhong = "LP2";
                    grouplp.Text = "Danh sách các phòng đôi";
                    griddsp.DataSource = bll.LayDuLieuPhongDoi();
                    groupvt.Text = "Danh sách vật tư trong phòng đôi";
                    griddsvt.DataSource = bll.LayDuLieuVTPhongDoi();
                }
                else
                {
                    maLoaiPhong = "LP3";
                    grouplp.Text = "Danh sách các phòng thượng hạng";
                    griddsp.DataSource = bll.LayDuLieuPhongThuongHang();
                    groupvt.Text = "Danh sách vật tư trong phòng thượng hạng";
                    griddsvt.DataSource = bll.LayDuLieuVTPhongThuongHang();
                }
            }
        }

        private void LoadComboboxMaVT()
        {
            DataTable dt = bll.LoadComboboxMaVT();
            cbmavt.DataSource = dt;
            cbmavt.DisplayMember = "MAVATTU";
            cbmavt.ValueMember = "TENVATTU";
        }

        private void formvattu_Load(object sender, EventArgs e)
        {
            cblp.Text = "Phòng đơn";
            cbmavt.Text = "B1";
            this.LoadComboboxMaVT();
            txttenvt.Text = "Bàn";
            KhoaDieuKhien();
            HienThi();
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (insert == true)
            {
                XtraMessageBox.Show("Đã hủy thêm.", "Thông báo");
                KhoaDieuKhien();
                XoaText();
            }
            else
            {
                if (insert == false)
                {
                    XtraMessageBox.Show("Đã hủy sửa.", "Thông báo");
                    KhoaDieuKhien();
                    XoaText();
                }
            }
        }

        private void griddsvt_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                cbmavt.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                txttenvt.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[1]).ToString();
                txtsoluong.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[2]).ToString();

            }
            catch
            {

            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            obj.MaLPhong = maLoaiPhong;
            obj.MaVT = cbmavt.Text;
            if (txtsoluong.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi để xóa!", "Thông báo");
                KhoaDieuKhien();
                HienThi();
            }
            else
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bll.DeleteCTVT(obj);
                    HienThi();
                    XoaText();
                    XtraMessageBox.Show("Xóa thành công!", "Thông báo");
                }
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            obj.MaVT = cbmavt.Text;
            obj.MaLPhong = maLoaiPhong;
            obj.SoLuong = txtsoluong.Text;
            if (insert == true)
            {
                if (txtsoluong.Text.Length != 0)
                {
                    if (bll.KiemTraSoLuongBanGhi(obj) >= 1)
                    {
                        XtraMessageBox.Show("Bản ghi đã tồn tại, hãy dùng chức năng sửa", "Chú ý");
                    }
                    else
                    {
                        try
                        {
                            bll.InsertCTVT(obj);
                            HienThi();
                            XtraMessageBox.Show("Đã thêm thành công!", "Thông báo");
                            XoaText();
                            KhoaDieuKhien();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Có lỗi xảy ra, thử lại.", "Thông báo");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông báo");
                }


            }
            else
            {
                if (txtsoluong.Text.Length != 0)
                {
                    try
                    {
                        cbmavt.Enabled = false;
                        bll.UpdateCTVT(obj);
                        HienThi();
                        XoaText();
                        XtraMessageBox.Show("Đã sửa thành công!", "Thông báo");
                        KhoaDieuKhien();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra, thử lại.", "Thông báo");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông báo");
                }

            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (txtsoluong.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi để sửa!", "Thông báo");
                KhoaDieuKhien();
                HienThi();
            }
            else
            {
                MoDieuKhien();
                cbmavt.Enabled = false;
                insert = false;
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            insert = true;
        }

        private void cbmavt_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txttenvt.Text = cbmavt.SelectedValue.ToString();
        }

        private void cblp_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThi();
            XoaText();
        }
    }
}
