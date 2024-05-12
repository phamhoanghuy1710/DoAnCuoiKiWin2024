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
    public partial class FDichVu : Form
    {
        DBFunction fn = new DBFunction();
        public FDichVu()
        {
            InitializeComponent();
        }

        private void FDichVu_Load(object sender, EventArgs e)
        {
        
            LoadDichVu();
        }
        public void LoadDichVu()
        {
            string query = string.Format("select * from DichVu");
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ItemDichVu item = new ItemDichVu(false);
                    item.MaDV = row["MaDichVu"].ToString();
                    item.TenDV = row["TenDichVu"].ToString();
                    item.Gia = Convert.ToInt32(row["Gia"]);
                    flowLayoutPanel1.Controls.Add(item);
                }
            }
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            string query = string.Format("insert into DichVu (MaDichVu,TenDichVu,Gia) values (N'{0}',N'{1}','{2}')", this.txtMaDichVu.Text, this.txtTenDichVu.Text, Convert.ToInt32(this.txtGia.Text));
            fn.setData(query, "Thêm thành công", true);
            // them vao 
            ItemDichVu item = new ItemDichVu(false);
            item.MaDV = this.txtMaDichVu.Text;
            item.TenDV = this.txtTenDichVu.Text;
            item.Gia = Convert.ToInt32(this.txtGia.Text);
            flowLayoutPanel1.Controls.Add(item);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
        }
    }
}
