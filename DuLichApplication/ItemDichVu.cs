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
    public partial class ItemDichVu : UserControl
    {
        string maDV;
        string tenDV;
        int gia;
        bool isKhach;
        DBFunction fn = new DBFunction();
        public ItemDichVu(bool isKhach)
        {
            InitializeComponent();
            this.isKhach = isKhach;
        }

        [Category("Custom Props")]
        public string MaDV
        {
            get { return maDV; }
            set { this.maDV = value; this.txtMaDichVu.Text = value; }
        }

        [Category("Custom Props")]
        public string TenDV
        {
            get { return tenDV; }
            set { this.tenDV = value; this.txtTenDichVu.Text = value; }

        }
        [Category("Custom Props")]
        public int Gia
        {
            get { return gia; }
            set { this.gia = value; this.txtGia.Text = value.ToString(); }

        }

        private void ItemDichVu_Load(object sender, EventArgs e)
        {
            if (isKhach == true)
            {
                btnChon.Visible = true;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            }
            else
            {
                btnChon.Visible = false;
                btnSua.Visible = true;
                btnXoa.Visible = true;
            }
        }
    }
}
