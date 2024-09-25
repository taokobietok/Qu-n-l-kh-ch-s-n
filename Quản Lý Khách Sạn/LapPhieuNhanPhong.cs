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
    public partial class LapPhieuNhanPhong : Form
    {
        #region
        ThuePhongBLL bll = new ThuePhongBLL();
        PhieuDatPhongDTO pdpobj = new PhieuDatPhongDTO();
        PhieuNhanPhongDTO obj = new PhieuNhanPhongDTO();
        private string maPDP;
        private string tenDN;
        #endregion
        public LapPhieuNhanPhong()
        {
            InitializeComponent();
        }
        public LapPhieuNhanPhong(string mapdp, string tendn)
        {
            maPDP = mapdp;
            tenDN = tendn;
            InitializeComponent();
        }

        private void KhoaDieuKhien()
        {
            cbmaptp.Enabled = false;
            cbmapdp.Enabled = false;
            cbmanv.Enabled = false;
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn hủy?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
            }
        }

        private void formlapphieunhanphongcs_Load(object sender, EventArgs e)
        {
            DataTable dt = bll.LayDuLieuPNP();
            KhoaDieuKhien();
            cbmapdp.Text = maPDP;
            cbmanv.Text = tenDN;
            cbmaptp.Text = dt.Rows.Count > 0 ? bll.CapNhatMaPhieuNhanPhong(dt.Rows[dt.Rows.Count - 1][0].ToString()) : "PNP000001";
        }

        private void btlapphieu_Click(object sender, EventArgs e)
        {
            try
            {
                obj.MaPNP = cbmaptp.Text;
                obj.MaPDP = cbmapdp.Text;
                obj.MaNV = cbmanv.Text;

                obj.MaDV = "DV001";

                bll.InsertPNP(obj);
                bll.KhoiTaoLuotDungPNP(obj);
                XtraMessageBox.Show("Đã thêm phiếu nhận phòng thành công", "Thông báo");
                this.Close();
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xẩy ra", "Thông báo");
            }
        }
    }
}
