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
    public partial class TaiKhoan : Form
    {
        #region
        TienIch ti = new TienIch();
        TaiKhoanBLL bll = new TaiKhoanBLL();
        TaiKhoanDangNhapDTO obj = new TaiKhoanDangNhapDTO();
        #endregion
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            txtpq.Enabled = false;
            txttendn.Enabled = false;

            bttao.Enabled = false;
            btvohieu.Enabled = false;
            btreset.Enabled = false;
        }
        private void MoKhoaCoTaiKhoan()
        {
            txtpq.Enabled = false;
            txttendn.Enabled = false;

            bttao.Enabled = false;
            btvohieu.Enabled = true;
            btreset.Enabled = true;
        }
        private void MoKhoaChuaCoTaiKhoan()
        {
            txtpq.Enabled = false;
            txttendn.Enabled = false;

            bttao.Enabled = true;
            btvohieu.Enabled = false;
            btreset.Enabled = false;
        }
        private void XoaText()
        {
            txtpq.Text = string.Empty;
            txttendn.Text = string.Empty;
        }
        private void HienThi()
        {
            if (cbloainv.Text == "Có tài khoản")
            {
                MoKhoaCoTaiKhoan();
                XoaText();
                groupdsnv.Text = "Danh sách nhân viên đã có tài khoản";
                gridtaikhoan.DataSource = bll.LayDuLieuCoTaiKhoan();

            }
            else
            {
                if (cbloainv.Text == "Chưa có tài khoản")
                {
                    groupdsnv.Text = "Danh sách nhân viên chưa có tài khoản";
                    MoKhoaChuaCoTaiKhoan();
                    XoaText();
                    gridtaikhoan.DataSource = bll.LayDuLieuChuaCoTaiKhoan();
                }
            }
        }

        private void formtaikhoan_Load(object sender, EventArgs e)
        {
            XoaText();
            cbloainv.Text = "Có tài khoản";
            HienThi();
        }

        private void btreset_Click(object sender, EventArgs e)
        {
            obj.MaNV = txttendn.Text;
            obj.TenDN = txttendn.Text;
            obj.MatKhau = ti.GetMD5("0000");
            if (txttendn.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn nhân viên cần reset tài khoản.", "Thông báo");
            }
            else
            {
                try
                {
                    bll.UpdateTKDN(obj);
                    XtraMessageBox.Show("Reset tài khoản thành công!", "Thông báo");
                    HienThi();
                }
                catch
                {
                    XtraMessageBox.Show("Xảy ra lỗi, thử lại", "Chú ý!");
                }
            }
        }

        private void btvohieu_Click(object sender, EventArgs e)
        {
            obj.MaNV = txttendn.Text;
            obj.TenDN = txttendn.Text;
            obj.MatKhau = "";
            if (txtpq.Text == "Admin")
            {
                XtraMessageBox.Show("Không thể vô hiệu tài khoản Admin", "Cảnh báo!");
            }
            else
            {
                if (txttendn.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nhân viên cần vô hiệu tài khoản.", "Thông báo");
                }
                else
                {
                    try
                    {
                        bll.UpdateTKDN(obj);
                        XtraMessageBox.Show("Vô hiệu tài khoản thành công!", "Thông báo");
                        HienThi();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Xảy ra lỗi, thử lại", "Chú ý!");
                    }
                }
            }
        }

        private void bttao_Click(object sender, EventArgs e)
        {
            obj.MaNV = txttendn.Text;
            obj.TenDN = txttendn.Text;
            obj.MatKhau = ti.GetMD5("0000");
            if (txttendn.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn nhân viên cần tạo.", "Thông báo");
            }
            else
            {
                try
                {
                    bll.UpdateTKDN(obj);
                    XtraMessageBox.Show("Đã tạo tài khoản thành công!", "Thông báo");
                    HienThi();
                }
                catch
                {
                    XtraMessageBox.Show("Xảy ra lỗi, thử lại", "Chú ý!");
                }
            }
        }

        private void gridtaikhoan_Click(object sender, EventArgs e)
        {
            try
            {
                txttendn.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtpq.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();

            }
            catch
            {

            }
        }

        private void cbloainv_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
