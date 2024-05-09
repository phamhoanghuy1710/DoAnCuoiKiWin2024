using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace DuLichApplication
{
    public partial class UcDanhGia : UserControl
    {
        private string danhGia;
        private string maKs;
        private int soSao;
        private string tenKhach;
        private string maKhach;
        private string ngayThang;
        private int soLike;
        private byte[] hinhAnh;
        private bool isLike;
        private int id;
        public string tenKhachDung;
        DataSet ds;
        DBFunction fn = new DBFunction();
        List <string> TenNguoiLike = new List<string>();
        public UcDanhGia()
        {
            InitializeComponent();
        }


        [Category("Custom Props")]
        public string MaKS
        {
            get { return maKs; }
            set { this.maKs = value; }
        }

        [Category("Custom Props")]
        public string TenKhachDung
        {
            get { return tenKhachDung; }
            set { this.tenKhachDung = value; }
        }

        public string MaKhach
        {
            get { return maKhach; }
            set { this.maKhach = value; }
        }

        [Category("Custom Props")]
        public string DanhGia
        {
            get { return danhGia; }
            set { this.danhGia = value; this.txtDanhGia.Text = value; }
        }

        [Category("Custom Props")]
        public int SoSao
        {
            get { return soSao; }
            set
            {
                this.soSao = value;
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


        [Category("Custom Props")]
        public string TenKhach
        {
            get { return tenKhach; }
            set { this.tenKhach = value; this.lblTenKhach.Text = value; }
        }



        [Category("Custom Props")]
        public string NgayThang
        {
            get { return ngayThang; }
            set { this.ngayThang = value; this.txtNgayThang.Text = value; }
        }


        [Category("Custom Props")]
        public int SoLike
        {
            get { return soLike; }
            set { this.soLike = value; this.btnSoLike.Text = value.ToString(); }
        }

        [Category("Custom Props")]
        public byte[] HinhAnh
        {
            get { return hinhAnh; }
            set
            {
                this.hinhAnh = value;
                // khi lấy lên dưới dạng byte , xài 1 cái ms truyen byte vao
                MemoryStream ms = new MemoryStream(value);
                if (value == null)
                {
                    MessageBox.Show("Không hợp lệ");
                }
                else
                {
                    this.picHinhAnh.Image = Image.FromStream(ms);
                }
            }
        }


        [Category("Custom Props")]
        public int ID
        {
            get { return id; }
            set { this.id = value; }
        }
        public void LoadNguoiLike()
        {
            string query1 = string.Format("select * from DanhSachNguoiLike where Id = '{0}'", id);
            this.ds = fn.getData(query1);
            bool isCo = false;
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["TaiKhoan"].ToString() == this.maKhach)
                    {
                        isCo = true;
                        break;
                    }
                }
            }
            if (isCo == true)
            {
                this.btnLike.Text = "Un Like";
                this.isLike = true;
            }
            else
            {
                this.isLike = false;
            }

        }

        private void btnLike_Click(object sender, EventArgs e)
        {
            if (isLike == false)
            {
                this.soLike += 1;
                this.btnSoLike.Text = this.soLike.ToString();
                string query = string.Format("update DanhGia set SoLike = '{0}' where Id = '{1}'", soLike, this.id);
                fn.setData(query, "oke", false);
                string query1 = string.Format("insert into DanhSachNguoiLike (Id,TaiKhoan,HoTen) values ('{0}','{1}','{2}')", this.id, this.maKhach, this.tenKhachDung);
                fn.setData(query1, "oke", false);
                isLike = true;
                this.btnLike.Text = "Un Like";
            }
            else
            {
                // is Like = True
                this.SoLike -= 1;
                this.btnSoLike.Text = this.soLike.ToString();
                string query = string.Format("update DanhGia set SoLike = '{0}' where Id = '{1}'", soLike, this.id);
                fn.setData(query, "oke", false);
                string query1 = string.Format("delete from DanhSachNguoiLike where Id = '{0}' and TaiKhoan = '{1}'", this.id, this.maKhach);
                fn.setData(query1, "oke", false);
                isLike = false;
                this.btnLike.Text = "Like";
            }
        }

        private void UcDanhGia_Load(object sender, EventArgs e)
        {
            LoadNguoiLike();
        }

        private void btnSoLike_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.TenNguoiLike.Clear();
            string query = string.Format("select * from DanhSachNguoiLike where Id = '{0}'", this.id);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    this.TenNguoiLike.Add(row["HoTen"].ToString());
                }
            }
            foreach (string tenNguoi in this.TenNguoiLike)
            {
                listBox1.Items.Add(tenNguoi);
            }
            listBox1.Visible = true;

        }
    }
}
