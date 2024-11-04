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
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbMaKhachHang = new System.Windows.Forms.ComboBox();
            this.cbbTenNhanVien = new System.Windows.Forms.ComboBox();
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.dateNgayGiaoDich = new System.Windows.Forms.DateTimePicker();
            this.cbbLoaiGiaoDich = new System.Windows.Forms.ComboBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGiaoDichMoi = new System.Windows.Forms.Button();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtMaGiaoDich = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.cbbMaKhachHang);
            this.panel2.Controls.Add(this.cbbTenNhanVien);
            this.panel2.Controls.Add(this.dgvGiaoDich);
            this.panel2.Controls.Add(this.dateNgayGiaoDich);
            this.panel2.Controls.Add(this.cbbLoaiGiaoDich);
            this.panel2.Controls.Add(this.btnXuatExcel);
            this.panel2.Controls.Add(this.btnXacNhan);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnGiaoDichMoi);
            this.panel2.Controls.Add(this.txtSoTien);
            this.panel2.Controls.Add(this.txtTenKhachHang);
            this.panel2.Controls.Add(this.txtMaGiaoDich);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 431);
            this.panel2.TabIndex = 1;
            // 
            // cbbMaKhachHang
            // 
            this.cbbMaKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaKhachHang.FormattingEnabled = true;
            this.cbbMaKhachHang.Location = new System.Drawing.Point(128, 92);
            this.cbbMaKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMaKhachHang.Name = "cbbMaKhachHang";
            this.cbbMaKhachHang.Size = new System.Drawing.Size(175, 27);
            this.cbbMaKhachHang.TabIndex = 23;
            this.cbbMaKhachHang.SelectedIndexChanged += new System.EventHandler(this.cbbMaKhachHang_SelectedIndexChanged_1);
            // 
            // cbbTenNhanVien
            // 
            this.cbbTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenNhanVien.FormattingEnabled = true;
            this.cbbTenNhanVien.Location = new System.Drawing.Point(518, 98);
            this.cbbTenNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTenNhanVien.Name = "cbbTenNhanVien";
            this.cbbTenNhanVien.Size = new System.Drawing.Size(149, 27);
            this.cbbTenNhanVien.TabIndex = 22;
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
            this.dgvGiaoDich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiaoDich_CellClick);
            // 
            // dateNgayGiaoDich
            // 
            this.dateNgayGiaoDich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayGiaoDich.Location = new System.Drawing.Point(518, 67);
            this.dateNgayGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateNgayGiaoDich.Name = "dateNgayGiaoDich";
            this.dateNgayGiaoDich.Size = new System.Drawing.Size(151, 26);
            this.dateNgayGiaoDich.TabIndex = 19;
            // 
            // cbbLoaiGiaoDich
            // 
            this.cbbLoaiGiaoDich.FormattingEnabled = true;
            this.cbbLoaiGiaoDich.Items.AddRange(new object[] {
            "Nhan Tien",
            "Chuyen Tien",
            "Gui Tiet Kiem",
            "Rut Tien Tiet Kiem",
            "Vay Von",
            "Tra No"});
            this.cbbLoaiGiaoDich.Location = new System.Drawing.Point(128, 66);
            this.cbbLoaiGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbbLoaiGiaoDich.Name = "cbbLoaiGiaoDich";
            this.cbbLoaiGiaoDich.Size = new System.Drawing.Size(175, 27);
            this.cbbLoaiGiaoDich.TabIndex = 18;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXuatExcel.Location = new System.Drawing.Point(352, 214);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(92, 28);
            this.btnXuatExcel.TabIndex = 16;
            this.btnXuatExcel.Text = "Xuất ra file excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXacNhan.Location = new System.Drawing.Point(242, 214);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(92, 28);
            this.btnXacNhan.TabIndex = 15;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXoa.Location = new System.Drawing.Point(128, 214);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 28);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGiaoDichMoi
            // 
            this.btnGiaoDichMoi.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnGiaoDichMoi.Location = new System.Drawing.Point(10, 214);
            this.btnGiaoDichMoi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGiaoDichMoi.Name = "btnGiaoDichMoi";
            this.btnGiaoDichMoi.Size = new System.Drawing.Size(109, 28);
            this.btnGiaoDichMoi.TabIndex = 13;
            this.btnGiaoDichMoi.Text = "Giao dịch mới";
            this.btnGiaoDichMoi.UseVisualStyleBackColor = true;
            this.btnGiaoDichMoi.Click += new System.EventHandler(this.btnGiaoDichMoi_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(518, 40);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(149, 26);
            this.txtSoTien.TabIndex = 10;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(128, 122);
            this.txtTenKhachHang.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(175, 26);
            this.txtTenKhachHang.TabIndex = 8;
            // 
            // txtMaGiaoDich
            // 
            this.txtMaGiaoDich.Location = new System.Drawing.Point(128, 38);
            this.txtMaGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaGiaoDich.Name = "txtMaGiaoDich";
            this.txtMaGiaoDich.Size = new System.Drawing.Size(175, 26);
            this.txtMaGiaoDich.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(396, 100);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 19);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nhân viên thực hiện :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 69);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian giao dịch :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền giao dịch :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã khách hàng :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên khách hàng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại giao dịch :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã  giao dịch :";
            // 
            // GiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 431);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "GiaoDich";
            this.Text = "GiaoDich";
            this.Load += new System.EventHandler(this.GiaoDich_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.TextBox txtMaGiaoDich;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGiaoDichMoi;
        private System.Windows.Forms.ComboBox cbbLoaiGiaoDich;
        private System.Windows.Forms.DateTimePicker dateNgayGiaoDich;
        private System.Windows.Forms.ComboBox cbbMaKhachHang;
        private System.Windows.Forms.ComboBox cbbTenNhanVien;
    }
}