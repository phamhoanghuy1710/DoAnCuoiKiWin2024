namespace DuLichApplication
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnExit = new Guna.UI2.WinForms.Guna2CircleButton();
            panel2 = new Panel();
            userControlSignUp1 = new UserControlSignUp();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel2.SuspendLayout();
            SuspendLayout();
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
            btnExit.Location = new Point(1852, 12);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnExit.Size = new Size(78, 64);
            btnExit.TabIndex = 1;
            btnExit.Click += btnExit_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(userControlSignUp1);
            panel2.Location = new Point(13, 122);
            panel2.Name = "panel2";
            panel2.Size = new Size(1899, 853);
            panel2.TabIndex = 4;
            // 
            // userControlSignUp1
            // 
            userControlSignUp1.BackColor = Color.Transparent;
            userControlSignUp1.Location = new Point(3, 3);
            userControlSignUp1.Name = "userControlSignUp1";
            userControlSignUp1.Size = new Size(1891, 873);
            userControlSignUp1.TabIndex = 0;
            userControlSignUp1.Load += userControlSignUp1_Load;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 30;
            guna2Elipse1.TargetControl = this;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(132, 122, 255);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1942, 1100);
            Controls.Add(panel2);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUp";
            WindowState = FormWindowState.Maximized;
            Load += SignUp_Load;
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton btnExit;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private UserControlSignUp userControlSignUp1;
    }
}