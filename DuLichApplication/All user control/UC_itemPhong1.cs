using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication.All_user_control
{
    public partial class UC_itemPhong1 : UserControl
    {
        private string maPhong;
        private string tienIch;
        private string giaTien;
        private string loaiPhong;
        private string trangThai;
        private string maKhach;
        public string maKS;
        public DateTime ngayNhanPhong;
        public DateTime ngayTraPhong;
        DBFunction fn = new DBFunction();

        public UC_itemPhong1()
        {
            InitializeComponent();
        }

        public string MaKS
        {
            get { return MaKS; }
            set { maKS = value; }
        }
        public string MaKhach
        {
            get { return maKhach; }
            set
            {
                this.maKhach = value;
            }
        }
        public DateTime NgayNhanPhong
        {
            get { return ngayNhanPhong; }
            set
            {
                this.ngayNhanPhong = value;
            }
        }

        public DateTime NgayTraPhong
        {
            get { return ngayTraPhong; }
            set
            {
                this.ngayTraPhong = value;
            }
        }


        [Category("Custom Props")]
        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; txtMaPhong.Text = value; }
        }

        [Category("Custom Props")]
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; txtTrangThai.Text = value; }
        }

        [Category("Custom Props")]
        public string TienIch
        {
            get { return tienIch; }
            set { tienIch = value; txtTienIch.Text = value; }
        }

        [Category("Custom Props")]
        public string GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; txtGiaTien.Text = value; }
        }

        [Category("Custom Props")]
        public string LoaiPhong
        {
            get { return loaiPhong; }
            set { loaiPhong = value; txtLoaiPhong.Text = value; }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            // đổi lại trạng thái phòng ,
            // thêm phòng đó vào danh sách phòng đã chọn
            if (trangThai == "Yes")
            {
                string query = string.Format("update [Phòng] set [Trạng thái] = 'wait' , MaKhach = '{0}' where [Mã phòng] = '{1}'", maKhach, maPhong);
                string query2 = string.Format("insert into DatPhong (TaiKhoan,NgayNhanPhong,NgayTraPhong,MaKS,MaPhong,TrangThai) values ('{0}','{1}','{2}','{3}','{4}','No')", maKhach, ngayNhanPhong, ngayTraPhong, maKS, maPhong);
                fn.setData(query, "Chọn phòng thành công");
                fn.setData(query2, "oke");
                trangThai = "wait";
                txtTrangThai.Text = trangThai;
            }
            else
            {
                MessageBox.Show("Không thể chọn");
            }
        }
    }
}
