using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DuLichApplication.All_user_control
{
    public partial class UC_ChonPhong : UserControl
    {
        string maKS;
        string maKhach;
        DateTime ngayNhanPhong;
        DateTime NgayTraPhong;
        public bool btnGioHangCliked = false;
        public UC_ChonPhong()
        {
            InitializeComponent();
        }
        public void getMaKhachSan(string maKS, string maKhach)
        {
            this.maKS = maKS;
            this.maKhach = maKhach;
        }
        public void getThongTin(DateTime ngayNhanPhong, DateTime ngayTraPhong)
        {
            this.ngayNhanPhong = ngayNhanPhong;
            this.NgayTraPhong = ngayTraPhong;
        }
        private void btnGioHang_Click(object sender, EventArgs e)
        {
            btnGioHangCliked = true;
        }
    }
}
