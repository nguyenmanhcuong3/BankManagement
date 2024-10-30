using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class NhanVien : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        public NhanVien()
        {
            InitializeComponent();

        }

        void ResetValue()
        {
            txtMaNhanVien.Text = string.Empty;
            txtTenNhanVien.Text = string.Empty;
            radioNam.Checked = false;
            radioNu.Checked = false;
            txtSoCCCD.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;


        }
        private void OffValue()
        {
            // Thiết lập các TextBox và DateTimePicker không thể nhập liệu
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            txtSoCCCD.Enabled = false;
            txtChucVu.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;

            // Thiết lập các DateTimePicker không thể chọn ngày
            dateNgaySinh.Enabled = false;
            dateNgayVaoLam.Enabled = false;

            // Thiết lập RadioButton không thể chọn lại
            radioNam.Enabled = false;
            radioNu.Enabled = false;
        }
        private void OnValue()
        {
            // Thiết lập các TextBox và DateTimePicker không thể nhập liệu
            txtMaNhanVien.Enabled = true;
            txtTenNhanVien.Enabled = true;
            txtSoCCCD.Enabled = true;
            txtChucVu.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtEmail.Enabled = true;

            // Thiết lập các DateTimePicker không thể chọn ngày
            dateNgaySinh.Enabled = true;
            dateNgayVaoLam.Enabled = true;

            // Thiết lập RadioButton không thể chọn lại
            radioNam.Enabled = true;
            radioNu.Enabled = true;
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            DataTable dbNhanVien = db.DocBang("select * from NhanVien");
            dgvNhanVien.DataSource = dbNhanVien;
            dbNhanVien.Dispose();
           
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnCapNhat.Enabled = false;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            OnValue();
            txtMaNhanVien.Focus();
            btnCapNhat.Enabled = true;

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string manv = txtMaNhanVien.Text.Trim();
            string tennv = txtTenNhanVien.Text.Trim();
            DateTime ngaySinh = dateNgaySinh.Value;
            string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : string.Empty;
            string cccd = txtSoCCCD.Text.Trim();
            string chucvu = txtChucVu.Text.Trim();
            string diachi = txtDiaChi.Text.Trim();
            string phone = txtSoDienThoai.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime ngayVaoLam = dateNgayVaoLam.Value;
            // xu ly dieu kien
            try
            {
                // xử lý thông tin rỗng 
                if (string.IsNullOrEmpty(manv) || string.IsNullOrEmpty(tennv) ||
                   string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(chucvu) || string.IsNullOrEmpty(gioiTinh)
                   ||
                   string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // kiểm tra trùng lặp mã nhân viên
                foreach (DataGridViewRow row in dgvNhanVien.Rows)
                {
                    if (row.Cells["MaNhanVien"].Value != null && row.Cells["MaNhanVien"].Value.ToString() == manv)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Kiểm tra điều kiện số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!");
                    return;
                }

                // Kiểm tra điều kiện số CCCD (phải có 12 chữ số)
                if (!System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^\d{12}$"))
                {
                    MessageBox.Show("Số CCCD phải có đúng 12 chữ số!");
                    return;
                }



                // Kiểm tra điều kiện email (phải có đuôi @gmail.com)
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@bank\.com$"))
                {
                    MessageBox.Show("Email phải có định dạng hợp lệ và có đuôi @bank.com!");
                    return;
                }



                SqlParameter[] parameters = {
            new SqlParameter("@MaNhanVien", manv),
            new SqlParameter("@TenNhanVien", tennv),
            new SqlParameter("@ChucVu", chucvu),
            new SqlParameter("@NgayVaoLam", ngayVaoLam),
            new SqlParameter("@NgaySinh",ngaySinh),
            new SqlParameter("@GioiTinh", gioiTinh),
            new SqlParameter("@DiaChi", diachi),
            new SqlParameter("@SoCCCD", cccd),
            new SqlParameter("@SoDienThoai", phone),
            new SqlParameter("@Email",email)

                 };

                string query = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, ChucVu, NgayVaoLam, NgaySinh, GioiTinh, DiaChi, SoCCCD, SoDienThoai, Email) " +
               "VALUES (@MaNhanVien, @TenNhanVien, @ChucVu, @NgayVaoLam, @NgaySinh, @GioiTinh, @DiaChi, @SoCCCD, @SoDienThoai, @Email)";


                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có muốn thêm thông tin nhân viên không?", "Xác nhận thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra nếu người dùng chọn Yes
                if (result == DialogResult.Yes)
                {
                    db.CapNhatDuLieu(query, parameters);

                    // Thông báo và cập nhật lại DataGridView sau khi cập nhật thành công
                    MessageBox.Show("Thêm thông tin nhân viên thành công!");
                    dgvNhanVien.DataSource = db.DocBang("SELECT * FROM NhanVien");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            ResetValue();

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải dòng hợp lệ được chọn hay không
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvNhanVien.Rows[e.RowIndex];

                // Hiển thị thông tin giao dịch từ dòng được chọn lên các ô nhập
                txtMaNhanVien.Text = selectedRow.Cells["MaNhanVien"].Value?.ToString();
                txtTenNhanVien.Text = selectedRow.Cells["TenNhanVien"].Value?.ToString();
                txtSoCCCD.Text = selectedRow.Cells["SoCCCD"].Value?.ToString();

                txtChucVu.Text = selectedRow.Cells["ChucVu"].Value?.ToString();
                txtDiaChi.Text = selectedRow.Cells["DiaChi"].Value?.ToString();
                txtSoDienThoai.Text = selectedRow.Cells["SoDienThoai"].Value?.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value?.ToString();
                string gioiTinh = dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    radioNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    radioNu.Checked = true;
                }

                // Kiểm tra và chuyển đổi dữ liệu ngày tháng, nếu có giá trị
                if (DateTime.TryParse(selectedRow.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaysinh))
                {
                    dateNgaySinh.Value = ngaysinh;
                }
                if (DateTime.TryParse(selectedRow.Cells["NgayVaoLam"].Value?.ToString(), out DateTime ngaylam))
                {
                    dateNgayVaoLam.Value = ngaylam;
                }

            }

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnCapNhat.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNhanVien.Text.Trim();
                string tennv = txtTenNhanVien.Text.Trim();
                DateTime ngaySinh = DateTime.TryParse(dateNgaySinh.Text, out DateTime ngaysinh) ? ngaysinh : DateTime.MinValue;
                string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : string.Empty;
                string cccd = txtSoCCCD.Text.Trim();
                string chucvu = txtChucVu.Text.Trim();
                string diachi = txtDiaChi.Text.Trim();
                string phone = txtSoDienThoai.Text.Trim();
                string email = txtEmail.Text.Trim();
                DateTime ngayVaoLam = DateTime.TryParse(dateNgayVaoLam.Text, out DateTime ngayvaolam) ? ngayvaolam : DateTime.MinValue;
                // xử lý thông tin rỗng 
                if (string.IsNullOrEmpty(manv) || string.IsNullOrEmpty(tennv) ||
                   string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(chucvu) || string.IsNullOrEmpty(gioiTinh)
                   || ngaysinh == DateTime.MinValue || ngayVaoLam == DateTime.MinValue ||
                   string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int selectedRowIndex = dgvNhanVien.CurrentCell.RowIndex; // Get the index of the selected row

                // kiểm tra mã nhân viên đã tồn tại hay chưa
                foreach (DataGridViewRow row in dgvNhanVien.Rows)
                {
                    if (row.Index != selectedRowIndex && // Skip the selected row
                        row.Cells["MaNhanVien"].Value != null &&
                        row.Cells["MaNhanVien"].Value.ToString() == manv)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                // Kiểm tra điều kiện số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!");
                    return;
                }

                // Kiểm tra điều kiện số CCCD (phải có 12 chữ số)
                if (!System.Text.RegularExpressions.Regex.IsMatch(cccd, @"^\d{12}$"))
                {
                    MessageBox.Show("Số CCCD phải có đúng 12 chữ số!");
                    return;
                }



                // Kiểm tra điều kiện email (phải có đuôi @gmail.com)
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@bank\.com$"))
                {
                    MessageBox.Show("Email phải có định dạng hợp lệ và có đuôi @bank.com!");
                    return;
                }
                SqlParameter[] parameters = {
                new SqlParameter("@MaNhanVien", manv),
                new SqlParameter("@TenNhanVien", tennv),
                new SqlParameter("@ChucVu", chucvu),
                new SqlParameter("@NgayVaoLam", ngayVaoLam),
                new SqlParameter("@NgaySinh", ngaySinh),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@DiaChi", diachi),
                new SqlParameter("@SoCCCD", cccd),
                new SqlParameter("@SoDienThoai", phone),
                new SqlParameter("@Email", email)
                };

                // Chuỗi câu lệnh SQL để cập nhật thông tin nhân viên vào cơ sở dữ liệu
                string query = "UPDATE NhanVien SET TenNhanVien = @TenNhanVien, ChucVu = @ChucVu, NgayVaoLam = @NgayVaoLam, " +
                               "NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, SoCCCD = @SoCCCD, " +
                               "SoDienThoai = @SoDienThoai, Email = @Email WHERE MaNhanVien = @MaNhanVien";

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có muốn cập nhật thông tin nhân viên không?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Kiểm tra nếu người dùng chọn Yes
                if (result == DialogResult.Yes)
                {
                    db.CapNhatDuLieu(query, parameters);

                    // Thông báo và cập nhật lại DataGridView sau khi cập nhật thành công
                    MessageBox.Show("Sửa thông tin nhân viên thành công!");
                    dgvNhanVien.DataSource = db.DocBang("SELECT * FROM NhanVien");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            ResetValue();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên có mã " + txtMaNhanVien.Text.Trim() + " này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes, thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    // Lấy mã giao dịch từ dòng được chọn
                    string manv = dgvNhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();

                    // Câu lệnh SQL xóa thông tin từ bảng GiaoDich
                    string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";

                    try
                    {
                        using (SqlConnection con = new SqlConnection(db.strConnect)) // Kết nối tới cơ sở dữ liệu
                        {
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@MaNhanVien", manv);

                            con.Open(); // Mở kết nối
                            int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa nhân viên thành công!");

                                // Cập nhật lại bảng DataGridView
                                string sqlSelect = "SELECT * FROM NhanVien"; // Lấy lại dữ liệu
                                dgvNhanVien.DataSource = db.DocBang(sqlSelect); // Gán dữ liệu vào DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy nhân viên để xóa!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
            }

            ResetValue();



        }
    }
}
