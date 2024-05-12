using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace DuLichApplication
{
    public partial class Form2 : Form
    {
        DataSet ds;
        DBFunction fn = new DBFunction();
        string taiKhoan;
        string matKhau;
        public Form2(DataSet ds)
        {
            InitializeComponent();
            this.ds = ds;
            this.taiKhoan = ds.Tables[0].Rows[0]["TaiKhoan"].ToString();
            this.matKhau = ds.Tables[0].Rows[0]["MatKhau"].ToString();
            this.uC_CustomerInfor2.btnLuu.Click += ThucHienChinhSua;
            this.uC_Addroom1.layTaiKhoan(taiKhoan);
            this.uC_CustomerInfor2.getTaiKhoan(taiKhoan);

        }

        public void ThucHienChinhSua(object sender, EventArgs e)
        {
            if (this.uC_CustomerInfor2.isButonLuuClicked == true)
            {
                if (CheckData.KiemTraDuLieu(this.uC_CustomerInfor2.txtHoTen, this.uC_CustomerInfor2.txtDiaChi, this.uC_CustomerInfor2.txtChungMinh, this.uC_CustomerInfor2.txtEmail, this.uC_CustomerInfor2.txtDienThoai, this.uC_CustomerInfor2.dtNgaySinh) == true)
                {
                    string query = string.Format("update KhachHang set HoTen = '{0}', ChungMinh = '{1}', DiaChi = '{2}', Email = '{3}', Sdt = '{4}', GioiTinh = '{5}', NgaySinh = '{6}' where TaiKhoan = '{7}'", this.uC_CustomerInfor2.txtHoTen.Text, this.uC_CustomerInfor2.txtChungMinh.Text, this.uC_CustomerInfor2.txtDiaChi.Text, this.uC_CustomerInfor2.txtEmail.Text, this.uC_CustomerInfor2.txtDienThoai.Text, this.uC_CustomerInfor2.txtGioiTinh.Text, this.uC_CustomerInfor2.dtNgaySinh.Value, taiKhoan);
                    fn.setData(query, "Chỉnh sửa thành công", true);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            uC_Addroom1.Visible = true;  // tim khach san 
            uC_CustomerInfor2.Visible = false;
            btnTimPhong.PerformClick();
            KiemTraPhongHetHan();
        }

        public void KiemTraPhongHetHan ()
        {
            // vua load phong het han . vua load phong chua dc thanh toan theo dung han
            // Them du lieu cho cot thong bao truoc
            DateTime toDay = DateTime.Now;
            string query = string.Format("select * from DatPhong where [NgayTraPhong] <= '{0}'", toDay);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string maKS = row["MaKS"].ToString();
                    string maPhong = row["MaPhong"].ToString();
                    DateTime ngayTraPhong = Convert.ToDateTime(row["NgayTraPhong"]);
                    DateTime ngayNhanPhong = Convert.ToDateTime(row["NgayNhanPhong"]);
                    // lenh de them tu bang DatPhong qua cai bang LSDatPhong
                    string query_them = string.Format("insert into LSDatPhong (MaKs,MaPhong,NgayTraPhong,NgayThongBao,ThongBao) values ('{0}','{1}','{2}','{3}',N'{4}')", maKS, maPhong, ngayTraPhong, toDay, "Phòng đã hết hạn");
                    fn.setData(query_them, "oke", false);
                    // lenh de xoa cac phong het han trong ban dat phong
                    string query_xoa = string.Format("delete from DatPhong where MaPhong = '{0}' and TrangThai = 'Yes' and NgayTraPhong = '{1}' and NgayNhanPhong = '{2}'", maPhong, ngayTraPhong, ngayNhanPhong);
                    fn.setData(query_xoa, "oke", false);
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTimPhong_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnTimPhong.Left + 20;
            uC_Addroom1.Visible = true;
            uC_Addroom1.BringToFront();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            panelMoving.Left = btnThongTin.Left;
            uC_CustomerInfor2.Visible = true;
            uC_CustomerInfor2.BringToFront();
            string query = string.Format("select * from KhachHang where TaiKhoan = '{0}' and MatKhau = '{1}' ", taiKhoan, matKhau);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                this.uC_CustomerInfor2.txtHoTen.Text = row["HoTen"].ToString();
                this.uC_CustomerInfor2.txtChungMinh.Text = row["ChungMinh"].ToString();
                this.uC_CustomerInfor2.txtDiaChi.Text = row["DiaChi"].ToString();
                this.uC_CustomerInfor2.txtEmail.Text = row["Email"].ToString();
                this.uC_CustomerInfor2.dtNgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                this.uC_CustomerInfor2.txtGioiTinh.Text = row["GioiTinh"].ToString();
                this.uC_CustomerInfor2.txtDienThoai.Text = row["Sdt"].ToString();
                byte[] pic = (byte[])row["HinhAnh"];
                MemoryStream ms = new MemoryStream(pic);
                if (pic == null)
                {
                    MessageBox.Show("Không hợp lệ");
                }
                else
                {
                    this.uC_CustomerInfor2.pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            FThongBao formtb = new FThongBao(taiKhoan);
            formtb.ShowDialog();    
        }
    }
}
