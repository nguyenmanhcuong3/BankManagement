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
            this.txtTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKH_KeyDown);
            txtTim.Text = "Nhập số tài khoản hoặc tên";
            txtTim.ForeColor = System.Drawing.Color.Gray;
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
            btnCapNhatKH.Enabled = false;
            dateNgaySinh.Enabled = false;

        }
        private void txtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim.Text.Equals("Nhập số tài khoản hoặc tên"))
            {
                txtTim.Text = "";
                txtTim.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = "Nhập số tài khoản hoặc tên";
                txtTim.ForeColor = System.Drawing.Color.Gray;
            }
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
            string searchValue = txtTim.Text.Trim();

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
            btnCapNhatKH.Enabled = true;
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản có mã là:" +
                    txtTaiKhoan.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                
                db.CapNhatDuLieu("delete KhachHang where TaiKhoan like N'" +
               txtTaiKhoan.Text + "'", null);
                db.CapNhatDuLieu("delete DangNhap where TaiKhoan like N'" +
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
            string hoTen = txttenKhachHang.Text.Trim();
            string email = txtEmail.Text.Trim();
            string soCCCD = txtSoCCCD.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string ngheNghiep = txtNgheNghiep.Text.Trim();
            string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
            DateTime ngaySinh = dateNgaySinh.Value;
            string SoTaiKhoan = txtSoTaiKhoan.Text.Trim();
            string SoDu = txtSoDu.Text.Trim();
            string taiKhoan = txtTaiKhoan.Text.Trim();
            string duongDanAnh = null;
            
            try
            {
                if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soCCCD) ||
    string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(ngheNghiep) ||
    string.IsNullOrEmpty(taiKhoan))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra ảnh đại diện mới
                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang");
                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    string imageFileName = $"{hoTen}{Path.GetExtension(imageFilePath)}";
                    string saveImagePath = Path.Combine(imageFolderPath, imageFileName);
                    File.Copy(imageFilePath, saveImagePath, true);

                    duongDanAnh = imageFileName;
                }
                else
                {
                    duongDanAnh = dgvKhachHang.CurrentRow.Cells["Anh"].Value?.ToString();
                }

                //ktraemail
                string querycheckemail = @"
                SELECT COUNT(*) as Count 
                FROM KhachHang 
                WHERE Email = @Email AND SoTaiKhoan <> @STK";

                SqlParameter[] parameterscheckemail = {
                  new SqlParameter("@Email", email),
                  new SqlParameter("@STK", SoTaiKhoan)
                };

                System.Data.DataTable checkemail = db.DocBang(querycheckemail, parameterscheckemail);
                int countemail = 0;
                if (checkemail.Rows.Count > 0)
                {
                    countemail = Convert.ToInt32(checkemail.Rows[0]["Count"]);
                }

                if (countemail > 0)
                {
                    MessageBox.Show("Email này đã được sử dụng bởi khách hàng khác!");
                    return;
                }

                //ktrasdt
                string querychecksdt = @"
                SELECT COUNT(*) as Count 
                FROM KhachHang 
                WHERE SoDienThoai = @Email AND SoTaiKhoan <> @STK";

                SqlParameter[] parameterschecksdt = {
                  new SqlParameter("@Email", soDienThoai),
                  new SqlParameter("@STK", SoTaiKhoan)
                };

                System.Data.DataTable checksdt = db.DocBang(querychecksdt, parameterschecksdt);
                int countsdt = 0;
                if (checksdt.Rows.Count > 0)
                {
                    countsdt = Convert.ToInt32(checksdt.Rows[0]["Count"]);
                }

                if (countsdt > 0)
                {
                    MessageBox.Show("Số điện thoại này đã được sử dụng bởi khách hàng khác!");
                    return;
                }

                //ktracccd
                string querycheckcccd = @"
                SELECT COUNT(*) as Count 
                FROM KhachHang 
                WHERE SoCCCD = @Email AND SoTaiKhoan <> @STK";

                SqlParameter[] parameterscheckcccd = {
                  new SqlParameter("@Email", soCCCD),
                  new SqlParameter("@STK", SoTaiKhoan)
                };

                System.Data.DataTable checkcccd = db.DocBang(querycheckcccd, parameterscheckcccd);
                int countcccd = 0;
                if (checkcccd.Rows.Count > 0)
                {
                    countcccd = Convert.ToInt32(checkcccd.Rows[0]["Count"]);
                }

                if (countcccd > 0)
                {
                    MessageBox.Show("Số căn cước công dân này đã tồn tại!");
                    return;
                }
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
                // Cập nhật thông tin khách hàng
                string queryUpdate = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang, SoCCCD = @SoCCCD, SoDienThoai = @SoDienThoai, SoDu = @SoDu, " +
                                     "GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, Email = @Email, DiaChi = @DiaChi, NgheNghiep = @NgheNghiep, " +
                                     "Anh = @DuongDanAnh, TaiKhoan = @TaiKhoan WHERE SoTaiKhoan = @SoTaiKhoan";

                // Khởi tạo các tham số cho truy vấn
                SqlParameter[] parameters = {
            new SqlParameter("@TaiKhoan", taiKhoan),
            new SqlParameter("@SoTaiKhoan", SoTaiKhoan),
            new SqlParameter("@TenKhachHang", hoTen),
            new SqlParameter("@SoCCCD", soCCCD),
            new SqlParameter("@SoDienThoai", soDienThoai),
            new SqlParameter("@GioiTinh", gioiTinh),
            new SqlParameter("@NgaySinh", ngaySinh),
            new SqlParameter("@Email", email),
            new SqlParameter("@DiaChi", diaChi),
            new SqlParameter("@NgheNghiep", ngheNghiep),
            new SqlParameter("@SoDu", decimal.TryParse(SoDu, out decimal soDuValue) ? (object)soDuValue : DBNull.Value),
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


        private void ResetValue()
        {
            txtTaiKhoan.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSoDu.Text = "";
            txtNgheNghiep.Text = "";
            txtSoCCCD.Text = "";
            txtSoDienThoai.Text = "";
            txttenKhachHang.Text = "";
            imageFilePath = "";
            radioNam.Checked = false;
            radioNu.Checked = false;
            radioKhac.Checked = false;
            pictureKhachHang.Image = null;
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM KhachHang";
            db.ExportDataToExcel(sql);
        }
    }
}
