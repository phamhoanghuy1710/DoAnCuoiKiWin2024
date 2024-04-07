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

namespace DuLichApplication.All_user_control
{

    public partial class ListItem : UserControl
    {
        DBFunction fn = new DBFunction();
        public event EventHandler ButtonClicked;
        public ListItem()
        {
            InitializeComponent();
        }

        private void ListItem_Load(object sender, EventArgs e)
        {

        }
        private int id;
        private string ten;
        private string diaChi;
        private string gia;
        private Image icon;
        private int soSao;
        public string taiKhoan;
        public DateTime ngayNhanPhong;
        public DateTime ngayTraPhong;

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string query = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", this.id);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                FPhong fp = new FPhong(ds, taiKhoan, ngayNhanPhong, ngayTraPhong);
                fp.Show();
            }

        }

        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { taiKhoan = value; }
        }
        public DateTime NgayNhanPhong
        {
            get { return ngayNhanPhong; }
            set { ngayNhanPhong = value; }
        }
        public DateTime NgayTraPhong
        {
            get { return ngayTraPhong; }
            set { ngayTraPhong = value; }
        }

        [Category("Custom Props")]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        [Category("Custom Props")]
        public string Ten
        {
            get { return ten; }
            set { ten = value; txtTenKS.Text = value; }
        }
        [Category("Custom Props")]
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; txtDiaChiKs.Text = value; }
        }
        [Category("Custom Props")]
        public string Gia
        {
            get { return gia; }
            set { gia = value; txtGiaTien.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return icon; }
            set { icon = value; picHinhAnh.Image = value; }
        }
        [Category("Custom Props")]
        public int SoSao
        {
            get { return soSao; }
            set
            {
                soSao = value;
                for (int i = 0; i < panelSao.Controls.Count; i++)
                {
                    if (i < value)
                    {
                        panelSao.Controls[i].Visible = true;
                    }
                    else
                    {
                        panelSao.Controls[i].Visible = false;
                    }
                }
            }
        }

    }
}
