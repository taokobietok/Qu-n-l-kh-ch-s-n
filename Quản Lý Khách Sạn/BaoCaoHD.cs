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
    public partial class BaoCaoHD : Form
    {
        public BaoCaoHD(DataTable dt )
        {
            InitializeComponent();
            table = dt;
        }
        DataTable table ;

        private void Form1_Load(object sender, EventArgs e)
        {
            BaoCaorpt baocao = new BaoCaorpt();
            baocao.SetDataSource( table );
            crystalReportViewer1.ReportSource = baocao;
        }
    }
}
