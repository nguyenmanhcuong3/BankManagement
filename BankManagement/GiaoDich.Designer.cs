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
            this.txtNhanVien = new System.Windows.Forms.TextBox();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1442, 125);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(574, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 65);
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
            this.panel2.Location = new System.Drawing.Point(14, 132);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1415, 506);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dateNgayGiaoDich
            // 
            this.dateNgayGiaoDich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayGiaoDich.Location = new System.Drawing.Point(924, 131);
            this.dateNgayGiaoDich.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateNgayGiaoDich.Name = "dateNgayGiaoDich";
            this.dateNgayGiaoDich.Size = new System.Drawing.Size(224, 26);
            this.dateNgayGiaoDich.TabIndex = 19;
            this.dateNgayGiaoDich.ValueChanged += new System.EventHandler(this.dateNgayGiaoDich_ValueChanged);
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
            this.cbbLoaiGiaoDich.Location = new System.Drawing.Point(192, 139);
            this.cbbLoaiGiaoDich.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbbLoaiGiaoDich.Name = "cbbLoaiGiaoDich";
            this.cbbLoaiGiaoDich.Size = new System.Drawing.Size(260, 28);
            this.cbbLoaiGiaoDich.TabIndex = 18;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(1107, 410);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(159, 72);
            this.btnXuatExcel.TabIndex = 16;
            this.btnXuatExcel.Text = "Xuất ra file excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.Location = new System.Drawing.Point(758, 410);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(156, 72);
            this.btnXacNhan.TabIndex = 15;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(423, 410);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(163, 72);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGiaoDichMoi
            // 
            this.btnGiaoDichMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaoDichMoi.Location = new System.Drawing.Point(87, 410);
            this.btnGiaoDichMoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGiaoDichMoi.Name = "btnGiaoDichMoi";
            this.btnGiaoDichMoi.Size = new System.Drawing.Size(153, 72);
            this.btnGiaoDichMoi.TabIndex = 13;
            this.btnGiaoDichMoi.Text = "Giao dịch mới";
            this.btnGiaoDichMoi.UseVisualStyleBackColor = true;
            this.btnGiaoDichMoi.Click += new System.EventHandler(this.btnGiaoDichMoi_Click);
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Location = new System.Drawing.Point(927, 210);
            this.txtNhanVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(221, 26);
            this.txtNhanVien.TabIndex = 12;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(927, 62);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(221, 26);
            this.txtSoTien.TabIndex = 10;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(192, 218);
            this.txtMaKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(260, 26);
            this.txtMaKhachHang.TabIndex = 9;
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(192, 312);
            this.txtTenKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(260, 26);
            this.txtTenKhachHang.TabIndex = 8;
            // 
            // txtMaGiaoDich
            // 
            this.txtMaGiaoDich.Location = new System.Drawing.Point(192, 58);
            this.txtMaGiaoDich.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaGiaoDich.Name = "txtMaGiaoDich";
            this.txtMaGiaoDich.Size = new System.Drawing.Size(260, 26);
            this.txtMaGiaoDich.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(708, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nhân viên thực hiện :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(709, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian giao dịch :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền giao dịch :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mã khách hàng :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tên khách hàng :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Loại giao dịch :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã  giao dịch :";
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.Location = new System.Drawing.Point(14, 640);
            this.dgvGiaoDich.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.Size = new System.Drawing.Size(1415, 258);
            this.dgvGiaoDich.TabIndex = 2;
            this.dgvGiaoDich.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGiaoDich_CellClick);
            // 
            // GiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 980);
            this.Controls.Add(this.dgvGiaoDich);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.TextBox txtNhanVien;
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
    }
}