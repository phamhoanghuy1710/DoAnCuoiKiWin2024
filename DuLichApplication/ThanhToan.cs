using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class ThanhToan : Form
    {
        string maKhach;
        string maKS;
        DBFunction fn = new DBFunction();
        string giaGoc;
        List<string> listMaPhong = new List<string> { };
        public ThanhToan(string maKhach, string maKS)
        {
            InitializeComponent();
            this.maKhach = maKhach;
            this.maKS = maKS;
        }
        public void LoadVoucher(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                string vc = ds.Tables[0].Rows[0]["Voucher"].ToString();
                string[] list_vc = vc.Split(",");
                this.cbbVoucher.DataSource = list_vc;
            }
            else
            {
                this.cbbVoucher.Items.Add("0%");
            }
        }
        public void ThanhToan_Load_2(object sender, EventArgs e)
        {
            // Load thông tin voucher
            string query2 = string.Format("select * from KhachHang where TaiKhoan = '{0}'", maKhach);
            DataSet ttKhach = fn.getData(query2);
            LoadVoucher(ttKhach);
            this.cbbHInhThuc.SelectedIndex = 0;
            // Load thong tin khach san
            this.lableTenKS.Text = this.maKS;
            string layTen = string.Format("select * from KhachSan where [Mã khách sạn] = '{0}'", maKS);
            DataSet ks = fn.getData(layTen);
            if (ks.Tables[0].Rows.Count > 0)
            {
                lableTenKS.Text = ks.Tables[0].Rows[0]["Tên khách sạn"].ToString();
                lblDiaChi.Text = ks.Tables[0].Rows[0]["Địa chỉ"].ToString();
            }
            // load gia
            string query = string.Format("select sum([GiaPhong]) as Gia from [DatPhong] where TaiKhoan = '{0}' and [MaKS] = '{1}' and TrangThai = 'No'", maKhach, maKS);
            DataSet ds = fn.getData(query);
            txtGiaGoc.Text = ds.Tables[0].Rows[0]["Gia"].ToString();
            giaGoc = txtGiaGoc.Text;

            // Load thong tin dat phong
            string query3 = string.Format("select * from DatPhong where TaiKhoan = '{0}' and MaKS = '{1}' and TrangThai = 'No'", maKhach, maKS);
            DataSet phong = fn.getData(query3);
            LoadThongTin(ttKhach);
            LoadPhong(phong);
            TinhTienVoiVoucher();
        }
        public void LoadPhong(DataSet ds)
        {
            this.cbbKhachSan.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    listMaPhong.Add(row["MaPhong"].ToString());
                }
            }
        }
        public void LoadThongTin(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtHoTen.Text = ds.Tables[0].Rows[0]["HoTen"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtDienThoai.Text = ds.Tables[0].Rows[0]["Sdt"].ToString();
            }
        }
        public void cbbVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {

            TinhTienVoiVoucher();
        }

        public void TinhTienVoiVoucher ()
        {
            int giamGia;
            if (cbbVoucher.Text == "")
            {
                giamGia = 0;
            }
            else
            {
                string giamGiaString = cbbVoucher.Text;
                giamGiaString = giamGiaString.Remove(giamGiaString.Length - 1);
                giamGia = Convert.ToInt32(giamGiaString);
            };
            // tinh tien
            int tongGia = Convert.ToInt32(giaGoc);
            int giaMoi = tongGia * (100 - giamGia) / 100;
            txtTongGia.Text = giaMoi.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // khi mà ấn dô đây thì tongtien sẽ được cộng vào tổng giá
            if (this.txtMaGiaoDich.Text == "")
            {
                MessageBox.Show("Mã giao dịch không hợp lệ");
            }
            else
            {
                DateTime toDay = DateTime.Now;
                int gio = toDay.Hour;
                int phut = toDay.Minute;
                int giay = toDay.Second;
                string DSMaPhong = "";
                foreach (string item in listMaPhong)
                {
                    DSMaPhong = DSMaPhong + item + ",";
                }
                string time = gio.ToString("00") + ":" + phut.ToString("00") + ":" + giay.ToString("00");
                string query2 = string.Format("INSERT INTO GiaoDich (MaKS, MaKhach, TenKhach, SoDT, NgayThanhToan, SoTien, Email,GioThanhToan,DSMaPhong,MaGiaoDich) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}','{7}','{8}','{9}')",
                    Convert.ToInt32(maKS),
                    maKhach,
                    this.txtHoTen.Text,
                    this.txtDienThoai.Text,
                    toDay.ToString("yyyy-MM-dd HH:mm:ss"), // Đảm bảo định dạng ngày tháng hợp lệ
                    Convert.ToInt32(this.txtTongGia.Text),
                    this.txtEmail.Text,
                    time,
                    DSMaPhong,
                    this.txtMaGiaoDich.Text);

                if (fn.setGiaoDich(query2, "oke", false) == true)
                {
                    // thanh toán xong thì xóa cái đó trong bảng đặt phòng và cập nhật trạng thái o bảng phòng thành NO.

                    string query1 = string.Format("update DatPhong set TrangThai = 'Yes' where  TaiKhoan = '{0}' and MaKS = '{1}'", maKhach, maKS);
                    fn.setData(query1, "Oke", false);
                    if (listMaPhong.Count > 0)
                    {
                        string listMaPhongString = string.Join(",", listMaPhong.Select(p => "'" + p + "'"));
                        string queryx = string.Format("UPDATE [Phòng] SET [Trạng thái] = 'No'  WHERE [Mã khách sạn] = '{0}' AND [Mã phòng] IN ({1})", maKS, listMaPhongString);
                        fn.setData(queryx, "Oke", false);
                    }
                    string query = string.Format("UPDATE KhachHang SET TongChi = TongChi + {0} where TaiKhoan = '{1}' ", Convert.ToInt32(this.txtTongGia.Text), maKhach);
                    fn.setData(query, "Thanh toán thành công", true);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lại thông tin");
                    this.txtMaGiaoDich.Focus();
                }
              
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
