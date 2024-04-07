using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DuLichApplication
{
    public partial class Form1 : Form
    {
        DBFunction fn = new DBFunction();
        string query;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLognin_Click(object sender, EventArgs e)
        {
            query = string.Format("select TaiKhoan,MatKhau from KhachHang where TaiKhoan ='{0}' and MatKhau = '{1}'", txtUsername.Text, txtPassword.Text);
            DataSet ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblError.Visible = false;
                Form2 form2 = new Form2(ds);
                this.Hide();
                form2.Show();
            }
            else
            {
                lblError.Visible = true;
                txtPassword.Clear();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SignUp sp = new SignUp();
           // this.Hide();
            sp.Show();
        }
    }
}