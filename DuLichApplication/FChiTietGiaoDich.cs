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
using System.Security.Cryptography;
using System.Collections.Generic; // Để sử dụng ToArray() và Select()
using MiniSoftware;
using MiniExcelLibs.OpenXml;
// Đây là namespace chứa lớp MiniWord
namespace DuLichApplication
{
    public partial class FChiTietGiaoDich : Form
    {
        public string maKS;
        public string tenKhach;
        public string maKhach;
        public string ngayThanhToan;
        public string gioThanhToan;
        public string sdt;
        public string email;
        public int soTien;
        public string dsPhong;
        public string maGiaoDich;
        string tenKS;
        string diaChi;
        string path_template = @"C:\Users\HUY\Desktop\DoAnCuoiKiWin2024\template_TT.docx";
        

        DBFunction fn = new DBFunction();
        public FChiTietGiaoDich(string maKS, string maKhach, string tenKhach, string sdt, string ngayThanhToan, string gioThanhToan, int soTien, string email, string dsPhong, string maGiaoDich)
        {
            InitializeComponent();
            this.maKS = maKS;
            this.tenKhach = tenKhach;
            this.maKhach = maKhach;
            this.ngayThanhToan = ngayThanhToan;
            this.gioThanhToan = gioThanhToan;
            this.sdt = sdt;
            this.email = email;
            this.soTien = soTien;
            this.dsPhong = dsPhong;
            this.maGiaoDich = maGiaoDich;
        }

        private void FChiTietGiaoDich_Load(object sender, EventArgs e)
        {
            this.dsPhong = this.dsPhong.Remove(this.dsPhong.Length - 1);
            string[] listDsPhong = this.dsPhong.Split(",");
            getThongTinKS();
            getThongTinPhong(listDsPhong);
            LoadThongTin();
        }
        public void getThongTinPhong(string[] listDS)
        {
            string listMaPhongString = string.Join(",", listDS.Select(p => "'" + p + "'"));
            string query = string.Format("select * from [Phòng] where [Mã phòng] in ({0}) ", listMaPhongString);
            DataSet ds = fn.getData(query);
            DataTable tb = new DataTable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataColumn colunm in ds.Tables[0].Columns)
                {
                    if (colunm.ColumnName == "Mã phòng" || colunm.ColumnName == "Loại giường" || colunm.ColumnName == "Giá")
                    {
                        tb.Columns.Add(colunm.ColumnName, colunm.DataType);
                    }
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DataRow newRow = tb.NewRow();
                    newRow["Mã phòng"] = row["Mã phòng"];
                    newRow["Loại giường"] = row["Loại giường"];
                    newRow["Giá"] = row["Giá"];
                    tb.Rows.Add(newRow);
                }
                this.dataGridView1.DataSource = tb;
            }
        }
        public void getThongTinKS()
        {
            string query = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", Convert.ToInt32(this.maKS));
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.tenKS = ds.Tables[0].Rows[0]["Tên khách sạn"].ToString();
                this.diaChi = ds.Tables[0].Rows[0]["Địa chỉ"].ToString();
            }
        }
        public void LoadThongTin()
        {
            this.txtTenKhach.Text = this.tenKhach;
            this.txtSDt.Text = this.sdt;
            this.txtEmail.Text = this.email;
            this.txtGiaTien.Text = this.soTien.ToString();
            this.txtNgayThanhToan.Text = this.ngayThanhToan;
            this.txtGioThanhToan.Text = this.gioThanhToan;
            this.txtTenKhachSan.Text = this.tenKS;
            this.txtDiaChi.Text = this.diaChi;
        }
        void Export_Data_To_Word(string filename)
        {
            var config = new OpenXmlConfiguration()
            {
                IgnoreTemplateParameterMissing = false,
            };
            List<Phong> lst_room = new List<Phong>();
            for (int r = 0; r <= dataGridView1.RowCount - 1; r++)
            {
                Phong student = new Phong();
                student.MaPhong = dataGridView1.Rows[r].Cells[0].Value?.ToString() ?? "";
                student.LoaiGiuong = dataGridView1.Rows[r].Cells[1].Value?.ToString() ?? "";
                student.Gia = dataGridView1.Rows[r].Cells[2].Value?.ToString() ?? "";
                lst_room.Add(student);
            }
            var data = lst_room.ToArray();
            var value = new
            {
                Phong = data,
                hoTen = this.txtTenKhach.Text,
                e_mail = this.txtEmail.Text,
                s_dt = this.txtSDt.Text,
                ten_KhachSan = this.txtTenKhachSan.Text,
                dia_Chi = this.txtDiaChi.Text,
                ngay_ThanhToan = this.txtNgayThanhToan.Text,
                gio_ThanhToan = this.txtGioThanhToan.Text,
                gia_Tien = this.txtGiaTien.Text,
            };
             MiniWord.SaveAsByTemplate(filename, path_template, value);
        }
        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.docx";
            savefile.Filter = "DOCX files(.docx)|.docx";

            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                Export_Data_To_Word(savefile.FileName);
                MessageBox.Show("Lưu file thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
