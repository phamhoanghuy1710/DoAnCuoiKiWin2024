using Microsoft.Data.SqlClient;
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
                string query = string.Format("insert into [Phòng] ([Mã phòng],[Loại giường],[Giá],[Trạng thái],[Tiện ích],[Mã khách sạn]) values (@MaPhong,@LoaiGiuong,@Gia,@TrangThai,@TienIch,@MaKS)");
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@MaPhong", this.txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@LoaiGiuong", this.txtLoaiPhong.Text);
                cmd.Parameters.AddWithValue("@Gia", Convert.ToInt32(this.txtGiaTien.Text));
                cmd.Parameters.AddWithValue("@TrangThai", "Yes");
                cmd.Parameters.AddWithValue("@TienIch", this.txtTienIch.Text);
                cmd.Parameters.AddWithValue("@MaKS", this.maKS);
                fn.themDBCoHinhAnh(cmd, "Thêm phòng thành công");
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
