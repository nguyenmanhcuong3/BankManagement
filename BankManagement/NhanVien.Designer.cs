namespace BankManagement
{
    partial class NhanVien
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
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dateNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.dateNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.radioNu = new System.Windows.Forms.RadioButton();
            this.radioNam = new System.Windows.Forms.RadioButton();
            this.txtSoCCCD = new System.Windows.Forms.TextBox();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.dgvNhanVien);
            this.panel2.Controls.Add(this.btnCapNhat);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.dateNgayVaoLam);
            this.panel2.Controls.Add(this.dateNgaySinh);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtSoDienThoai);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.txtChucVu);
            this.panel2.Controls.Add(this.radioNu);
            this.panel2.Controls.Add(this.radioNam);
            this.panel2.Controls.Add(this.txtSoCCCD);
            this.panel2.Controls.Add(this.txtTenNhanVien);
            this.panel2.Controls.Add(this.txtMaNhanVien);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
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
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(-2, 274);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(726, 189);
            this.dgvNhanVien.TabIndex = 2;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnCapNhat.Location = new System.Drawing.Point(300, 214);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(92, 28);
            this.btnCapNhat.TabIndex = 32;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXoa.Location = new System.Drawing.Point(202, 214);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(92, 28);
            this.btnXoa.TabIndex = 30;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSua.Location = new System.Drawing.Point(106, 214);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(92, 28);
            this.btnSua.TabIndex = 29;
            this.btnSua.Text = "Sửa ";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnThem.Location = new System.Drawing.Point(10, 214);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(92, 28);
            this.btnThem.TabIndex = 28;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dateNgayVaoLam
            // 
            this.dateNgayVaoLam.Location = new System.Drawing.Point(523, 160);
            this.dateNgayVaoLam.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateNgayVaoLam.Name = "dateNgayVaoLam";
            this.dateNgayVaoLam.Size = new System.Drawing.Size(160, 22);
            this.dateNgayVaoLam.TabIndex = 20;
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.Location = new System.Drawing.Point(134, 94);
            this.dateNgaySinh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Size = new System.Drawing.Size(159, 22);
            this.dateNgaySinh.TabIndex = 19;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(523, 126);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(160, 22);
            this.txtEmail.TabIndex = 18;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(523, 98);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(160, 22);
            this.txtSoDienThoai.TabIndex = 17;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(523, 63);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(160, 22);
            this.txtDiaChi.TabIndex = 16;
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(523, 22);
            this.txtChucVu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(160, 22);
            this.txtChucVu.TabIndex = 15;
            // 
            // radioNu
            // 
            this.radioNu.AutoSize = true;
            this.radioNu.Location = new System.Drawing.Point(221, 135);
            this.radioNu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioNu.Name = "radioNu";
            this.radioNu.Size = new System.Drawing.Size(40, 17);
            this.radioNu.TabIndex = 14;
            this.radioNu.TabStop = true;
            this.radioNu.Text = "Nữ";
            this.radioNu.UseVisualStyleBackColor = true;
            // 
            // radioNam
            // 
            this.radioNam.AutoSize = true;
            this.radioNam.Location = new System.Drawing.Point(134, 135);
            this.radioNam.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioNam.Name = "radioNam";
            this.radioNam.Size = new System.Drawing.Size(48, 17);
            this.radioNam.TabIndex = 13;
            this.radioNam.TabStop = true;
            this.radioNam.Text = "Nam";
            this.radioNam.UseVisualStyleBackColor = true;
            // 
            // txtSoCCCD
            // 
            this.txtSoCCCD.Location = new System.Drawing.Point(134, 158);
            this.txtSoCCCD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoCCCD.Name = "txtSoCCCD";
            this.txtSoCCCD.Size = new System.Drawing.Size(159, 22);
            this.txtSoCCCD.TabIndex = 12;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(134, 63);
            this.txtTenNhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(159, 22);
            this.txtTenNhanVien.TabIndex = 11;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(134, 31);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(159, 22);
            this.txtMaNhanVien.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(435, 167);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Ngày vào làm :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(435, 101);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Số điện thoại :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 135);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Email :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(435, 66);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Địa chỉ :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 169);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Số CCCD :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Chức vụ :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 135);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Giới tính :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày sinh :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên nhân viên :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhân viên :";
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 431);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "NhanVien";
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.NhanVien_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateNgayVaoLam;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.RadioButton radioNu;
        private System.Windows.Forms.RadioButton radioNam;
        private System.Windows.Forms.TextBox txtSoCCCD;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
    }
}