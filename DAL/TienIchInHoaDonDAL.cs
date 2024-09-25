using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class TienIchInHoaDonDAL
    {
        connect conn = new connect();
        DataTable dt = new DataTable();

        public DataTable LayDuLieuChiTietHoaDon(string ID)
        {
            SqlParameter[] para =
            {
                new SqlParameter("mahd", ID)
            };
            return conn.LayDuLieu("sp_tinhtien_hoadon", para);
        }
        public void InHoaDon(string date,string tientra,string mahd,object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dt = LayDuLieuChiTietHoaDon(mahd);
            float tongtp = int.Parse(dt.Rows[0][7].ToString()) * float.Parse(dt.Rows[0][9].ToString());
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12);
            float FontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 70;

            graphic.DrawString("                           Quang Huy", new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);
            graphic.DrawString("                           xã Sơn Đông, Thị xã Sơn Tây, TP Hà Nội", font, new SolidBrush(Color.Black), startX, startY + 30);
            string top0 = "                       Mã Hóa Đơn              ".PadRight(24) + dt.Rows[0][0].ToString();
            string ngay = "                       Ngày Thanh Toán         ".PadRight(24) + date;
            string top1 = "                       Mã Phiếu Thuê           ".PadRight(24) + dt.Rows[0][1].ToString();
            string top2 = "                       Tên Khách Hàng          ".PadRight(24) + dt.Rows[0][3].ToString();
            string top3 = "                       Nhân viên               ".PadRight(24) + dt.Rows[0][4].ToString();
            string top = "                       Loại phòng/Dịch vụ      ".PadRight(51) + "Thành Tiền";
            graphic.DrawString(top0, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight;
            graphic.DrawString(ngay, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight;
            graphic.DrawString(top1, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight;
            graphic.DrawString(top2, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight;
            graphic.DrawString(top3, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight;
            offset = offset + (int)FontHeight;
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 20; //make the spacing consistent
            graphic.DrawString("                       ===========================================", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent

            //load tiền phòng
            graphic.DrawString("                       " + dt.Rows[0][8].ToString() + "(" + dt.Rows[0][7] + " ngày)", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("                       " + tongtp + " USD", font, new SolidBrush(Color.Black), startX + 300, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent 

            //trẻ em(nếu có)
            float tientreem = 0;
            if(int.Parse(dt.Rows[0][17].ToString()) >2)
            {
                tientreem = (tongtp * 30) / 100;
            }
            graphic.DrawString("                       Số trẻ em" + "(" + dt.Rows[0][17] + " người)", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("                       " + tientreem + " USD", font, new SolidBrush(Color.Black), startX + 300, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent 

            float tong = tongtp + tientreem;
            //load tiền dịch vụ
            for (int i= 0; i< dt.Rows.Count; i++)
            {
                
                graphic.DrawString("                       " + dt.Rows[i][12].ToString() + "("+ dt.Rows[i][14].ToString() + " lần)", font, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString("                       " + dt.Rows[i][15].ToString() + " USD", font, new SolidBrush(Color.Black), startX + 300, startY + offset);
                offset = offset + (int)FontHeight + 5; //make the spacing consistent  
                float tiendv = float.Parse(dt.Rows[i][15].ToString());
                tong = tong + tiendv;
            }
            offset = offset + 7; //make some room so that the total stands out.

            float tiencoc = 0;
            if(dt.Rows[0][8].ToString() == "Phòng đơn")
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
        

            graphic.DrawString("                       Tiền cọc ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("                       " + tiencoc + " USD", font, new SolidBrush(Color.Black), startX + 300, startY + offset);


            offset = offset + (int)FontHeight + 20; //make the spacing consistent   

            tong = tong - tiencoc;


            graphic.DrawString("                       TỔNG TIỀN ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("                       " + tong +" USD", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 300, startY + offset);
            
            
            offset = offset + (int)FontHeight + 5; //make the spacing consistent            
            graphic.DrawString("                       TIỀN THANH TOÁN ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("                       " + tientra + " USD", font, new SolidBrush(Color.Black), startX + 300, startY + offset);

            float ttra = float.Parse(tientra);
            float ttlai = ttra - tong;
            offset = offset + (int)FontHeight + 5; //make the spacing consistent              
            graphic.DrawString("                       TIỀN TRẢ LẠI ", font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString("                       " + ttlai + " USD", font, new SolidBrush(Color.Black), startX + 300, startY + offset);
            
            offset = offset + (int)FontHeight + 10; //make the spacing consistent              
            graphic.DrawString("                              CẢM ƠN BẠN ĐÃ GHÉ THĂM!", font, new SolidBrush(Color.Black), startX, startY + offset);
        }

        
    }
}
