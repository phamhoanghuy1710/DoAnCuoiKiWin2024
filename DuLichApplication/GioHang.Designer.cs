namespace DuLichApplication
{
    partial class GioHang
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GioHang));
            flowPanelPhong = new FlowLayoutPanel();
            btnThanhToan = new Guna.UI2.WinForms.Guna2Button();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            SuspendLayout();
            // 
            // flowPanelPhong
            // 
            flowPanelPhong.AutoScroll = true;
            flowPanelPhong.BackColor = Color.Transparent;
            flowPanelPhong.Location = new Point(38, 94);
            flowPanelPhong.Name = "flowPanelPhong";
            flowPanelPhong.Size = new Size(859, 379);
            flowPanelPhong.TabIndex = 0;
            // 
            // btnThanhToan
            // 
            btnThanhToan.BackColor = Color.Transparent;
            btnThanhToan.BorderRadius = 20;
            btnThanhToan.CustomizableEdges = customizableEdges1;
            btnThanhToan.DisabledState.BorderColor = Color.DarkGray;
            btnThanhToan.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThanhToan.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThanhToan.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThanhToan.FillColor = Color.White;
            btnThanhToan.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnThanhToan.ForeColor = Color.Black;
            btnThanhToan.Location = new Point(630, 509);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnThanhToan.Size = new Size(164, 56);
            btnThanhToan.TabIndex = 1;
            btnThanhToan.Text = "Đặt ngay";
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // guna2Button1
            // 
            guna2Button1.BackColor = Color.Transparent;
            guna2Button1.BorderRadius = 20;
            guna2Button1.CustomizableEdges = customizableEdges3;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.White;
            guna2Button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            guna2Button1.ForeColor = Color.Black;
            guna2Button1.Location = new Point(150, 509);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Button1.Size = new Size(180, 56);
            guna2Button1.TabIndex = 2;
            guna2Button1.Text = "Cập nhật";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 30;
            guna2Elipse1.TargetControl = this;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.Transparent;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageSize = new Size(35, 35);
            btnExit.Location = new Point(856, 21);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(60, 45);
            btnExit.TabIndex = 3;
            btnExit.Click += btnExit_Click_1;
            // 
            // GioHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(939, 597);
            Controls.Add(btnExit);
            Controls.Add(guna2Button1);
            Controls.Add(btnThanhToan);
            Controls.Add(flowPanelPhong);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Location = new Point(452, 232);
            Name = "GioHang";
            Text = "GioHang";
            TransparencyKey = Color.IndianRed;
            Load += GioHang_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowPanelPhong;
        private Guna.UI2.WinForms.Guna2Button btnThanhToan;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
    }
}