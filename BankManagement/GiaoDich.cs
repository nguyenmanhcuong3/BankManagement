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
           txtMaGiaoDich.Text= string.Empty;
           cbbLoaiGiaoDich.Text = string.Empty;
           txtTenKhachHang.Text = string.Empty;
           txtTenKhachHang.Text= string.Empty;
            txtSoTien.Text= string.Empty;
            txtNhanVien.Text= string.Empty;
            btnGiaoDichMoi.Enabled = false;
            btnXacNhan.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = false;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateNgayGiaoDich_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            DataTable dbGiaoDich = db.DocBang("select * from GiaoDich");
            dgvGiaoDich.DataSource = dbGiaoDich;
            dbGiaoDich.Dispose();
            btnGiaoDichMoi.Enabled = true;
            btnXoa.Enabled=false;
            btnXuatExcel.Enabled=false;
            btnXacNhan.Enabled=false;
        }

        private void btnGiaoDichMoi_Click(object sender, EventArgs e)
        {
            // lấy thông tin từ dữ liệu nhập
            
            string magiaodich = txtMaGiaoDich.Text.Trim();
            string loaigiaodich = cbbLoaiGiaoDich.Text.Trim();
            string makh = txtMaKhachHang.Text.Trim();
            string tenkh = txtTenKhachHang.Text.Trim();
            int SoTien = int.TryParse(txtSoTien.Text, out int sotien) ? sotien: 0;
            DateTime timeGiaoDich = DateTime.TryParse(dateNgayGiaoDich.Text, out DateTime ngaygiaodich) ? ngaygiaodich : DateTime.MinValue;
            string tennhanvien = txtNhanVien.Text.Trim();
            // xử lý thông tin rỗng 
            if (string.IsNullOrEmpty(magiaodich) || string.IsNullOrEmpty(loaigiaodich) ||
               string.IsNullOrEmpty(makh) || string.IsNullOrEmpty(tenkh) ||
               SoTien <= 0 || timeGiaoDich == DateTime.MinValue ||
               string.IsNullOrEmpty(tennhanvien))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hoặc nhập lại ô \"Số Tiền Giao Dịch\"","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return; // Dừng xử lý nếu có thông tin rỗng
            }
            // kiểm tra trùng lặp mã giao dịch
            foreach (DataGridViewRow row in dgvGiaoDich.Rows)
            {
                if (row.Cells["MaGiaoDich"].Value != null && row.Cells["MaGiaoDich"].Value.ToString() == txtMaGiaoDich.Text)
                {
                    MessageBox.Show("Mã giao dịch đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // kiểm tra có tồn tại mã khách hàng từ bảng KhachHang
            // Kiểm tra có tồn tại mã khách hàng từ form KhachHang
            List<string> maKhachHangList = db.GetMaKhachHangList(); // Lấy danh sách mã khách hàng từ CSDL

            if (!maKhachHangList.Contains(makh))
            {
                MessageBox.Show("Mã khách hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // kiểm tra tên có khớp với tên trong bảng KhachHang ứng với trường MaKhachHang tương ứng 
            // Kiểm tra tên khách hàng
            string tenKhachHang = db.GetTenKhachHangByMa(makh); // Lấy tên khách hàng từ CSDL bằng mã khách hàng
            if (!string.Equals(tenKhachHang, tenkh, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tên khách hàng không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra tên nhân viên có tồn tại trong cơ sở dữ liệu hay không
            if (!db.CheckNhanVienByTen(tennhanvien))
            {
                MessageBox.Show("Tên nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // lấy mã nhân viên theo tennhanvien
            string maNhanVien = db.GetMaNhanVienByTen(tennhanvien);
            // thêm thông tin giao dịch vào bảng
            string sqlInsert = "INSERT INTO GiaoDich (MaGiaoDich, LoaiGiaoDich, MaNhanVien, TenKhachHang, MaKhachHang, ThoiGianGiaoDich, SoTienGiaoDich) " +
                   "VALUES (@MaGiaoDich, @LoaiGiaoDich, @MaNhanVien, @TenKhachHang, @MaKhachHang, @ThoiGianGiaoDich, @SoTienGiaoDich)";

            using (SqlConnection con = new SqlConnection(db.strConnect))  // Kết nối đến cơ sở dữ liệu
            {
                try
                {
                    con.Open();  // Mở kết nối
                    using (SqlCommand cmd = new SqlCommand(sqlInsert, con))
                    {
                        // Thêm các tham số để tránh SQL Injection
                        cmd.Parameters.AddWithValue("@MaGiaoDich", magiaodich);
                        cmd.Parameters.AddWithValue("@LoaiGiaoDich", loaigiaodich);
                        cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cmd.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);
                        cmd.Parameters.AddWithValue("@MaKhachHang", makh);
                        cmd.Parameters.AddWithValue("@ThoiGianGiaoDich", timeGiaoDich);
                        cmd.Parameters.AddWithValue("@SoTienGiaoDich", SoTien);

                        // Thực thi câu lệnh thêm dữ liệu
                        int result = cmd.ExecuteNonQuery();

                        // Nếu thêm thành công, thông báo và cập nhật lại DataGridView
                        if (result > 0)
                        {
                            MessageBox.Show("Thêm giao dịch thành công!");

                            // Truy vấn để lấy tất cả dữ liệu từ bảng GiaoDich
                            string sqlSelect = "SELECT * FROM GiaoDich";
                            DataTable dtGiaoDich = db.DocBang(sqlSelect);
                            dgvGiaoDich.DataSource = dtGiaoDich;  // Cập nhật DataGridView với dữ liệu mới
                        }
                        else
                        {
                            MessageBox.Show("Thêm giao dịch thất bại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            ResetValue();

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
        }

        private void dgvGiaoDich_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
                txtMaKhachHang.Text = selectedRow.Cells["MaKhachHang"].Value?.ToString();
                txtTenKhachHang.Text = selectedRow.Cells["TenKhachHang"].Value?.ToString();
                txtSoTien.Text = selectedRow.Cells["SoTienGiaoDich"].Value?.ToString();

                // Kiểm tra và chuyển đổi dữ liệu ngày tháng, nếu có giá trị
                if (DateTime.TryParse(selectedRow.Cells["ThoiGianGiaoDich"].Value?.ToString(), out DateTime ngayGiaoDich))
                {
                    dateNgayGiaoDich.Value = ngayGiaoDich;
                }

                string manv = selectedRow.Cells["MaNhanVien"].Value?.ToString();
                string ten = db.GetTenNhanVienByMa(manv);
                txtNhanVien.Text = ten;
            }
            btnXoa.Enabled = true;
            btnXacNhan.Enabled = true;
        }
    }
}
