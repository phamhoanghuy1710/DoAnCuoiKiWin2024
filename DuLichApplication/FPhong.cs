using DuLichApplication.All_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class FPhong : Form
    {
        DataSet ds;
        string taiKhoan;
        DateTime ngayNhanPhong;
        DateTime ngayTraPhong;
        DBFunction fn = new DBFunction();
        public FPhong(DataSet ds, string taiKhoan, DateTime ngayNhanPhong, DateTime ngayTraPhong)
        {
            InitializeComponent();
            this.ds = ds;
            this.taiKhoan = taiKhoan;
            this.ngayNhanPhong = ngayNhanPhong;
            this.ngayTraPhong = ngayTraPhong;
            this.uC_ChonPhong1.btnGioHang.Click += MoGioHang;
        }


        private void MoGioHang(object sender, EventArgs e)
        {
            if (this.uC_ChonPhong1.btnGioHangCliked == true)
            {
                GioHang gh = new GioHang(ds.Tables[0].Rows[0]["Mã khách sạn"].ToString(), taiKhoan);
                gh.yeuCauLoad = new GioHang.YeuCauLoad(XacNhanLoad);
                gh.Show();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FPhong_Load(object sender, EventArgs e)
        {
            // chuyen thong tin qua cho uControl
            this.uC_ChonPhong1.getMaKhachSan(ds.Tables[0].Rows[0]["Mã khách sạn"].ToString(), taiKhoan);
            this.uC_ChonPhong1.getThongTin(ngayNhanPhong, ngayTraPhong);
            // lấy mã khách sạn để truyền
            this.uC_ChonPhong1.lblTenKS.Text = ds.Tables[0].Rows[0]["Tên khách sạn"].ToString();
            this.uC_ChonPhong1.lblDiaChi.Text = "Địa chỉ: " + ds.Tables[0].Rows[0]["Địa chỉ"].ToString();
            this.uC_ChonPhong1.lblGia.Text = "Giá: " + ds.Tables[0].Rows[0]["Giá"].ToString() + " VND";
            this.uC_ChonPhong1.guna2TextBox2.Text = ds.Tables[0].Rows[0]["Review"].ToString();
            int number;
            int soSao;
            if (int.TryParse(ds.Tables[0].Rows[0]["Số Sao"].ToString(), out number))
            {
                soSao = number;
            }
            else
            {
                soSao = -1;
            }
            for (int i = 0; i < this.uC_ChonPhong1.panelSao.Controls.Count; i++)
            {
                if (i < soSao)
                {
                    this.uC_ChonPhong1.panelSao.Controls[i].Visible = true;
                }
                else
                {
                    this.uC_ChonPhong1.panelSao.Controls[i].Visible = false;
                }
            }
            int MaKs = Convert.ToInt32(ds.Tables[0].Rows[0]["Mã khách sạn"]);
            string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}'", MaKs);
            LoadPhong(query);

        }

        public void XacNhanLoad(bool isLose)
        {
            if (isLose == true)
            {
                string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}'", ds.Tables[0].Rows[0]["Mã khách sạn"]);
                LoadPhong(query);
            }
        }
        private void LoadPhong(string query)
        {
            DataSet ds = fn.getData(query);
            this.uC_ChonPhong1.flowPanelPhong.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UC_itemPhong1 it = new UC_itemPhong1();
                    it.MaPhong = row["Mã phòng"].ToString();
                    it.TienIch = row["Tiện ích"].ToString();
                    it.GiaTien = row["Giá"].ToString();
                    it.TrangThai = row["Trạng thái"].ToString();
                    it.LoaiPhong = row["Loại giường"].ToString();
                    it.MaKhach = taiKhoan;
                    it.MaKS = ds.Tables[0].Rows[0]["Mã khách sạn"].ToString();
                    it.NgayNhanPhong = ngayNhanPhong;
                    it.NgayTraPhong = ngayTraPhong;
                    this.uC_ChonPhong1.flowPanelPhong.Controls.Add(it);
                }
            }

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.FPhong_Load(sender, e);
        }
    }
}
