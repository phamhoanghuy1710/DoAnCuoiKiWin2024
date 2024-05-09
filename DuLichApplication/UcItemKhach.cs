using Guna.UI2.WinForms;
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
    public partial class UcItemKhach : UserControl
    {
        private string taiKhoan;
        private string tenKhach;
        private string email;
        private string sdt;
        private string tongChi;
        string voucher = "";
        DBFunction fn = new DBFunction();

        [Category("Custom Props")]
        public string TaiKhoan
        {
            get { return taiKhoan; }
            set { this.taiKhoan = value; this.txtTaiKhoan.Text = value; }
        }

        [Category("Custom Props")]
        public string TenKhach
        {
            get { return tenKhach; }
            set { this.tenKhach = value; this.txtKhachHang.Text = value; }

        }

        [Category("Custom Props")]
        public string Email
        {
            get { return email; }
            set { this.email = value; this.txtEmail.Text = value; }
        }

        [Category("Custom Props")]
        public string SDT
        {
            get { return sdt; }
            set { this.sdt = value; this.txtSoDienThoai.Text = value; }
        }

        [Category("Custom Props")]
        public string TongChi
        {
            get { return tongChi; }
            set { this.tongChi = value; this.txtGiaTien.Text = value; }
        }
        public UcItemKhach()
        {
            InitializeComponent();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            bool check = false;
            foreach (Control ct in this.panel1.Controls)
            {
                if (ct is Guna2CheckBox)
                {
                    Guna2CheckBox cb = (Guna2CheckBox)ct;
                    if (cb.Checked)
                    {
                        check = true;
                        this.voucher += cb.Text + ',';
                    }
                }
            }
            if (check == false)
            {
                MessageBox.Show("Vui lòng chọn đề tài");
            }
            else
            {
                string query = string.Format("update KhachHang set Voucher = '{0}' where TaiKhoan = '{1}'", voucher, this.taiKhoan);
                fn.setData(query, "Thêm voucher thành công", true);
            }
        }


    }
}
