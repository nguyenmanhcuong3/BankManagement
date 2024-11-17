namespace BankManagement
{
    partial class KhachGiaoDich
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtChuTaiKhoanNhan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaiKhoanGui = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.dateNgayGiaoDich = new System.Windows.Forms.DateTimePicker();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnGiaoDichMoi = new System.Windows.Forms.Button();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtMaGiaoDich = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.txtChuTaiKhoanNhan);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTaiKhoanGui);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dgvGiaoDich);
            this.panel2.Controls.Add(this.dateNgayGiaoDich);
            this.panel2.Controls.Add(this.btnXuatExcel);
            this.panel2.Controls.Add(this.btnXacNhan);
            this.panel2.Controls.Add(this.btnGiaoDichMoi);
            this.panel2.Controls.Add(this.txtSoTien);
            this.panel2.Controls.Add(this.txtMaGiaoDich);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 450);
            this.panel2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(487, 71);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 24);
            this.comboBox1.TabIndex = 31;
            // 
            // txtChuTaiKhoanNhan
            // 
            this.txtChuTaiKhoanNhan.Location = new System.Drawing.Point(487, 128);
            this.txtChuTaiKhoanNhan.Name = "txtChuTaiKhoanNhan";
            this.txtChuTaiKhoanNhan.Size = new System.Drawing.Size(171, 22);
            this.txtChuTaiKhoanNhan.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Chủ tài khoản";
            // 
            // txtTaiKhoanGui
            // 
            this.txtTaiKhoanGui.Location = new System.Drawing.Point(128, 77);
            this.txtTaiKhoanGui.Name = "txtTaiKhoanGui";
            this.txtTaiKhoanGui.Size = new System.Drawing.Size(175, 22);
            this.txtTaiKhoanGui.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tài khoản nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Tài khoản gửi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Lịch sử giao dịch";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.Location = new System.Drawing.Point(-2, 274);
            this.dgvGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.Size = new System.Drawing.Size(726, 189);
            this.dgvGiaoDich.TabIndex = 2;
            // 
            // dateNgayGiaoDich
            // 
            this.dateNgayGiaoDich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayGiaoDich.Location = new System.Drawing.Point(487, 27);
            this.dateNgayGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateNgayGiaoDich.Name = "dateNgayGiaoDich";
            this.dateNgayGiaoDich.Size = new System.Drawing.Size(171, 22);
            this.dateNgayGiaoDich.TabIndex = 19;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXuatExcel.Location = new System.Drawing.Point(487, 197);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(92, 28);
            this.btnXuatExcel.TabIndex = 16;
            this.btnXuatExcel.Text = "Sao kê";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXacNhan.Location = new System.Drawing.Point(309, 197);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(92, 28);
            this.btnXacNhan.TabIndex = 15;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnGiaoDichMoi
            // 
            this.btnGiaoDichMoi.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnGiaoDichMoi.Location = new System.Drawing.Point(128, 197);
            this.btnGiaoDichMoi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGiaoDichMoi.Name = "btnGiaoDichMoi";
            this.btnGiaoDichMoi.Size = new System.Drawing.Size(109, 28);
            this.btnGiaoDichMoi.TabIndex = 13;
            this.btnGiaoDichMoi.Text = "Giao dịch mới";
            this.btnGiaoDichMoi.UseVisualStyleBackColor = true;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(128, 131);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(175, 22);
            this.txtSoTien.TabIndex = 10;
            // 
            // txtMaGiaoDich
            // 
            this.txtMaGiaoDich.Location = new System.Drawing.Point(128, 27);
            this.txtMaGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaGiaoDich.Name = "txtMaGiaoDich";
            this.txtMaGiaoDich.Size = new System.Drawing.Size(175, 22);
            this.txtMaGiaoDich.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 134);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã  giao dịch :";
            // 
            // KhachGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.panel2);
            this.Name = "KhachGiaoDich";
            this.Text = "KhachGiaoDich";
            this.Load += new System.EventHandler(this.KhachGiaoDich_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.DateTimePicker dateNgayGiaoDich;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnGiaoDichMoi;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtMaGiaoDich;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaiKhoanGui;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChuTaiKhoanNhan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}