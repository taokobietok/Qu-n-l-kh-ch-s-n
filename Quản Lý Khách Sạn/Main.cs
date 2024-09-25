using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quản_Lý_Khách_Sạn
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Main()
        {
            InitializeComponent();
        }
        public static String quyen = "";
        public static String tenDN;
        public static String matKhau;

        public static String taiKhoan;
        public Main(string phanquyen, string ten, string mk, string tk)
        {
            quyen = phanquyen;
            tenDN = ten;
            matKhau = mk;
            taiKhoan = tk;
            InitializeComponent();
        }

        private Form CheckForm(Type t)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == t)
                {
                    return f;
                }
            }
            return null;
        }
        private void KhoaHeThong()
        {
            tabhello.Visible = false;
            tabcnnc.Visible = false;
            tabql.Visible = false;
            tabdtp.Visible = false;
            //group2_tabht.Visible = false;
            //thoátToolStripMenuItem.Visible = true;

            btndangnhap.Enabled = true;
            btndangxuat.Enabled = false;
            btndoimk.Enabled = false;
            //barbtsaoluu.Enabled = false;
        }
        private void ChiTietDangNhap()
        {
            tabhello.Text = "Xin chào:  " + quyen + " (" + tenDN + ")";
        }

        private void MoHeThong(String quyen)
        {
            if (quyen == "")
            {
                KhoaHeThong();
            }
            else
            {
                if (quyen == "Nhân viên")
                {
                    ChiTietDangNhap();

                    tabhello.Visible = true;
                    tabcnnc.Visible = false;
                    tabql.Visible = true;
                    tabdtp.Visible = true;
                    //group2_tabht.Visible = true;
                    //thoátToolStripMenuItem.Visible = true;

                    btndangnhap.Enabled = false;
                    btndangxuat.Enabled = true;
                    btndoimk.Enabled = true;
                    //barbtsaoluu.Enabled = true;
                }
                else
                {
                    if (quyen == "Quản lý")
                    {
                        ChiTietDangNhap();

                        tabhello.Visible = true;
                        tabcnnc.Visible = true;
                        tabql.Visible = true;
                        tabdtp.Visible = true;
                        //group2_tabht.Visible = false;
                        //thoátToolStripMenuItem.Visible = true;

                        btndangnhap.Enabled = false;
                        btntaikhoan.Enabled = false;
                        btndangxuat.Enabled = true;
                        btndoimk.Enabled = true;
                        //barbtsaoluu.Enabled = false;
                    }
                    else
                    {
                        if (quyen == "Admin")
                        {
                            ChiTietDangNhap();

                            tabhello.Visible = true;
                            tabcnnc.Visible = true;
                            tabql.Visible = true;
                            tabdtp.Visible = true;
                            //group2_tabht.Visible = true;
                            //thoátToolStripMenuItem.Visible = true;

                            btndangnhap.Enabled = false;
                            btndangxuat.Enabled = true;
                            btndoimk.Enabled = true;
                            //barbtsaoluu.Enabled = true;
                        }
                    }
                }
            }
        }
        private void AddForm(Form f)
        {
            this.pnlMain.Controls.Clear();//xóa các control hiện có trên groupbox
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;//bỏ viền của form
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.pnlMain.Controls.Add(f);
            f.Show();
        }
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void bttrangchu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(Nen));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formhello frhl = new formhello();
                frhl.MdiParent = this;
                frhl.Show();*/
                var hl = new Nen();
                AddForm(hl);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MoHeThong(quyen);
            /*Form form = CheckForm(typeof(Nen));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formhello frhl = new formhello();
                frhl.MdiParent = this;
                frhl.Show();//
                var hl = new Nen();
                AddForm(hl);
            }*/
        }

        private void btndangnhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Login frdangnhap = new Login();
            this.Hide();
            frdangnhap.Show();
        }

        private void btndangxuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất?", "thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                quyen = "";
                Main frmain = new Main();
                this.Hide();
                frmain.Show();
                MessageBox.Show("Đăng xuất thành công!", "Thông báo");

                KhoaHeThong();
            }
        }

        private void btndoimk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(DoiMatKhau));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                DoiMatKhau.taiKhoan = taiKhoan;
                DoiMatKhau.matKhau = matKhau;
                /*formdoimatkhau frdmk = new formdoimatkhau(formdoimatkhau.taiKhoan, formdoimatkhau.matKhau);
                frdmk.MdiParent = this;
                frdmk.Show();*/
                var doimk = new DoiMatKhau(DoiMatKhau.taiKhoan, DoiMatKhau.matKhau);
                AddForm(doimk);
            }
        }

        private void btnkhachhang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(KhachHang));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formkhachhang frkhachhang = new formkhachhang();
                frkhachhang.MdiParent = this;
                frkhachhang.Show();*/
                var kh = new KhachHang();
                AddForm(kh);
            }
        }

        private void btnphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(Phong));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formphong frphong = new formphong();
                frphong.MdiParent = this;
                frphong.Show();*/
                var phong = new Phong();
                AddForm(phong);
            }
        }

        private void btnvattutungphon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(VatTu));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formvattu frvattu = new formvattu();
                frvattu.MdiParent = this;
                frvattu.Show();*/
                var vattu = new VatTu();
                AddForm(vattu);
            }
        }

        private void btnctvt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(ChiTietVatTu));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formchitietvattu frctvt = new formchitietvattu();
                frctvt.MdiParent = this;
                frctvt.Show();*/
                var ctvt = new ChiTietVatTu();
                AddForm(ctvt);
            }
        }

        private void btndichvu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(DichVu));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formdichvu frdichvu = new formdichvu();
                frdichvu.MdiParent = this;
                frdichvu.Show();*/
                var dichvu = new DichVu();
                AddForm(dichvu);
            }
        }

        private void btnktphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(KiemTraPhongDat));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formcheckphong frcp = new formcheckphong(tenDN, taiKhoan);
                frcp.MdiParent = this;
                frcp.Show();*/
                var timphong = new KiemTraPhongDat(tenDN, taiKhoan);
                AddForm(timphong);
            }
        }

        private void btnpdatphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(PhieuDatPhong));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formphieudatphong frpdp = new formphieudatphong(taiKhoan);
                frpdp.MdiParent = this;
                frpdp.Show();*/
                var pdp = new PhieuDatPhong(taiKhoan);
                AddForm(pdp);
            }
        }

        private void btnpthuephong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(PhieuThuePhong));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formphieuthuephong frptp = new formphieuthuephong();
                frptp.MdiParent = this;
                frptp.Show();*/
                var ptp = new PhieuThuePhong();
                AddForm(ptp);

            }
        }

        private void btnhoadon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(HoaDon));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formhoadon frhd = new formhoadon();
                frhd.MdiParent = this;
                frhd.Show();*/
                var hoadon = new HoaDon();
                AddForm(hoadon);

            }
        }

        private void btnnhanvien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(NhanVien));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formnhanvien frnhanvien = new formnhanvien();
                frnhanvien.MdiParent = this;
                frnhanvien.Show();*/
                var nv = new NhanVien();
                AddForm(nv);

            }
        }

        private void btntaikhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = CheckForm(typeof(TaiKhoan));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                /*formtaikhoan frtk = new formtaikhoan();
                frtk.MdiParent = this;
                frtk.Show();*/
                var tk = new TaiKhoan();
                AddForm(tk);

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Bạn có muốn thoát?", "thông báo", MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
