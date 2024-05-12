using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class UcItemHuyPhong : UserControl
    {

        private string maPhong;
        private string taiKhoan;
        private string maKS;
        private string gia;
        DateTime ngayNhanPhong;
        DateTime ngayTraPhong;

        DBFunction fn = new DBFunction();
        public UcItemHuyPhong()
        {
            InitializeComponent();
        }


        [Category("Custom Props")]
        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; txtMaPhong.Text = value; }
        }

        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { this.taiKhoan = value; }
        }

        public string MaKS
        {
            get { return maKS; }
            set { this.maKS = value; }
        }


        [Category("Custom Props")]
        public string Gia
        {
            get { return gia; }
            set { this.gia = value; txtGiaTien.Text = value; }
        }

        [Category("Custom Props")]
        public DateTime NgayNhanPhong
        {
            get { return ngayNhanPhong; }
            set { this.ngayNhanPhong = value; txtNgayNhanPhong.Text = value.ToString("dd/MM/yyyy"); }
        }

        [Category("Custom Props")]
        public DateTime NgayTraPhong
        {
            get { return ngayTraPhong; }
            set { this.ngayTraPhong = value; txtNgayTraPhong.Text = value.ToString("dd/MM/yyyy"); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("delete from DatPhong where TaiKhoan = '{0}' and MaPhong = '{1}' and MaKS = '{2}' and NgayNhanPhong = '{3}' and NgayTraPhong = '{4}'", this.taiKhoan, this.maPhong, this.maKS, this.ngayNhanPhong, this.ngayTraPhong);
            fn.setData(query, "Xóa phòng thành công", true);
            string query_Ls = string.Format("insert into LSDatPhong (MaKS,MaPhong,NgayTraPhong,NgayThongBao,ThongBao) values ('{0}','{1}','{2}','{3}',N'{4}')", this.maKS, this.maPhong, DateTime.Now, DateTime.Now, "Khách hủy phòng");
            fn.setData(query_Ls, "oke", false);
            this.Dispose();
        }
    }
}
