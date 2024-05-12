using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
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
        public DateTime tmp;


        public bool btnGioHangCliked = false;
        public UC_ChonPhong()
        {
            InitializeComponent();
            this.cbbSoDem.SelectedIndex = 0;
        }
        public void getMaKhachSan(string maKS, string maKhach)
        {
            this.maKS = maKS;
            this.maKhach = maKhach;
        }
        private void btnGioHang_Click(object sender, EventArgs e)
        {
            btnGioHangCliked = true;
        }


        private void btnDanhGIa_Click(object sender, EventArgs e)
        {
            FDanhGia form = new FDanhGia(maKS, maKhach);
            form.ShowDialog();
        }

        private void UC_ChonPhong_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this.ngayNhanPhong.ToString() + " " + this.NgayTraPhong.ToString());
        }

        private void LoadNgay()
        {
            this.ngayNhanPhong = dtNgayNhanPhong.Value;
            int soDem = Convert.ToInt32(cbbSoDem.Text);
            this.NgayTraPhong = ngayNhanPhong.AddDays(soDem);
            dtNgayTraPhong.Value = NgayTraPhong;
        }

        private void dtNgayNhanPhong_ValueChanged(object sender, EventArgs e)
        {
            DateTime toDay = DateTime.Now;
            if (this.dtNgayNhanPhong.Value < toDay )
            {
                MessageBox.Show("Vui lòng chọn ngày hợp lệ");
                this.dtNgayNhanPhong.Focus();
                this.dtNgayNhanPhong.Value = this.tmp;
            }
            this.tmp = this.dtNgayNhanPhong.Value;
            LoadNgay();
            AddDay();
        }

        private void cbbSoDem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNgay();
            AddDay();
        }
        public void AddDay ()
        {
            foreach (UC_itemPhong1 item in this.flowPanelPhong.Controls)
            {
                item.NgayNhanPhong = this.ngayNhanPhong;
                item.NgayTraPhong = this.NgayTraPhong;
            }
        }
    }
}
