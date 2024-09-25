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
    public partial class Phong : Form
    {
        #region
        DanhSachPhongBLL bll = new DanhSachPhongBLL();
        DanhSachPhongDTO obj = new DanhSachPhongDTO();
        ThongKeBLL tkbll = new ThongKeBLL();

        HoaDonBLL hdbll = new HoaDonBLL();

        ThuePhongBLL tpbll = new ThuePhongBLL();
        private bool insert = false;
        DataTable dt = new DataTable();
        #endregion
        public Phong()
        {
            InitializeComponent();
        }
        private void KhoaDieuKhien()
        {
            gridp.Enabled = true;
            txttinhtrang.Enabled = false;
            txtmap.Enabled = false;
            cbmalp.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;

            btluu.Enabled = false;
            bthuy.Enabled = false;
        }
        private void MoDieuKhien()
        {
            gridp.Enabled = false;
            txttinhtrang.Enabled = false;
            txtmap.Enabled = false;
            cbmalp.Enabled = true;

            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
        }

        private void XoaText()
        {
            txttinhtrang.Text = String.Empty;
            txtmap.Text = String.Empty;
            cbmalp.Text = String.Empty;
        }
        private void HienThi()
        {
            gridp.DataSource = bll.LayDuLieu();

        }

        private void txtsop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        

        private void formphong_Load(object sender, EventArgs e)
        {
            bll.CapNhatPhongRR();
            bll.CapNhatPhongDD();
            bll.CapNhatPhongDN();
            KhoaDieuKhien();
            HienThi();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (txtmap.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
            }
            else
            {
                //đổ dữ liệu mã phòng ra
                string map = txtmap.Text;

                //xem các bản ghi của thống kê qua mã phòng
                DataTable tk = tkbll.LayDuLieu_Qua_MaPhong(map);
                //kiểm tra số bản ghi thống kê tồn tại
                if (tk.Rows.Count > 0)
                {
                    //nếu có bản ghi thì xóa
                    tkbll.XoaDuLieu_Qua_MaPhong(map);
                    XtraMessageBox.Show("Đã xóa dữ liệu thống kê", "Thông báo");
                    //vì có dữ liệu hóa đơn thì mới tồn tại dữ liệu thống kê, 
                    //Nên xóa dữ liệu hóa đơn mà không cần kiểm tra
                    hdbll.XoaDuLieu_Qua_MaPhong(map);
                    XtraMessageBox.Show("Đã xóa dữ liệu hóa đơn", "Thông báo");

                    //xem các bản ghi chi tiết thuê phòng
                    DataTable cttp = tpbll.LayDuLieu_Qua_MaPhongCTTP(map);

                    //Kiểm tra số lượng bản ghi cttp
                    if (cttp.Rows.Count > 0)
                    {
                        //nếu có thì xóa
                        tpbll.XoaDuLieu_Qua_MaPhongCTTP(map);
                        //đồng thời xóa luôn phiếu thuê
                        tpbll.XoaDuLieu_Qua_MaPhongPNP(map);
                        XtraMessageBox.Show("Đã xóa dữ liệu thuê phòng", "Thông báo");

                        //xemcasc bản ghi phiếu đặt
                        DataTable pdp = tpbll.LayDuLieu_Qua_MaPhongPDP(map);


                        //kiểm tra số lượng
                        if (pdp.Rows.Count > 0)
                        {
                            //Xóa luôn ctpdp
                            tpbll.XoaDuLieu_Qua_MaPhongCTPDP(map);
                            //nếu có thì xóa
                            tpbll.XoaDuLieu_Qua_MaPhongPDP(map);
                            XtraMessageBox.Show("Đã xóa dữ liệu đặt phòng", "Thông báo");

                            //Xóa dữ liệu phòng 
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();
                        }

                        else
                        {
                            //nếu không có dữ liệu đặt phòng thì bỏ qua
                            //Xóa dữ liệu phòng 
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();


                        }
                    }
                    else
                    {
                        //nếu không có dữ liệu thuê phòng thì bỏ qua

                        //xemcasc bản ghi phiếu đặt
                        DataTable pdp = tpbll.LayDuLieu_Qua_MaPhongPDP(map);
                        //kiểm tra số lượng
                        if (pdp.Rows.Count > 0)
                        {
                            //Xóa luôn ctpdp
                            tpbll.XoaDuLieu_Qua_MaPhongCTPDP(map);
                            //nếu có thì xóa
                            tpbll.XoaDuLieu_Qua_MaPhongPDP(map);
                            XtraMessageBox.Show("Đã xóa dữ liệu đặt phòng", "Thông báo");

                            //Xóa dữ liệu phòng 
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();
                        }
                        else
                        {
                            //nếu không có dữ liệu đặt phòng thì bỏ qua
                            //Xóa dữ liệu phòng 
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();


                        }
                    }

                }
                else
                {
                    //nếu không có dữ liệu thống kê(hóa đơn) thì bỏ qua

                    //xem các bản ghi chi tiết thuê phòng
                    DataTable cttp = tpbll.LayDuLieu_Qua_MaPhongCTTP(map);
                    //Kiểm tra số lượng bản ghi cttp
                    if (cttp.Rows.Count > 0)
                    {
                        //nếu có thì xóa
                        tpbll.XoaDuLieu_Qua_MaPhongCTTP(map);
                        //đồng thời xóa luôn phiếu thuê
                        tpbll.XoaDuLieu_Qua_MaPhongPNP(map);
                        XtraMessageBox.Show("Đã xóa dữ liệu thuê phòng", "Thông báo");

                        //xemcasc bản ghi phiếu đặt
                        DataTable pdp = tpbll.LayDuLieu_Qua_MaPhongPDP(map);

                        //kiểm tra số lượng
                        if (pdp.Rows.Count > 0)
                        {
                            //Xóa luôn ctpdp
                            tpbll.XoaDuLieu_Qua_MaPhongCTPDP(map);
                            //nếu có thì xóa
                            tpbll.XoaDuLieu_Qua_MaPhongPDP(map);
                            XtraMessageBox.Show("Đã xóa dữ liệu đặt phòng", "Thông báo");

                            //Xóa dữ liệu phòng 
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();
                        }
                        else
                        {
                            //không có dữ liệu đặp phòng thì bỏ qua

                            //xóa dữ liệu phòng
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();

                        }
                    }
                    else
                    {
                        //Không có dữ liệu thê phòng thì bỏ qua
                        //xemcasc bản ghi phiếu đặt
                        DataTable pdp = tpbll.LayDuLieu_Qua_MaPhongPDP(map);

                        //kiểm tra số lượng
                        if (pdp.Rows.Count > 0)
                        {
                            //Xóa luôn ctpdp
                            tpbll.XoaDuLieu_Qua_MaPhongCTPDP(map);
                            //nếu có thì xóa
                            tpbll.XoaDuLieu_Qua_MaPhongPDP(map);
                            XtraMessageBox.Show("Đã xóa dữ liệu đặt phòng", "Thông báo");

                            //Xóa dữ liệu phòng 
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();
                        }
                        else
                        {
                            //không có dữ liệu đặp phòng thì bỏ qua

                            //xóa dữ liệu phòng
                            bll.Delete(map);
                            XtraMessageBox.Show("Đã xóa phòng thành công", "Thông báo");
                            KhoaDieuKhien();
                            HienThi();
                            XoaText();

                        }
                    }
                }

            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (insert == true)
            {
                XtraMessageBox.Show("Đã hủy thêm", "Thông báo");
                KhoaDieuKhien();
                XoaText();
                HienThi();

            }
            else
            {
                XtraMessageBox.Show("Đã hủy sửa", "Thông báo");
                KhoaDieuKhien();
                XoaText();
                HienThi();
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            obj.MaLPhong = cbmalp.Text;
            obj.MaPhong = txtmap.Text;
            obj.DaDat = "";
            obj.DaNhan = "";
            if (insert == true)
            {
                if (cbmalp.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo");
                }
                else
                {
                    try
                    {
                        bll.Insert(obj);
                        KhoaDieuKhien();
                        XoaText();
                        XtraMessageBox.Show("Đã thêm thành công", "Thông báo");
                        HienThi();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra, hãy thử lại", "Thông báo");
                        KhoaDieuKhien();
                        XoaText();
                        HienThi();
                    }
                }
            }
            else
            {
                if (cbmalp.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo");
                }
                else
                {
                    {
                        try
                        {
                            bll.Update(obj);
                            KhoaDieuKhien();
                            XoaText();
                            XtraMessageBox.Show("Đã sửa thành công", "Thông báo");
                            HienThi();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Có lỗi xảy ra, hãy thử lại", "Thông báo");
                            KhoaDieuKhien();
                            XoaText();
                            HienThi();
                        }
                    }
                }
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (txtmap.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
                KhoaDieuKhien();
                HienThi();
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

            txtmap.Text = dtTable.Rows.Count > 0 ? bll.CapNhatMaPhong(dtTable.Rows[dtTable.Rows.Count - 1][0].ToString()) : "KSA101";

            //txtmap.Text = dt.Rows.Count > 0 ? danhsachphong_service.CapNhatMaPhong(dt.Rows[dt.Rows.Count - 1][0].ToString()) : "KSA101";
            insert = true;
        }

        private void gridp_Click(object sender, EventArgs e)
        {
            txtmap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            string tenlphong = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
            string dat = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[5]).ToString();
            string nhan = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[6]).ToString();
            if (tenlphong == "Phòng đơn")
            {
                cbmalp.Text = "LP1";
            }
            else
            {
                if (tenlphong == "Phòng đôi")
                {
                    cbmalp.Text = "LP2";
                }
                else
                {
                    cbmalp.Text = "LP3";
                }
            }
            if (dat == "False" && nhan == "False")
            {
                txttinhtrang.Text = "Rảnh rỗi";
            }
            else
            {
                if (dat == "True" && nhan == "False")
                {
                    txttinhtrang.Text = "Đã đặt";
                }
                else
                {
                    txttinhtrang.Text = "Đã nhận";
                }

            }
        }
    }
}
