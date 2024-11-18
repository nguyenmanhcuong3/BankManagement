namespace BankManagement
{
    partial class Khach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Khach));
            this.panel1 = new System.Windows.Forms.Panel();
            this.plDiChuyen = new System.Windows.Forms.Panel();
            this.pcExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnVayVon = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThongTin = new System.Windows.Forms.Button();
            this.btnGiaoDich = new System.Windows.Forms.Button();
            this.btnTietKiem = new System.Windows.Forms.Button();
            this.pictureBoxKhach = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKhach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.plDiChuyen);
            this.panel1.Controls.Add(this.pcExit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1257, 160);
            this.panel1.TabIndex = 1;
            // 
            // plDiChuyen
            // 
            this.plDiChuyen.Dock = System.Windows.Forms.DockStyle.Top;
            this.plDiChuyen.Location = new System.Drawing.Point(0, 0);
            this.plDiChuyen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plDiChuyen.Name = "plDiChuyen";
            this.plDiChuyen.Size = new System.Drawing.Size(1257, 49);
            this.plDiChuyen.TabIndex = 34;
            this.plDiChuyen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plDiChuyen_MouseDown);
            this.plDiChuyen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.plDiChuyen_MouseMove);
            this.plDiChuyen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.plDiChuyen_MouseUp);
            // 
            // pcExit
            // 
            this.pcExit.Image = ((System.Drawing.Image)(resources.GetObject("pcExit.Image")));
            this.pcExit.Location = new System.Drawing.Point(1212, 0);
            this.pcExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pcExit.Name = "pcExit";
            this.pcExit.Size = new System.Drawing.Size(45, 49);
            this.pcExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcExit.TabIndex = 27;
            this.pcExit.TabStop = false;
            this.pcExit.Click += new System.EventHandler(this.pcExit_Click);
            this.pcExit.MouseEnter += new System.EventHandler(this.pcExit_MouseEnter);
            this.pcExit.MouseLeave += new System.EventHandler(this.pcExit_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bank Management";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.btnVayVon);
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnThongTin);
            this.panel2.Controls.Add(this.btnGiaoDich);
            this.panel2.Controls.Add(this.btnTietKiem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 663);
            this.panel2.TabIndex = 2;
            // 
            // btnVayVon
            // 
            this.btnVayVon.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVayVon.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnVayVon.Location = new System.Drawing.Point(10, 300);
            this.btnVayVon.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnVayVon.Name = "btnVayVon";
            this.btnVayVon.Size = new System.Drawing.Size(172, 62);
            this.btnVayVon.TabIndex = 10;
            this.btnVayVon.Text = "Vay vốn";
            this.btnVayVon.UseVisualStyleBackColor = false;
            this.btnVayVon.Click += new System.EventHandler(this.btnVayVon_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLogin.Location = new System.Drawing.Point(14, 386);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(172, 54);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Đăng xuất";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.button1.Location = new System.Drawing.Point(10, 468);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 54);
            this.button1.TabIndex = 9;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThongTin
            // 
            this.btnThongTin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnThongTin.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnThongTin.Location = new System.Drawing.Point(10, 35);
            this.btnThongTin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(172, 62);
            this.btnThongTin.TabIndex = 7;
            this.btnThongTin.Text = "Thông tin";
            this.btnThongTin.UseVisualStyleBackColor = false;
            this.btnThongTin.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnGiaoDich
            // 
            this.btnGiaoDich.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGiaoDich.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnGiaoDich.Location = new System.Drawing.Point(10, 123);
            this.btnGiaoDich.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnGiaoDich.Name = "btnGiaoDich";
            this.btnGiaoDich.Size = new System.Drawing.Size(172, 62);
            this.btnGiaoDich.TabIndex = 4;
            this.btnGiaoDich.Text = "Giao dịch";
            this.btnGiaoDich.UseVisualStyleBackColor = false;
            this.btnGiaoDich.Click += new System.EventHandler(this.btnGiaoDich_Click);
            // 
            // btnTietKiem
            // 
            this.btnTietKiem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnTietKiem.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnTietKiem.Location = new System.Drawing.Point(10, 214);
            this.btnTietKiem.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTietKiem.Name = "btnTietKiem";
            this.btnTietKiem.Size = new System.Drawing.Size(172, 62);
            this.btnTietKiem.TabIndex = 3;
            this.btnTietKiem.Text = "Tiết kiệm";
            this.btnTietKiem.UseVisualStyleBackColor = false;
            this.btnTietKiem.Click += new System.EventHandler(this.btnTietKiem_Click);
            // 
            // pictureBoxKhach
            // 
            this.pictureBoxKhach.Location = new System.Drawing.Point(189, 160);
            this.pictureBoxKhach.Name = "pictureBoxKhach";
            this.pictureBoxKhach.Size = new System.Drawing.Size(1068, 663);
            this.pictureBoxKhach.TabIndex = 3;
            this.pictureBoxKhach.TabStop = false;
            // 
            // Khach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1257, 823);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxKhach);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Khach";
            this.Text = "Khach";
            this.Load += new System.EventHandler(this.Khach_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKhach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plDiChuyen;
        private System.Windows.Forms.PictureBox pcExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnThongTin;
        private System.Windows.Forms.Button btnGiaoDich;
        private System.Windows.Forms.Button btnTietKiem;
        private System.Windows.Forms.Button btnVayVon;
        private System.Windows.Forms.PictureBox pictureBoxKhach;
    }
}