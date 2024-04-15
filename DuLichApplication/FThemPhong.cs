using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class FThemPhong : Form
    {
        string maKS;
        bool isKetThuc = false;
        DBFunction fn = new DBFunction();

        public delegate void TruyenChoCha(bool isLose);
        public TruyenChoCha truyenChoCha;
        public FThemPhong(string maKS)
        {
            InitializeComponent();
            this.maKS = maKS;
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (CheckData.KiemTraPhong(this.txtLoaiPhong, this.txtGiaTien, this.txtTienIch) == true && CheckData.KiemTraMaPhong(this.txtMaPhong) == true)
            {
                string query = string.Format("insert into [Phòng] ([Mã phòng],[Loại giường],[Giá],[Trạng thái],[Tiện ích],[Mã khách sạn]) values ('{0}','{1}','{2}','{3}','{4}','{5}')", txtMaPhong.Text, txtLoaiPhong.Text, txtGiaTien.Text, txtTrangThai.Text, txtTienIch.Text, maKS);
                fn.setData(query, "Thêm phòng thành công");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (truyenChoCha != null)
            {
                this.isKetThuc = true;
                truyenChoCha (isKetThuc);
                this.Dispose();
            }    
        }
    }
}
