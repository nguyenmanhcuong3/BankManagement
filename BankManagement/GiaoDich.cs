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
using Excel = Microsoft.Office.Interop.Excel;
namespace BankManagement
{
    public partial class GiaoDich : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        private KhachHang khachHangForm;
        private DataTable dbGiaoDich = new DataTable();
        public GiaoDich()
        {
            InitializeComponent();
            // Khởi tạo danh sách mã khách hàng rỗng
            //maKhachHangList = new List<string>();

            // Thiết lập DateTimePicker để ẩn ngày tháng mặc định
            dateNgayGiaoDich.Format = DateTimePickerFormat.Custom;
            dateNgayGiaoDich.CustomFormat = " "; // Ẩn ngày mặc định

            // Hiển thị ngày khi có thay đổi
            dateNgayGiaoDich.ValueChanged += (s, e) =>
            {
                dateNgayGiaoDich.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày tháng
            };
        }
        public GiaoDich(KhachHang khForm) // Nhận tham chiếu form KhachHang từ constructor
        {
            InitializeComponent();
            khachHangForm = khForm;
        }

        private void ResetValue()
        {
            txtMaGiaoDich.Text = string.Empty;
            cbbLoaiGiaoDich.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtSoTien.Text = string.Empty;
            cbbTenNhanVien.Text = string.Empty;
            btnGiaoDichMoi.Enabled = true;
            btnXacNhan.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;

        }
       


        private void GiaoDich_Load(object sender, EventArgs e)
        {
            dbGiaoDich = db.DocBang("select * from GiaoDich");
            dgvGiaoDich.DataSource = dbGiaoDich;
            dbGiaoDich.Dispose();
            btnGiaoDichMoi.Enabled = true;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;
            btnXacNhan.Enabled = false;
            // thêm mã khách hàng vào cbbMaKhachHang
            List<string> listkh = db.GetMaKhachHangList();
            foreach (string i in listkh)
            {
                cbbMaKhachHang.Items.Add(i);
            }
            // them ten nhan vien vao cbbTenNhanVien
            List<string> listnv = db.GetTenNhanVienList();
            foreach (string i in listnv)
            {
                cbbTenNhanVien.Items.Add(i);
            }
       
        }

        private void btnGiaoDichMoi_Click(object sender, EventArgs e)
        {
            txtMaGiaoDich.Enabled = true;
            txtSoTien.Enabled = true;
            txtTenKhachHang.Enabled = true;
            cbbMaKhachHang.Enabled = true;
            cbbLoaiGiaoDich.Enabled = true;
            cbbTenNhanVien.Enabled = true;
            dateNgayGiaoDich.Enabled = true;
            txtMaGiaoDich.Focus();
            txtMaGiaoDich.Text = "";
            txtSoTien.Text = "";
            txtTenKhachHang.Text = "";
            cbbMaKhachHang.Text = "";
            cbbTenNhanVien.Text = "";
            btnXacNhan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dgvGiaoDich.SelectedRows.Count > 0)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giao dịch này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes, thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    // Lấy mã giao dịch từ dòng được chọn
                    string maGiaoDich = dgvGiaoDich.SelectedRows[0].Cells["MaGiaoDich"].Value.ToString();

                    // Câu lệnh SQL xóa thông tin từ bảng GiaoDich
                    string sql = "DELETE FROM GiaoDich WHERE MaGiaoDich = @MaGiaoDich";

                    try
                    {
                        using (SqlConnection con = new SqlConnection(db.strConnect)) // Kết nối tới cơ sở dữ liệu
                        {
                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.Parameters.AddWithValue("@MaGiaoDich", maGiaoDich);

                            con.Open(); // Mở kết nối
                            int rowsAffected = cmd.ExecuteNonQuery(); // Thực thi câu lệnh

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa giao dịch thành công!");

                                // Cập nhật lại bảng DataGridView
                                string sqlSelect = "SELECT * FROM GiaoDich"; // Lấy lại dữ liệu
                                dgvGiaoDich.DataSource = db.DocBang(sqlSelect); // Gán dữ liệu vào DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy dữ liệu để xóa.");
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
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
            }
         
            ResetValue();
        }



