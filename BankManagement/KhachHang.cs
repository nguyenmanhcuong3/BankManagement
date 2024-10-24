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
    public partial class KhachHang : Form
    {
        ProcessDatabase db= new ProcessDatabase();
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
            btnCapNhat.Enabled = false;
            btnSua.Enabled= false;
            btnTaiAnh.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            DataTable dbKhachHang = db.DocBang("select * from KhachHang");
            dgvKhachHang.DataSource = dbKhachHang;
            dbKhachHang.Dispose();
            btnCapNhat.Enabled = false;
            btnSua.Enabled = false;
            btnTaiAnh.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }
        private string imageFilePath = "";
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
            btnThoat.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMaKhachHang.Text = "";
            txtNgheNghiep.Text = "";
            txtSoCCCD.Text = "";
            txtSoDienThoai.Text = "";
            txttenKhachHang.Text = "";
            txtDiaChi.Focus();
            txtEmail.Focus();
            txtMaKhachHang.Focus();
            txtNgheNghiep.Focus();
            txtSoCCCD.Focus();
            txtSoDienThoai.Focus();
            txttenKhachHang.Focus();
            btnCapNhat.Enabled = true;
            btnTaiAnh.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không được bỏ trống!");
                    return;
                }

                string maKhachHang = txtMaKhachHang.Text;
                string tenKhachHang = txttenKhachHang.Text;
                string soCCCD = txtSoCCCD.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
                DateTime ngaySinh = dateNgaySinh.Value;
                string email = txtEmail.Text;
                string diaChi = txtDiaChi.Text;
                string ngheNghiep = txtNgheNghiep.Text;
                string duongDanAnh = string.IsNullOrEmpty(imageFilePath) ? null : imageFilePath;

                string query = "INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoCCCD, SoDienThoai, GioiTinh, NgaySinh, Email, DiaChi, NgheNghiep, AnhDaiDien) " +
                               "VALUES (@MaKhachHang, @TenKhachHang, @SoCCCD, @SoDienThoai, @GioiTinh, @NgaySinh, @Email, @DiaChi, @NgheNghiep, @DuongDanAnh)";

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

                db.CapNhatDuLieu(query, parameters);

        
                if (!string.IsNullOrEmpty(duongDanAnh))
                {
                    string queryAnhKhachHang = "INSERT INTO AnhKhachHang ( MaKhachHang, AnhDaiDien) " +
                                               "VALUES ( @MaKhachHang, @DuongDanAnh)";
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
            btnThoat.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
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
                try
                {
                    pictureKhachHang.Image = Image.FromFile(anhDaiDien); 
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

            db.CapNhatDuLieu("delete KhachHang where MaKhachHang='" +
              txtMaKhachHang.Text + "'", null);
            dgvKhachHang.DataSource = db.DocBang("Select * from KhachHang");

            btnTaiAnh.Enabled = true;
            btnThoat.Enabled = true;
            btnCapNhat.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa khách hàng  có mã là:" +
                    txtMaKhachHang.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                db.CapNhatDuLieu("delete KhachHang where MaKhachHang='" +
               txtMaKhachHang.Text + "'",null);
                dgvKhachHang.DataSource = db.DocBang("Select * from KhachHang");
                MessageBox.Show("Xóa khách hàng thành công !");

                ResetValue();
            }
            btnThoat.Enabled = true;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    try
                    {
                        pictureKhachHang.Image = Image.FromFile(anhDaiDien); 
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
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
