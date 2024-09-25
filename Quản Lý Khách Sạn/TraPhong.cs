using BLL;
using DevExpress.XtraEditors;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lý_Khách_Sạn
{
    public partial class TraPhong : Form
    {
        #region
        ThuePhongBLL pdbll = new ThuePhongBLL();
        TienIch ti = new TienIch();
        
        ThongKeBLL tkbll = new ThongKeBLL();
        HoaDonBLL bll = new HoaDonBLL();
        PhieuDatPhongDTO pdobj = new PhieuDatPhongDTO();
        ThongKeDTO tkobj = new ThongKeDTO();
        HoaDonDTO obj = new HoaDonDTO();
        public string maphieuthue;
        public string maphieudat;
        public string nhanvien;
        public string makhach;
        DataTable dt = new DataTable();
        #endregion
        public TraPhong(string mp, string mk, string nv, string pd)
        {
            maphieuthue = mp;
            maphieudat = pd;
            nhanvien = nv;
            makhach = mk;
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            groupinhd.Enabled = false;
            txtmahd.Enabled = false;
            txtmaptp.Enabled = false;
            txtmakh.Enabled = false;
            txtngaytra.Enabled = false;
            txtnv.Enabled = false;

        }
        private void MoDieuKhien()
        {
            groupinhd.Enabled = true;
            grouplaphd.Enabled = false;
            txttongtp.Enabled = false;
            txttongtdv.Enabled = false;
            txttongt.Enabled = false;
            txttienktt.Enabled = true;
        }
        private void HienThi()
        {
            dt = bll.LayDuLieu_AllHD();
            txtmaptp.Text = maphieuthue;
            txtnv.Text = nhanvien;
            txtmakh.Text = makhach;
            txtngaytra.Text = ti.XuLyNgay(DateTime.Today);
            txtmahd.Text = dt.Rows.Count > 0 ? bll.CapNhatMaHoaDon(dt.Rows[dt.Rows.Count - 1][0].ToString()) : "HD000001";
            
        }
        private void Update_TinhTrang_PhieuDat()
        {
            try
            {
                dt = pdbll.LayDL_ThepMaPhieuPDP(maphieudat);
                pdobj.MaPD = dt.Rows[0][0].ToString();
                XtraMessageBox.Show(dt.Rows[0][0].ToString());
                pdobj.MaKH = dt.Rows[0][1].ToString();
                pdobj.NgayDen = dt.Rows[0][2].ToString();
                pdobj.NgayDi = dt.Rows[0][3].ToString();
                pdobj.TienCoc = dt.Rows[0][4].ToString();
                pdobj.TenDN = dt.Rows[0][5].ToString();
                pdobj.TinhTrang = "Đã trả";
                pdobj.SoNguoi = dt.Rows[0][7].ToString();
                pdobj.NgayLap = dt.Rows[0][8].ToString();
                pdobj.SoTreEm = dt.Rows[0][9].ToString();
                pdobj.SoNguoiLon = dt.Rows[0][10].ToString();

                pdbll.UpdatePDP(pdobj);
            }
            catch
            {
                XtraMessageBox.Show("Thử lại", "Thông báo");
            }
        }
        private void TaoHoaDon()
        {
            obj.MaHD = txtmahd.Text;
            obj.MaPTP = maphieuthue;
            obj.MaKH = makhach;
            obj.NgayTra = ti.XuLyNgay(DateTime.Today);
            obj.NhanVien = nhanvien;

            bll.InsertHD(obj);
        }
        private void Load_ThongSo_ThanhToan()
        {
            dt = bll.LayDuLieuChiTietHoaDon(txtmahd.Text);
            float tp = float.Parse(dt.Rows[0][9].ToString()) * int.Parse(dt.Rows[0][7].ToString());
            float tientreem = 0;
            if (int.Parse(dt.Rows[0][17].ToString()) > 2)
            {
                tientreem = (tp * 30) / 100;
            }
            float tongtp = tp + tientreem;
            txttongtp.Text = tongtp.ToString();
            float tiendv = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                float dv = float.Parse(dt.Rows[i][15].ToString());
                tiendv += dv;
            }

            float tiencoc = 0;
            if (dt.Rows[0][8].ToString() == "Phòng đơn")
            {
                tiencoc = 50;
            }
            if (dt.Rows[0][8].ToString() == "Phòng đôi")
            {
                tiencoc = 70;
            }
            if (dt.Rows[0][8].ToString() == "Phòng thượng hạng")
            {
                tiencoc = 100;
            }
            txttongtdv.Text = tiendv.ToString();
            txttongt.Text = ((tongtp + tiendv) - tiencoc).ToString();
        }


        private void Insert_ThongKe()
        {
            Load_ThongSo_ThanhToan();
            tkobj.MaHD = txtmahd.Text;
            tkobj.TongTien = txttongt.Text;

            tkbll.Insert(tkobj);
        }

        private void formtraphong_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        private void txttienktt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bthuy_Click_1(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Đã hủy lập hóa đơn", "Thông báo");
            this.Close();
        }

        private void btinhoadon_Click(object sender, EventArgs e)
        {
            if (txttienktt.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa nhập tiền thanh toán", "Thông báo");
            }
            else
            {
                if (float.Parse(txttienktt.Text) < float.Parse(txttongt.Text))
                {
                    XtraMessageBox.Show("Tiền thanh toán không đủ.", "Thông báo");
                }
                else
                {
                    try
                    {
                        bll.date = ti.XuLyNgay(DateTime.Today);
                        bll.tientra = txttienktt.Text;
                        bll.mahd = txtmahd.Text;
                        PrintDialog _PrintDialog = new PrintDialog();
                        PrintDocument _PrintDocument = new PrintDocument();

                        _PrintDialog.Document = _PrintDocument; //add the document to the dialog box

                        _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(bll.InHoaDon); //add an event handler that will do the printing
                                                                                                                       //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
                        DialogResult result = _PrintDialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            _PrintDocument.Print();
                        }

                    }
                    catch
                    {
                        XtraMessageBox.Show("Thử lại", "Thông báo");
                    }
                }
            }
        }

        private void btlaphd_Click(object sender, EventArgs e)
        {
            try
            {
                TaoHoaDon();
                Update_TinhTrang_PhieuDat();
                //thêm bản ghi vào bảng thống kê
                Insert_ThongKe();
                XtraMessageBox.Show("Đã thêm hóa đơn thành công", "Thông báo");
                MoDieuKhien();
                Load_ThongSo_ThanhToan();;

            }
            catch
            {
                XtraMessageBox.Show("Thử lại, Kiểm tra hóa đơn đã có chưa?", "Thông báo");
            }
        }
    }
}
