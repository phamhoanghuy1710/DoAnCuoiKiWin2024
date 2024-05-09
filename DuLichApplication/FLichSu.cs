using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class FLichSu : Form
    {
        string maKhach;
        DBFunction fn = new DBFunction();
        public FLichSu(string maKhach)
        {
            InitializeComponent();
            this.maKhach = maKhach;
        }

        private void FLichSu_Load(object sender, EventArgs e)
        {
            string query = string.Format("select * from GiaoDich where MaKhach = '{0}'", maKhach);
            DataSet ds = fn.getData(query);
            LoadLS(ds);
        }
        public void LoadLS(DataSet ds)
        {
            this.flowLayoutPanel1.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UcItemLichSu it = new UcItemLichSu();
                    it.TenKhach = row["TenKhach"].ToString();
                    it.MaKS = row["MaKS"].ToString();
                    it.NgayThanhToan = row["NgayThanhToan"].ToString();
                    it.GioThanhToan = row["GioThanhToan"].ToString();
                    it.SoTien = Convert.ToInt32(row["SoTien"]);
                    it.Email = row["Email"].ToString();
                    it.SDT = row["SoDT"].ToString();
                    it.MaKhach = row["MaKhach"].ToString();
                    it.DSPhong = row["DSMaPhong"].ToString();
                    //it.MaGiaoDich = row["MaGiaoDich"].ToString();

                    this.flowLayoutPanel1.Controls.Add(it);
                }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
