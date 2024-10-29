namespace BankManagement
{
    partial class DangKi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangKi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.LinkLabel();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.txtMaNv = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.btnDangKi = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtNhapTk = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtNhapLaiMk = new System.Windows.Forms.TextBox();
            this.txtNhapMk = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbNhapMkMo = new System.Windows.Forms.PictureBox();
            this.pbNhapLaiMkMo = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhapMkMo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhapLaiMkMo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.pbNhapLaiMkMo);
            this.panel1.Controls.Add(this.pbNhapMkMo);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.txtMaNv);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.btnDangKi);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.txtNhapTk);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.txtNhapLaiMk);
            this.panel1.Controls.Add(this.txtNhapMk);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(324, 74);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 389);
            this.panel1.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.AutoSize = true;
            this.btnThoat.Location = new System.Drawing.Point(298, 362);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(35, 13);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.TabStop = true;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnThoat_LinkClicked);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.Blue;
            this.btnDangNhap.Location = new System.Drawing.Point(129, 326);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(205, 33);
            this.btnDangNhap.TabIndex = 16;
            this.btnDangNhap.Text = "Đăng nhâp (đã có tài khoản)";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // txtMaNv
            // 
            this.txtMaNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNv.Location = new System.Drawing.Point(51, 144);
            this.txtMaNv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaNv.Multiline = true;
            this.txtMaNv.Name = "txtMaNv";
            this.txtMaNv.Size = new System.Drawing.Size(283, 33);
            this.txtMaNv.TabIndex = 15;
            this.txtMaNv.Enter += new System.EventHandler(this.txtMaNv_Enter);
            this.txtMaNv.Leave += new System.EventHandler(this.txtMaNv_Leave);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(17, 144);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(30, 32);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 14;
            this.pictureBox7.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(123, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 40);
            this.label1.TabIndex = 13;
            this.label1.Text = "Đăng kí";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(304, 240);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(29, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // btnDangKi
            // 
            this.btnDangKi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKi.ForeColor = System.Drawing.Color.Blue;
            this.btnDangKi.Location = new System.Drawing.Point(30, 326);
            this.btnDangKi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDangKi.Name = "btnDangKi";
            this.btnDangKi.Size = new System.Drawing.Size(95, 33);
            this.btnDangKi.TabIndex = 11;
            this.btnDangKi.Text = "Đăng kí";
            this.btnDangKi.UseVisualStyleBackColor = true;
            this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::BankManagement.Properties.Resources.Icons8_Windows_8_Security_Password_2;
            this.pictureBox5.Location = new System.Drawing.Point(17, 286);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // txtNhapTk
            // 
            this.txtNhapTk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapTk.Location = new System.Drawing.Point(51, 188);
            this.txtNhapTk.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNhapTk.Multiline = true;
            this.txtNhapTk.Name = "txtNhapTk";
            this.txtNhapTk.Size = new System.Drawing.Size(283, 33);
            this.txtNhapTk.TabIndex = 9;
            this.txtNhapTk.Enter += new System.EventHandler(this.txtNhapTk_Enter);
            this.txtNhapTk.Leave += new System.EventHandler(this.TxtNhapTk_Leave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(304, 287);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // txtNhapLaiMk
            // 
            this.txtNhapLaiMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapLaiMk.Location = new System.Drawing.Point(51, 287);
            this.txtNhapLaiMk.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNhapLaiMk.Multiline = true;
            this.txtNhapLaiMk.Name = "txtNhapLaiMk";
            this.txtNhapLaiMk.Size = new System.Drawing.Size(283, 33);
            this.txtNhapLaiMk.TabIndex = 7;
            this.txtNhapLaiMk.Enter += new System.EventHandler(this.txtNhapLaiMk_Enter);
            this.txtNhapLaiMk.Leave += new System.EventHandler(this.txtNhapLaiMk_Leave);
            // 
            // txtNhapMk
            // 
            this.txtNhapMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhapMk.Location = new System.Drawing.Point(51, 240);
            this.txtNhapMk.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNhapMk.Multiline = true;
            this.txtNhapMk.Name = "txtNhapMk";
            this.txtNhapMk.Size = new System.Drawing.Size(283, 33);
            this.txtNhapMk.TabIndex = 6;
            this.txtNhapMk.Enter += new System.EventHandler(this.txtNhapMk_Enter_1);
            this.txtNhapMk.Leave += new System.EventHandler(this.txtNhapMk_Leave_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::BankManagement.Properties.Resources.Icons8_Windows_8_Security_Password_2;
            this.pictureBox3.Location = new System.Drawing.Point(17, 241);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BankManagement.Properties.Resources.user_icon_150670;
            this.pictureBox2.Location = new System.Drawing.Point(17, 188);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BankManagement.Properties.Resources._0af3c9613761d2d2394d99312aeba397;
            this.pictureBox1.Location = new System.Drawing.Point(121, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbNhapMkMo
            // 
            this.pbNhapMkMo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbNhapMkMo.Image = ((System.Drawing.Image)(resources.GetObject("pbNhapMkMo.Image")));
            this.pbNhapMkMo.Location = new System.Drawing.Point(304, 240);
            this.pbNhapMkMo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbNhapMkMo.Name = "pbNhapMkMo";
            this.pbNhapMkMo.Size = new System.Drawing.Size(29, 32);
            this.pbNhapMkMo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNhapMkMo.TabIndex = 18;
            this.pbNhapMkMo.TabStop = false;
            this.pbNhapMkMo.Click += new System.EventHandler(this.pbNhapMkMo_Click);
            // 
            // pbNhapLaiMkMo
            // 
            this.pbNhapLaiMkMo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbNhapLaiMkMo.Image = ((System.Drawing.Image)(resources.GetObject("pbNhapLaiMkMo.Image")));
            this.pbNhapLaiMkMo.Location = new System.Drawing.Point(304, 286);
            this.pbNhapLaiMkMo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbNhapLaiMkMo.Name = "pbNhapLaiMkMo";
            this.pbNhapLaiMkMo.Size = new System.Drawing.Size(29, 32);
            this.pbNhapLaiMkMo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNhapLaiMkMo.TabIndex = 19;
            this.pbNhapLaiMkMo.TabStop = false;
            this.pbNhapLaiMkMo.Click += new System.EventHandler(this.pbNhapLaiMkMo_Click);
            // 
            // DangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BankManagement.Properties.Resources.pngtree_business_finance_rising_stock_market_dollar_sign_background_image_906548;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(961, 637);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DangKi";
            this.Text = "DangKi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DangKi_Load);
            this.Resize += new System.EventHandler(this.DangKi_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhapMkMo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNhapLaiMkMo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtNhapMk;
        private System.Windows.Forms.TextBox txtNhapLaiMk;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.TextBox txtNhapTk;
        private System.Windows.Forms.Button btnDangKi;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNv;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.LinkLabel btnThoat;
        private System.Windows.Forms.PictureBox pbNhapMkMo;
        private System.Windows.Forms.PictureBox pbNhapLaiMkMo;
    }
}