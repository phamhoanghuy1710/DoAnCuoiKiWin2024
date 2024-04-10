using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class ucUpdateKS : UserControl
    {
        DBFunction fn = new DBFunction();
        int trangThaiChinh = 0;
        string maKS;
        public bool isLuu = false;
        public ucUpdateKS()
        {
            InitializeComponent();
        }

        public void getMaKhachSan(string maKS)
        {
            this.maKS = maKS;
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (trangThaiChinh == 0)
            {
                // mo ra cho nguoi dung nhap vao
                this.btnChinhSua.Text = "Lưu Thông Tin";
                this.isLuu = false ; 
                this.txtTenKhachSan.ReadOnly = false;
                this.txtDiaChiKs.ReadOnly = false;
                this.txtGia.ReadOnly = false;
                this.txtGioiThieuKhachSan.ReadOnly = false;
                this.numericUpDown1.Visible = true;
                trangThaiChinh = 1;
            }
            else
            {
                this.btnChinhSua.Text = "Chỉnh sửa thông tin";
                this.numericUpDown1.Visible = false;
                this.isLuu = true ; 
                // kiem tra thong tin nguoi dung nhap vao
                if (CheckData.KiemTraKhachSan(this.txtTenKhachSan, this.txtDiaChiKs, this.txtGia, this.txtGioiThieuKhachSan) == true)
                {
                    // chinh sua trong data base
                    string query = string.Format("update KhachSan  set [Tên khách sạn] = '{0}', [Địa chỉ] = '{1}',  [Giá] = '{2}', [Review] = '{3}' , [Số sao] = '{4}' where [Mã khách sạn] = '{5}' ",txtTenKhachSan.Text,txtDiaChiKs.Text,Convert.ToInt32(txtGia.Text),txtGioiThieuKhachSan.Text,Convert.ToInt32(numericUpDown1.Value) , maKS);
                    fn.setData(query, "Đã chỉnh sửa thành công");
                    this.txtTenKhachSan.ReadOnly = true;
                    this.txtDiaChiKs.ReadOnly = true;
                    this.txtGia.ReadOnly = true;
                    this.txtGioiThieuKhachSan.ReadOnly = true;
                    this.numericUpDown1.Visible = false;
                    trangThaiChinh = 0;
                }
            }
        }

        private void ucUpdateKS_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(maKS);
        }
    }
}
