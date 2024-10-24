﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankManagement
{
    public partial class TaiKhoan : Form
    {
        ProcessDatabase dbtk = new ProcessDatabase();
        void ResetValue()
        {
            cbbLoaiTaiKhoan.Text = "";
            txtSoTien.Text = "";
            txtMaTaiKhoan.Text = "";
            txtTenKhachHang.Text = "";
            txtMaKhachHang.Text = "";
            txtSoTienGui.Text = "";
            txtSoTienVay.Text = "";
            btnCapNhat.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;

        }
        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchValue = txtTim.Text.Trim(); 

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.");
                return;
            }

            DataTable searchResult = dbtk.DocBang($"SELECT * FROM TaiKhoan WHERE MaTaiKhoan LIKE '%{searchValue}%' OR TenKhachHang LIKE '%{searchValue}%'");

            if (searchResult.Rows.Count > 0)
            {
                dgvTaiKhoan.DataSource = searchResult;
                MessageBox.Show("Tìm thấy kết quả tìm kiếm!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp!");
                dgvTaiKhoan.DataSource = null; 
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cbbLoaiTaiKhoan.Text = "";
            txtSoTien.Text = "";
            txtMaTaiKhoan.Text = "";
            txtTenKhachHang.Text = "";
            txtSoTienGui.Text = "";
            txtSoTienVay.Text = "";
            txtMaKhachHang.Text = "";
            txtSoTien.Focus();
            txtMaTaiKhoan.Focus();
            txtTenKhachHang.Focus();
            txtMaTaiKhoan.Focus();
            txtSoTienGui.Focus();
            txtSoTienVay.Focus();
            txtMaKhachHang.Focus();
            btnCapNhat.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable dbTaiKhoan = dbtk.DocBang("select * from TaiKhoan");
            dgvTaiKhoan.DataSource = dbTaiKhoan;
            dbTaiKhoan.Dispose();
            btnCapNhat.Enabled = false;
            btnSua.Enabled = false;
            btnTim.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaTaiKhoan.Text = dgvTaiKhoan.CurrentRow.Cells["MaTaiKhoan"].Value.ToString();
            cbbLoaiTaiKhoan.Text = dgvTaiKhoan.CurrentRow.Cells["LoaiTaiKhoan"].Value.ToString();
            txtSoTien.Text = dgvTaiKhoan.CurrentRow.Cells["SoTien"].Value.ToString();
            string ngayMostr = dgvTaiKhoan.CurrentRow.Cells["ThoiGianMo"].Value?.ToString();
            if (!string.IsNullOrEmpty(ngayMostr) && DateTime.TryParse(ngayMostr, out DateTime ngaymo))
            {
                dateNgayMo.Value = ngaymo;
            }
            txtTenKhachHang.Text = dgvTaiKhoan.CurrentRow.Cells["TenKhachHang"].Value.ToString();

            dbtk.CapNhatDuLieu("delete TaiKhoan where MaTaiKhoan='" +
              txtMaTaiKhoan.Text + "'", null);
            dgvTaiKhoan.DataSource = dbtk.DocBang("Select * from KhachHang");

            btnCapNhat.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản có mã là:" +
                    txtMaTaiKhoan.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                dbtk.CapNhatDuLieu("delete TaiKhoan where MaTaiKhoan='" +
               txtMaTaiKhoan.Text + "'", null);
                dgvTaiKhoan.DataSource = dbtk.DocBang("Select * from TaiKhoan");
                MessageBox.Show("Xóa tài khoản thành công !");
                ResetValue();
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaTaiKhoan.Text))
                {
                    MessageBox.Show("Mã tài khoản không được bỏ trống!");
                    return;
                }

                string maTaiKhoan = txtMaTaiKhoan.Text;
                string loaiTaiKhoan = cbbLoaiTaiKhoan.Text;

                DateTime ngayMo = dateNgayMo.Value;
                int soTien = int.Parse(txtSoTien.Text);
                string tenKhachHang = txtTenKhachHang.Text;

                string query = "INSERT INTO TaiKhoan (MaTaiKhoan, LoaiTaiKhoan, SoTien, ThoiGianMo, TenKhachHang) " +
                               "VALUES (@MaTaiKhoan, @LoaiTaiKhoan, @SoTien, @ThoiGianMo, @TenKhachHang)";

                SqlParameter[] parameters = {
            new SqlParameter("@MaTaiKhoan", maTaiKhoan),
            new SqlParameter("@LoaiTaiKhoan", loaiTaiKhoan),
            new SqlParameter("@Sotien", soTien),
            new SqlParameter("@ThoiGianMo", ngayMo),
            new SqlParameter("@TenKhachHang", tenKhachHang),
            };

                dbtk.CapNhatDuLieu(query, parameters);
                MessageBox.Show("Cập nhật thông tin tài khoản thành công!");
                dgvTaiKhoan.DataSource = dbtk.DocBang("SELECT * FROM TaiKhoan");
                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateNgayMo_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvTaiKhoan_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null)
            {

                txtMaTaiKhoan.Text = dgvTaiKhoan.CurrentRow.Cells["MaTaiKhoan"].Value.ToString();
                cbbLoaiTaiKhoan.Text = dgvTaiKhoan.CurrentRow.Cells["LoaiTaiKhoan"].Value.ToString();
                txtSoTien.Text = dgvTaiKhoan.CurrentRow.Cells["SoTien"].Value.ToString();
                string ngayMostr = dgvTaiKhoan.CurrentRow.Cells["ThoiGianMo"].Value?.ToString();
                if (!string.IsNullOrEmpty(ngayMostr) && DateTime.TryParse(ngayMostr, out DateTime ngaymo))
                {
                    dateNgayMo.Value = ngaymo;
                }
                txtTenKhachHang.Text = dgvTaiKhoan.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            }
 
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
