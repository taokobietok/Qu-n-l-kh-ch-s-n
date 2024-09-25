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
    public partial class DichVu : Form
    {
        #region
        DichVuBLL bll = new DichVuBLL();
        DichVuDTO obj = new DichVuDTO();
        DataTable dt = new DataTable();
        private bool insert = false;
        #endregion
        public DichVu()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            txtmadv.Enabled = false;
            txttendv.Enabled = false;
            txtgiadv.Enabled = false;
            txtdvt.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;

            btluu.Enabled = false;
            bthuy.Enabled = false;
        }

        private void MoDieuKhien()
        {
            txtmadv.Enabled = false;
            txttendv.Enabled = true;
            txtgiadv.Enabled = true;
            txtdvt.Enabled = true;

            btthem.Enabled = false;
            btsua.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
        }

        private void XoaText()
        {
            txtmadv.Text = string.Empty;
            txttendv.Text = string.Empty;
            txtgiadv.Text = string.Empty;
        }
        private void HienThi()
        {
            griddv.DataSource = bll.LayDuLieu();
        }
        private void formdichvu_Load_1(object sender, EventArgs e)
        {
            txtdvt.Text = "USD";
            KhoaDieuKhien();
            HienThi();

        }

        private void txtgiadv_KeyPress_1(object sender, KeyPressEventArgs e)
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
                XtraMessageBox.Show("Đã hủy thêm", "Thông báo");
                KhoaDieuKhien();
                HienThi();
                XoaText();
            }
            else
            {
                XtraMessageBox.Show("Đã hủy sửa", "Thông báo");
                KhoaDieuKhien();
                HienThi();
                XoaText();
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            obj.MaDV = txtmadv.Text;
            obj.TenDV = txttendv.Text;
            obj.GiaDV = txtgiadv.Text;
            obj.DVT = txtdvt.Text;
            if (insert == true)
            {
                if (txttendv.Text.Length == 0 || txtgiadv.Text.Length == 0 || txtdvt.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn nhập thiếu thông tin", "Thông báo");
                }
                else
                {
                    try
                    {
                        bll.Insert(obj);
                        HienThi();
                        XtraMessageBox.Show("Thêm thành công", "Thông báo");
                        XoaText();
                        KhoaDieuKhien();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra, thử lại", " Thông báo");
                    }
                }

            }
            else
            {
                if (txttendv.Text.Length == 0 || txtgiadv.Text.Length == 0 || txtdvt.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn nhập thiếu thông tin", "Thông báo");
                }
                else
                {
                    try
                    {
                        bll.Update(obj);
                        HienThi();
                        XtraMessageBox.Show("Sửa thành công", "Thông báo");
                        XoaText();
                        KhoaDieuKhien();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra, thử lại", " Thông báo");
                    }

                }

            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (txtmadv.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
                KhoaDieuKhien();
                XoaText();
            }
            else
            {
                MoDieuKhien();
                insert = false;
            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            DataTable dtTable = bll.LayDuLieu();
            MoDieuKhien();
            XoaText();
            txtmadv.Text = dtTable.Rows.Count > 0 ? bll.CapNhatMaDichVu(dtTable.Rows[dtTable.Rows.Count - 1][0].ToString()) : "DV001";
            insert = true;
        }

        private void griddv_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtmadv.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                txttendv.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[1]).ToString();
                txtgiadv.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[2]).ToString();
                txtdvt.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[3]).ToString();
            }
            catch
            {

            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (txtmadv.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
                KhoaDieuKhien();
                XoaText();
            }
            else
            {
                if (txtmadv.Text == "DV001")
                {
                    XtraMessageBox.Show("Không thể xóa dịch vụ dùng khởi tạo", "Thông báo");
                }
                else
                {
                    if (XtraMessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            bll.Delete(txtmadv.Text);
                            XtraMessageBox.Show("Đã xóa thành công", "Thông báo");
                            XoaText();
                            KhoaDieuKhien();
                            HienThi();
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}
