using BLL;
using DevExpress.XtraEditors;
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
    public partial class HoaDon : Form
    {
        #region
        HoaDonBLL bll = new HoaDonBLL();
        TienIch ti = new TienIch();
        DataTable dt = new DataTable();
        #endregion
        public HoaDon()
        {
            InitializeComponent();
        }
        private void KhoaDieuKhien()
        {
            txttennv.Enabled = false;
            txtmahd.Enabled = false;
            txtmaptp.Enabled = false;
            txtmakh.Enabled = false;
            datengaytt.Enabled = false;
            txttongtien.Enabled = false;

            txttongtp.Enabled = false;
            txttongtiendv.Enabled = false;
        }

        private void HienThi()
        {
            gridhd.DataSource = bll.LayDuLieu_AllHD();

        }
        void LoadDateTimepickerBill()
        {
            DateTime today = DateTime.Now;
            dateTimePickercheckIn.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePickercheckOut.Value = dateTimePickercheckIn.Value.AddMonths(1).AddDays(-1);
        }
        void LoadlistBillByDate(DateTime checIn, DateTime checOut)
        {
            DataSet hoadon = bll.LayDuLieu_AllHD_ngay(checIn, checOut);
            gridhd.DataSource = hoadon.Tables[0];
            dt = hoadon.Tables[0];
        }

        private void formhoadon_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
        }

        private void txttienkhachtt_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txttienkhachtt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gridhd_Click(object sender, EventArgs e)
        {
            try
            {


                txtmahd.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtmaptp.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtmakh.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                datengaytt.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString();
                txttennv.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[4]).ToString();

                dt = bll.LayDuLieuChiTietHoaDon(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
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
                txttongtiendv.Text = tiendv.ToString();
                txttongtien.Text = ((tongtp + tiendv) - tiencoc).ToString();
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo");
            }
        }
        private void btnLoc_Click_1(object sender, EventArgs e)
        {
            LoadlistBillByDate(dateTimePickercheckIn.Value, dateTimePickercheckOut.Value);

        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            BaoCaoHD bc = new BaoCaoHD(dt);
            bc.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtmahd.Text.Length == 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn hóa đơn", "Thông báo");
            }
            else
            {
                if (txttienkhanhtt.Text.Length == 0)
                {
                    XtraMessageBox.Show("Bạn chưa nhập tiền thanh toán", "Thông báo");
                }
                else
                {
                    if (float.Parse(txttienkhanhtt.Text) < float.Parse(txttongtien.Text))
                    {
                        XtraMessageBox.Show("Số tiền thanh toán không đủ", "Thông báo");
                    }
                    else
                    {
                        try
                        {
                            bll.date = ti.XuLyNgay(DateTime.Today);
                            bll.tientra = txttienkhanhtt.Text;
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
        }
    }
}
