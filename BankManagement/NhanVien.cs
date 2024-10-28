
using Microsoft.SqlServer.Server;
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
		private string connectionString = "Data Source=LAPTOP-KGNBC7V6\\SQLEXPRESS;Initial Catalog=QLBank_BTL;Integrated Security=True;Encrypt=False";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adt;
		public NhanVien()
        {
            InitializeComponent();
        }

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			
		}
		private void RefreshDataGrid()
		{
			try
			{
				using (con = new SqlConnection(connectionString))
				{
					con.Open();
					cmd = new SqlCommand("SELECT MaNhanVien, TenNhanVien, ChucVu, NgayVaoLam, NgaySinh, GioiTinh, DiaChi, SoCCCD, SoDienThoai, Email FROM NhanVien", con);
					adt = new SqlDataAdapter(cmd);
					SqlCommandBuilder builder = new SqlCommandBuilder();
					var ds = new DataSet();
					ds.Clear();
					adt.Fill(ds);
					dgvNhanVien.DataSource = ds.Tables[0];

					// Đặt tên hiển thị cho các cột
					dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
					dgvNhanVien.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
					dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
					dgvNhanVien.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
					dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
					dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
					dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
					dgvNhanVien.Columns["SoCCCD"].HeaderText = "Số CCCD";
					dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
					dgvNhanVien.Columns["Email"].HeaderText = "Email";
					// Thiết lập tự động điều chỉnh kích thước cột dựa trên nội dung
					dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading data: " + ex.Message);
			}
		}
		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void NhanVien_Load(object sender, EventArgs e)
		{
			RefreshDataGrid();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				using (con = new SqlConnection(connectionString))
				{
					con.Open();
					string query = "INSERT INTO NhanVien (MaNhanVien, TenNhanVien, ChucVu, NgayVaoLam, NgaySinh, GioiTinh, DiaChi, SoCCCD, SoDienThoai, Email) " +
								   "VALUES (@MaNhanVien, @TenNhanVien, @ChucVu, @NgayVaoLam, @NgaySinh, @GioiTinh, @DiaChi, @SoCCCD, @SoDienThoai, @Email)";

					using (cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);
						cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNhanVien.Text);
						cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);
						cmd.Parameters.AddWithValue("@NgayVaoLam", DateTime.Parse(dateNgayVaoLam.Text));
						cmd.Parameters.AddWithValue("@NgaySinh", DateTime.Parse(dateNgaySinh.Text));
						cmd.Parameters.AddWithValue("@GioiTinh", radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : (object)DBNull.Value);
						cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
						cmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);
						cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
						cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
						// Thực thi câu truy vấn
						cmd.ExecuteNonQuery();
						MessageBox.Show("Khách hàng đã được thêm thành công!");

						// Làm mới lại DataGridView để hiển thị bản ghi mới
						RefreshDataGrid();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Bạn có muốn sửa thông tin không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				try
				{
					using (con = new SqlConnection(connectionString))
					{
						con.Open();
						string query = "UPDATE NhanVien SET MaNhanVien=@MaNhanVien, TenNhanVien=@TenNhanVien, ChucVu=@ChucVu, NgayVaoLam=@NgayVaoLam, " +
									   "NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi, SoCCCD=@SoCCCD, SoDienThoai=@SoDienThoai, Email=@Email " +
									   "WHERE MaNhanVien=@MaNhanVien";

						using (cmd = new SqlCommand(query, con))
						{
							cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);
							cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNhanVien.Text);
							cmd.Parameters.AddWithValue("@ChucVu", txtChucVu.Text);

							// Kiểm tra trường ngày có hợp lệ không
							cmd.Parameters.AddWithValue("@NgayVaoLam", DateTime.TryParse(dateNgayVaoLam.Text, out DateTime ngayVaoLam) ? ngayVaoLam : (object)DBNull.Value);
							cmd.Parameters.AddWithValue("@NgaySinh", DateTime.TryParse(dateNgaySinh.Text, out DateTime ngaySinh) ? ngaySinh : (object)DBNull.Value);

							// Xử lý giới tính
							cmd.Parameters.AddWithValue("@GioiTinh", radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : (object)DBNull.Value);

							cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
							cmd.Parameters.AddWithValue("@SoCCCD", txtSoCCCD.Text);
							cmd.Parameters.AddWithValue("@SoDienThoai", txtSoDienThoai.Text);
							cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

							// Thực hiện cập nhật
							cmd.ExecuteNonQuery();
							MessageBox.Show("Thông tin khách hàng đã được sửa thành công!");
							RefreshDataGrid();
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi sửa thông tin khách hàng: " + ex.Message);
				}
			}
		}


		private void button3_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				// Xóa dòng hiện tại
				dgvNhanVien.Rows.RemoveAt(dgvNhanVien.CurrentRow.Index);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Kiểm tra xem người dùng có nhấp vào một dòng hợp lệ không
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

				// Hiển thị dữ liệu từ các ô của dòng đó lên các điều khiển
				txtMaNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString();
				txtTenNhanVien.Text = row.Cells["TenNhanVien"].Value?.ToString();
				txtChucVu.Text = row.Cells["ChucVu"].Value?.ToString();

				// Nếu cột NgàyVaoLam hoặc NgàySinh có giá trị, hiển thị nó lên DateTimePicker
				if (DateTime.TryParse(row.Cells["NgayVaoLam"].Value?.ToString(), out DateTime ngayVaoLam))
				{
					dateNgayVaoLam.Value = ngayVaoLam;
				}
				if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out DateTime ngaySinh))
				{
					dateNgaySinh.Value = ngaySinh;
				}

				// Kiểm tra giới tính và đặt RadioButton tương ứng
				string gioiTinh = row.Cells["GioiTinh"].Value?.ToString();
				if (gioiTinh == "Nam")
				{
					radioNam.Checked = true;
				}
				else if (gioiTinh == "Nữ")
				{
					radioNu.Checked = true;
				}

				// Các thông tin khác
				txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
				txtSoCCCD.Text = row.Cells["SoCCCD"].Value?.ToString();
				txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
				txtEmail.Text = row.Cells["Email"].Value?.ToString();
			}
		}
	}
}
