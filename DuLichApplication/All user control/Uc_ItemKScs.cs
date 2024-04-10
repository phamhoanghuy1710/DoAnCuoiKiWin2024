using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace DuLichApplication.All_user_control
{
    public partial class Uc_ItemKScs : UserControl
    {

        DBFunction fn = new DBFunction();
        public Uc_ItemKScs()
        {
            InitializeComponent();
        }
        private int id;
        private string ten;
        private string diaChi;
        private string gia;
        private int sao;
        private Image icon;

        private void btnChonKS_Click(object sender, EventArgs e)
        {
            string query = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'",this.id);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                FPhong fPhong = new FPhong(ds,"chu");
                fPhong.Show();
            }
        }


        [Category("Custom Props")]
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }

        [Category("Custom Props")]
        public string Ten
        {
            get { return ten; }
            set { ten = value; txtTenKS.Text = ten; }
        }

        [Category("Custom Props")]
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; this.txtDiaChiKs.Text = diaChi; }
        }

        [Category("Custom Props")]
        public string Gia
        {
            get { return gia; }
            set { gia = value; this.txtGiaTien.Text = gia; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return icon; }
            set { icon = value; picHinhAnh.Image = value; }
        }

        [Category("Custom Props")]
        public int Sao
        {
            get { return sao; }
            set
            {
                sao = value;
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
