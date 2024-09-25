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
    public partial class NhanVien : Form
    {
        #region
        TienIch ti = new TienIch();
        TaiKhoanBLL tkbll = new TaiKhoanBLL();
        NhanVienBLL bll = new NhanVienBLL();
        TaiKhoanDangNhapDTO tkobj = new TaiKhoanDangNhapDTO();
        NhanVienDTO obj = new NhanVienDTO();
        private bool insert = false;
        #endregion
        public NhanVien()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            txttendn.Enabled = false;
            txtmanv.Enabled = false;
            txttennv.Enabled = false;
            txtgtinh.Enabled = false;
            txtngaysinh.Enabled = false;
            txtchucvu.Enabled = false;
            txtdiachi.Enabled = false;
            txtsdt.Enabled = false;

            btluu.Enabled = false;
            bthuy.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }

        private void MoDieuKhien()
        {
            txttendn.Enabled = false;
            txtmanv.Enabled = false;
            txttennv.Enabled = true;
            txtgtinh.Enabled = true;
            txtngaysinh.Enabled = true;
            txtchucvu.Enabled = true;
            txtdiachi.Enabled = true;
            txtsdt.Enabled = true;

            btluu.Enabled = true;
            bthuy.Enabled = true;
            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }

        private void XoaText()
        {
            txtmanv.Text = String.Empty;
            txttennv.Text = String.Empty;
            txtgtinh.Text = String.Empty;
            txtngaysinh.Text = String.Empty;
            txtchucvu.Text = String.Empty;
            txtdiachi.Text = String.Empty;
            txtsdt.Text = String.Empty;
        }

        private void HienThi()
        {
            btxoa.Enabled = true;
            gridnhanvien.DataSource = bll.LayDuLieuNV_DiLam();
        }

        private void formnhanvien_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        private void cbhientrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThi();
        }

        private void txtsdt_KeyPress(object sender, KeyPressEventArgs e)
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
                XtraMessageBox.Show("Đã hủy thêm!", "Thông báo");
                KhoaDieuKhien();
                XoaText();
                HienThi();
            }
            else
            {
                XtraMessageBox.Show("Đã hủy sửa!", "Thông báo");
                KhoaDieuKhien();
                XoaText();
                HienThi();
            }
        }

        private void gridnhanvien_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtmanv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txttennv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtngaysinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtgtinh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                txtdiachi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtsdt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtchucvu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
            }
            catch
            {

            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            obj.MaNV = txtmanv.Text;
            obj.TenNV = txttennv.Text;
            obj.NgaySinh = txtngaysinh.Text;
            obj.GioiTinh = txtgtinh.Text;
            obj.DiaChi = txtdiachi.Text;
            obj.SDT = txtsdt.Text;
            obj.ChucVu = txtchucvu.Text;

            tkobj.TenDN = txtmanv.Text;
            tkobj.MaNV = txtmanv.Text;
            tkobj.MatKhau = "";

            if (insert == true)
            {

                if (txttennv.Text.Length == 0 || txtgtinh.Text.Length == 0 || txtngaysinh.Text.Length == 0 || txtchucvu.Text.Length == 0 || txtdiachi.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết.\nMục (*) không được để trống.", "Thông báo");
                }
                else
                {
                    if (txtsdt.Text.Length != 0 && txtsdt.Text.Length < 10 || txtsdt.Text.Length != 0 && txtsdt.Text.Length > 12)
                    {

                        if (txtsdt.Text.Substring(0, 1) != "0")
                        {
                            XtraMessageBox.Show("Số điện thoại không chính xác", "Thông báo");
                        }
                        else
                            XtraMessageBox.Show("Số điện thoại không chính xác", "Thông báo");
                    }
                    else
                    {
                        try
                        {

                            bll.Insert(obj);
                            tkbll.InsertTKDN(tkobj);
                            XtraMessageBox.Show("Thêm thành công!", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết.\nMục (*) không được để trống.", "Thông báo");
                        }
                    }
                }

            }
            else
            {
                if (txttennv.Text.Length == 0 || txtgtinh.Text.Length == 0 || txtngaysinh.Text.Length == 0 || txtchucvu.Text.Length == 0 || txtdiachi.Text.Length == 0)
                {
                    XtraMessageBox.Show("Mục (*) không được để trống.", "Thông báo");
                }
                else
                {
                    if (txtsdt.Text.Length != 0 && txtsdt.Text.Length < 10 || txtsdt.Text.Length != 0 && txtsdt.Text.Length > 12)
                    {

                        if (txtsdt.Text.Substring(0, 1) != "0")
                        {
                            XtraMessageBox.Show("Số điện thoại không chính xác", "Thông báo");
                        }
                        else
                            XtraMessageBox.Show("Số điện thoại không chính xác", "Thông báo");
                    }
                    else
                    {
                        try
                        {

                            bll.Update(obj);
                            XtraMessageBox.Show("Sửa thành công!", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Mục (*) không được để trống.", "Thông báo");
                        }
                    }
                }

            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "NV001")
            {
                XtraMessageBox.Show("Đây là tài khoản Admin.\nKhông thể thao tác!", "Cảnh báo");
            }
            else
            {
                if (txtmanv.Text.Length != 0)
                {
                    tkobj.MaNV = txtmanv.Text;
                    tkobj.TenDN = txtmanv.Text;
                    tkobj.MatKhau = "";
                    if (XtraMessageBox.Show("Bạn có muốn tiếp tục?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            //update
                            bll.NhanVienNghiViec(txtmanv.Text);
                            XtraMessageBox.Show("Thành công", "Thông báo");
                            tkbll.UpdateTKDN(tkobj);
                            XtraMessageBox.Show("Vô hiệu tài khoản tương đương", "Thông báo");
                            KhoaDieuKhien();
                            XoaText();
                            HienThi();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Thử lại", "Thông báo");
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Bạn chưa chọn bản ghi.", "Thông báo");
                    KhoaDieuKhien();
                    HienThi();
                }
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text.Length != 0)
            {
                MoDieuKhien();
                txtmanv.Enabled = false;
                insert = false;
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi.", "Thông báo");
                KhoaDieuKhien();
                HienThi();
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            DataTable dtTable = bll.LayDuLieu();
            MoDieuKhien();
            XoaText();

            txtmanv.Text = dtTable.Rows.Count > 0 ? bll.CapNhatMaNhanVien(dtTable.Rows[dtTable.Rows.Count - 1][0].ToString()) : "NV001";

            insert = true;
        }
    }
}
