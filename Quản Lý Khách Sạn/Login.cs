using BLL;
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
    public partial class Login : Form
    {
        #region
        TaiKhoanBLL bll = new TaiKhoanBLL();
        DangNhapDTO obj = new DangNhapDTO();
        LichSuDangNhapDTO lobj = new LichSuDangNhapDTO();
        TienIch ti = new TienIch();
        #endregion
        public Login()
        {
            InitializeComponent();
        }
        private void btdangnhap_Click_1(object sender, EventArgs e)
        {
            obj.TenDN = txttaikhoan.Text;
            obj.MatKhau = ti.GetMD5(txtmatkhau.Text);
            if (txttaikhoan.Text.Length == 0 || txtmatkhau.Text.Length == 0)
            {
                lbthongbao.Text = "Bạn nhập thiếu thông tin.";
                txttaikhoan.Focus();

            }
            else
            {
                if (bll.KiemTraSoLuongBanGhi(obj) <= 0)
                {
                    lbthongbao.Text = "Bạn nhập sai thông tin!";
                    txttaikhoan.Focus();
                }
                else
                {
                    if (bll.KiemTraSoLuongBanGhi(obj) == 1)
                    {
                        DataTable data = new DataTable();
                        data = bll.ChiTietTaiKhoan(obj);

                        Main.quyen = data.Rows[0][3].ToString();
                        Main.tenDN = data.Rows[0][2].ToString();
                        Main.matKhau = data.Rows[0][1].ToString();
                        Main.taiKhoan = data.Rows[0][0].ToString();

                        lobj.TenDN = data.Rows[0][0].ToString();
                        lobj.TenNV = data.Rows[0][2].ToString();
                        lobj.TGian = DateTime.Today.ToString();

                        bll.InsertLSDN(lobj);

                        Main frmain = new Main(Main.quyen, Main.tenDN, Main.matKhau, Main.taiKhoan);
                        this.Dispose();
                        frmain.Show();
                    }
                }
            }
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            txtmatkhau.UseSystemPasswordChar = true;
        }

        private void txtmatkhau_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btdangnhap.Focus();
            }
        }

        private void txttaikhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmatkhau.Focus();
            }
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Main frmain = new Main();
            frmain.Show();
        }

        private void checkmatkhau_CheckedChanged(object sender, EventArgs e)
        {
            if (checkmatkhau.Checked == true)
            {
                txtmatkhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtmatkhau.UseSystemPasswordChar = true;
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Main frmain = new Main();
            frmain.Show();
        }
    }
}
