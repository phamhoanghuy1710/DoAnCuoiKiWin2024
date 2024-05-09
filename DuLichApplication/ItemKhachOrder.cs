using Microsoft.Identity.Client.Extensions.Msal;
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
    public partial class ItemKhachOrder : UserControl
    {
        string maDV;
        string tenDV;
        int gia;
        int soLuong;
        public ItemKhachOrder()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string MaDV
        {
            get { return maDV; }
            set { this.maDV = value; }
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

        [Category("Custom Props")]
        public int SoLuong
        {
            get { return soLuong; }
            set { this.soLuong = value; }
        }
    }
}
