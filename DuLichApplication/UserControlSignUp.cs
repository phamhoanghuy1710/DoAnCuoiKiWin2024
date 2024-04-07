using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
namespace DuLichApplication
{
    public partial class UserControlSignUp : UserControl
    {
        DBFunction fc = new DBFunction();
        string query;
        string imagePath;
        public UserControlSignUp()
        {
            InitializeComponent();
            this.cbbVaiTro.SelectedIndex = 0;   
        }    

        private void btnNhapTT_Click(object sender, EventArgs e)
        {
            if (CheckData.KiemTraTaiKhoan(txtUsername, txtMatKhau) == true && CheckData.KiemTraDuLieu(txtHoTen, txtDiaChi, txtChungMinh, txtEmail, txtSdt, dtNgaySinh) == true)
            {
                // load ảnh 
                MemoryStream  ms = new MemoryStream();
                pictureBox1.Image.Save (ms,System.Drawing.Imaging.ImageFormat.Png);
                byte[] pic = ms.ToArray(); 
                fc.SetDataImage (this.txtUsername,this.txtMatKhau,this.txtHoTen,this.txtChungMinh,this.txtDiaChi,this.txtEmail,this.txtSdt,this.cbbGioiTinh,this.dtNgaySinh,pic, "Thêm thông tin thanh công");
            }
        }

        private void btnThayAnh_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Lấy đường dẫn của hình ảnh được chọn
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        string FileName = openFileDialog.FileName;
                        imagePath = FileName;
                        if (myStream.Length > 512000)
                        {
                            MessageBox.Show("Hinh qua kich thuoc");
                        }
                        else
                        {
                            pictureBox1.Load(FileName);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
       
    }
}
