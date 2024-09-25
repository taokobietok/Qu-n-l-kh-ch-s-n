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
    public partial class PhieuThuePhong : Form
    {
        #region
        ThuePhongBLL bll = new ThuePhongBLL();
        DichVuBLL dvbll = new DichVuBLL();
        PhieuNhanPhongDTO obj = new PhieuNhanPhongDTO();
        DichVuDTO dvobj = new DichVuDTO();
        private bool them = false;
        private string soluot;
        #endregion
        public PhieuThuePhong()
        {
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            txtnv.Enabled = false;
            txtmapdp.Enabled = false;
            txtmaptp.Enabled = false;
            txtmap.Enabled = false;

            cbtendv.Enabled = false;
            cbmadv.Enabled = false;

            bttraphong.Enabled = true;
            btthemdv.Enabled = true;
            btxoa.Enabled = true;

            btluu.Enabled = false;
            bthuy.Enabled = false;
            gridsddv.Enabled = false;
            gridptp.Enabled = true;
        }

        private void KhoaDieuKhienAll()
        {
            txtnv.Enabled = false;
            txtmapdp.Enabled = false;
            txtmaptp.Enabled = false;
            txtmap.Enabled = false;

            cbtendv.Enabled = false;
            cbmadv.Enabled = false;

            bttraphong.Enabled = false;
            btthemdv.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = false;
            bthuy.Enabled = false;
            gridsddv.Enabled = false;
            gridptp.Enabled = true;
        }

        private void MoDieuKhienThemDV()
        {
            txtnv.Enabled = false;
            txtmapdp.Enabled = false;
            txtmaptp.Enabled = false;
            txtmap.Enabled = false;

            cbtendv.Enabled = true;
            cbmadv.Enabled = false;

            bttraphong.Enabled = false;
            btthemdv.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
            gridsddv.Enabled = false;
            gridptp.Enabled = true;
        }

        private void MoDieuKhienXoaLuotDung()
        {
            txtnv.Enabled = false;
            txtmapdp.Enabled = false;
            txtmaptp.Enabled = false;
            txtmap.Enabled = false;

            cbtendv.Enabled = false;
            cbmadv.Enabled = false;

            bttraphong.Enabled = false;
            btthemdv.Enabled = false;
            btxoa.Enabled = false;

            btluu.Enabled = true;
            bthuy.Enabled = true;
            gridsddv.Enabled = true;
            gridptp.Enabled = false;
        }

        private void XoaText()
        {
            txtnv.Text = string.Empty;
            txtmapdp.Text = string.Empty;
            txtmaptp.Text = string.Empty;
            txtmap.Text = string.Empty;

            cbtendv.Text = string.Empty;
            cbmadv.Text = string.Empty;
        }

        private void HienThi()
        {
                KhoaDieuKhien();
                gridptp.DataSource = bll.LayDuLieu_Add_MaPhong_DangHoatDongPNP();
            
        }
        //load các dịch vụ hiện có vào combobox
        private void LoadComboboxTenDV()
        {
            DataTable dt = dvbll.LayDuLieu();
            cbtendv.DataSource = dt;
            cbtendv.DisplayMember = "TENDICHVU";
            cbtendv.ValueMember = "MADICHVU";
        }

        private void cbtuychon_SelectedIndexChanged(object sender, EventArgs e)
        {
            XoaText();
            HienThi();
        }

        private void formphieuthuephong_Load(object sender, EventArgs e)
        {
            cbtuychon.Text = "Phiếu hoạt động";
            HienThi();
        }

        private void bttraphong_Click(object sender, EventArgs e)
        {
            if (txtmaptp.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
            }
            else
            {
                DataTable dt = bll.LoadMaKhachHangPNP(txtmaptp.Text);
                string mak = dt.Rows[0][0].ToString();
                TraPhong frtp = new TraPhong(txtmaptp.Text, mak, txtnv.Text, txtmapdp.Text);
                frtp.ShowDialog();
            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (them == true)
            {
                XtraMessageBox.Show("Đã hủy thêm dịch vụ", "Thông báo");
                KhoaDieuKhien();
                HienThi();
                XoaText();
            }
            else
            {
                XtraMessageBox.Show("Đã hủy xóa lần dùng", "Thông báo");
                KhoaDieuKhien();
                HienThi();
                XoaText();
            }
        }

        private void gridsddv_Click(object sender, EventArgs e)
        {
            try
            {
                txtmaptp.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[0]).ToString();
                cbmadv.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[1]).ToString();
                soluot = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns[2]).ToString();
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            them = false;
            if (txtmaptp.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi", "Thông báo");
            }
            else
            {
                MoDieuKhienXoaLuotDung();

            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            obj.MaPNP = txtmaptp.Text;
            obj.MaDV = cbmadv.Text;
            obj.LanSD = "1";
            DataTable dt = bll.LayDuLieu_ChiTietThuePhong_TheoMaPhieuThue_And_MaDVPNP(obj);
            if (them == true)
            {
                //thêm dịch vụ sử dụng
                if (dt.Rows.Count > 0)
                {
                    //sửa số lượt dùng tăng thêm 1
                    try
                    {
                        bll.Update_LuotDungDichVuPNP(obj);
                        XtraMessageBox.Show("Đã thêm dịch vụ thành công", "Thông báo");
                        gridsddv.DataSource = bll.LayDuLieu_ChiTietThuePhongPNP(txtmaptp.Text);
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
                    }
                }
                else
                {
                    try
                    {
                        //thêm mới sử dụng dịch vụ
                        bll.Insert_ChiTietThuePhongPNP(obj);
                        XtraMessageBox.Show("Đã thêm dịch vụ thành công", "Thông báo");
                        gridsddv.DataSource = bll.LayDuLieu_ChiTietThuePhongPNP(txtmaptp.Text);
                        KhoaDieuKhien();
                        HienThi();
                        XoaText();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
                    }
                }
            }
            else
            {
                //Xóa lượt dùng dịch vụ
                if (cbmadv.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa chọn dịch vụ cần hủy lượt dùng", "Thông báo");

                }
                else
                {
                    if (soluot == "0")
                    {
                        try
                        {
                            XtraMessageBox.Show("Chưa sử dụng", "Thông báo");
                            gridsddv.DataSource = bll.LayDuLieu_ChiTietThuePhongPNP(txtmaptp.Text);
                            KhoaDieuKhien();
                            XoaText();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
                        }
                    }
                    else
                    {
                        //sửa lượt dùng giảm đi 1
                        try
                        {
                            bll.Xoa_LuotDungDichVuPNP(obj);
                            XtraMessageBox.Show("Đã hủy sử dụng dịch vụ thành công", "Thông báo");
                            gridsddv.DataSource = bll.LayDuLieu_ChiTietThuePhongPNP(txtmaptp.Text);
                            KhoaDieuKhien();
                            XoaText();
                        }
                        catch
                        {
                            XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
                        }
                    }
                }

            }
        }

        private void btthemdv_Click(object sender, EventArgs e)
        {
            them = true;
            if (txtmaptp.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo");
            }
            else
            {
                MoDieuKhienThemDV();
                this.LoadComboboxTenDV();
                cbtendv.Text = string.Empty;
                cbmadv.Text = string.Empty;

            }
        }

        private void cbtendv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtendv.Text.Length == 0)
            {
                cbmadv.Text = "";
            }
            else
            {
                this.cbmadv.Text = cbtendv.SelectedValue.ToString();
            }
        }

        private void gridptp_Click(object sender, EventArgs e)
        {
            try
            {
                txtmaptp.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtmapdp.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtmap.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtnv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();

                //hiện thi chi tiết qua mã phiếu thuê
                gridsddv.DataSource = bll.LayDuLieu_ChiTietThuePhongPNP(txtmaptp.Text);

            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
            }
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            formphieuthuephong_Load(sender, e);
        }
    }
}
