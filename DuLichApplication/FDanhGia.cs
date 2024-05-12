using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DuLichApplication
{
    public partial class FDanhGia : Form
    {
        DBFunction fn = new DBFunction();
        string maKs;
        string maKhach;
        string imagePath;
        string tenKhachDung;
        int id = 1;
        public FDanhGia(string maKs, string maKhach)
        {
            InitializeComponent();
            this.maKs = maKs;
            this.maKhach = maKhach;
        }

        private void FDanhGia_Load(object sender, EventArgs e)
        {
            LayTenKS();
            LoadTenKhach();
            LoadDanhGia();
        }
        public void LayTenKS()
        {
            string query = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", this.maKs);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.lblTenKS.Text = ds.Tables[0].Rows[0]["Tên khách sạn"].ToString();
            }
        }
        public void LoadTenKhach()
        {
            string query = string.Format("select * from KhachHang where TaiKhoan = '{0}'", maKhach);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                tenKhachDung = ds.Tables[0].Rows[0]["HoTen"].ToString();
            }
        }

        public void LoadDanhGia()
        {
            string query = string.Format("select * from DanhGia");
            DataSet ds = fn.getData(query);
            flowLayoutPanel1.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                int lastRowIndex = ds.Tables[0].Rows.Count - 1;
                DataRow lastRow = ds.Tables[0].Rows[lastRowIndex];
                this.id = Convert.ToInt32(lastRow["Id"]) + 1;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["MaKs"].ToString() == maKs)
                    {
                        UcDanhGia item = new UcDanhGia();
                        item.MaKS = row["MaKs"].ToString();
                        item.DanhGia = row["DanhGia"].ToString();
                        item.NgayThang = row["NgayDanhGia"].ToString();
                        item.TenKhach = row["TenKhach"].ToString();
                        item.SoSao = Convert.ToInt32(row["SoSao"]);
                        item.SoLike = Convert.ToInt32(row["SoLike"]);
                        byte[] pic = (byte[])row["HinhAnh"];
                        item.HinhAnh = pic;
                        item.ID = Convert.ToInt32(row["Id"]);
                        item.MaKhach = this.maKhach;
                        item.TenKhachDung = this.tenKhachDung;
                        flowLayoutPanel1.Controls.Add(item);
                    }
                }
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
        public bool  KiemTraDanhGia ()
        {
            bool isHopLe = false;
            string query = string.Format("select * from GiaoDich");
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["MaKhach"].ToString().Contains(this.maKhach) && row["MaKS"].ToString().Contains(this.maKs))
                    {
                        isHopLe = true;
                        break;
                    }
                }
            }
            if (isHopLe == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            if (KiemTraDanhGia()==true)
            {
                // này là đưa vô nè
                DateTime today = DateTime.Now;
                int soSao = Convert.ToInt32(numSao.Value);
                if (string.IsNullOrEmpty(this.txtDanhGia.Text) == true)
                {
                    MessageBox.Show("Hãy viết đánh giá");
                }
                else
                {
                    // load ảnh 
                    MemoryStream ms = new MemoryStream();
                    pictureHinhAnh.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] pic = ms.ToArray();
                    // cau lenh

                    string query = "INSERT INTO DanhGia (MaKs, DanhGia, NgayDanhGIa, HinhAnh, SoSao, TenKhach,SoLike) VALUES (@MaKs, @DanhGia, @NgayDanhGia, @HinhAnh, @SoSao, @TenKhach,@SoLike)";
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Parameters.AddWithValue("@MaKs", this.maKs);
                    cmd.Parameters.AddWithValue("@DanhGia", this.txtDanhGia.Text);
                    cmd.Parameters.AddWithValue("@NgayDanhGia", today);
                    cmd.Parameters.AddWithValue("@HinhAnh", pic);
                    cmd.Parameters.AddWithValue("@SoSao", soSao);
                    cmd.Parameters.AddWithValue("@TenKhach", this.tenKhachDung);
                    cmd.Parameters.AddWithValue("@SoLike", 0);
                    fn.themDBCoHinhAnh(cmd, "Thêm đánh giá thanh công");
                    // tạo một cái item mới
                    UcDanhGia item = new UcDanhGia();
                    item.MaKS = this.maKs;
                    item.TenKhach = this.tenKhachDung;
                    item.SoSao = soSao;
                    item.DanhGia = this.txtDanhGia.Text;
                    item.NgayThang = today.ToString();
                    item.HinhAnh = pic;
                    item.SoLike = 0;
                    item.MaKhach = this.maKhach;
                    item.ID = id;
                    item.TenKhachDung = this.tenKhachDung;
                    id += 1;
                    flowLayoutPanel1.Controls.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đặt phòng để được đánh giá");
            }
        }

        private void numSao_ValueChanged(object sender, EventArgs e)
        {
            int soSao = Convert.ToInt32(this.numSao.Value);
            for (int i = 0; i < panelSao.Controls.Count; i++)
            {
                if (i < soSao)
                {
                    panelSao.Controls[i].Visible = true;
                }
                else
                {
                    panelSao.Controls[i].Visible = false;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
