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
    public partial class KhachHang : Form
    {
        #region
        KhachHangDTO obj = new KhachHangDTO();
        KhachHangBLL bll = new KhachHangBLL();
        ThongKeBLL tkbll = new ThongKeBLL();
        HoaDonBLL hdbll = new HoaDonBLL();
        ThuePhongBLL thuephong = new ThuePhongBLL();
        TienIch ti = new TienIch();
        private bool insert = false;
        #endregion
        public KhachHang()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            txtdate.Enabled = false;
            txtmakh.Enabled = false;
            txttenkh.Enabled = false;
            txtphai.Enabled = false;
            txtdiachi.Enabled = false;
            txtcmnd.Enabled = false;
            txtcoquan.Enabled = false;
            txtemail.Enabled = false;
            txtfax.Enabled = false;
            txtsdt.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;

            btluu.Enabled = false;
            bthuy.Enabled = false;
        }

        private void MoDieuKhien()
        {
            txtdate.Enabled = false;
            txtmakh.Enabled = false;
            txttenkh.Enabled = true;
            txtphai.Enabled = true;
            txtdiachi.Enabled = true;
            txtcmnd.Enabled = true;
            txtcoquan.Enabled = true;
            txtemail.Enabled = true;
            txtfax.Enabled = true;
            txtsdt.Enabled = true;

            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
        }

        private void XoaText()
        {
            txtmakh.Text = String.Empty;
            txttenkh.Text = String.Empty;
            txtphai.Text = String.Empty;
            txtdiachi.Text = String.Empty;
            txtcmnd.Text = String.Empty;
            txtcoquan.Text = String.Empty;
            txtemail.Text = String.Empty;
            txtfax.Text = String.Empty;
            txtsdt.Text = String.Empty;
        }

        private void HienThi()
        {
            gridkhachhang.DataSource = bll.LayDuLieu();
        }

        private void btthem_Click_1(object sender, EventArgs e)
        {
            DataTable dtTable = bll.LayDuLieu();
            MoDieuKhien();
            XoaText();
            txtmakh.Text = dtTable.Rows.Count > 0 ? bll.CapNhatMaKhachHang(dtTable.Rows[dtTable.Rows.Count - 1][0].ToString()) : "KH000001";

            insert = true;
        }

        private void formkhachhang_Load_1(object sender, EventArgs e)
        {
            txtdate.Text = ti.XuLyNgay(DateTime.Today);
            KhoaDieuKhien();
            HienThi();
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

        private void txtcmnd_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txttenkh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 122) || e.KeyChar == 8 || e.KeyChar == 32);
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

        private void gridkhachhang_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtmakh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txttenkh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtphai.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtcmnd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                txtdiachi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();
                txtcoquan.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
                txtsdt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
                txtemail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[7]).ToString();
                txtfax.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[8]).ToString();
            }
            catch
            {

            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            obj.MaKH = txtmakh.Text;
            obj.TenKH = txttenkh.Text;
            obj.GioiTinh = txtphai.Text;
            obj.CMND = txtcmnd.Text;
            obj.DiaChi = txtdiachi.Text;
            obj.CoQuan = txtcoquan.Text;
            obj.SDT = txtsdt.Text;
            obj.Email = txtemail.Text;
            obj.Fax = txtfax.Text;

            if (insert == true)
            {

                if (txttenkh.Text.Length == 0 || txtphai.Text.Length == 0 || txtcmnd.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết. Mục (*) không được để trống.", "Thông báo");
                }
                else
                {
                    if (txtcmnd.Text.Length < 9)
                    {
                        XtraMessageBox.Show("Số CMND không hợp lệ", "Thông báo");
                    }
                    else
                    {
                        try
                        {

                            bll.Insert(obj);
                            XtraMessageBox.Show("Thêm thành công!", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết. Mục (*) không được để trống.", "Thông báo");
                        }
                    }
                }

            }
            else
            {
                if (txttenkh.Text.Length == 0 || txtphai.Text.Length == 0 || txtcmnd.Text.Length == 0)
                {
                    XtraMessageBox.Show("Mục (*) không được để trống.", "Thông báo");
                }
                else
                {
                    if (txtcmnd.Text.Length < 9)
                    {
                        XtraMessageBox.Show("Số CMND không hợp lệ", "Thông báo");
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
            if (txtmakh.Text.Length != 0)
            {
                if (XtraMessageBox.Show("Xóa khách hàng sẽ xóa toàn bộ giao dịch. \n Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        DataTable dp = thuephong.LayDuLieu_QuaIMaKHPDP(txtmakh.Text);

                        if (dp.Rows.Count > 0)
                        {
                            DataTable tp = thuephong.LayDuLieu_QuaMaPDP(dp.Rows[0][0].ToString());
                            if (tp.Rows.Count > 0)
                            {

                                DataTable hd = hdbll.LayDuLieu_Qua_MaKH(txtmakh.Text);
                                //XtraMessageBox.Show((hd.Rows[0][0].ToString() + "\n" + tp.Rows[0][0].ToString() + "\n" + dp.Rows[0][0].ToString()));
                                //xóa thống kê

                                if (hd.Rows.Count > 0)
                                {
                                    tkbll.Delete(hd.Rows[0][0].ToString());
                                    XtraMessageBox.Show("Đã xóa dữ liệu từ thống kê", "Thông báo");
                                    hdbll.DeleteHD(hd.Rows[0][0].ToString());
                                    XtraMessageBox.Show("Đã xóa dữ liệu từ hóa đơn", "Thông báo");
                                }
                                else
                                {
                                    XtraMessageBox.Show("Không có dữ liệu hóa đơn", "Thông báo");
                                }

                                //xóa ct thuê
                                thuephong.DeleteCTTP(tp.Rows[0][0].ToString());

                                //xóa phiếu thuê
                                thuephong.Delete_By_maPDP(dp.Rows[0][0].ToString());
                                XtraMessageBox.Show("Đã xóa dữ liệu thuê phòng", "Thông báo");

                                //xóa ct đặt
                                thuephong.DeleteCTPDP(dp.Rows[0][0].ToString());

                                //xóa đặt
                                thuephong.Delete_QuaIMaKHPDP(txtmakh.Text);
                                XtraMessageBox.Show("Đã xóa dữ liệu đặt phòng", "Thông báo");


                            }
                            else
                            {
                                //xóa ct đặt
                                thuephong.DeleteCTPDP(dp.Rows[0][0].ToString());

                                //xóa đặt
                                thuephong.Delete_QuaIMaKHPDP(txtmakh.Text);
                                XtraMessageBox.Show("Đã xóa dữ liệu đặt phòng", "Thông báo");
                            }

                        }

                        //xóa khách hàng
                        bll.Delete(txtmakh.Text);

                        //hoàn tất
                        XtraMessageBox.Show("Đã xóa thành công", "Thông báo");
                        XoaText();
                        KhoaDieuKhien();
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

        private void btsua_Click(object sender, EventArgs e)
        {
            if (txtmakh.Text.Length != 0)
            {
                MoDieuKhien();
                txtmakh.Enabled = false;
                insert = false;
            }
            else
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi.", "Thông báo");
                KhoaDieuKhien();
                HienThi();
            }
        }
    }
}
