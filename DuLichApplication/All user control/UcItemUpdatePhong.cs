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
    public partial class UcItemUpdatePhong : UserControl
    {


        private string maPhong;
        private string tienIch;
        private string giaTien;
        private string loaiPhong;
        private string trangThai;
        public int isLuu = 0;
        DBFunction fn = new DBFunction();

        public UcItemUpdatePhong()
        {
            InitializeComponent();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("delete from [Phòng] where [Mã phòng] = '{0}' ", maPhong);
            fn.setData(query, "Đã xóa phòng thành công", true);
            this.Dispose();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (isLuu == 0)
            {
                if (txtTrangThai.Text == "Yes")
                {
                    txtGiaTien.ReadOnly = false;
                    txtLoaiPhong.ReadOnly = false;
                    txtTienIch.ReadOnly = false;
                    isLuu = 1;
                }
                else
                {
                    MessageBox.Show("Phòng đăng có người chọn");
                }
            }
            else
            {
                if (CheckData.KiemTraPhong(this.txtLoaiPhong, this.txtGiaTien, this.txtTienIch) == true)
                {
                    string query = string.Format("update [Phòng] set [Loại giường] = '{0}', [Giá] = '{1}', [Tiện ích] = '{2}' where [Mã phòng] = '{3}'", txtLoaiPhong.Text, Convert.ToInt32(txtGiaTien.Text), txtTienIch.Text, txtMaPhong.Text);
                    fn.setData(query, "Cập nhật thành công", true);
                    txtGiaTien.ReadOnly = true;
                    txtLoaiPhong.ReadOnly = true;
                    txtTienIch.ReadOnly = true;
                    isLuu = 0;
                }
            }

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void UcItemUpdatePhong_Load(object sender, EventArgs e)
        {

        }
    }
}

