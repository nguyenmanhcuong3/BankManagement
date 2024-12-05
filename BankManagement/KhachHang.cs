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
    public partial class QLKhachHang : Form
    {
        IOManager db= new IOManager();
        private string imageFilePath = "";
        public QLKhachHang()
        {
            InitializeComponent();
            this.txtTimKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKH_KeyDown);
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbKhachHang = db.DocBang("select * from KhachHang");
            dgvKhachHang.DataSource = dbKhachHang;
            dbKhachHang.Dispose();
            txtTaiKhoan.Enabled = false;
            txtSoTaiKhoan.Enabled=false;
            txtSoDu.Enabled = false;
            txtNgheNghiep.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSoCCCD.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            txttenKhachHang.Enabled = false;
            btnTaiAnhKH.Enabled = false;

        }
        private void txtTimKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTim.PerformClick(); // Kích hoạt sự kiện Click của btnTim
            }
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchValue = txtTimKH.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.");
                return;
            }

            System.Data.DataTable searchResult = db.DocBang($"SELECT * FROM KhachHang WHERE SoTaiKhoan LIKE '%{searchValue}%' OR TenKhachHang LIKE '%{searchValue}%' OR TaiKhoan LIKE '%{searchValue}%'");

            if (searchResult.Rows.Count > 0)
            {
                dgvKhachHang.DataSource = searchResult;
                MessageBox.Show("Tìm thấy kết quả tìm kiếm!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp!");
                dgvKhachHang.DataSource = null;
            }
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.CurrentRow != null)
            {
                if (dgvKhachHang.CurrentRow != null)
                {
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
                    else if (gioiTinh == "Nu")
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
                    txtSoTaiKhoan.Text=dgvKhachHang.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
                    txtSoDu.Text = dgvKhachHang.CurrentRow.Cells["SoDu"].Value.ToString();
                    txtTaiKhoan.Text = dgvKhachHang.CurrentRow.Cells["TaiKhoan"].Value.ToString();
                    string anhDaiDien = dgvKhachHang.CurrentRow.Cells["Anh"].Value?.ToString();
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

            }
            txtNgheNghiep.Enabled = true;
            txtDiaChi.Enabled = true;
            txtSoCCCD.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtEmail.Enabled = true;
            txttenKhachHang.Enabled = true;
            btnTaiAnhKH.Enabled = true;
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản có mã là:" +
                    txtTaiKhoan.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                
                db.CapNhatDuLieu("delete KhachHang where TaiKhoan='" +
               txtTaiKhoan.Text + "'", null);
                db.CapNhatDuLieu("delete DangNhap where TaiKhoan='" +
               txtTaiKhoan.Text + "'", null);

                dgvKhachHang.DataSource = db.DocBang("Select * from KhachHang");
                MessageBox.Show("Xóa khách hàng thành công !");

                
            }
        }

        private void btnTaiAnhKH_Click(object sender, EventArgs e)
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

        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {
            string hoTen = txttenKhachHang.Text;
            string email = txtEmail.Text;
            string soCCCD = txtSoCCCD.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;
            string ngheNghiep = txtNgheNghiep.Text;
            string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
            DateTime ngaySinh = dateNgaySinh.Value;
            int soTaiKhoan;
            string taiKhoan = txtTaiKhoan.Text;
            string duongDanAnh = null;
            int soDu;
            try
            {
                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soCCCD) ||
                    string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(ngheNghiep) ||
                    string.IsNullOrEmpty(taiKhoan) )
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ( !int.TryParse(txtSoTaiKhoan.Text, out soTaiKhoan))
                {
                    return;
                }
                if (!int.TryParse(txtSoDu.Text, out soDu))
                {
                    return;
                }
                // Kiểm tra điều kiện số CCCD (12 chữ số)
                if (!System.Text.RegularExpressions.Regex.IsMatch(soCCCD, @"^\d{12}$"))
                {
                    MessageBox.Show("Số CCCD phải có đúng 12 chữ số!");
                    return;
                }

                // Kiểm tra điều kiện số điện thoại (10 chữ số và bắt đầu bằng số 0)
                if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!");
                    return;
                }

                // Kiểm tra định dạng email
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@gmail\.com$"))
                {
                    MessageBox.Show("Email phải có định dạng hợp lệ và có đuôi @gmail.com!");
                    return;
                }
                // Xử lý ảnh
           
                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    // Đường dẫn thư mục lưu ảnh
                    string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang");
                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    // Tạo tên file mới cho ảnh
                    string imageFileName = $"{taiKhoan}{Path.GetExtension(imageFilePath)}";
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

                // Câu lệnh SQL
                SqlParameter[] parameters = {
        new SqlParameter("@TenKhachHang", hoTen),
        new SqlParameter("@Email", email),
        new SqlParameter("@SoCCCD", soCCCD),
        new SqlParameter("@SoDienThoai", soDienThoai),
        new SqlParameter("@GioiTinh", gioiTinh),
        new SqlParameter("@NgaySinh", ngaySinh),
        new SqlParameter("@DiaChi", diaChi),
        new SqlParameter("@NgheNghiep", ngheNghiep),
        new SqlParameter("@SoDu", soDu),
        new SqlParameter("@TaiKhoan", taiKhoan),
        new SqlParameter("@SoTaiKhoan", soTaiKhoan),
        new SqlParameter("@Anh", duongDanAnh)
    };

                string query = @"
    UPDATE KhachHang 
    SET 
        TenKhachHang = @TenKhachHang,
        Email = @Email,
        SoCCCD = @SoCCCD,
        SoDienThoai = @SoDienThoai,
        GioiTinh = @GioiTinh,
        NgaySinh = @NgaySinh,
        DiaChi = @DiaChi,
        NgheNghiep = @NgheNghiep,
        SoDu = @SoDu,
        TaiKhoan = @TaiKhoan,
        SoTaiKhoan = @SoTaiKhoan,
        Anh = @Anh
    WHERE TaiKhoan = @TaiKhoan";
                db.CapNhatDuLieu(query, parameters);


                MessageBox.Show("Cập nhật thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM KhachHang";
            db.ExportDataToExcel(sql);
        }
    }
}
