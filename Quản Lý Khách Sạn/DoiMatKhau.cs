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
    public partial class DoiMatKhau : Form
    {
        #region
        DoiMatKhauDTO obj = new DoiMatKhauDTO();
        TaiKhoanBLL bll = new TaiKhoanBLL();
        TienIch ti = new TienIch();
        public static string taiKhoan;
        public static string matKhau;
        #endregion
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        public DoiMatKhau(string taikhoan, string mk)
        {
            taiKhoan = taikhoan;
            matKhau = mk;
            InitializeComponent();
        }

        private void formdoimatkhau_Load_1(object sender, EventArgs e)
        {
            txttendn.Enabled = false;
            txttendn.Text = taiKhoan;
        }

        private void checkhnl_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkhnl.Checked == true)
            {
                txtnhaplai.UseSystemPasswordChar = false;
            }
            else
            {
                txtnhaplai.UseSystemPasswordChar = true;
            }
        }

        private void checkhmkm_CheckedChanged(object sender, EventArgs e)
        {
            if (checkhmkm.Checked == true)
            {
                txtmkmoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtmkmoi.UseSystemPasswordChar = true;
            }
        }

        private void checkhmkc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkhmkc.Checked == true)
            {
                txtmkcu.UseSystemPasswordChar = false;
            }
            else
            {
                txtmkcu.UseSystemPasswordChar = true;
            }
        }

        private void btxacnhan_Click_1(object sender, EventArgs e)
        {
            if (v2.Text.Length == 0 || v1.Text.Length == 0 || v3.Text.Length == 0)
            {
                lbthongbao.Text = "Bạn nhập thiếu thông tin.";
            }
            else
            {
                if (ti.GetMD5(v2.Text) != matKhau)
                {
                    lbthongbao.Text = "Nhập sai mật khẩu cũ.";
                }
                else
                {
                    if (v1.Text != v3.Text)
                    {
                        lbthongbao.Text = "Nhập lại mật khẩu không trùng khớp.";
                    }
                    else
                    {
                        if (v1.Text == v2.Text)
                        {
                            lbthongbao.Text = "Chọn một mật khẩu khác.";
                        }
                        else
                        {
                            obj.MatKMoi = ti.GetMD5(v1.Text);
                            obj.TenDN = taiKhoan;
                            bll.DoiMatkhau(obj);
                            XtraMessageBox.Show("Sửa thành công!", "Thông báo");
                        }
                    }
                }
            }
        }
    }
}
