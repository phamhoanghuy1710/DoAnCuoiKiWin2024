using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class UCItemThongTB : UserControl
    {
        private string maKS;
        private string maPhong;
        string ngayTraPhong;
        string ngayThongBao;
        string thongBao;
        DBFunction fn = new DBFunction();
        public UCItemThongTB()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string MaKS
        {
            get { return maKS; }
            set { this.maKS = value; }

        }

        [Category("Custom Props")]
        public string MaPhong
        {
            get { return maPhong; }
            set { this.maPhong = value; this.txtMaPhong.Text = value; }

        }

        [Category("Custom Props")]
        public string ThongBao
        {
            get { return thongBao; }
            set { this.thongBao = value; this.txtThongBao.Text = value; }

        }

        [Category("Custom Props")]
        public string NgayTraPhong
        {
            get { return ngayTraPhong; }
            set { this.ngayTraPhong = value; this.txtNgayHetHan.Text = value; }

        }

        [Category("Custom Props")]
        public string NgayThongBao
        {
            get { return ngayThongBao; }
            set { this.ngayThongBao = value; this.txtNgayThongBao.Text = value; }

        }

        private void UCItemThongTB_Load(object sender, EventArgs e)
        {
            string query = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", this.maKS);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.txtTenKS.Text = ds.Tables[0].Rows[0]["Tên khách sạn"].ToString();
            }
        }
    }
}
