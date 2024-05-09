namespace DuLichApplication
{
    partial class FChonDichVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelDuoi = new Panel();
            DachSachDaChon = new FlowLayoutPanel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            DanhSachDichVu = new FlowLayoutPanel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            DanhSachPhong = new FlowLayoutPanel();
            panelDuoi.SuspendLayout();
            SuspendLayout();
            // 
            // panelDuoi
            // 
            panelDuoi.Controls.Add(DachSachDaChon);
            panelDuoi.Controls.Add(guna2HtmlLabel2);
            panelDuoi.Controls.Add(guna2HtmlLabel1);
            panelDuoi.Controls.Add(DanhSachDichVu);
            panelDuoi.Location = new Point(2, 304);
            panelDuoi.Name = "panelDuoi";
            panelDuoi.Size = new Size(1570, 601);
            panelDuoi.TabIndex = 0;
            panelDuoi.Visible = false;
            // 
            // DachSachDaChon
            // 
            DachSachDaChon.Location = new Point(841, 66);
            DachSachDaChon.Name = "DachSachDaChon";
            DachSachDaChon.Size = new Size(701, 508);
            DachSachDaChon.TabIndex = 3;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(864, 24);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(109, 22);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Dịch vụ đã chọn";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Location = new Point(23, 24);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(122, 22);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Danh sách dịch vụ";
            // 
            // DanhSachDichVu
            // 
            DanhSachDichVu.Location = new Point(12, 66);
            DanhSachDichVu.Name = "DanhSachDichVu";
            DanhSachDichVu.Size = new Size(786, 508);
            DanhSachDichVu.TabIndex = 0;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Location = new Point(12, 12);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(177, 22);
            guna2HtmlLabel3.TabIndex = 2;
            guna2HtmlLabel3.Text = "Danh Sách Phòng Của Bạn";
            // 
            // DanhSachPhong
            // 
            DanhSachPhong.AutoScroll = true;
            DanhSachPhong.Location = new Point(12, 40);
            DanhSachPhong.Name = "DanhSachPhong";
            DanhSachPhong.Size = new Size(804, 239);
            DanhSachPhong.TabIndex = 3;
            // 
            // FChonDichVu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1598, 886);
            Controls.Add(DanhSachPhong);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(panelDuoi);
            Name = "FChonDichVu";
            Text = "FChonDichVu";
            Load += FChonDichVu_Load;
            panelDuoi.ResumeLayout(false);
            panelDuoi.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelDuoi;
        private FlowLayoutPanel DanhSachDichVu;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private FlowLayoutPanel DachSachDaChon;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private FlowLayoutPanel DanhSachPhong;
    }
}