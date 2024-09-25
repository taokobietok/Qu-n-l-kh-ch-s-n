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
    public partial class KiemTraPhongDat : Form
    {
        #region
        TienIch ti = new TienIch();
        ThuePhongBLL bll = new ThuePhongBLL();
        CheckPhongDTO obj = new CheckPhongDTO();
        private bool check = false;
        public string TenDN;
        public string MaNV;
        public string MaPhong = "";
        #endregion
        public KiemTraPhongDat(string ten, string manv)
        {
            MaNV = manv;
            TenDN = ten;
            InitializeComponent();
        }
        public KiemTraPhongDat()
        {
            InitializeComponent();
        }
        private void CheckNgayDen(string ngayden, string homnay)
        {
            if (ti.TachNam(ngayden) > ti.TachNam(homnay))
            {
                //ok
                CheckNgay(datengayden.Text, datengaydi.Text);
            }
            else
            {
                if (ti.TachNam(ngayden) < ti.TachNam(homnay))
                {
                    XtraMessageBox.Show("Ngày đến phải sau hoặc cùng ngày hôm nay", "Thông báo");
                    KhoaDieuKhien();
                    datengayden.Text = string.Empty;
                    datengaydi.Text = string.Empty;
                    btphongranh.Enabled = true;
                    btlpt.Enabled = false;
                    bthuy.Enabled = false;
                    HienThi();
                }
                else
                {
                    if (ti.TachThang(ngayden) > ti.TachThang(homnay))
                    {
                        //ok
                        CheckNgay(datengayden.Text, datengaydi.Text);
                    }
                    else
                    {
                        if (ti.TachThang(ngayden) < ti.TachThang(homnay))
                        {
                            XtraMessageBox.Show("Ngày đến phải sau hoặc cùng ngày hôm nay", "Thông báo");
                            KhoaDieuKhien();
                            datengayden.Text = string.Empty;
                            datengaydi.Text = string.Empty;
                            btphongranh.Enabled = true;
                            btlpt.Enabled = false;
                            bthuy.Enabled = false;
                            HienThi();
                        }
                        else
                        {
                            if (ti.TachNgay(ngayden) >= ti.TachNgay(homnay))
                            {
                                //ok
                                CheckNgay(datengayden.Text, datengaydi.Text);
                            }
                            else
                            {
                                XtraMessageBox.Show("Ngày đến phải sau hoặc cùng ngày hôm nay", "Thông báo");
                                KhoaDieuKhien();
                                datengayden.Text = string.Empty;
                                datengaydi.Text = string.Empty;
                                btphongranh.Enabled = true;
                                btlpt.Enabled = false;
                                bthuy.Enabled = false;
                                HienThi();
                            }
                        }
                    }
                }
            }
        }
        private void HienThiKetQuaCheck()
        {
                groupControl1.Text = "Danh sách phòng thỏa mãn";
                gridp.DataSource = bll.LayDuLieuPhongRanhRoiTLP(obj.tenLP);
        }

        private void CheckNgay(string ngayden, string ngaydi)
        {
            if (ti.TachNam(ngaydi) > ti.TachNam(ngayden))
            {
                //ok
                MoDieuKhien();
                HienThiKetQuaCheck();
            }
            else
            {
                if (ti.TachNam(ngaydi) < ti.TachNam(ngayden))
                {
                    XtraMessageBox.Show("Ngày đi phải sau ngày đến", "Thông báo");
                    KhoaDieuKhien();
                    datengayden.Text = string.Empty;
                    datengaydi.Text = string.Empty;
                    btphongranh.Enabled = true;
                    btlpt.Enabled = false;
                    bthuy.Enabled = false;
                    HienThi();
                }
                else
                {
                    if (ti.TachThang(ngaydi) > ti.TachThang(ngayden))
                    {
                        //ok
                        MoDieuKhien();
                        HienThiKetQuaCheck();
                    }
                    else
                    {
                        if (ti.TachThang(ngaydi) < ti.TachThang(ngayden))
                        {
                            XtraMessageBox.Show("Ngày đi phải sau ngày đến", "Thông báo");
                            KhoaDieuKhien();
                            datengayden.Text = string.Empty;
                            datengaydi.Text = string.Empty;
                            btphongranh.Enabled = true;
                            btlpt.Enabled = false;
                            bthuy.Enabled = false;
                            HienThi();
                        }
                        else
                        {
                            if (ti.TachNgay(ngaydi) > ti.TachNgay(ngayden))
                            {
                                //ok
                                MoDieuKhien();
                                HienThiKetQuaCheck();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ngày đi phải sau ngày đến", "Thông báo");
                                KhoaDieuKhien();
                                datengayden.Text = string.Empty;
                                datengaydi.Text = string.Empty;
                                btphongranh.Enabled = true;
                                btlpt.Enabled = false;
                                bthuy.Enabled = false;
                                HienThi(); ;
                            }
                        }
                    }
                }
            }
        }

        private void KhoaDieuKhien()
        {
            txthomnay.Enabled = false;
            cbloaip.Enabled = true;
            cbtreem.Enabled = true;
            cbnguoilon.Enabled = true;


            cbsonguoi.Enabled = false;
            datengayden.Enabled = true;
            datengaydi.Enabled = true;

            bthuy.Enabled = false;
            btphongranh.Enabled = true;
            btlpt.Enabled = false;


        }
        private void MoDieuKhien()
        {
            txthomnay.Enabled = false;
            cbloaip.Enabled = false;
            cbsonguoi.Enabled = false;
            datengayden.Enabled = false;
            datengaydi.Enabled = false;
            cbtreem.Enabled = false;
            cbnguoilon.Enabled = true;

            bthuy.Enabled = true;
            btphongranh.Enabled = false;
            btlpt.Enabled = true;

        }

        private void XoaText()
        {
            cbloaip.Text = String.Empty;
            cbloaip.Enabled = false;
            datengayden.Text = string.Empty;
            datengaydi.Text = string.Empty;
            cbnguoilon.Text = string.Empty;
            cbtreem.Text = string.Empty;
        }

        private void HienThi()
        {
            if (check == false)
            {
                txthomnay.Text = ti.XuLyNgay(DateTime.Today);
                if (cbtinhtrang.Text == "Rảnh rỗi")
                {
                    groupControl1.Text = "Danh sách phòng đang rảnh";
                    gridp.DataSource = bll.LayDuLieuPhongRanhRoi();
                }
            }
            else
            {
                if (cbloaip.Text == "LP1")
                {
                    obj.tenLP = "Phòng đơn";
                }
                if (cbloaip.Text == "LP2")
                {
                    obj.tenLP = "Phòng đôi";
                }
                if (cbloaip.Text == "LP3")
                {
                    obj.tenLP = "Phòng thượng hạng";
                }
                obj.NgayDen = ti.TachNgay(datengayden.Text).ToString();
                obj.NgayDi = ti.TachNgay(datengaydi.Text).ToString();
                obj.ThangDen = ti.TachThang(datengayden.Text).ToString();
                obj.ThangDi = ti.TachThang(datengaydi.Text).ToString();
                obj.NamDen = ti.TachNam(datengayden.Text).ToString();
                obj.NamDi = ti.TachNam(datengaydi.Text).ToString();
                txthomnay.Text = ti.XuLyNgay(DateTime.Today);
                if (cbtinhtrang.Text == "Rảnh rỗi")
                {
                    groupControl1.Text = "Danh sách phòng thỏa mãn";
                    gridp.DataSource = bll.LayDuLieuPhongRanhRoiTLP(obj.tenLP);
                }
            }


        }
        private void hienthiphongttrong()
        {
            if (cbtinhtrang.Text == "Rảnh rỗi")
            {
                groupControl1.Text = "Danh sách phòng thỏa mãn";
                gridp.DataSource = bll.LayDuLieuPhongRanhRoiTLP(obj.tenLP);
            }
        }

        private void formcheckphong_Load(object sender, EventArgs e)
        {
            cbtinhtrang.Text = "Rảnh rỗi";
            KhoaDieuKhien();
            HienThi();
        }

        private void cbtinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KhoaDieuKhien();
            HienThi();
        }

        private void gridp_Click(object sender, EventArgs e)
        {
            if (cbtinhtrang.Text == "Đã nhận" && bll.KiemTraSoBanGhiPDN() == 0)
            {
                XtraMessageBox.Show("Không có phòng nào", "Thông báo");
            }
            else
            {
                if (cbtinhtrang.Text == "Đã nhận" && bll.KiemTraSoBanGhiPDN() > 0)
                {
                    MaPhong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                }
                else
                {
                    if (cbtinhtrang.Text == "Đang chờ" && bll.KiemTraSoBanGhiPDD() == 0)
                    {
                        XtraMessageBox.Show("Không có phòng nào", "Thông báo");
                    }
                    else
                    {
                        if (cbtinhtrang.Text == "Đang chờ" && bll.KiemTraSoBanGhiPDD() > 0)
                        {
                            MaPhong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                        }
                        else
                        {
                            if (cbtinhtrang.Text == "Đang chờ" && bll.KiemTraSoBanGhiPRR() == 0)
                            {
                                XtraMessageBox.Show("Không có phòng nào", "Thông báo");
                            }
                            else
                            {
                                MaPhong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();

                            }
                        }
                    }
                }
            }

        }

        private void btphongranh_Click(object sender, EventArgs e)
        {
            check = true;
            if (cbloaip.Text == "LP1")
            {
                obj.tenLP = "Phòng đơn";
            }
            if (cbloaip.Text == "LP2")
            {
                obj.tenLP = "Phòng đôi";
            }
            if (cbloaip.Text == "LP3")
            {
                obj.tenLP = "Phòng thượng hạng";
            }
            obj.NgayDen = ti.TachNgay(datengayden.Text).ToString();
            obj.NgayDi = ti.TachNgay(datengaydi.Text).ToString();
            obj.ThangDen = ti.TachThang(datengayden.Text).ToString();
            obj.ThangDi = ti.TachThang(datengaydi.Text).ToString();
            obj.NamDen = ti.TachNam(datengayden.Text).ToString();
            obj.NamDi = ti.TachNam(datengaydi.Text).ToString();
            if (cbloaip.Text.Length == 0 || datengayden.Text.Length == 0 || datengaydi.Text.Length == 0 || cbsonguoi.Text.Length == 0 || cbnguoilon.Text.Length == 0 || cbtreem.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo");
                KhoaDieuKhien();
            }
            else
            {
                try
                {

                    CheckNgayDen(datengayden.Text, txthomnay.Text);
                    HienThi();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo");
                    KhoaDieuKhien();
                    HienThi();
                    XoaText();
                }


            }
        }

        private void cbsonguoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbloaip.Enabled = true;
        }

        private void cbloaip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbnguoilon.Text != "1")
            {
                if (cbloaip.Text == "LP1")
                {
                    XtraMessageBox.Show("Loại phòng 1 chỉ cho 1 người lớn", "Thông báo");
                    cbloaip.Text = string.Empty;
                }
                else
                {
                    datengayden.Enabled = true;
                }
            }
            else
            {
                datengayden.Enabled = true;
            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            check = false;
            KhoaDieuKhien();
            XoaText();
            HienThi();
        }

        private void btlpt_Click(object sender, EventArgs e)
        {
            if (MaPhong == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn phòng", "Thông báo");
            }
            else
            {
                LapPhieuDatPhong frlpdp = new LapPhieuDatPhong(TenDN, MaNV, datengayden.Text, datengaydi.Text, cbnguoilon.Text, cbtreem.Text, cbsonguoi.Text, MaPhong, cbloaip.Text);
                frlpdp.ShowDialog();
            }
        }

        private void datengayden_SelectionChanged(object sender, EventArgs e)
        {
            datengaydi.Enabled = true;
        }

        private void cbnguoilon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbloaip.Text.Length == 0)
            {
                if (cbtreem.Text.Length == 0)
                {
                    cbtreem.Enabled = true;
                }
                else
                {
                    if (cbnguoilon.Text.Length == 0 || cbtreem.Text.Length == 0)
                    {
                        cbsonguoi.Text = "";
                    }
                    else
                    {
                        int tong = (int.Parse(cbnguoilon.Text) + int.Parse(cbtreem.Text));
                        cbsonguoi.Text = tong.ToString();
                    }
                }
            }
            else
            {
                if (cbloaip.Text == "LP1")
                {
                    if (cbnguoilon.Text != "1")
                    {
                        XtraMessageBox.Show("Loại phòng 1 chỉ tối đa 1 người lớn", "Chú ý");
                        cbnguoilon.Text = "1";
                        if (cbnguoilon.Text.Length == 0 || cbtreem.Text.Length == 0)
                        {
                            cbsonguoi.Text = "";
                        }
                        else
                        {
                            int tong = (int.Parse(cbnguoilon.Text) + int.Parse(cbtreem.Text));
                            cbsonguoi.Text = tong.ToString();
                        };
                    }
                }
                else
                {
                    if (cbnguoilon.Text.Length == 0 || cbtreem.Text.Length == 0)
                    {
                        cbsonguoi.Text = "";
                    }
                    else
                    {
                        int tong = (int.Parse(cbnguoilon.Text) + int.Parse(cbtreem.Text));
                        cbsonguoi.Text = tong.ToString();
                    }
                }
            }
        }

        private void cbtreem_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbloaip.Enabled = true;
            if (cbnguoilon.Text.Length == 0 || cbtreem.Text.Length == 0)
            {
                cbsonguoi.Text = "";
            }
            else
            {
                int tong = (int.Parse(cbnguoilon.Text) + int.Parse(cbtreem.Text));
                cbsonguoi.Text = tong.ToString();
            };
        }
    }
}
