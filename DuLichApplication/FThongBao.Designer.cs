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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            dtNgayThongBao = new Guna.UI2.WinForms.Guna2DateTimePicker();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            guna2HtmlLabel1.Location = new Point(363, 31);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(292, 39);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Thông Báo Hằng Ngày";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(48, 91);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(114, 22);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Ngày Thông Báo";
            // 
            // dtNgayThongBao
            // 
            dtNgayThongBao.Checked = true;
            dtNgayThongBao.CustomizableEdges = customizableEdges1;
            dtNgayThongBao.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dtNgayThongBao.Format = DateTimePickerFormat.Long;
            dtNgayThongBao.Location = new Point(48, 129);
            dtNgayThongBao.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtNgayThongBao.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtNgayThongBao.Name = "dtNgayThongBao";
            dtNgayThongBao.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtNgayThongBao.Size = new Size(250, 45);
            dtNgayThongBao.TabIndex = 2;
            dtNgayThongBao.Value = new DateTime(2024, 5, 9, 9, 38, 1, 972);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.AppWorkspace;
            flowLayoutPanel1.Location = new Point(77, 212);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(787, 409);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // FThongBao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 645);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dtNgayThongBao);
            Controls.Add(guna2HtmlLabel2);
            Controls.Add(guna2HtmlLabel1);
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
    }
}