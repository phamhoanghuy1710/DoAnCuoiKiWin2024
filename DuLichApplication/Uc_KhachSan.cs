using DuLichApplication.All_user_control;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class Uc_KhachSan : UserControl
    {
        DBFunction fn = new DBFunction();
        string imagePath;
        public Uc_KhachSan()
        {
            InitializeComponent();
        }

        private void Uc_KhachSan_Load(object sender, EventArgs e)
        {
            string query = string.Format("select top 10 * from KhachSan");
            DataSet ds = fn.getData(query);
            LoadThongTin(ds);
        }

        public void LoadThongTin(DataSet ds)
        {
            this.flowLayoutPanel1.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Uc_ItemKScs item = new Uc_ItemKScs();
                    item.Ten = row["Tên khách sạn"].ToString();
                    item.DiaChi = row["Địa chỉ"].ToString();
                    item.Gia = row["Giá"].ToString();
                    item.ID = Convert.ToInt32(row["Mã khách sạn"].ToString());
                    int soSao;
                    if (int.TryParse(row["Số sao"].ToString(), out soSao))
                    {
                        item.Sao = soSao;
                    }
                    else
                    {
                        soSao = -1;
                    }
                    this.flowLayoutPanel1.Controls.Add(item);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from KhachSan where [Tên khách sạn] like N'%{0}%'", this.txtTenKhachSan.Text);
            DataSet ds = fn.getData(query);
            LoadThongTin(ds);
        }

        private void panelTienIch_Paint(object sender, PaintEventArgs e)
        {

        }
        public string getTienNghi()
        {
            string tienIch = "";
            foreach (Control c in panelTienIch.Controls)
            {
                if (c is Guna2CheckBox)
                {
                    Guna2CheckBox cb = (Guna2CheckBox)c;
                    if (cb.Checked)
                    {
                        tienIch += c.Text + ',';
                    }
                }
            }
            return tienIch;
        }
        public string getDichVu()
        {
            string dichVu = "";
            foreach (Control c in panelDichVu.Controls)
            {
                if (c is Guna2CheckBox)
                {
                    Guna2CheckBox cb = (Guna2CheckBox)c;
                    if (cb.Checked)
                    {
                        dichVu += c.Text + ',';
                    }
                }
            }
            return dichVu;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // thêm khách sạn
            string tienNghi = getTienNghi();
            string dichVu = getDichVu();
            // load hinh anh thanh byte []
            MemoryStream ms = new MemoryStream();
            pictureAnh.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] pic = ms.ToArray(); 
            //

            string query = string.Format("insert into KhachSan ([Mã khách sạn],[Tên khách sạn],[Địa chỉ],[Giá],[Số sao],[Review],[Trạng Thái],[Thể Loại],[TienNghiPhong],[DichVuKhachSan],[HinhAnh]) values (@MaKS,@TenKS,@DiaChi,@Gia,@SoSao,@Review,@TrangThai,@TheLoai,@TienNghi,@DichVu,@HinhAnh)");
            SqlCommand cmd = new SqlCommand (query);
            cmd.Parameters.AddWithValue("@MaKS", this.txtMaKhachSan.Text);
            cmd.Parameters.AddWithValue("@TenKS", this.txtTenKS.Text);
            cmd.Parameters.AddWithValue("@DiaChi", this.txtDiaChi.Text);
            cmd.Parameters.AddWithValue("@Gia", Convert.ToInt32(this.txtGia.Text));
            cmd.Parameters.AddWithValue("@SoSao",Convert.ToInt32(this.cbbSoSao.Text));
            cmd.Parameters.AddWithValue("Review", this.txtReview.Text);
            cmd.Parameters.AddWithValue("@TrangThai", "Yes");
            cmd.Parameters.AddWithValue("@TheLoai",this.cbbTheLoai.Text);
            cmd.Parameters.AddWithValue("@TienNghi",tienNghi);
            cmd.Parameters.AddWithValue("@DichVu", dichVu);
            cmd.Parameters.AddWithValue("@HinhAnh", pic);
            fn.themDBCoHinhAnh(cmd, "Thêm khách sạn thành công");

        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        string fileName = openFileDialog.FileName;
                        imagePath = fileName;
                        if (myStream.Length > 512000)
                        {
                            MessageBox.Show("Hình Ảnh quá kích thước");

                        }
                        else
                        {
                            pictureAnh.Load(fileName);
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
