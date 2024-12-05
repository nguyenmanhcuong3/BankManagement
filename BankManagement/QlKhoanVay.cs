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
    public partial class QlKhoanVay : Form
    {
        DataTransaction db = new DataTransaction();
        public QlKhoanVay()
        {
            InitializeComponent();
        }

        private void QlKhoanVay_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbKhoanVay = db.DocBang("select * from KhoanVay");
            dgvKhoanVay.DataSource = dbKhoanVay;
            dbKhoanVay.Dispose();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

            string searchValue = txtTim.Text.Trim();

            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm.");
                return;
            }

            System.Data.DataTable searchResult = db.DocBang($"SELECT * FROM KhoanVay WHERE SoTaiKhoan LIKE '%{searchValue}%' ");

            if (searchResult.Rows.Count > 0)
            {
                dgvKhoanVay.DataSource = searchResult;
                MessageBox.Show("Tìm thấy kết quả tìm kiếm!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp!");
                dgvKhoanVay.DataSource = null;
            }
        }

        private void dgvKhoanVay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChiTietGiaoDich_Click(object sender, EventArgs e)
        {
            string chiTietGiaoDich = txtChiTietKhoanVay.Text.Trim();

            string query = @"
    SELECT t.[MaKhoanVay], 
           t.[SoTaiKhoan], 
           c.[SoTien], 
           c.[ThoiGianGiaoDich], 
           c.[HoatDong]
    FROM KhoanVay t
    JOIN ChiTietKhoanVay c ON t.MaKhoanVay = c.MaKhoanVay
    WHERE t.[SoTaiKhoan] LIKE @SoTaiKhoan";

            SqlParameter[] parameters = {
    new SqlParameter("@SoTaiKhoan", $"%{chiTietGiaoDich}%")
};

            System.Data.DataTable searchResult = db.DocBang(query, parameters);

            if (searchResult.Rows.Count > 0)
            {

                dgvKhoanVay.DataSource = searchResult;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dgvKhoanVay_Click(object sender, EventArgs e)
        {
            if (dgvKhoanVay.CurrentRow != null)
            {
                if (dgvKhoanVay.CurrentRow != null)
                {
                    txtMaKhoanVay.Text = dgvKhoanVay.CurrentRow.Cells["MaKhoanVay"].Value.ToString();
                    txtTaiKhoan.Text = dgvKhoanVay.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
                    txtSoTien.Text = dgvKhoanVay.CurrentRow.Cells["SoTien"].Value.ToString();

                    string thoiGian = dgvKhoanVay.CurrentRow.Cells["ThoiGian"].Value?.ToString();
                    if (!string.IsNullOrEmpty(thoiGian) && DateTime.TryParse(thoiGian, out DateTime ThoiGianGiaoDich))
                    {
                        dateNgayGiaoDich.Value = ThoiGianGiaoDich;
                    }

                    txtKiHan.Text = dgvKhoanVay.CurrentRow.Cells["KyHan"].Value.ToString();
                    txtLaiSuat.Text = dgvKhoanVay.CurrentRow.Cells["LaiSuat"].Value.ToString();
                    txtSoTienDuKien.Text = dgvKhoanVay.CurrentRow.Cells["SoTienPhaiTra"].Value.ToString();
                    txtHoTen.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoan.Text);


                }

            }
        }
    }
}
