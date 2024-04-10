using DuLichApplication.All_user_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class Uc_KhachSan : UserControl
    {
        DBFunction fn  = new DBFunction();
        public Uc_KhachSan()
        {
            InitializeComponent();
        }

        private void Uc_KhachSan_Load(object sender, EventArgs e)
        {
            string query = string.Format("select top 10 * from KhachSan");
            DataSet ds = fn.getData(query);
            LoadThongTin(ds);
        }

        public void LoadThongTin(DataSet ds)
        {
            this.flowLayoutPanel1.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Uc_ItemKScs item = new Uc_ItemKScs ();
                    item.Ten = row["Tên khách sạn"].ToString();
                    item.DiaChi = row["Địa chỉ"].ToString();
                    item.Gia = row["Giá"].ToString();
                    item.ID = Convert.ToInt32(row["Số sao"].ToString());
                    int soSao;
                    if (int.TryParse(row["Số sao"].ToString(),out soSao))
                    {
                        item.Sao  = soSao;
                    }
                    else
                    {
                        soSao = -1;
                    }
                    this.flowLayoutPanel1.Controls.Add(item);
                }
            }
        }
    }
}
