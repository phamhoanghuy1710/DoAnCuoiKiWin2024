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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DuLichApplication
{
    public partial class UcItemLichSu : UserControl
    {
        private string maKS;
        private string tenKhach;
        private string maKhach;
        private string ngayThanhToan;
        private string gioThanhToan;
        private string sdt;
        private string email;
        private int soTien;
        private string dsPhong;
        private string maGiaoDich;



        public string MaKhach
        {
            get { return maKhach; }
            set { this.maKhach = value; }
        }


        public string SDT
        {
            get { return SDT; }
            set { this.sdt = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }

        [Category("Custom Props")]
        public string MaKS
        {
            get { return maKS; }
            set { this.maKS = value; this.txtMaKS.Text = value; }
        }

        public int SoTien
        {
            get { return soTien; }
            set { this.soTien = value; }
        }


        public string DSPhong
        {
            get { return dsPhong; }
            set { this.dsPhong = value; }
        }

        public string MaGiaoDich
        {
            get { return maGiaoDich; }
            set { this.MaGiaoDich = value; }
        }

        [Category("Custom Props")]
        public string TenKhach
        {
            get { return tenKhach; }
            set { this.tenKhach = value; this.txtKhachHang.Text = value; }

        }

        [Category("Custom Props")]
        public string NgayThanhToan
        {
            get { return ngayThanhToan; }
            set { this.ngayThanhToan = value; this.txtNgayThanhToan.Text = value; }
        }

        [Category("Custom Props")]
        public string GioThanhToan
        {
            get { return gioThanhToan; }
            set { this.gioThanhToan = value; this.txtGioThanhToan.Text = value; }
        }
        public UcItemLichSu()
        {
            InitializeComponent();
        }

        private void UcItemLichSu_Load(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            FChiTietGiaoDich form = new FChiTietGiaoDich(this.maKS, this.maKhach, this.tenKhach, this.sdt, this.ngayThanhToan, this.gioThanhToan, this.soTien, this.email, this.dsPhong, this.maGiaoDich);
            form.ShowDialog();
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            FDanhGia f = new FDanhGia(this.maKS,this.maKhach);
            f.ShowDialog();
        }
    }
}
