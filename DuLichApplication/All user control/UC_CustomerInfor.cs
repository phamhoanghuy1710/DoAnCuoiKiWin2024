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

namespace DuLichApplication.All_user_control
{
    public partial class UC_CustomerInfor : UserControl
    {
        public bool isButonLuuClicked = false;

        public UC_CustomerInfor()
        {
            InitializeComponent();

        }



        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            txtHoTen.Focus();
            btnLuu.Visible = true;
            isButonLuuClicked = false;
            foreach (Control txtBox in this.Controls)
            {
                if (txtBox is Guna2TextBox)
                {
                    Guna2TextBox txt = (Guna2TextBox)txtBox;
                    txt.ReadOnly = false;
                }
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            isButonLuuClicked = true;
            foreach (Control txtBox in this.Controls)
            {
                if (txtBox is Guna2TextBox)
                {
                    Guna2TextBox txt = (Guna2TextBox)txtBox;
                    txt.ReadOnly = true;
                }
            }
        }
    }
}
