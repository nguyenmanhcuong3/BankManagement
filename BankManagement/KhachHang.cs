using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class KhachHang : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        private string imageFilePath = "";
        public KhachHang()
        {
            InitializeComponent();
        }
        void ResetValue()
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMaKhachHang.Text = "";
            txtNgheNghiep.Text = "";
            txtSoCCCD.Text = "";
            txtSoDienThoai.Text = "";
            txttenKhachHang.Text = "";
            radioNam.Checked = false;
            radioNu.Checked = false;
            radioKhac.Checked = false;
            pictureKhachHang.Image = null;
            imageFilePath = "";
            btnCapNhatKH.Enabled = false;
            btnSuaKH.Enabled = false;
            btnTaiAnhKH.Enabled = false;
            btnThemKH.Enabled = false;
            btnXoaKH.Enabled = false;
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbKhachHang = db.DocBang("select * from KhachHang");
            dgvKhachHang.DataSource = dbKhachHang;
            dbKhachHang.Dispose();
            btnCapNhatKH.Enabled = false;
            btnSuaKH.Enabled = false;
            btnTaiAnhKH.Enabled = false;
            btnThemKH.Enabled = true;
            btnXoaKH.Enabled = false;

        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFilePath = openFileDialog.FileName;
                pictureKhachHang.Image = Image.FromFile(imageFilePath);
                pictureKhachHang.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMaKhachHang.Text = "";
            txtNgheNghiep.Text = "";
            txtSoCCCD.Text = "";
            txtSoDienThoai.Text = "";
            txttenKhachHang.Text = "";
            txtMaKhachHang.Focus();
            btnCapNhatKH.Enabled = true;
            btnTaiAnhKH.Enabled = true;
            btnSuaKH.Enabled = false;
            btnXoaKH.Enabled = false;
            btnTaiAnhKH.Image = null;
            pictureKhachHang.Image = null;
            radioKhac.Checked = true;

        }
        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text;
            string tenKhachHang = txttenKhachHang.Text;
            string soCCCD = txtSoCCCD.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;
            string ngheNghiep = txtNgheNghiep.Text;
            string duongDanAnh = null;
            try
            {
                if (string.IsNullOrEmpty(txtMaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không được bỏ trống!");
                    return;
                }

                // Kiểm tra điều kiện số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!");
                    return;
                }

                // Kiểm tra điều kiện số CCCD (phải có 12 chữ số)
                if (!System.Text.RegularExpressions.Regex.IsMatch(soCCCD, @"^\d{12}$"))
                {
                    MessageBox.Show("Số CCCD phải có đúng 12 chữ số!");
                    return;
                }

                string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
                DateTime ngaySinh = dateNgaySinh.Value;
                string email = txtEmail.Text;

                // Kiểm tra điều kiện email (phải có đuôi @gmail.com)
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@gmail\.com$"))
                {
                    MessageBox.Show("Email phải có định dạng hợp lệ và có đuôi @gmail.com!");
                    return;
                }

                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang");

                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    string imageFileName = $"{maKhachHang}{Path.GetExtension(imageFilePath)}";
                    string saveImagePath = Path.Combine(imageFolderPath, imageFileName);

                    File.Copy(imageFilePath, saveImagePath, true);

                    duongDanAnh = imageFileName;
                }

                SqlParameter[] parameters = {
            new SqlParameter("@MaKhachHang", maKhachHang),
            new SqlParameter("@TenKhachHang", tenKhachHang),
            new SqlParameter("@SoCCCD", soCCCD),
            new SqlParameter("@SoDienThoai", soDienThoai),
            new SqlParameter("@GioiTinh", gioiTinh),
            new SqlParameter("@NgaySinh", ngaySinh),
            new SqlParameter("@Email", email),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@NgheNghiep", ngheNghiep),
            new SqlParameter("@DuongDanAnh", duongDanAnh)
                 };

                string query = "INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoCCCD, SoDienThoai, GioiTinh, NgaySinh, Email, DiaChi, NgheNghiep, AnhDaiDien) " +
                               "VALUES (@MaKhachHang, @TenKhachHang, @SoCCCD, @SoDienThoai, @GioiTinh, @NgaySinh, @Email, @DiaChi, @NgheNghiep, @DuongDanAnh)";

                db.CapNhatDuLieu(query, parameters);

                if (!string.IsNullOrEmpty(duongDanAnh))
                {
                    string queryAnhKhachHang = "INSERT INTO AnhKhachHang (MaKhachHang, AnhDaiDien) VALUES (@MaKhachHang, @DuongDanAnh)";
                    SqlParameter[] parametersAnh = {
                new SqlParameter("@MaKhachHang", maKhachHang),
                new SqlParameter("@DuongDanAnh", duongDanAnh)
                    };

                    db.CapNhatDuLieu(queryAnhKhachHang, parametersAnh);
                }

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                dgvKhachHang.DataSource = db.DocBang("SELECT * FROM KhachHang");
                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra mã khách hàng
                if (string.IsNullOrEmpty(txtMaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không được bỏ trống!");
                    return;
                }

                // Lấy thông tin từ các trường nhập liệu
                string maKhachHang = txtMaKhachHang.Text;
                string tenKhachHang = txttenKhachHang.Text;
                string soCCCD = txtSoCCCD.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
                DateTime ngaySinh = dateNgaySinh.Value;
                string email = txtEmail.Text;
                string diaChi = txtDiaChi.Text;
                string ngheNghiep = txtNgheNghiep.Text;

                string duongDanAnh = null;

                // Kiểm tra ảnh đại diện mới
                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    // Đường dẫn thư mục lưu ảnh
                    string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang");
                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    // Tạo tên file mới cho ảnh
                    string imageFileName = $"{maKhachHang}{Path.GetExtension(imageFilePath)}";
                    string saveImagePath = Path.Combine(imageFolderPath, imageFileName);

                    // Sao chép ảnh vào thư mục
                    File.Copy(imageFilePath, saveImagePath, true);

                    // Cập nhật đường dẫn ảnh chỉ với tên file
                    duongDanAnh = imageFileName;
                }
                else
                {
                    // Nếu không chọn ảnh mới, giữ lại ảnh cũ
                    duongDanAnh = dgvKhachHang.CurrentRow.Cells["AnhDaiDien"].Value?.ToString();
                }

                // Cập nhật thông tin khách hàng
                string queryUpdate = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, SoCCCD = @SoCCCD, SoDienThoai = @SoDienThoai, " +
                                     "GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, Email = @Email, DiaChi = @DiaChi, NgheNghiep = @NgheNghiep, " +
                                     "AnhDaiDien = @DuongDanAnh WHERE MaKhachHang = @MaKhachHang";

                // Khởi tạo các tham số cho truy vấn
                SqlParameter[] parameters = {
            new SqlParameter("@MaKhachHang", maKhachHang),
            new SqlParameter("@TenKhachHang", tenKhachHang),
            new SqlParameter("@SoCCCD", soCCCD),
            new SqlParameter("@SoDienThoai", soDienThoai),
            new SqlParameter("@GioiTinh", gioiTinh),
            new SqlParameter("@NgaySinh", ngaySinh),
            new SqlParameter("@Email", email),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@NgheNghiep", ngheNghiep),
            new SqlParameter("@DuongDanAnh", string.IsNullOrEmpty(duongDanAnh) ? (object)DBNull.Value : duongDanAnh)
        };

                // Thực hiện cập nhật
                db.CapNhatDuLieu(queryUpdate, parameters);

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!");
                dgvKhachHang.DataSource = db.DocBang("SELECT * FROM KhachHang");
                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi cập nhật thông tin: " + ex.Message);
            }
        }


        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng  có mã là:" +
                    txtMaKhachHang.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                db.CapNhatDuLieu("delete KhachHang where MaKhachHang='" +
               txtMaKhachHang.Text + "'", null);
                dgvKhachHang.DataSource = db.DocBang("Select * from KhachHang");
                MessageBox.Show("Xóa khách hàng thành công !");

                ResetValue();
            }

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                txtMaKhachHang.Text = dgvKhachHang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                txttenKhachHang.Text = dgvKhachHang.CurrentRow.Cells["TenKhachHang"].Value.ToString();
                txtSoCCCD.Text = dgvKhachHang.CurrentRow.Cells["SoCCCD"].Value.ToString();
                txtSoDienThoai.Text = dgvKhachHang.CurrentRow.Cells["SoDienThoai"].Value.ToString();

                string ngaySinhStr = dgvKhachHang.CurrentRow.Cells["NgaySinh"].Value?.ToString();
                if (!string.IsNullOrEmpty(ngaySinhStr) && DateTime.TryParse(ngaySinhStr, out DateTime ngaySinh))
                {
                    dateNgaySinh.Value = ngaySinh;
                }

                string gioiTinh = dgvKhachHang.CurrentRow.Cells["GioiTinh"].Value.ToString();
                if (gioiTinh == "Nam")
                {
                    radioNam.Checked = true;
                }
                else if (gioiTinh == "Nữ")
                {
                    radioNu.Checked = true;
                }
                else
                {
                    radioKhac.Checked = true;
                }

                txtEmail.Text = dgvKhachHang.CurrentRow.Cells["Email"].Value.ToString();
                txtDiaChi.Text = dgvKhachHang.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtNgheNghiep.Text = dgvKhachHang.CurrentRow.Cells["NgheNghiep"].Value.ToString();

                string anhDaiDien = dgvKhachHang.CurrentRow.Cells["AnhDaiDien"].Value?.ToString();
                if (!string.IsNullOrEmpty(anhDaiDien))
                {
                    string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang", anhDaiDien);

                    try
                    {
                        if (pictureKhachHang.Image != null)
                        {
                            pictureKhachHang.Image.Dispose();
                            pictureKhachHang.Image = null;
                        }

                        using (var stream = new MemoryStream(File.ReadAllBytes(fullPath)))
                        {
                            pictureKhachHang.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                        pictureKhachHang.Image = null;
                    }
                }
                else
                {
                    pictureKhachHang.Image = null;
                }
            }

            btnXoaKH.Enabled = true;
            btnThemKH.Enabled = true;
            btnSuaKH.Enabled = true;
            btnTaiAnhKH.Enabled = true;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM KhachHang"; // Truy vấn SQL để lấy dữ liệu từ bảng KhachHang

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"; // Chỉ cho phép lưu file với đuôi .xlsx
                saveFileDialog.DefaultExt = "xlsx"; // Đặt đuôi mặc định
                saveFileDialog.Title = "Lưu file Excel"; // Tiêu đề của hộp thoại

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName; // Lấy đường dẫn file đã chọn
                    db.ExportToExcel(sql, filePath);
                    MessageBox.Show("Xuất dữ liệu ra file Excel thành công!");
                }
            }
        }
    }
}
