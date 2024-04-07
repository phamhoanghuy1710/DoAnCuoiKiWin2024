using DuLichApplication.All_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class GioHang : Form
    {
        DBFunction fn = new DBFunction();
        string maKS;
        string maKhach;
        public delegate void YeuCauLoad(bool isLose);
        public YeuCauLoad yeuCauLoad;
        public GioHang(string maKS, string maKhach)
        {
            InitializeComponent();
            this.maKS = maKS;
            this.maKhach = maKhach;
        }


        private void GioHang_Load(object sender, EventArgs e)
        {
            string query = string.Format("select * from [Phòng] where [Trạng thái] = 'wait' and [Mã khách sạn] = '{0}' and MaKhach = '{1}'", maKS, maKhach);
            LoadPhong(query);
        }
        private void LoadPhong(string query)
        {
            DataSet ds = fn.getData(query);
            flowPanelPhong.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Uc_itemGioHang it = new Uc_itemGioHang();
                    it.MaPhong = row["Mã phòng"].ToString();
                    it.TienIch = row["Tiện ích"].ToString();
                    it.GiaTien = row["Giá"].ToString();
                    it.LoaiPhong = row["Loại giường"].ToString();
                    flowPanelPhong.Controls.Add(it);
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.GioHang_Load(sender, e);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToan tt = new ThanhToan(maKhach, maKS);
            tt.Show();
        }


        private void btnExit_Click_1(object sender, EventArgs e)
        {
            bool isExit = true;
            yeuCauLoad(isExit);
            this.Close(); ;
        }
    }
}
