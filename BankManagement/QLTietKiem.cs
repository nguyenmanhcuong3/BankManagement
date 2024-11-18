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
    public partial class QLTietKiem : Form
    {
        DataTransaction db = new DataTransaction();
        public QLTietKiem()
        {
            InitializeComponent();
        }

        private void dgvTietKiem_Click(object sender, EventArgs e)
        {
            if (dgvTietKiem.CurrentRow != null)
            {
                if (dgvTietKiem.CurrentRow != null)
                {
                    txtMaTietKiem.Text = dgvTietKiem.CurrentRow.Cells["MaTietKiem"].Value.ToString();
                    txtTaiKhoan.Text = dgvTietKiem.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
                    txtSoTien.Text = dgvTietKiem.CurrentRow.Cells["SoTien"].Value.ToString();

                    string thoiGian = dgvTietKiem.CurrentRow.Cells["ThoiGian"].Value?.ToString();
                    if (!string.IsNullOrEmpty(thoiGian) && DateTime.TryParse(thoiGian, out DateTime ThoiGianGiaoDich))
                    {
                        dateNgayGiaoDich.Value = ThoiGianGiaoDich;
                    }

                    txtKiHan.Text = dgvTietKiem.CurrentRow.Cells["KyHan"].Value.ToString();
                    txtLaiSuat.Text = dgvTietKiem.CurrentRow.Cells["LaiSuat"].Value.ToString();
                    txtSoTienDuKien.Text = dgvTietKiem.CurrentRow.Cells["SoTienDuKienNhan"].Value.ToString();
                    txtHoTen.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoan.Text);


                }

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

            System.Data.DataTable searchResult = db.DocBang($"SELECT * FROM TietKiem WHERE SoTaiKhoan LIKE '%{searchValue}%' ");

            if (searchResult.Rows.Count > 0)
            {
                dgvTietKiem.DataSource = searchResult;
                MessageBox.Show("Tìm thấy kết quả tìm kiếm!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp!");
                dgvTietKiem.DataSource = null;
            }
        }

        

        private void QLTietKiem_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbTietKiem = db.DocBang("select * from TietKiem");
            dgvTietKiem.DataSource = dbTietKiem;
            dbTietKiem.Dispose();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM TietKiem";
            db.ExportDataToExcel(sql);
        }
    }
}
