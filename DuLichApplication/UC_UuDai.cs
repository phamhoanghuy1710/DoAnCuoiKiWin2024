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
    public partial class UC_UuDai : UserControl
    {
        DBFunction fn = new DBFunction();
        public UC_UuDai()
        {
            InitializeComponent();
        }

        private void UC_UuDai_Load(object sender, EventArgs e)
        {
            string query = string.Format("select * from KhachHang");
            DataSet ds = fn.getData(query);
            LoadItem(ds);
        }

        public void LoadItem(DataSet ds)
        {
            this.flowLayoutPanel1.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    UcItemKhach it = new UcItemKhach();
                    it.TenKhach = row["HoTen"].ToString();
                    it.TaiKhoan = row["TaiKhoan"].ToString();
                    it.Email = row["Email"].ToString();
                    it.TongChi = row["TongChi"].ToString();
                    it.SDT = row["Sdt"].ToString();
                    this.flowLayoutPanel1.Controls.Add(it);
                }
        }
    }
}
