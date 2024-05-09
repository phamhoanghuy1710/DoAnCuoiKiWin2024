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
using System.Collections.Generic;
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
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] pic = ms.ToArray();
                fc.SetDataImage(this.txtUsername, this.txtMatKhau, this.txtHoTen, this.txtChungMinh, this.txtDiaChi, this.txtEmail, this.txtSdt, this.cbbGioiTinh, this.dtNgaySinh, pic, "Thêm thông tin thanh công");
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
        /*
        void Export_Data_To_Word(string filename)
        {
            var config = new OpenXmlConfiguration()
            {
                IgnoreTemplateParameterMissing = false,
            };
            List<Student> lst_Student = new List<Student>();
            for (int r = 0; r <= dataGridView1.RowCount - 1; r++)
            {
                Student student = new Student();
                student.MSSV = dataGridView1.Rows[r].Cells[0].Value.ToString();
                student.Fname = dataGridView1.Rows[r].Cells[1].Value.ToString();
                student.Lname = dataGridView1.Rows[r].Cells[2].Value.ToString();
                student.Dob = (DateTime)dataGridView1.Rows[r].Cells[3].Value;
                student.Dateofbirth = student.Dob.ToString("dd/MM/yyyy");
                student.Gender = dataGridView1.Rows[r].Cells[4].Value.ToString();
                student.Hometown = dataGridView1.Rows[r].Cells[5].Value.ToString();
                student.Address = dataGridView1.Rows[r].Cells[6].Value.ToString();
                student.Phone = dataGridView1.Rows[r].Cells[7].Value.ToString();
                student.Email = dataGridView1.Rows[r].Cells[8].Value.ToString();
                if (dataGridView1.Rows[r].Cells[9].Value is byte[])
                {
                    byte[] pic;
                    pic = (byte[])dataGridView1.Rows[r].Cells[9].Value;
                    student.Strpic = new MiniWordPicture() { Bytes = pic, Width = 80, Height = 80, Extension = "jpg" }; // Đưa dữ liệu kiểu bytes thành ảnh vào word
                }
                student.Monhoc = dataGridView1.Rows[r].Cells[10].Value.ToString();
                lst_Student.Add(student);
            }
            var data = lst_Student.ToArray();
            var value = new
            {
                Student = data,
                tieu_de = "Danh Sách Các Sinh Viên",
                ky_ten = "Trưởng Khoa Công Nghệ Thông Tin",
            };
            MiniWord.SaveAsByTemplate(filename, path_template, value);
        }
        */
        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.docx";
            savefile.Filter = "DOCX files(.docx)|.docx";

            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                //Export_Data_To_Word(savefile.FileName);
                MessageBox.Show("Lưu file thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = "*.docx";
            savefile.Filter = "DOCX files(.docx)|.docx";

            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                //Export_Data_To_Word(savefile.FileName);
                MessageBox.Show("Lưu file thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
