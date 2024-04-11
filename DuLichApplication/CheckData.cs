using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace DuLichApplication
{
    static public class CheckData
    {
        static string patternEmail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        static string patternPhone = @"^\d{10}$";

        static public bool KiemTraMaPhong (Guna2TextBox maPhong)
        {
            if (string.IsNullOrEmpty(maPhong.Text))
            {
                MessageBox.Show("Mã Phòng không được trống");
                maPhong.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        static public bool KiemTraPhong (Guna2TextBox loaiPhong, Guna2TextBox giaTien, Guna2TextBox tienNghi)
        {
            if (string.IsNullOrEmpty(loaiPhong.Text))
            {
                MessageBox.Show("Loại phòng không được trống");
                loaiPhong.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(tienNghi.Text))
            {
                MessageBox.Show("Tiện nghi không được trống");
                tienNghi.Focus(); return false;
            }
            else if (IsMoneyValid(giaTien.Text.ToString()) == false)
            {
                MessageBox.Show("Giá tiền chỉ chấp nhận kiểu số");
                giaTien.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        static public bool KiemTraKhachSan (Guna2TextBox tenKS , Guna2TextBox diaChi, Guna2TextBox Gia , Guna2TextBox gioiThieu)
        {
            if (string.IsNullOrEmpty (tenKS.Text))
            {
                MessageBox.Show("Tên Khách Sạn không được trống");
                tenKS.Focus ();
                return false;
            }
            else if (string.IsNullOrEmpty(diaChi.Text))
            {
                MessageBox.Show("Địa chỉ Khách Sạn không được trống");
                diaChi.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(Gia.Text))
            {
                MessageBox.Show("Không thể để trống giá");
                Gia.Focus();   
                return false;   
            }
            else if (IsMoneyValid(Gia.Text.ToString()) == false)
            {
                MessageBox.Show("Giá tiền chỉ chấp nhận kiểu số");
                Gia.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(gioiThieu.Text))
            {
                MessageBox.Show("Giới thiệu về khách sạn không được trống");
                gioiThieu.Focus ();
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool IsMoneyValid (string text)
        {
            Regex regex = new Regex(@"^[1-9]\d*$");
            return regex.IsMatch (text);
        }
        static public bool KiemTraTaiKhoan(Guna2TextBox taiKhoan, Guna2TextBox matKhau)
        {
            if (string.IsNullOrEmpty(taiKhoan.Text))
            {
                MessageBox.Show("Tài khoản không được trống");
                taiKhoan.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(matKhau.Text))
            {
                MessageBox.Show("Mật khẩu không được trống");
                matKhau.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        static public bool KiemTraDuLieu(Guna2TextBox hoTen, Guna2TextBox diaChi, Guna2TextBox chungMinh, Guna2TextBox email, Guna2TextBox Sdt, Guna2DateTimePicker ngaySinh)
        {
            if (string.IsNullOrEmpty(hoTen.Text))
            {
                MessageBox.Show("Họ tên không được trống");
                hoTen.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(diaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được trống");
                diaChi.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(chungMinh.Text))
            {
                MessageBox.Show("Chứng minh không được trống");
                chungMinh.Focus();
                return false;
            }
            else if (HopLe(email.Text, patternEmail) == false)
            {
                MessageBox.Show("Không đúng định dạng email");
                email.Focus();
                return false;
            }
            else if (HopLe(Sdt.Text, patternPhone) == false)
            {
                MessageBox.Show("Không đúng định dạng số diên thoại");
                Sdt.Focus();
                return false;
            }
            else if (DuTuoi(ngaySinh.Value) == false)
            {
                MessageBox.Show("Bạn chưa đủ tuổi để sử dụng app");
                ngaySinh.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        static public bool HopLe(string str, string pattern)
        {
            return Regex.IsMatch(str, pattern);
        }
        static public bool DuTuoi(DateTime ngaySinh)
        {
            DateTime toDay = DateTime.Now;
            if (toDay.Year - ngaySinh.Year >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
