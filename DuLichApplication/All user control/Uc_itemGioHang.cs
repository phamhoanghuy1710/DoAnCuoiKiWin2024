using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication.All_user_control
{
    public partial class Uc_itemGioHang : UserControl
    {
        DBFunction fn = new DBFunction();


        public Uc_itemGioHang()
        {
            InitializeComponent();
        }
        private string maPhong;
        private string giaTien;
        private string tienIch;
        private string loaiPhong;

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("update [Phòng] set [Trạng thái] = 'Yes' , [MaKhach] = 'null' where [Mã phòng] = '{0}'", maPhong);
            fn.setData(query, "Đã xóa phòng thành công");
            string query2 = string.Format("delete from DatPhong where MaPhong = '{0}'", this.maPhong);
            fn.setData(query2, "oke");
            this.Dispose();

        }

        [Category("Custom Props")]
        public string MaPhong
        {
            get { return maPhong; }
            set
            { maPhong = value; txtMaPhong.Text = maPhong; }
        }

        [Category("Custom Props")]
        public string GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; txtGiaTien.Text = giaTien; }
        }

        [Category("Custom Props")]
        public string TienIch
        {
            get { return tienIch; }
            set { tienIch = value; txtTienIch.Text = tienIch; }
        }

        [Category("Custom Props")]
        public string LoaiPhong
        {
            get { return loaiPhong; }
            set { loaiPhong = value; txtLoaiPhong.Text = loaiPhong; }
        }

    }
}
