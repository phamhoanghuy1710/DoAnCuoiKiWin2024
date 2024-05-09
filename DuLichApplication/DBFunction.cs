using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Guna.UI2.WinForms;

namespace DuLichApplication
{
    internal class DBFunction
    {
        protected SqlConnection getConnection ()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=dbHotel;Integrated Security=True";
            return conn;
        }

        public DataSet getData (String query)
        {
            SqlConnection conn = getConnection ();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;    
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adt.Fill (ds); 
            return ds; 
        }
        public bool setGiaoDich (String query, String message, bool isMessage)
        {
            SqlConnection conn = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = query;
            bool ok = false;
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                    if (isMessage == true)
                        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ok =  true;
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show("Không thể thực thi");
                MessageBox.Show(EX.Message);
            }
   
            if (ok == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void setData (String query,String message, bool isMessage)
        {
                SqlConnection conn = getConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = query;
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        conn.Close();
                        if (isMessage == true)
                            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception EX)
                {
                    MessageBox.Show("Không thể thực thi");
                    MessageBox.Show(EX.Message);
                }
        }
        public SqlDataReader getForCombo (String query)
        {
            SqlConnection conn = getConnection ();
            SqlCommand cmd = new SqlCommand(); 
            cmd.Connection = conn;
            conn.Open();
            cmd = new SqlCommand(query,conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr; 
        }
        
        public void SetDataImage (Guna2TextBox tk, Guna2TextBox mk, Guna2TextBox hoTen, Guna2TextBox ChungMinh, Guna2TextBox diaChi, Guna2TextBox email, Guna2TextBox sdt, Guna2ComboBox gt, Guna2DateTimePicker ngaySinh, byte[] pic, string mess)
        {
            SqlConnection conn = getConnection (); 
            conn.Open();
            string query = "INSERT INTO KhachHang (TaiKhoan, MatKhau, HoTen, ChungMinh, DiaChi, Email, Sdt, GioiTinh, NgaySinh, HinhAnh) VALUES (@TaiKhoan, @MatKhau, @HoTen, @ChungMinh, @DiaChi, @Email, @Sdt, @GioiTinh, @NgaySinh, @HinhAnh)";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.AddWithValue("@TaiKhoan", tk.Text);
            cmd.Parameters.AddWithValue("@MatKhau", mk.Text);
            cmd.Parameters.AddWithValue("@HoTen", hoTen.Text);
            cmd.Parameters.AddWithValue("@ChungMinh", ChungMinh.Text);
            cmd.Parameters.AddWithValue("@DiaChi", diaChi.Text);
            cmd.Parameters.AddWithValue("@Email", email.Text);
            cmd.Parameters.AddWithValue("@Sdt", sdt.Text);
            cmd.Parameters.AddWithValue("@GioiTinh", gt.Text);
            cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh.Value);
            cmd.Parameters.AddWithValue("@HinhAnh", pic);
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                MessageBox.Show(mess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể thực thi");
            }
            conn.Close ();
        }

        public void themDBCoHinhAnh (SqlCommand cmd,string mess)
        {
            SqlConnection conn = getConnection();
            conn.Open ();
            cmd.Connection = conn;
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close ();
                MessageBox.Show(mess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể thực thi");
            }
        }


    }
}
