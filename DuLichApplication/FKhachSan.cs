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
    }
}
