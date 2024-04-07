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

namespace DuLichApplication
{
    public partial class ThanhToan : Form
    {
        string maKhach;
        string maKS;
        DBFunction fn = new DBFunction();
        string giaGoc;
        public ThanhToan(string maKhach, string maKS)
        {
            InitializeComponent();
            this.maKhach = maKhach;
            this.maKS = maKS;
            this.cbbHInhThuc.SelectedIndex = 1;
        }
        public void ThanhToan_Load_2(object sender, EventArgs e)
        {
            /*
            this.cbbHInhThuc.SelectedIndex = 0;
            this.cbbVoucher.SelectedIndex = 0;
            */
            this.lableTenKS.Text = this.maKS;
            string layTen = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", maKS);
            DataSet ks = fn.getData(layTen);
            if (ks.Tables[0].Rows.Count > 0)
            {
                lableTenKS.Text = ks.Tables[0].Rows[0]["Tên khách sạn"].ToString();
                lblDiaChi.Text = ks.Tables[0].Rows[0]["Địa chỉ"].ToString();
            }

            string query = string.Format("select sum([Giá]) as Gia from [Phòng] where MaKhach = '{0}' and [Mã khách sạn] = '{1}'", maKhach, maKS);
            DataSet ds = fn.getData(query);
            txtGiaGoc.Text = ds.Tables[0].Rows[0]["Gia"].ToString();
            string query2 = string.Format("select * from KhachHang where TaiKhoan = '{0}'", maKhach);
            DataSet ttKhach = fn.getData(query2);
            string query3 = string.Format("select * from DatPhong where TaiKhoan = '{0}' and MaKS = '{1}'", maKhach, maKS);
            DataSet phong = fn.getData(query3);
            LoadThongTin(ttKhach);
            LoadPhong(phong);
            giaGoc = txtGiaGoc.Text;
        }
        public void LoadPhong(DataSet ds)
        {
            this.cbbKhachSan.DataSource = ds.Tables[0];
        }
        public void LoadThongTin(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtHoTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtDienThoai.Text = ds.Tables[0].Rows[0]["Sdt"].ToString();
            }
        }
        public void cbbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {

            string giamGia = cbbVoucher.Text;
            giamGia = giamGia.Remove(giamGia.Length - 1);
            int g = Convert.ToInt32(giamGia);
            int tongGia = Convert.ToInt32(giaGoc);
            int giaMoi = tongGia * (100 - g) / 100;
            txtTongGia.Text = giaMoi.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (this.cbbHInhThuc.Text.ToLower() == "online")
            {
                this.pictureQR.Visible = true;
                this.txtMaGiaoDich.Visible = true;
                this.lblMaGiaoDich.Visible = true;
                this.lblDiaChi.Visible = false;
                this.lblHinhThuc.Visible = false;
                this.lblThoiGian.Visible = false;
            }
            else
            {
                this.pictureQR.Visible = false;
                this.txtMaGiaoDich.Visible = false;
                this.lblMaGiaoDich.Visible = false;
                this.lblDiaChi.Visible = true;
                this.lblHinhThuc.Visible = true;
                this.lblThoiGian.Visible = true;
            }
        }
    }
}
