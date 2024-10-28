namespace BankManagement
{
    partial class GiaoDich
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateNgayGiaoDich = new System.Windows.Forms.DateTimePicker();
            this.cbbLoaiGiaoDich = new System.Windows.Forms.ComboBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGiaoDichMoi = new System.Windows.Forms.Button();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtMaGiaoDich = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 100);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(510, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giao dịch";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.dateNgayGiaoDich);
            this.panel2.Controls.Add(this.cbbLoaiGiaoDich);
            this.panel2.Controls.Add(this.btnXuatExcel);
            this.panel2.Controls.Add(this.btnXacNhan);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnGiaoDichMoi);
            this.panel2.Controls.Add(this.txtNhanVien);
            this.panel2.Controls.Add(this.txtSoTien);
            this.panel2.Controls.Add(this.txtMaKhachHang);
            this.panel2.Controls.Add(this.txtTenKhachHang);
            this.panel2.Controls.Add(this.txtMaGiaoDich);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1258, 405);
            this.panel2.TabIndex = 1;
            // 
            // dateNgayGiaoDich
            // 
            this.dateNgayGiaoDich.Location = new System.Drawing.Point(821, 105);
            this.dateNgayGiaoDich.Name = "dateNgayGiaoDich";
            this.dateNgayGiaoDich.Size = new System.Drawing.Size(200, 22);
            this.dateNgayGiaoDich.TabIndex = 19;
            // 
            // cbbLoaiGiaoDich
            // 
            this.cbbLoaiGiaoDich.FormattingEnabled = true;
            this.cbbLoaiGiaoDich.Location = new System.Drawing.Point(171, 235);
            this.cbbLoaiGiaoDich.Name = "cbbLoaiGiaoDich";
            this.cbbLoaiGiaoDich.Size = new System.Drawing.Size(232, 24);
            this.cbbLoaiGiaoDich.TabIndex = 18;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(984, 328);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(141, 58);
            this.btnXuatExcel.TabIndex = 16;
            this.btnXuatExcel.Text = "Xuất ra file excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatRaExcel_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(678, 328);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(139, 58);
            this.btnXacNhan.TabIndex = 15;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(376, 328);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(145, 58);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGiaoDichMoi
            // 
            this.btnGiaoDichMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaoDichMoi.Location = new System.Drawing.Point(77, 328);
            this.btnGiaoDichMoi.Name = "btnGiaoDichMoi";
            this.btnGiaoDichMoi.Size = new System.Drawing.Size(136, 58);
            this.btnGiaoDichMoi.TabIndex = 13;
            this.btnGiaoDichMoi.Text = "Giao dịch mới";
            this.btnGiaoDichMoi.UseVisualStyleBackColor = true;
            this.btnGiaoDichMoi.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(824, 50);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(197, 22);
            this.txtSoTien.TabIndex = 10;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(171, 111);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(232, 22);
            this.txtMaKhachHang.TabIndex = 9;
            this.txtMaKhachHang.TextChanged += new System.EventHandler(this.txtMaKhachHang_TextChanged);
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(171, 171);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(232, 22);
            this.txtTenKhachHang.TabIndex = 8;
            // 
            // txtMaGiaoDich
            // 
            this.txtMaGiaoDich.Location = new System.Drawing.Point(171, 46);
            this.txtMaGiaoDich.Name = "txtMaGiaoDich";
            this.txtMaGiaoDich.Size = new System.Drawing.Size(232, 22);
            this.txtMaGiaoDich.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(629, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nhân viên thực hiện :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian giao dịch :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(630, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền giao dịch :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã khách hàng :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên khách hàng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại giao dịch :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã  giao dịch :";
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.Location = new System.Drawing.Point(12, 512);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.Size = new System.Drawing.Size(1258, 206);
            this.dgvGiaoDich.TabIndex = 2;
            this.dgvGiaoDich.Click += new System.EventHandler(this.dgvGiaoDich_Click);
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Location = new System.Drawing.Point(824, 168);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(197, 22);
            this.txtNhanVien.TabIndex = 12;
            // 
            // GiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 784);
            this.Controls.Add(this.dgvGiaoDich);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GiaoDich";
            this.Text = "GiaoDich";
            this.Load += new System.EventHandler(this.GiaoDich_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtMaGiaoDich;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGiaoDichMoi;
        private System.Windows.Forms.ComboBox cbbLoaiGiaoDich;
        private System.Windows.Forms.DateTimePicker dateNgayGiaoDich;
        private System.Windows.Forms.TextBox txtNhanVien;
    }
}