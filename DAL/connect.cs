using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace DAL
{
    public class connect
    {
        
        private string ConnectionString = "Data Source=DESKTOP-TMAANNK;Initial Catalog=Test;Integrated Security=True";
        private SqlConnection conn;

        public connect()
        {
            conn = new SqlConnection(ConnectionString);
        }
        //Sử dụng câu lệnh SQL


        //Lấy dữ liệu bằng câu lệnh select trong SQL
        private static connect instance; // chỉ co nội bộ mí dc quen set dữ lieu thong qua bien instance

        internal static connect Instance
        {
            get { if (instance == null) instance = new connect(); return connect.instance; }
            private set { connect.instance = value; } // cho private ln de bao mat hơn
        }
        public DataTable Test(string query, object[] parameter = null)//parameter chu yeu la theo n proc 
        {
            DataTable data = new DataTable();

            using (SqlConnection connetion = new SqlConnection(ConnectionString))
            {
                connetion.Open();
                SqlCommand command = new SqlCommand(query, connetion);
                if (parameter != null)
                {
                    string[] ListPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in ListPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connetion.Close();
            }
            return data;
        }
        public DataTable LayDuLieu(string sql)
        {
            DataTable data = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Open();
            da.Fill(data);
            conn.Close();
            return data;
        }


        

        //Thực hiện các câu lệnh Insert, Update, Delete,...
        public int SuaDuLieu(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq;
        }

        //Xem thông tin tài khoản vừa đăng nhập
        public DataTable ChiTietTaiKhoan(string sql)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            // Sử dụng DataAdapter để điền vào DataTable
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            conn.Open();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        //Kiểm tra số lượng bản ghi
        public int KiemTraSoLuongBanGhi(string sql)
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                // Sử dụng DataAdapter để điền vào DataTable
                da = new SqlDataAdapter(sql, conn);
                dt = new DataTable();
                da.Fill(dt);
                int banGhi = dt.Rows.Count;
                return banGhi;
            }
            catch
            {
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }


        //Sử dụng proc trong SQL

        //Sử dụng Proc thực hiện select
        public DataTable LayDuLieu(string tenProc, SqlParameter[] para)
        {
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = tenProc;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
                cmd.Parameters.AddRange(para);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(data);
            conn.Close();
            return data;
        }

        //Sử dụng proc thực hiện Delete, Update, ...
        public int SuaDuLieu(string tenProc, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = tenProc;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
                cmd.Parameters.AddRange(para);
            cmd.Connection = conn;
            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq;
        }

        //Kiểm tra số lượng bản ghi
        public int KiemTraSoLuongBanGhi(string tenProc, SqlParameter[] para)
        {
            try
            {
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = tenProc;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                conn.Open();
                da.Fill(data);
                int banGhi = data.Rows.Count;
                conn.Close();
                return banGhi;
                
            }
            catch
            {
                return -1;
            }
        }

        //Xem thông tin tài khoản vừa đăng nhập
        public DataTable ChiTietTaiKhoan(string tenProc, SqlParameter[] para)
        {
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = tenProc;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
                cmd.Parameters.AddRange(para);
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            conn.Open();
            da.Fill(data);
            conn.Close();
            return data;
        }


        //Backup dữ liệu
        public int Backup(string tenProc, SqlParameter[] para)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = tenProc;
            cmd.CommandType = CommandType.StoredProcedure;
            if (para != null)
                cmd.Parameters.AddRange(para);
            cmd.Connection = conn;
            conn.Open();
            int kq = cmd.ExecuteNonQuery();
            conn.Close();
            return kq;
        }



        //Tiện ích DAL
        public int TachNam(string ngay)
        {
            int year = 0;
            if (ngay.Length == 0)
            {
                return year;
            }
            else
            {
                if (ngay.Substring(5, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(6, 4).ToString());
                }
                if (ngay.Substring(1, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(5, 4).ToString());
                }
                if (ngay.Substring(3, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(4, 4).ToString());
                }
                if (ngay.Substring(2, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    year = int.Parse(ngay.Substring(5, 4).ToString());
                }
            }

            return year;
        }
        public int TachThang(string ngay)
        {
            int month = 0;
            if (ngay.Length == 0)
            {
                return month;
            }
            else
            {
                if (ngay.Substring(1, 1).ToString() == "/")
                {
                    month = int.Parse(ngay.Substring(0, 1).ToString());
                }
                if (ngay.Substring(2, 1).ToString() == "/")
                {
                    month = int.Parse(ngay.Substring(0, 2).ToString());
                }
            }
            return month;
        }

        public int TachNgay(string ngay)
        {
            int day = 0;
            if (ngay.Length == 0)
            {
                return day;
            }
            else
            {
                if (ngay.Substring(5, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(3, 2).ToString());
                }
                if (ngay.Substring(1, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(2, 2).ToString());
                }
                if (ngay.Substring(3, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(2, 1).ToString());
                }
                if (ngay.Substring(2, 1).ToString() == "/" && ngay.Substring(4, 1).ToString() == "/")
                {
                    day = int.Parse(ngay.Substring(2, 1).ToString());
                }
            }

            return day;
        }


        public string XuLyNgay(DateTime dt)
        {
            int ngay = dt.Day, thang = dt.Month, nam = dt.Year;
            string strngay = ngay.ToString();
            string strthang = thang.ToString();
            string strnam = nam.ToString();
            return strthang + '/' + strngay + '/' + strnam;
        }

    }
    
}
