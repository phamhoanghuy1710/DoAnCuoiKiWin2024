﻿using DocumentFormat.OpenXml.Spreadsheet;
using DuLichApplication.All_user_control;
using Microsoft.IdentityModel.Logging;
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

namespace DuLichApplication
{
    public partial class FPhong : Form
    {
        DataSet ds;
        string taiKhoan;
        DateTime ngayNhanPhong;
        DateTime ngayTraPhong;
        DBFunction fn = new DBFunction();


        public FPhong(DataSet ds, string taiKhoan)
        {
            InitializeComponent();
            this.ds = ds;
            this.taiKhoan = taiKhoan;
            this.ucUpdateks1.getMaKhachSan(ds.Tables[0].Rows[0]["Mã khách sạn"].ToString());
            this.ucUpdateks1.btnChinhSua.Click += LoadLaiKs;
            this.ucUpdateks1.btnXoa.Click += TatForm;
            

        }
        public FPhong(DataSet ds, string taiKhoan, DateTime ngayNhanPhong, DateTime ngayTraPhong)
        {
            InitializeComponent();
            this.ds = ds;
            this.taiKhoan = taiKhoan;
            this.ngayNhanPhong = ngayNhanPhong;
            this.ngayTraPhong = ngayTraPhong;
        }
        public void TatForm (object sender , EventArgs e)
        {
            if (this.ucUpdateks1.isTatForm == true)
            {
                this.Dispose();
            }
        }
        public void LoadLaiKs(object sender, EventArgs e)
        {
            if (this.ucUpdateks1.isLuu == true)
            {
                string query = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", ds.Tables[0].Rows[0]["Mã khách sạn"].ToString());
                this.ds = fn.getData(query);
                FPhong_Load(sender, e);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FPhong_Load(object sender, EventArgs e)
        {
            if (this.taiKhoan == "chu")
            {
                this.uC_ChonPhong1.Visible = false;
                this.ucUpdateks1.Visible = true;
                this.ucUpdateks1.BringToFront();
                LoadGiaoDienChu();
                int MaKs = Convert.ToInt32(ds.Tables[0].Rows[0]["Mã khách sạn"]);
                string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}'", MaKs);
                LoadPhongChu(query);
            }
            else
            {
                this.uC_ChonPhong1.Visible = true;
                this.ucUpdateks1.Visible = false;
                this.uC_ChonPhong1.BringToFront();
                LoadGiaoDienCus();
                int MaKs = Convert.ToInt32(ds.Tables[0].Rows[0]["Mã khách sạn"]);
                string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}'", MaKs);
                LoadPhong(query);

            }
        }

