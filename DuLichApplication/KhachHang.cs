using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DuLichApplication
{
    internal class KhachHang
    {
        public string tiaKhoan;
        public string matKhau;
        public string hoTen;
        public string chungMinh;
        public string diaChi;
        public string sdt;
        public string email;
        public DateTime ngaySinh;
        public string gioiTinh;
        public Image hinhAnh;
        public string vaiTro;

        public KhachHang(string hoTen,string diaChi,string chungMinh,string sdt,string email,DateTime ngaySinh,string GioiTinh,Image hinhAnh)
        { 
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.chungMinh = chungMinh;
            this.sdt = sdt;
            this.email = email;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = GioiTinh;
            this.hinhAnh = hinhAnh;
        }
        public KhachHang(string taiKhoan , string matKhau) 
        { 
            this.tiaKhoan = taiKhoan;
            this.matKhau = matKhau;
        }

    }
}
