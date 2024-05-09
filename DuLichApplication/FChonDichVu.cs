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

    public partial class FChonDichVu : Form
    {
        string maKS;
        string maKhach;
        DBFunction fn = new DBFunction();
        public FChonDichVu(string maKS, string maKhach)
        {
            InitializeComponent();
            this.maKS = maKS;
            this.maKhach = maKhach;
        }

        private void FChonDichVu_Load(object sender, EventArgs e)
        {
            LoadPhong();
        }

        public void LoadPhong()
        {
            string query = string.Format("select * from [Phòng] where [Mã khách sạn] = '{0}' and [MaKhach] = '{1}' and [Trạng thái] = 'No'", this.maKS, this.maKhach);
            DataSet ds = fn.getData (query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UC_itemPhong1 it = new UC_itemPhong1(true);
                    it.MaPhong = row["Mã phòng"].ToString();
                    it.TienIch = row["Tiện ích"].ToString();
                    it.GiaTien = row["Giá"].ToString();
                    it.TrangThai = row["Trạng thái"].ToString();
                    it.LoaiPhong = row["Loại giường"].ToString();
                    it.MaKS = ds.Tables[0].Rows[0]["Mã khách sạn"].ToString();
                    DanhSachPhong.Controls.Add(it);
                }
            }
        }
    }
}
