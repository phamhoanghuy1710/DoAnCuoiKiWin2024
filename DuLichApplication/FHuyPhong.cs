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
    public partial class FHuyPhong : Form
    {
        string taiKhoan;
        DBFunction fn = new DBFunction();
        DataSet ds;
        public FHuyPhong(string taiKhoan)
        {
            InitializeComponent();
            this.taiKhoan = taiKhoan;
        }

        private void FHuyPhong_Load(object sender, EventArgs e)
        {
            CauLenh();
            LoaKS();
            LoadPhong();
        }
        public void CauLenh()
        {
            string query = string.Format("select * from DatPhong where TaiKhoan = '{0}' and TrangThai = 'Yes'", this.taiKhoan);
            this.ds = fn.getData(query);
        }
        public void LoadPhong()
        {
            CauLenh();
            string tenKS = this.cbbDSKhachSan.Text;
            string maKS = tenKS.Split(".")[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.flowLayoutPanel1.Controls.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["MaKS"].ToString() == maKS)
                    {
                        UcItemHuyPhong item = new UcItemHuyPhong();
                        item.MaPhong = row["MaPhong"].ToString();
                        item.Gia = row["GiaPhong"].ToString();
                        DateTime ngayNhanPhong = DateTime.ParseExact(row["NgayNhanPhong"].ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        item.NgayNhanPhong = ngayNhanPhong;

                        DateTime ngayTraPhong = DateTime.ParseExact(row["NgayTraPhong"].ToString(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                        item.NgayTraPhong = ngayTraPhong;

                        item.TaiKhoan = row["TaiKhoan"].ToString();
                        item.MaKS = row["MaKS"].ToString();
                        this.flowLayoutPanel1.Controls.Add(item);
                    }
                }
            }
        }

        public void LoaKS()
        {
            List<string> dsKS = new List<string>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dsKS.Add(row["MaKS"].ToString());
                }
            }

            string query = string.Format("select * from KhachSan where [Mã khách sạn] in ('{0}')", string.Join("','", dsKS));
            DataSet data = fn.getData(query);
            List<string> listTenKS = new List<string>();
            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    listTenKS.Add(row["Mã khách sạn"].ToString() + "." + row["Tên khách sạn"].ToString());
                }
            }
            this.cbbDSKhachSan.DataSource = listTenKS;

        }

        private void cbbDSKhachSan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPhong();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
