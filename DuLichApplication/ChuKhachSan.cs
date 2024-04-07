using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLichApplication
{
    internal class ChuKhachSan
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

        public ChuKhachSan (string hoTen, string diaChi, string chungMinh, string sdt, string email, DateTime ngaySinh, string GioiTinh, Image hinhAnh)
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

        public ChuKhachSan (string taiKhoan, string matKhau)
        {
            this.tiaKhoan = taiKhoan;
            this.matKhau = matKhau;
        }
    }
}
