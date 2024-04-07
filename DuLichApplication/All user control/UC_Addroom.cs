using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DuLichApplication.All_user_control
{
    public partial class UC_Addroom : UserControl
    {
        DBFunction fn = new DBFunction();
        int Sao = 0;
        string tienIch = "";
        string condition = "";
        string taiKhoan = "";
        public UC_Addroom()
        {
            InitializeComponent();
            cbbSoDem.SelectedIndex = 0;
            cbbLoaiPhong.SelectedIndex = 0;

        }
        public void layTaiKhoan(string tk)
        {
            this.taiKhoan = tk;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ]  LIKE '%{0}%'  AND [Thể Loại] LIKE '%{1}%'", txtDiaChi.Text, cbbLoaiPhong.Text);
            LoadDS(query);
        }

        private void UC_Addroom_Load(object sender, EventArgs e)
        {
            string query = "SELECT TOP 10 * FROM KhachSan";
            LoadDS(query);
            LoadNgay();
        }
        private void LoadNgay()
        {
            DateTime ngayChonPhong = dtNgayNhanPhong.Value;
            int soDem = Convert.ToInt32(cbbSoDem.Text);
            DateTime ngayTraPhong = ngayChonPhong.AddDays(soDem);
            dtNgayTraPhong.Value = ngayTraPhong;
        }

        private void cbbSoDem_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNgay();
        }

        private void dtNgayNhanPhong_ValueChanged(object sender, EventArgs e)
        {
            LoadNgay();
        }

        private void LoadDS(string query)
        {
            DataSet ds = fn.getData(query);
            flowLayoutPanel1.Controls.Clear();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblLoi.Visible = false;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ListItem it = new ListItem();
                    it.Ten = row["Tên khách sạn"].ToString();
                    it.DiaChi = row["Địa chỉ"].ToString();
                    it.Gia = row["Giá"].ToString();
                    it.ID = Convert.ToInt32(row["Mã khách sạn"].ToString());
                    it.taiKhoan = this.taiKhoan.ToString();
                    it.NgayNhanPhong = this.dtNgayNhanPhong.Value;
                    it.NgayTraPhong = this.dtNgayTraPhong.Value;
                    int soSao;
                    if (int.TryParse(row["Số Sao"].ToString(), out soSao))
                    {
                        it.SoSao = soSao;
                    }
                    else
                    {
                        it.SoSao = -1;
                    }
                    flowLayoutPanel1.Controls.Add(it);
                }
            }
            else
            {
                lblLoi.Visible = true;
            }
        }

        private void guna2RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                foreach (Control c in panelTienIch.Controls)
                {
                    if (c is Guna2CheckBox)
                    {
                        Guna2CheckBox cb = (Guna2CheckBox)c;
                        cb.Checked = false;
                    }
                }
                Sao = Convert.ToInt32(radio.Text);
                string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ]  LIKE '%{0}%'  AND [Thể Loại] LIKE '%{1}%' AND [Số Sao] = '{2}' AND [Giá] <= '{3}'", txtDiaChi.Text, cbbLoaiPhong.Text, Sao, numGia.Value);
                LoadDS(query);
            }
        }

        private void guna2CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            Guna2CheckBox checkbox = sender as Guna2CheckBox;
            tienIch = "";
            if (checkbox.Checked == true || checkbox.Checked == false)
            {
                foreach (Control c in panelTienIch.Controls)
                {
                    if (c is Guna2CheckBox)
                    {
                        Guna2CheckBox cb = (Guna2CheckBox)c;
                        if (cb.Checked)
                        {
                            tienIch += c.Text + ',';
                        }
                    }
                }
                if (tienIch != "")
                {
                    // lấy ra các tiện ích
                    condition = "";
                    string[] Ti = tienIch.Split(',');
                    // Tạo danh sách điều kiện cho các phần tử trong mảng Ti
                    foreach (string item in Ti)
                    {
                        condition += "[TienNghiPhong] LIKE '%" + item.Trim() + "%' AND ";  // item.trim() tuc la lay chuoi do ra khoi mang
                    }
                    // Loại bỏ dấu "AND" cuối cùng
                    if (!string.IsNullOrEmpty(condition))
                    {
                        condition = condition.Remove(condition.Length - 5);
                    }
                }

                /// khúc này là lấy ra từ database
                if (Sao == 0)
                {
                    string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ] LIKE '%{0}%' AND [Thể Loại] LIKE '%{1}%' AND ({2}) AND [Giá] <= '{3}'", txtDiaChi.Text, cbbLoaiPhong.Text, condition, numGia.Value);
                    LoadDS(query);
                }
                else
                {
                    // Tạo truy vấn SQL với điều kiện đã tạo
                    string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ] LIKE '%{0}%' AND [Thể Loại] LIKE '%{1}%' AND [Số Sao] = '{2}' AND ({3}) AND [Giá] <= '{4}'", txtDiaChi.Text, cbbLoaiPhong.Text, Sao, condition, numGia.Value);
                    LoadDS(query);
                }
            }

        }



        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Sao == 0 && tienIch == "")
            {
                string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ] LIKE '%{0}%' AND [Thể Loại] LIKE '%{1}%' AND [Giá] <= '{2}'", txtDiaChi.Text, cbbLoaiPhong.Text, numGia.Value);
                LoadDS(query);
            }
            else if (Sao == 0 && tienIch != "")
            {
                string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ] LIKE '%{0}%' AND [Thể Loại] LIKE '%{1}%' AND ({2}) AND [Giá] <= '{3}'", txtDiaChi.Text, cbbLoaiPhong.Text, condition, numGia.Value);
                LoadDS(query);
            }
            else if (Sao != 0 && tienIch != "")
            {
                string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ] LIKE '%{0}%' AND [Thể Loại] LIKE '%{1}%' AND [Số Sao] = '{2}' AND ({3}) AND [Giá] <= '{4}'", txtDiaChi.Text, cbbLoaiPhong.Text, Sao, condition, numGia.Value);
                LoadDS(query);
            }
            else if (Sao != 0 && tienIch == "")
            {
                string query = string.Format("SELECT * FROM KhachSan WHERE [Địa chỉ] LIKE '%{0}%' AND [Thể Loại] LIKE '%{1}%' AND [Số Sao] = '{2}' AND [Giá] <= '{3}'", txtDiaChi.Text, cbbLoaiPhong.Text, Sao, numGia.Value);
                LoadDS(query);
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
