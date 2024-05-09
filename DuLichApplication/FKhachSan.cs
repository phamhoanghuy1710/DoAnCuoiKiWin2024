using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuLichApplication
{
    public partial class FKhachSan : Form
    {
        public FKhachSan()
        {
            InitializeComponent();
        }

        private void FKhachSan_Load(object sender, EventArgs e)
        {
            this.uc_KhachSan1.Visible = true;
            this.uC_UuDai1.Visible = false;
            btnThemKhachSan.PerformClick();
        }

        private void btnThemKhachSan_Click(object sender, EventArgs e)
        {
            this.panelMoving.Left = this.btnThemKhachSan.Left + 20;
            this.uc_KhachSan1.Visible = true;
            this.uc_KhachSan1.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void uc_KhachSan1_Load(object sender, EventArgs e)
        {

        }

        private void panelMoving_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.panelMoving.Left = this.btnUuDai.Left + 20;
            this.uC_UuDai1.Visible = true;
            this.uC_UuDai1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FDichVu form = new FDichVu();
            form.ShowDialog();
        }
    }
}
