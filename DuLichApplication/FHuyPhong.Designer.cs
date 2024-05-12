namespace DuLichApplication
{
    partial class FHuyPhong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FHuyPhong));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cbbDSKhachSan = new Guna.UI2.WinForms.Guna2ComboBox();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Calibri", 24F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.ForeColor = Color.White;
            guna2HtmlLabel1.Location = new Point(300, 26);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(362, 51);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Hủy các phòng đã đặt";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Location = new Point(55, 92);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(258, 26);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Các khách sạn đang đặt phòng";
            // 
            // cbbDSKhachSan
            // 
            cbbDSKhachSan.BackColor = Color.Transparent;
            cbbDSKhachSan.CustomizableEdges = customizableEdges1;
            cbbDSKhachSan.DrawMode = DrawMode.OwnerDrawFixed;
            cbbDSKhachSan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDSKhachSan.FocusedColor = Color.FromArgb(94, 148, 255);
            cbbDSKhachSan.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbbDSKhachSan.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point);
            cbbDSKhachSan.ForeColor = Color.Black;
            cbbDSKhachSan.ItemHeight = 30;
            cbbDSKhachSan.Location = new Point(55, 124);
            cbbDSKhachSan.Name = "cbbDSKhachSan";
            cbbDSKhachSan.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbbDSKhachSan.Size = new Size(835, 36);
            cbbDSKhachSan.TabIndex = 2;
            cbbDSKhachSan.SelectedIndexChanged += cbbDSKhachSan_SelectedIndexChanged;
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Calibri", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel3.ForeColor = Color.White;
            guna2HtmlLabel3.Location = new Point(321, 191);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(293, 35);
            guna2HtmlLabel3.TabIndex = 3;
            guna2HtmlLabel3.Text = "Danh sách các bảng phòng ";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(55, 232);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(835, 336);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
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
            btnExit.Location = new Point(862, 26);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(60, 45);
            btnExit.TabIndex = 28;
            btnExit.Click += btnExit_Click;
            // 
            // FHuyPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(949, 580);
            Controls.Add(btnExit);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(cbbDSKhachSan);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            ForeColor = Color.SteelBlue;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FHuyPhong";
            Text = "FHuyPhong";
            Load += FHuyPhong_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2ComboBox cbbDSKhachSan;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
    }
}