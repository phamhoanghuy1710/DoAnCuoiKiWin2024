namespace DuLichApplication
{
    partial class FPhong
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPhong));
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            btnReload = new Guna.UI2.WinForms.Guna2Button();
            uC_ChonPhong1 = new All_user_control.UC_ChonPhong();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.Controls.Add(btnReload);
            guna2Panel1.Controls.Add(uC_ChonPhong1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Location = new Point(44, 104);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(1831, 882);
            guna2Panel1.TabIndex = 0;
            // 
            // btnReload
            // 
            btnReload.BorderRadius = 10;
            btnReload.CustomizableEdges = customizableEdges1;
            btnReload.DisabledState.BorderColor = Color.DarkGray;
            btnReload.DisabledState.CustomBorderColor = Color.DarkGray;
            btnReload.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnReload.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnReload.FillColor = Color.White;
            btnReload.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnReload.ForeColor = Color.Black;
            btnReload.Location = new Point(890, 63);
            btnReload.Name = "btnReload";
            btnReload.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnReload.Size = new Size(225, 56);
            btnReload.TabIndex = 1;
            btnReload.Text = "ReLoad";
            btnReload.Click += btnReload_Click;
            // 
            // uC_ChonPhong1
            // 
            uC_ChonPhong1.BackColor = Color.Transparent;
            uC_ChonPhong1.Location = new Point(3, 36);
            uC_ChonPhong1.Name = "uC_ChonPhong1";
            uC_ChonPhong1.Size = new Size(1800, 880);
            uC_ChonPhong1.TabIndex = 0;
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
            btnExit.Location = new Point(1833, 12);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges5;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(79, 49);
            btnExit.TabIndex = 1;
            btnExit.Click += btnExit_Click;
            // 
            // FPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1055);
            Controls.Add(btnExit);
            Controls.Add(guna2Panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FPhong";
            WindowState = FormWindowState.Maximized;
            Load += FPhong_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private All_user_control.UC_ChonPhong uC_ChonPhong1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private Guna.UI2.WinForms.Guna2Button btnReload;
    }
}