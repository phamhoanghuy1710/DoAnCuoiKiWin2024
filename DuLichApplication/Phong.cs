using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuLichApplication
{
    public class Phong
    {
        public string maPhong;
        public string loaiGiuong;
        public string gia;

        public string MaPhong
        {
            get { return maPhong; }
            set { this.maPhong = value; }
        }
        public string LoaiGiuong
        {
            set { this.loaiGiuong = value; }
            get { return loaiGiuong; }
        }
        public string Gia
        {
            get { return gia; }
            set { this.gia = value; }    
        }

        public Phong ()
        {
         
        }
    }
}
