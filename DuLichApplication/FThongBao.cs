using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class FThongBao : Form
    {
        string taiKhoan;
        DBFunction fn = new DBFunction();
        public FThongBao(string taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
            this.dtNgayThongBao.Value = DateTime.Now;
        }

        private void FThongBao_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            string query = string.Format("select * from LSDatPhong where NgayThongBao = '{0}'", this.dtNgayThongBao.Value);
            DataSet ds = fn.getData(query);
            LoadTB(ds);
        }

        public void LoadTB(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UCItemThongTB it = new UCItemThongTB();
                    it.MaKS = row["MaKS"].ToString();
                    it.MaPhong = row["MaPhong"].ToString();
                    DateTime ngayTraPhong = DateTime.ParseExact(row["NgayTraPhong"].ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    it.NgayTraPhong = ngayTraPhong.ToString("dd/MM/yyyy");
                    DateTime ngayThongBao = DateTime.ParseExact(row["NgayThongBao"].ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    it.NgayThongBao = ngayThongBao.ToString("dd/MM/yyyy");
                    it.ThongBao = row["ThongBao"].ToString();
                    flowLayoutPanel1.Controls.Add(it);
                }
            }
        }

        private void dtNgayThongBao_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayThonBao = this.dtNgayThongBao.Value;
            FThongBao_Load(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
