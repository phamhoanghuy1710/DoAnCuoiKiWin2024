namespace DuLichApplication
{
    partial class FThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FThongBao));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dtNgayThongBao = new Guna.UI2.WinForms.Guna2DateTimePicker();
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
            guna2HtmlLabel1.Location = new Point(318, 38);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(366, 51);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Thông Báo Hằng Ngày";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Calibri", 18F, FontStyle.Italic, GraphicsUnit.Point);
            guna2HtmlLabel2.ForeColor = Color.White;
            guna2HtmlLabel2.Location = new Point(250, 135);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(200, 39);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Ngày Thông Báo";
            // 
            // dtNgayThongBao
            // 
            dtNgayThongBao.BorderRadius = 10;
            dtNgayThongBao.Checked = true;
            dtNgayThongBao.CustomizableEdges = customizableEdges1;
            dtNgayThongBao.FillColor = Color.White;
            dtNgayThongBao.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dtNgayThongBao.Format = DateTimePickerFormat.Long;
            dtNgayThongBao.Location = new Point(499, 135);
            dtNgayThongBao.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtNgayThongBao.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtNgayThongBao.Name = "dtNgayThongBao";
            dtNgayThongBao.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtNgayThongBao.Size = new Size(250, 45);
            dtNgayThongBao.TabIndex = 2;
            dtNgayThongBao.Value = new DateTime(2024, 5, 9, 9, 38, 1, 972);
            dtNgayThongBao.ValueChanged += dtNgayThongBao_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(59, 212);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(849, 409);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.BorderColor = Color.Transparent;
            btnExit.CustomBorderColor = Color.Transparent;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.Transparent;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnExit.ForeColor = Color.Transparent;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageSize = new Size(30, 30);
            btnExit.Location = new Point(895, 12);
            btnExit.Name = "btnExit";
            btnExit.PressedColor = Color.Transparent;
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges3;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(69, 64);
            btnExit.TabIndex = 56;
            btnExit.Click += btnExit_Click;
            // 
            // FThongBao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(976, 645);
            Controls.Add(btnExit);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dtNgayThongBao);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FThongBao";
            Text = "FThongBao";
            Load += FThongBao_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtNgayThongBao;
        private FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
    }
}