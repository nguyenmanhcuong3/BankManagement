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
    public partial class ThongTinKhach : Form
    {
        string taiKhoan;
        ProcessDatabase db= new ProcessDatabase();
        private string imageFilePath;
        public ThongTinKhach(string taikhoan)
        {
            InitializeComponent();
            taiKhoan= taikhoan;
        }

        private void ThongTinKhach_Load(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtSoTaiKhoan.Enabled = false;
            txtSoDu.Enabled = false;
            txtSoCCCD.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtEmail.Enabled = false;
            btnCapNhat.Enabled = false;
            DataTable dbKhachHang = db.DocBang($"select * from KhachHang where TaiKhoan like '%{taiKhoan}%'");
            if(dbKhachHang.Rows.Count > 0)
            {
                DataRow row = dbKhachHang.Rows[0];

                // Gán dữ liệu từ DataTable vào các ô nhập liệu
                txtHoTen.Text = row["TenKhachHang"].ToString();
                txtSoTaiKhoan.Text = row["SoTaiKhoan"].ToString();
                txtSoDu.Text = row["SoDu"].ToString();
                txtSoCCCD.Text = row["SoCCCD"].ToString();
                txtSoDienThoai.Text = row["SoDienThoai"].ToString();
                txtEmail.Text = row["Email"].ToString();
                string anhDaiDien = row["Anh"].ToString();
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

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            txtEmail.Enabled = true;
            txtSoDienThoai.Enabled = true;
            btnCapNhat.Enabled = true;
            btnSuaThongTin.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ giao diện
                string hoTen = txtHoTen.Text;
                string email = txtEmail.Text;
                string soCCCD = txtSoCCCD.Text;
                string soDienThoai = txtSoDienThoai.Text;
                int soTaiKhoan, soDu;
                string duongDanAnh = null;

                // Kiểm tra các trường bắt buộc
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soDienThoai))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng số tài khoản và số dư
                if (!int.TryParse(txtSoTaiKhoan.Text, out soTaiKhoan))
                {
                    MessageBox.Show("Số tài khoản phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtSoDu.Text, out soDu))
                {
                    MessageBox.Show("Số dư phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng số điện thoại
                if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra định dạng email
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@gmail\.com$"))
                {
                    MessageBox.Show("Email phải có định dạng hợp lệ và có đuôi @gmail.com!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Chuẩn bị câu truy vấn và tham số
                string query = @"
                UPDATE KhachHang 
                SET 
                    Email = @Email,
                    SoDienThoai = @SoDienThoai
                WHERE SoTaiKhoan = @SoTaiKhoan";

                SqlParameter[] parameters = {
            new SqlParameter("@Email", email),
            new SqlParameter("@SoDienThoai", soDienThoai),
            new SqlParameter("@SoTaiKhoan",soTaiKhoan)
        };

                // Thực thi câu lệnh cập nhật
                db.CapNhatDuLieu(query, parameters);

                // Thông báo thành công
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và thông báo
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtEmail.Enabled= false;
            txtSoDienThoai.Enabled= false;
            btnSuaThongTin.Enabled = true;
            btnCapNhat.Enabled= false;
        }  
    }
}
