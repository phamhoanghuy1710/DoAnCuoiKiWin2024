﻿using DuLichApplication.All_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class ucUpdateKS : UserControl
    {
        DBFunction fn = new DBFunction();
        int trangThaiChinh = 0;
        string maKS;
        public bool isLuu = false;
        public bool isTatForm = false;
        public ucUpdateKS()
        {
            InitializeComponent();
        }

        public void getMaKhachSan(string maKS)
        {
            this.maKS = maKS;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (trangThaiChinh == 0)
            {
                // mo ra cho nguoi dung nhap vao
                this.btnChinhSua.Text = "Lưu Thông Tin";
                this.isLuu = false;
                this.txtTenKhachSan.ReadOnly = false;
                this.txtDiaChiKs.ReadOnly = false;
                this.txtGia.ReadOnly = false;
                this.txtGioiThieuKhachSan.ReadOnly = false;
                this.numericUpDown1.Visible = true;
                // tat vnd trong txt Gia.Tex
                this.txtGia.Text = this.txtGia.Text.ToString().Replace("VND", "");
                trangThaiChinh = 1;
            }
            else
            {
                this.numericUpDown1.Visible = false;
                this.isLuu = true;
                // kiem tra thong tin nguoi dung nhap vao
                if (CheckData.KiemTraKhachSan(this.txtTenKhachSan, this.txtDiaChiKs, this.txtGia, this.txtGioiThieuKhachSan) == true)
                {
                    // chinh sua trong data base
                    this.btnChinhSua.Text = "Chỉnh sửa thông tin";
                    string query = string.Format("update KhachSan  set [Tên khách sạn] = '{0}', [Địa chỉ] = '{1}',  [Giá] = '{2}', [Review] = '{3}' , [Số sao] = '{4}' where [Mã khách sạn] = '{5}' ", txtTenKhachSan.Text, txtDiaChiKs.Text, Convert.ToInt32(txtGia.Text), txtGioiThieuKhachSan.Text, Convert.ToInt32(numericUpDown1.Value), maKS);
                    fn.setData(query, "Đã chỉnh sửa thành công",true);
                    this.txtTenKhachSan.ReadOnly = true;
                    this.txtDiaChiKs.ReadOnly = true;
                    this.txtGia.ReadOnly = true;
                    this.txtGioiThieuKhachSan.ReadOnly = true;
                    this.numericUpDown1.Visible = false;
                    trangThaiChinh = 0;
                }
            }
        }

        private void ucUpdateKS_Load(object sender, EventArgs e)
        {
            // không cần làm gì hết
        }
       
        public void LoadLaiPhong()
        {
            string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}'", this.maKS);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.flowPanelPhong.Controls.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UcItemUpdatePhong it = new UcItemUpdatePhong();
                    it.MaPhong = row["Mã phòng"].ToString();
                    it.TienIch = row["Tiện ích"].ToString();
                    it.GiaTien = row["Giá"].ToString();
                    it.LoaiPhong = row["Loại giường"].ToString();
                    byte[] pic = (byte[])row["HinhAnh"];
                    it.HinhAnh = pic;
                    this.flowPanelPhong.Controls.Add(it);
                }
            }
        }
        public void KiemTraDong(bool isDong)
        {
            if (isDong)
            {
                LoadLaiPhong();
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            FThemPhong fThem = new FThemPhong(maKS);
            fThem.truyenChoCha = new FThemPhong.TruyenChoCha(KiemTraDong);
            fThem.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // khi ấn nút xóa khách sạn này thì khách sạn sẽ cút  luôn
            // trước khi xóa khách sạn là phải xóa phòng trước
            string xoa_query = string.Format("delete from [Phòng] where [Mã khách sạn] = '{0}' ", this.maKS);
            fn.setData (xoa_query,"Xóa hết các phòng ở khách sạn này",false);
            string query = string.Format("delete from KhachSan where [Mã khách sạn] = '{0}'", this.maKS);
            fn.setData(query, "Đã xóa khách sạn thành công", true);
            this.isTatForm = true;

        }
    }
}