        public void LoadGiaoDienChu()
        {
            this.ucUpdateks1.txtTenKhachSan.Text = ds.Tables[0].Rows[0]["Tên khách sạn"].ToString();
            this.ucUpdateks1.txtDiaChiKs.Text = ds.Tables[0].Rows[0]["Địa chỉ"].ToString();
            this.ucUpdateks1.txtGia.Text = ds.Tables[0].Rows[0]["Giá"].ToString() + "VND";
            this.ucUpdateks1.txtGioiThieuKhachSan.Text = ds.Tables[0].Rows[0]["Review"].ToString();

            int number;
            int soSao;
            if (int.TryParse(ds.Tables[0].Rows[0]["Số sao"].ToString(), out number))
            {
                soSao = number;
            }
            else
            {
                soSao = -1;
            }

            for (int i = 0; i < this.ucUpdateks1.panelSao.Controls.Count; i++)
            {
                if (i < soSao)
                {
                    this.ucUpdateks1.panelSao.Controls[i].Visible = true;
                }
                else
                {
                    this.ucUpdateks1.panelSao.Controls[i].Visible = false;
                }
            }
            byte[] pic = (byte[])ds.Tables[0].Rows[0]["HinhAnh"];
            MemoryStream ms = new MemoryStream(pic);
            if (pic == null)
            {
                MessageBox.Show("Không hợp lệ");
            }
            else
            {
                this.ucUpdateks1.pictureKS.Image = Image.FromStream(ms);
            }

        }
        public void LoadGiaoDienCus()
        {
            // chuyen thong tin qua cho uControl
            this.uC_ChonPhong1.getMaKhachSan(ds.Tables[0].Rows[0]["Mã khách sạn"].ToString(), taiKhoan);
            // lấy mã khách sạn để truyền
            this.uC_ChonPhong1.dtNgayNhanPhong.Value = this.ngayNhanPhong;
            this.uC_ChonPhong1.dtNgayTraPhong.Value = this.ngayTraPhong;
            this.uC_ChonPhong1.tmp = this.ngayNhanPhong;
            this.uC_ChonPhong1.cbbSoDem.Text  = (ngayTraPhong - ngayNhanPhong).TotalDays.ToString() ;
            this.uC_ChonPhong1.lblTenKS.Text = ds.Tables[0].Rows[0]["Tên khách sạn"].ToString();
            this.uC_ChonPhong1.lblDiaChi.Text = "Địa chỉ: " + ds.Tables[0].Rows[0]["Địa chỉ"].ToString();
            this.uC_ChonPhong1.lblGia.Text = "Giá: " + ds.Tables[0].Rows[0]["Giá"].ToString() + "VND";  // fix sau
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
            byte[] pic = (byte[])ds.Tables[0].Rows[0]["HinhAnh"];
            MemoryStream ms = new MemoryStream(pic);
            if (pic == null)
            {
                MessageBox.Show("Không hợp lệ");
            }
            else
            {
                this.uC_ChonPhong1.pictureKS.Image = Image.FromStream(ms);
            }
            string tienIch = ds.Tables[0].Rows[0]["TienNghiPhong"].ToString();
            string dichVu =  ds.Tables[0].Rows[0]["DichVuKhachSan"].ToString();
            string[] listTI = tienIch.Split(",");
            string[] listDv = dichVu.Split(",");
            for (int i = 0; i < this.uC_ChonPhong1.panelTienIch.Controls.Count; i++)
            {
                if (i < listTI.Length)
                {
                    this.uC_ChonPhong1.panelTienIch.Controls[i].Text = listTI[i];
                }
                else
                {
                    this.uC_ChonPhong1.panelTienIch.Controls[i].Text = "";
                }
            }
            for (int i = 0; i < this.uC_ChonPhong1.panelDichVu.Controls.Count; i++)
            {
                if (i < listDv.Length)
                {
                    this.uC_ChonPhong1.panelDichVu.Controls[i].Text = listDv[i];
                }
                else
                {
                    this.uC_ChonPhong1.panelDichVu.Controls[i].Text = "";
                }
            }
        }
        public void XacNhanLoad(bool isLose)
        {
            if (isLose == true)
            {
                string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}'", ds.Tables[0].Rows[0]["Mã khách sạn"]);
                LoadPhong(query);
            }
        }

        public void LoadPhongChu(string query)
        {
            DataSet ds = fn.getData(query);
            this.ucUpdateks1.flowPanelPhong.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UcItemUpdatePhong it = new UcItemUpdatePhong();
                    it.MaPhong = row["Mã phòng"].ToString();
                    it.TienIch = row["Tiện ích"].ToString();
                    it.GiaTien = row["Giá"].ToString();
                    it.LoaiPhong = row["Loại giường"].ToString();
                    byte[] pic = (byte[])row["HinhAnh"];
                    it.HinhAnh = pic;
                    this.ucUpdateks1.flowPanelPhong.Controls.Add(it);
                }
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
                    UC_itemPhong1 it = new UC_itemPhong1(false);
                    it.MaPhong = row["Mã phòng"].ToString();
                    it.TienIch = row["Tiện ích"].ToString();
                    it.GiaTien = row["Giá"].ToString();
                    it.LoaiPhong = row["Loại giường"].ToString();
                    it.MaKhach = taiKhoan;
                    it.MaKS = ds.Tables[0].Rows[0]["Mã khách sạn"].ToString();
                    it.NgayNhanPhong = ngayNhanPhong;
                    it.NgayTraPhong = ngayTraPhong;
                    byte[] pic = (byte[])row["HinhAnh"];
                    it.HinhAnh = pic;
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
