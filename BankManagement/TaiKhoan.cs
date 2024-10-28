using System;
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
        ProcessDatabase db = new ProcessDatabase();
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

            DataTable searchResult = db.DocBang($"SELECT * FROM TaiKhoan WHERE MaTaiKhoan LIKE '%{searchValue}%' OR MaKhachHang LIKE '%{searchValue}%'");

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
            txtMaTaiKhoan.Enabled = true;
            cbbLoaiTaiKhoan.Enabled = true;
            txtSoTien.Enabled = true;
            txtTenKhachHang.Enabled = true;
            txtSoTienGui.Enabled = true;
            txtSoTienVay.Enabled = true;
            txtMaKhachHang.Enabled = true;
            dateNgayMo.Enabled = true;
            ResetValue();
            txtSoTien.Focus();
            txtMaKhachHang.Focus();
            txtSoTienGui.Focus();
            txtSoTienVay.Focus();
            txtMaTaiKhoan.Focus();
            btnCapNhat.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            DataTable dbTaiKhoan = db.DocBang("select * from TaiKhoan");
            dgvTaiKhoan.DataSource = dbTaiKhoan;
            dbTaiKhoan.Dispose();
            btnCapNhat.Enabled = false;
            btnSua.Enabled = false;
            btnTim.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
           // OffValue();

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
            txtMaKhachHang.Text = dgvTaiKhoan.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            var tenkhachhang = db.DocBang("select TenKhachHang from KhachHang where MaKhachHang like N'" + txtMaKhachHang.Text + "'");
            string Text = tenkhachhang.Rows[0][0].ToString();
            txtTenKhachHang.Text = Text;
            txtSoTienGui.Text = dgvTaiKhoan.CurrentRow.Cells["SoTienGuiTietKiem"].Value.ToString();
            txtSoTienVay.Text = dgvTaiKhoan.CurrentRow.Cells["SoTienVay"].Value.ToString();

            db.CapNhatDuLieu("delete TaiKhoan where MaTaiKhoan='" +
              txtMaTaiKhoan.Text + "'", null);
            dgvTaiKhoan.DataSource = db.DocBang("Select * from TaiKhoan");

            btnCapNhat.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản có mã là:" +
                    txtMaTaiKhoan.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                db.CapNhatDuLieu("delete TaiKhoan where MaTaiKhoan='" +
               txtMaTaiKhoan.Text + "'", null);
                dgvTaiKhoan.DataSource = db.DocBang("Select * from TaiKhoan");
                MessageBox.Show("Xóa tài khoản thành công !");
                ResetValue();
            }
            OffValue();

        }
        private void OffValue()
        {
            txtMaTaiKhoan.Enabled = false;
            cbbLoaiTaiKhoan.Enabled = false;
            txtSoTien.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtSoTienGui.Enabled = false;
            txtSoTienVay.Enabled = false;
            txtMaKhachHang.Enabled = false;
            dateNgayMo.Enabled = false;
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
                // Kiểm tra xem mã tài khoản đã tồn tại trong cơ sở dữ liệu chưa
                int checkmaTK = (int)db.DocBang("SELECT COUNT(*) FROM TaiKhoan WHERE MaTaiKhoan like N'" + maTaiKhoan + "' ").Rows[0][0];

                if (checkmaTK > 0)
                {
                    MessageBox.Show("Mã tài khoản này đã tồn tại trong cơ sở dữ liệu! Vui lòng nhập mã tài khoản khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string loaiTaiKhoan = cbbLoaiTaiKhoan.Text;

                DateTime ngayMo = dateNgayMo.Value.Date;
                int soTien = int.Parse(txtSoTien.Text);
                string maKhachHang = txtMaKhachHang.Text;
                int soTienGui = int.Parse(txtSoTienGui.Text);
                int soTienVay = int.Parse(txtSoTienVay.Text);
                //kiem tra xem ma khach hang da co tai khoan chua

                int accountCount = (int)db.DocBang("SELECT COUNT(*) FROM TaiKhoan WHERE MaKhachHang like N'" + maKhachHang + "'").Rows[0][0];

                if (accountCount > 0)
                {
                    MessageBox.Show("Khách hàng này đã có tài khoản. Mỗi khách hàng chỉ được mở một tài khoản!");
                    return;
                }
                //
                string query = "INSERT INTO TaiKhoan (MaTaiKhoan, LoaiTaiKhoan, SoTien, ThoiGianMo,MaKhachHang,SoTienGuiTietKiem,SoTienVay ) " +
                               "VALUES (@MaTaiKhoan, @LoaiTaiKhoan, @SoTien, @ThoiGianMo,@MaKhachHang,@SoTienGuiTietKiem,@SoTienVay)";

                SqlParameter[] parameters = {
            new SqlParameter("@MaTaiKhoan", maTaiKhoan),
            new SqlParameter("@LoaiTaiKhoan", loaiTaiKhoan),
            new SqlParameter("@Sotien", soTien),
            new SqlParameter("@ThoiGianMo", ngayMo),
            new SqlParameter("@MaKhachHang", maKhachHang),
            new SqlParameter("@SoTienGuiTietKiem",soTienGui),
            new SqlParameter("@SoTienVay", soTienVay)

            };

                db.CapNhatDuLieu(query, parameters);
                MessageBox.Show("Thông tin tài khoản đã được cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvTaiKhoan.DataSource = db.DocBang("SELECT * FROM TaiKhoan");
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
                txtMaKhachHang.Text = dgvTaiKhoan.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                var tenkhachhang = db.DocBang("select TenKhachHang from KhachHang where MaKhachHang like N'" + txtMaKhachHang.Text + "'");
                string Text = tenkhachhang.Rows[0][0].ToString();
                txtTenKhachHang.Text = Text;
                txtSoTienGui.Text = dgvTaiKhoan.CurrentRow.Cells["SoTienGuiTietKiem"].Value.ToString();
                txtSoTienVay.Text = dgvTaiKhoan.CurrentRow.Cells["SoTienVay"].Value.ToString();


            }

            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;

        }



        private void label7_Click(object sender, EventArgs e)
        {

        }
        //Nhap ma khach hang ra ten khach hang
        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbbLoaiTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