        private void dgvGiaoDich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có phải dòng hợp lệ được chọn hay không
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn trong DataGridView
                DataGridViewRow selectedRow = dgvGiaoDich.Rows[e.RowIndex];

                // Hiển thị thông tin giao dịch từ dòng được chọn lên các ô nhập
                txtMaGiaoDich.Text = selectedRow.Cells["MaGiaoDich"].Value?.ToString();
                cbbLoaiGiaoDich.Text = selectedRow.Cells["LoaiGiaoDich"].Value?.ToString();
                cbbMaKhachHang.Text = selectedRow.Cells["MaKhachHang"].Value?.ToString();
                txtTenKhachHang.Text = selectedRow.Cells["TenKhachHang"].Value?.ToString();
                txtSoTien.Text = selectedRow.Cells["SoTienGiaoDich"].Value?.ToString();

                // Kiểm tra và chuyển đổi dữ liệu ngày tháng, nếu có giá trị
                if (DateTime.TryParse(selectedRow.Cells["ThoiGianGiaoDich"].Value?.ToString(), out DateTime ngayGiaoDich))
                {
                    dateNgayGiaoDich.Value = ngayGiaoDich;
                }

                string manv = selectedRow.Cells["MaNhanVien"].Value?.ToString();
                string ten = db.GetTenNhanVienByMa(manv);
                cbbTenNhanVien.Text = ten;
            }
            btnXoa.Enabled = true;
            btnXacNhan.Enabled = true;
            btnGiaoDichMoi.Enabled = true;
            btnXuatExcel.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string magiaodich = txtMaGiaoDich.Text.Trim();
            string loaigiaodich = cbbLoaiGiaoDich.Text.Trim();
            string makh = cbbMaKhachHang.Text.Trim();
            string tenkh = txtTenKhachHang.Text.Trim();
            int soTien = int.TryParse(txtSoTien.Text, out int sotien) ? sotien : 0;
            DateTime timeGiaoDich = DateTime.TryParse(dateNgayGiaoDich.Text, out DateTime ngaygiaodich) ? ngaygiaodich : DateTime.MinValue;
            string tennhanvien = cbbTenNhanVien.Text.Trim();

            // Xử lý thông tin rỗng
            if (string.IsNullOrEmpty(magiaodich) || string.IsNullOrEmpty(loaigiaodich) ||
                string.IsNullOrEmpty(makh) || string.IsNullOrEmpty(tenkh) ||
                soTien <= 0 || timeGiaoDich == DateTime.MinValue ||
                string.IsNullOrEmpty(tennhanvien))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hoặc nhập lại ô \"Số Tiền Giao Dịch\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng lặp mã giao dịch
            if (dgvGiaoDich.Rows.Cast<DataGridViewRow>().Any(row => row.Cells["MaGiaoDich"].Value?.ToString() == magiaodich))
            {
                MessageBox.Show("Mã giao dịch đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra tên khách hàng
            string tenKhachHang = db.GetTenKhachHangByMa(makh);
            if (!string.Equals(tenKhachHang, tenkh, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tên khách hàng không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy mã nhân viên theo tên nhân viên
            string maNhanVien = db.GetMaNhanVienByTen(tennhanvien);

            // Thêm thông tin giao dịch vào bảng
            string sqlInsert = "INSERT INTO GiaoDich (MaGiaoDich, LoaiGiaoDich, MaNhanVien, TenKhachHang, MaKhachHang, ThoiGianGiaoDich, SoTienGiaoDich) " +
                               "VALUES (@MaGiaoDich, @LoaiGiaoDich, @MaNhanVien, @TenKhachHang, @MaKhachHang, @ThoiGianGiaoDich, @SoTienGiaoDich)";

            SqlParameter[] parameters = {
    new SqlParameter("@MaGiaoDich", magiaodich),
    new SqlParameter("@LoaiGiaoDich", loaigiaodich),
    new SqlParameter("@MaNhanVien", maNhanVien),
    new SqlParameter("@TenKhachHang", tenKhachHang),
    new SqlParameter("@MaKhachHang", makh),
    new SqlParameter("@ThoiGianGiaoDich", timeGiaoDich),
    new SqlParameter("@SoTienGiaoDich", soTien)
};

            try
            {
                db.CapNhatDuLieu(sqlInsert, parameters);
                MessageBox.Show("Thêm giao dịch thành công!");
                dgvGiaoDich.DataSource = db.DocBang("SELECT * FROM GiaoDich");

                // Tính số tiền cho bảng tài khoản
                string updateQuery = string.Empty;

                switch (loaigiaodich)
                {
                    case "Nhan Tien":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien + @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Chuyen Tien":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien - @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Gui Tiet Kiem":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien - @SoTienGiaoDich, SoTienGuiTietKiem = SoTienGuiTietKiem + @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Rut Tien Tiet Kiem":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien + @SoTienGiaoDich, SoTienGuiTietKiem = SoTienGuiTietKiem - @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Vay Von":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien + @SoTienGiaoDich, SoTienVay = SoTienVay + @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Tra No":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien - @SoTienGiaoDich, SoTienVay = SoTienVay - @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                }

                if (!string.IsNullOrEmpty(updateQuery))
                {
                    SqlParameter[] updateParameters = {
            new SqlParameter("@SoTienGiaoDich", soTien),
            new SqlParameter("@MaKhachHang", makh)
        };
                    db.CapNhatDuLieu(updateQuery, updateParameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            ResetValue();


        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng cho việc xuất dữ liệu
            ProcessDatabase db = new ProcessDatabase();
            string sql = "SELECT * FROM GiaoDich"; // Truy vấn SQL để lấy dữ liệu từ bảng KhachHang

            // Tạo SaveFileDialog để cho phép người dùng chọn vị trí lưu file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx"; // Chỉ cho phép lưu file với đuôi .xlsx
                saveFileDialog.DefaultExt = "xlsx"; // Đặt đuôi mặc định
                saveFileDialog.Title = "Lưu file Excel"; // Tiêu đề của hộp thoại

                // Hiển thị hộp thoại và kiểm tra nếu người dùng đã chọn file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName; // Lấy đường dẫn file đã chọn

                    // Xuất dữ liệu ra file Excel
                    db.ExportToExcel(sql, filePath);
                    MessageBox.Show("Xuất dữ liệu ra file Excel thành công!");
                }
            }
        }

        private void cbbMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbMaKhachHang_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Lấy mã khách hàng được chọn trong ComboBox
            string maKhachHang = cbbMaKhachHang.SelectedItem.ToString();

            // Sử dụng ProcessDatabase để lấy tên khách hàng từ cơ sở dữ liệu

            string tenKhachHang = db.GetTenKhachHangByMa(maKhachHang);

            // Hiển thị tên khách hàng trên TextBox
            txtTenKhachHang.Text = tenKhachHang;

            if (!string.IsNullOrEmpty(maKhachHang))
            {

                DataTable loaiTaiKhoanTable = db.DocBang("SELECT LoaiTaiKhoan FROM TaiKhoan WHERE MaKhachHang like  N'" + maKhachHang + "'");
                if (loaiTaiKhoanTable.Rows.Count > 0)
                {
                    string loaiTaiKhoan = loaiTaiKhoanTable.Rows[0]["LoaiTaiKhoan"].ToString();
                    if (loaiTaiKhoan == "ThanhToan")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                    }
                    else if (loaiTaiKhoan == "TietKiem")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                        cbbLoaiGiaoDich.Items.Add("Gui Tiet Kiem");
                        cbbLoaiGiaoDich.Items.Add("Rut Tien Tiet Kiem");
                    }
                    else if (loaiTaiKhoan == "VayVon")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                        cbbLoaiGiaoDich.Items.Add("Vay Von");
                        cbbLoaiGiaoDich.Items.Add("Tra No");
                    }
                    else if (loaiTaiKhoan == "DaNang")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                        cbbLoaiGiaoDich.Items.Add("Vay Von");
                        cbbLoaiGiaoDich.Items.Add("Tra No");
                        cbbLoaiGiaoDich.Items.Add("Gui Tiet Kiem");
                        cbbLoaiGiaoDich.Items.Add("Rut Tien Tiet Kiem");
                    }

                }
            }
            else
            {
                txtTenKhachHang.Text = "";
                cbbLoaiGiaoDich.Items.Clear();
            }
        }
    }
}
