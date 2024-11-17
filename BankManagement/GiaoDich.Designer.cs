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
            this.dgvGiaoDich = new System.Windows.Forms.DataGridView();
            this.dateNgayGiaoDich = new System.Windows.Forms.DateTimePicker();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.txtMaGiaoDich = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txttaiKhoanGui = new System.Windows.Forms.TextBox();
            this.txtTenNguoiGui = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtTaiKhoanNhan = new System.Windows.Forms.TextBox();
            this.txtTenNguoiNhan = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.txtTenNguoiNhan);
            this.panel2.Controls.Add(this.txtTaiKhoanNhan);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.txtTenNguoiGui);
            this.panel2.Controls.Add(this.txttaiKhoanGui);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnTim);
            this.panel2.Controls.Add(this.txtTim);
            this.panel2.Controls.Add(this.dgvGiaoDich);
            this.panel2.Controls.Add(this.dateNgayGiaoDich);
            this.panel2.Controls.Add(this.btnXuatExcel);
            this.panel2.Controls.Add(this.txtMaGiaoDich);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 431);
            this.panel2.TabIndex = 1;
            // 
            // dgvGiaoDich
            // 
            this.dgvGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaoDich.Location = new System.Drawing.Point(-2, 266);
            this.dgvGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvGiaoDich.Name = "dgvGiaoDich";
            this.dgvGiaoDich.RowHeadersWidth = 51;
            this.dgvGiaoDich.RowTemplate.Height = 24;
            this.dgvGiaoDich.Size = new System.Drawing.Size(726, 197);
            this.dgvGiaoDich.TabIndex = 2;
            // 
            // dateNgayGiaoDich
            // 
            this.dateNgayGiaoDich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayGiaoDich.Location = new System.Drawing.Point(154, 99);
            this.dateNgayGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateNgayGiaoDich.Name = "dateNgayGiaoDich";
            this.dateNgayGiaoDich.Size = new System.Drawing.Size(175, 26);
            this.dateNgayGiaoDich.TabIndex = 19;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnXuatExcel.Location = new System.Drawing.Point(481, 192);
            this.btnXuatExcel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(92, 28);
            this.btnXuatExcel.TabIndex = 16;
            this.btnXuatExcel.Text = "Xuất ra file excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;

            // 
            // txtMaGiaoDich
            // 
            this.txtMaGiaoDich.Location = new System.Drawing.Point(154, 46);
            this.txtMaGiaoDich.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMaGiaoDich.Name = "txtMaGiaoDich";
            this.txtMaGiaoDich.Size = new System.Drawing.Size(175, 26);
            this.txtMaGiaoDich.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 19);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian giao dịch :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(366, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền giao dịch :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã  giao dịch :";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(122, 7);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(207, 26);
            this.txtTim.TabIndex = 24;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(392, 10);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 23);
            this.btnTim.TabIndex = 25;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tài khoản gửi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(366, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 19);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tài khoản nhận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Tên người nhận";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tên người gửi";
            // 
            // txttaiKhoanGui
            // 
            this.txttaiKhoanGui.Location = new System.Drawing.Point(154, 145);
            this.txttaiKhoanGui.Name = "txttaiKhoanGui";
            this.txttaiKhoanGui.Size = new System.Drawing.Size(175, 26);
            this.txttaiKhoanGui.TabIndex = 30;
            // 
            // txtTenNguoiGui
            // 
            this.txtTenNguoiGui.Location = new System.Drawing.Point(154, 194);
            this.txtTenNguoiGui.Name = "txtTenNguoiGui";
            this.txtTenNguoiGui.Size = new System.Drawing.Size(175, 26);
            this.txtTenNguoiGui.TabIndex = 31;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(508, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(150, 26);
            this.textBox3.TabIndex = 32;
            // 
            // txtTaiKhoanNhan
            // 
            this.txtTaiKhoanNhan.Location = new System.Drawing.Point(508, 92);
            this.txtTaiKhoanNhan.Name = "txtTaiKhoanNhan";
            this.txtTaiKhoanNhan.Size = new System.Drawing.Size(150, 26);
            this.txtTaiKhoanNhan.TabIndex = 33;
            // 
            // txtTenNguoiNhan
            // 
            this.txtTenNguoiNhan.Location = new System.Drawing.Point(508, 142);
            this.txtTenNguoiNhan.Name = "txtTenNguoiNhan";
            this.txtTenNguoiNhan.Size = new System.Drawing.Size(150, 26);
            this.txtTenNguoiNhan.TabIndex = 34;
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDich)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvGiaoDich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaGiaoDich;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DateTimePicker dateNgayGiaoDich;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTenNguoiNhan;
        private System.Windows.Forms.TextBox txtTaiKhoanNhan;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtTenNguoiGui;
        private System.Windows.Forms.TextBox txttaiKhoanGui;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}