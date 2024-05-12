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
        string imagePath;

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
                // load ảnh 
                MemoryStream ms = new MemoryStream();
                pictureHinhAnh.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] pic = ms.ToArray();
                // cau lenh
                string query = string.Format("insert into [Phòng] ([Mã khách sạn],[Mã phòng],[Loại giường],[Giá],[Tiện ích],[HinhAnh]) values (@MaKS,@MaPhong,@LoaiGiuong,@Gia,@TienIch,@HinhAnh)");
                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@MaKS", Convert.ToInt32(this.maKS));
                cmd.Parameters.AddWithValue("@MaPhong", this.txtMaPhong.Text);
                cmd.Parameters.AddWithValue("@LoaiGiuong", this.txtLoaiPhong.Text);
                cmd.Parameters.AddWithValue("@Gia", this.txtGiaTien.Text);
                cmd.Parameters.AddWithValue("@TienIch", this.txtTienIch.Text);
                cmd.Parameters.AddWithValue("@HinhAnh", pic);
                fn.themDBCoHinhAnh(cmd, "Thêm phòng thành công");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (truyenChoCha != null)
            {
                this.isKetThuc = true;
                truyenChoCha(isKetThuc);
                this.Dispose();
            }
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Lấy đường dẫn của hình ảnh được chọn
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        string FileName = openFileDialog.FileName;
                        imagePath = FileName;
                        if (myStream.Length > 512000)
                        {
                            MessageBox.Show("Hinh qua kich thuoc");
                        }
                        else
                        {
                            pictureHinhAnh.Load(FileName);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
