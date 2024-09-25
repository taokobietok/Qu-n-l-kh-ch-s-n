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
    public partial class ChiTietVatTu : Form
    {
        #region
        VatTuBLL bll = new VatTuBLL();
        VatTuDTO obj = new VatTuDTO();
        DataTable dt = new DataTable();
        private bool insert = false;
        #endregion
        public ChiTietVatTu()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            txtmavt.Enabled = false;
            txttenvt.Enabled = false;

            btthem.Enabled = true;
            btsua.Enabled = true;
            btxoa.Enabled = true;

            btluu.Enabled = false;
            bthuy.Enabled = false;
        }

        private void MoDieuKhien()
        {
            txtmavt.Enabled = false;
            txttenvt.Enabled = true;

            btthem.Enabled = false;
            btsua.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
        }
        private void XoaText()
        {
            txtmavt.Text = string.Empty;
            txttenvt.Text = string.Empty;
        }
        private void HienThi()
        {
            gridvattu.DataSource = bll.LayDuLieuVT();

        }
        private void formchitietvattu_Load_1(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
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
            if (insert == true)
            {
                obj.MaVT = txtmavt.Text;
                obj.TenVT = txttenvt.Text;
                if (txttenvt.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập đủ thông tin.", "Thông báo");
                }
                else
                {
                    try
                    {

                        bll.InsertVT(obj);
                        KhoaDieuKhien();
                        HienThi();
                        XtraMessageBox.Show("Đã thêm tành công!", "Thông báo");
                        XoaText();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Chưa thêm được!", "Chú ý!");
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                }
            }
            else
            {
                obj.MaVT = txtmavt.Text;
                obj.TenVT = txttenvt.Text;
                if (txtmavt.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
                    KhoaDieuKhien();
                    HienThi();
                }
                else
                {
                    try
                    {
                        bll.UpdateVT(obj);
                        KhoaDieuKhien();
                        HienThi();
                        XtraMessageBox.Show("Sửa thành công", "Thông báo");
                        XoaText();

                    }
                    catch
                    {
                        XtraMessageBox.Show("Chưa sửa được!", "Chú ý!");
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                }
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (txtmavt.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
                KhoaDieuKhien();
                HienThi();
            }
            else
            {
                if (XtraMessageBox.Show("Thao tác này sẽ xóa tất cả dữ liệu liên quan. \nBạn có tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)

                {
                    //đổ dữ liệu mã vật tư
                    string mavt = txtmavt.Text;

                    //xem bản ghi chi tiết sử dụng vật tư
                    DataTable ctvt = bll.LayDuLieu_Qua_MaVatTu(mavt);

                    //kiểm tra số lượng bản ghi
                    if (ctvt.Rows.Count > 0)
                    {
                        //nếu có thì xóa
                        bll.XoaDuLieu_Qua_MaVatTu(mavt);
                        XtraMessageBox.Show("Đã xóa dữ liệu chi tiết vật tư các phòng", "Thông báo");

                        //xóa dữ liệu vật tư

                        bll.DeleteVT(mavt);
                        XtraMessageBox.Show("Đã xóa dữ liệu vật tư", "Thông báo");
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                    else
                    {
                        //xóa dữ liệu vật tư

                        bll.DeleteVT(mavt);
                        XtraMessageBox.Show("Đã xóa dữ liệu vật tư", "Thông báo");
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                }
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (txtmavt.Text.Length == 0)
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

        private void groupControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridvattu_Click_1(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtmavt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txttenvt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();

            }
            catch
            {

            }
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            dt = bll.LayDuLieuVT();

            txtmavt.Text = dt.Rows.Count > 0 ? bll.CapNhatMaVatTu(dt.Rows[dt.Rows.Count - 1][0].ToString()) : "VT001";
            MoDieuKhien();
            insert = true;
        }
    }
}
