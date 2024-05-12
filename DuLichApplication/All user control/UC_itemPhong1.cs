using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication.All_user_control
{
    public partial class UC_itemPhong1 : UserControl
    {
        private string maPhong;
        private string tienIch;
        private string giaTien;
        private string loaiPhong;
        private string maKhach;
        public string maKS;
        public DateTime ngayNhanPhong;
        public DateTime ngayTraPhong;
        DBFunction fn = new DBFunction();
        private byte[] hinhAnh;
        bool dv;

        public UC_itemPhong1(bool dv)
        {
            InitializeComponent();
            this.dv = dv;
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

        public string MaKS
        {
            get { return MaKS; }
            set { maKS = value; }
        }
        public string MaKhach
        {
            get { return maKhach; }
            set
            {
                this.maKhach = value;
            }
        }
        public DateTime NgayNhanPhong
        {
            get { return ngayNhanPhong; }
            set
            {
                this.ngayNhanPhong = value;
            }
        }

        public DateTime NgayTraPhong
        {
            get { return ngayTraPhong; }
            set
            {
                this.ngayTraPhong = value;
            }
        }


        [Category("Custom Props")]
        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; txtMaPhong.Text = value; }
        }


        [Category("Custom Props")]
        public string TienIch
        {
            get { return tienIch; }
            set { tienIch = value; txtTienIch.Text = value; }
        }

        [Category("Custom Props")]
        public string GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; txtGiaTien.Text = value; }
        }

        [Category("Custom Props")]
        public string LoaiPhong
        {
            get { return loaiPhong; }
            set { loaiPhong = value; txtLoaiPhong.Text = value; }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            // đổi lại trạng thái phòng ,
            // thêm phòng đó vào danh sách phòng đã chọn
            bool isHopLe = false;
            //
            string query_kt = string.Format("select * from DatPhong where TrangThai = 'Yes' and MaPhong = '{0}'",this.maPhong);
            DataSet ds = fn.getData(query_kt);
            // data set dang chua bang, sap xep phong
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count-1; i++)
                {
                    int minPos = i;
                    for (int j = i + 1; j < ds.Tables[0].Rows.Count; j++)
                    {
                        if (Convert.ToDateTime(ds.Tables[0].Rows[j]["NgayNhanPhong"]) < Convert.ToDateTime(ds.Tables[0].Rows[minPos]["NgayNhanPhong"]))
                        {
                            minPos = j;
                        }
                    }
                    // hoán đổi
                    if (minPos != i)
                    {
                        DataRow temp = ds.Tables[0].NewRow();
                        temp.ItemArray = ds.Tables[0].Rows[i].ItemArray;
                        ds.Tables[0].Rows[i].ItemArray = ds.Tables[0].Rows[minPos].ItemArray;
                        ds.Tables[0].Rows[minPos].ItemArray = temp.ItemArray;
                    }
                }
            }
            // duyet dieu kien
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (this.ngayNhanPhong > Convert.ToDateTime(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["NgayTraPhong"]))
                {
                    isHopLe = true;
                }
                else // truong hop nay la o giua
                {
                    for (int i = 0; i< ds.Tables[0].Rows.Count-1 ; i ++)
                    {
                        if (this.ngayNhanPhong > Convert.ToDateTime(ds.Tables[0].Rows[i]["NgayTraPhong"]) && this.ngayTraPhong < Convert.ToDateTime(ds.Tables[0].Rows[i+1]["NgayNhanPhong"]))
                        {
                            isHopLe = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                isHopLe = true;
            }
             //kiem tra dat phong truoc
            if (isHopLe == true)
            {
                string query2 = string.Format("insert into DatPhong (TaiKhoan,NgayNhanPhong,NgayTraPhong,MaKS,MaPhong,TrangThai,GiaPhong) values ('{0}','{1}','{2}','{3}','{4}','No','{5}')", maKhach, ngayNhanPhong, ngayTraPhong, maKS, maPhong, Convert.ToInt32(this.GiaTien));
                fn.setData(query2, "oke", false);
                ThanhToan form = new ThanhToan(this.maKhach, this.maKS);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không thể đặt do trùng lịch");
            }
        }

        private void UC_itemPhong1_Load(object sender, EventArgs e)
        {
            if (this.dv == true)
            {
                this.btnChon.Visible = false;
                this.btnDichVu.Visible = true;
            }
            else
            {
                this.btnChon.Visible = true;
                this.btnDichVu.Visible = false;
            }
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
