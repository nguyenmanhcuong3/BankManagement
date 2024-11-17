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
    public partial class KhachGuiTietKiem : Form
    {
        DataTransaction db = new DataTransaction();
        string TaiKhoan;
        public KhachGuiTietKiem(string username)
        {
            InitializeComponent();
            TaiKhoan = username;
        }

        private void KhachGuiTietKiem_Load(object sender, EventArgs e)
        {

            dateGui.Enabled = false;
            dateTra.Enabled = false;
            // Đặt tất cả các TextBox và ComboBox về rỗng và không cho phép chỉnh sửa
            // Gửi tiền
            txtMaTietKiem.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtHoatDongGuiTien.Text = string.Empty;
            cbbKiHan.Text = string.Empty;
            cbbLaiSuat.Text = string.Empty;
            txtTienGui.Text = string.Empty;
            txtTienNhanSauLai.Text = string.Empty;

            txtMaTietKiem.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtHoTen.Enabled = false;
            txtHoatDongGuiTien.Enabled = false;
            cbbKiHan.Enabled = false;
            cbbLaiSuat.Enabled = false;
            txtTienGui.Enabled = false;
            txtTienNhanSauLai.Enabled = false;

            // Rút tiền
            txtMaKhoanVayTra.Text = string.Empty;
            txtTaiKhoanRut.Text = string.Empty;
            txtHoTenRut.Text = string.Empty;
            txtHoatDongRutTien.Text = string.Empty;
            txtKiHan.Text = string.Empty;
            txtLaiSuat.Text = string.Empty;
            txtSoTienRut.Text = string.Empty;
            txtSoTienConLai.Text = string.Empty;

            txtMaKhoanVayTra.Enabled = false;
            txtTaiKhoanRut.Enabled = false;
            txtHoTenRut.Enabled = false;
            txtHoatDongRutTien.Enabled = false;
            txtKiHan.Enabled = false;
            txtLaiSuat.Enabled = false;
            txtSoTienRut.Enabled = false;
            txtSoTienConLai.Enabled = false;
            // lay du lieu tu bang tietkiem
            System.Data.DataTable dt = db.DocBang("select * from TietKiem");
            dgvVay.DataSource = dt;
            dgvRut.DataSource = dt;
            dt.Dispose();
        }

        private void btnKhoanGuiMoi_Click(object sender, EventArgs e)
        {
            // Cho phép các TextBox và ComboBox trong tab "Gửi tiền" nhập được
           
            txtMaTietKiem.Text = IOManager.GetMaGiaoDich(8);
            txtTaiKhoan.Text = db.LaySoTaiKhoan(TaiKhoan);
            txtHoTen.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoan.Text.Trim());
            txtHoatDongGuiTien.Text = "Nap tien tiet kiem";
            // Thêm các thông tin vào ComboBox cbbKiHan
            cbbKiHan.Items.Clear(); // Xóa các mục cũ (nếu có)
            cbbKiHan.Items.AddRange(new string[] { "1", "3", "6", "12", "18", "24" });

            // Thêm các thông tin vào ComboBox cbbLaiSuat
            cbbLaiSuat.Items.Clear(); // Xóa các mục cũ (nếu có)
            cbbLaiSuat.Items.AddRange(new string[] { "3,8%", "4%", "5,2%", "5,8%", "6%" });


            cbbKiHan.Enabled = true;
            cbbLaiSuat.Enabled = true;
            txtTienGui.Enabled = true;
            txtTienNhanSauLai.Enabled = true;
            /////
            if (decimal.TryParse(txtTienGui.Text, out decimal P) && cbbLaiSuat.SelectedItem != null && int.TryParse(cbbKiHan.SelectedItem.ToString(), out int n))
            {
                // Lấy lãi suất từ ComboBox và chuyển đổi sang dạng thập phân
                string laiSuatStr = cbbLaiSuat.SelectedItem.ToString().TrimEnd('%');

                if (decimal.TryParse(laiSuatStr, out decimal r))
                {
                    r /= 100; // chuyển đổi từ phần trăm sang dạng thập phân

                    // Công thức tính số tiền sau lãi (lãi suất tính theo tháng)
                    decimal S = P * (1 + r * n); // Tính tiền sau lãi với lãi suất đơn giản

                    // Cập nhật kết quả vào TextBox txtTienNhanSauLai
                    txtTienNhanSauLai.Text = S.ToString();
                }
                else
                {
                    MessageBox.Show("Lãi suất không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnKhoanRutMoi_Click(object sender, EventArgs e)
        {
            // Cho phép các TextBox và ComboBox trong tab "Rút tiền" nhập được
            txtMaKhoanVayTra.Enabled = true;
            txtTaiKhoanRut.Enabled = true;
            txtHoTenRut.Enabled = true;
            txtHoatDongRutTien.Enabled = true;
            txtKiHan.Enabled = true;
            txtLaiSuat.Enabled = true;
            txtSoTienRut.Enabled = true;
            txtSoTienConLai.Enabled = true;
        }

        private void btnXacNhanGui_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường bắt buộc rỗng
            if (string.IsNullOrWhiteSpace(cbbKiHan.Text) || string.IsNullOrWhiteSpace(cbbLaiSuat.Text) || string.IsNullOrWhiteSpace(txtTienGui.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra định dạng số tiền gửi (Số tiền phải là số nguyên hợp lệ)
            if (!decimal.TryParse(txtTienGui.Text, out decimal soTienGui) || soTienGui <= 0)
            {
                MessageBox.Show("Số tiền gửi phải là số dương hợp lệ!");
                return;
            }

            // Kiểm tra nếu tiền nhận sau lãi là hợp lệ
            if (!decimal.TryParse(txtTienNhanSauLai.Text, out decimal soTienNhanSauLai))
            {
                MessageBox.Show("Vui lòng tính lại số tiền nhận sau lãi!");
                return;
            }

            // Kiểm tra nếu người dùng chọn kỳ hạn và lãi suất hợp lệ
            if (!int.TryParse(cbbKiHan.Text, out int kyHan) || kyHan <= 0)
            {
                MessageBox.Show("Kỳ hạn phải là số nguyên dương hợp lệ!");
                return;
            }

            if (!decimal.TryParse(cbbLaiSuat.Text.TrimEnd('%'), out decimal laiSuat))
            {
                MessageBox.Show("Lãi suất phải là số hợp lệ!");
                return;
            }

            laiSuat /= 100; // Chuyển đổi từ phần trăm sang dạng thập phân

            // Tính số tiền nhận sau lãi nếu chưa có sẵn giá trị (sử dụng công thức lãi suất)
            if (txtTienNhanSauLai.Text == string.Empty)
            {
                decimal tienNhanSauLai = soTienGui * (decimal)Math.Pow((double)(1 + laiSuat / 12), kyHan);
                txtTienNhanSauLai.Text = tienNhanSauLai.ToString("N2");
            }

            // Tạo các tham số cho câu lệnh SQL
            string maTietKiem = txtMaTietKiem.Text;
            int soTaiKhoan = int.Parse(txtTaiKhoan.Text);
            DateTime thoiGian = DateTime.Now;

            // Tạo truy vấn SQL để chèn dữ liệu vào bảng TietKiem
            string sqlInsert = "INSERT INTO TietKiem (MaTietKiem, SoTaiKhoan, SoTien, ThoiGian, KyHan, LaiSuat, SoTienDuKienNhan) " +
                               "VALUES (@MaTietKiem, @SoTaiKhoan, @SoTien, @ThoiGian, @KyHan, @LaiSuat, @SoTienDuKienNhan)";

            SqlParameter[] parameters = {
        new SqlParameter("@MaTietKiem", maTietKiem),
        new SqlParameter("@SoTaiKhoan", soTaiKhoan),
        new SqlParameter("@SoTien", soTienGui),
        new SqlParameter("@ThoiGian", thoiGian),
        new SqlParameter("@KyHan", kyHan),
        new SqlParameter("@LaiSuat", laiSuat),
        new SqlParameter("@SoTienDuKienNhan", soTienNhanSauLai)
    };

            try
            {
                // Thực thi truy vấn SQL
                db.CapNhatDuLieu(sqlInsert, parameters);
                MessageBox.Show("Thêm thông tin tiết kiệm thành công!");

                // Cập nhật lại DataGridView
                dgvVay.DataSource = db.DocBang("SELECT * FROM TietKiem");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
