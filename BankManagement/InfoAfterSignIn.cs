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
    public partial class InfoAfterSignIn : Form
    {
        IOManager db = new IOManager();
        private string imageFilePath = "";
        public InfoAfterSignIn()
        {
            InitializeComponent();
            btnDangKi.Enabled = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            txtHoTen.Focus();
            
        }

        private void pictureKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void InfoAfterSignIn_Load(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string email = txtEmail.Text;
            string soCCCD = txtSoCCCD.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;
            string ngheNghiep = txtNgheNghiep.Text;
            string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
            DateTime ngaySinh = dateNgaySinh.Value;
            int soTaiKhoan;
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string duongDanAnh = null;

            try
            {
                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soCCCD) ||
                    string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(ngheNghiep) ||
                    string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtSoTaiKhoan.Text) || !int.TryParse(txtSoTaiKhoan.Text, out soTaiKhoan))
                {
                    MessageBox.Show("Số tài khoản phải là một số hợp lệ và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang");

                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    string imageFileName = $"{taiKhoan}{Path.GetExtension(imageFilePath)}";
                    string saveImagePath = Path.Combine(imageFolderPath, imageFileName);

                    File.Copy(imageFilePath, saveImagePath, true);
                    duongDanAnh = imageFileName;
                }
                int soDu = 0;
                // Câu lệnh SQL
                string role = "User";
                string querylog = "INSERT INTO DangNhap (TaiKhoan, MatKhau,Role) VALUES (@TaiKhoan, @MatKhau,@Role)";
                SqlParameter[] parameterslog = {
                new SqlParameter("@TaiKhoan", taiKhoan),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@Role", role)
                    };

                db.CapNhatDuLieu(querylog, parameterslog);
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
        new SqlParameter("@DuongDanAnh", duongDanAnh)
    };

                string query = "INSERT INTO KhachHang (SoTaiKhoan,SoDu,TenKhachHang, Email, SoCCCD, SoDienThoai, GioiTinh, NgaySinh, DiaChi, NgheNghiep, TaiKhoan, Anh) " +
                               "VALUES (@SotaiKhoan,@SoDu,@TenKhachHang, @Email, @SoCCCD, @SoDienThoai, @GioiTinh, @NgaySinh, @DiaChi, @NgheNghiep, @TaiKhoan, @DuongDanAnh)";

                db.CapNhatDuLieu(query, parameters);


                MessageBox.Show("Đăng ký thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            DangNhap_DangKi login= new DangNhap_DangKi();
            login.Show();
            this.Hide();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                btnDangKi.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                btnDangKi.Enabled = false;
            }
        }
    }
}
