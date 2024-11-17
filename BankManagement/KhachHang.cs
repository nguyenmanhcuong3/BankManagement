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
        ProcessDatabase db= new ProcessDatabase();
        public QLKhachHang()
        {
            InitializeComponent();
        }

        private void QLKhachHang_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbKhachHang = db.DocBang("select * from KhachHang");
            dgvKhachHang.DataSource = dbKhachHang;
            dbKhachHang.Dispose();
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
        }
    }
}
