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
using Excel = Microsoft.Office.Interop.Excel;
namespace BankManagement
{
    public partial class GiaoDich : Form
    {
        DataTransaction db = new DataTransaction();
        public GiaoDich()
        {
            InitializeComponent();
            txtTim.Text = "Nhập số tài khoản";
            txtTim.ForeColor = System.Drawing.Color.Gray;

        }


        private void GiaoDich_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbGiaoDich = db.DocBang("select * from GiaoDich");
            dgvGiaoDich.DataSource = dbGiaoDich;
            dbGiaoDich.Dispose();
        }

        private void txtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim.Text.Equals("Nhập số tài khoản"))
            {
                txtTim.Text = "";
                txtTim.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = "Nhập số tài khoản";
                txtTim.ForeColor = System.Drawing.Color.Gray;
            }
        }
        private void dgvGiaoDich_Click(object sender, EventArgs e)
        {
            if (dgvGiaoDich.CurrentRow != null)
            {
                if (dgvGiaoDich.CurrentRow != null)
                {
                    txtMaGiaoDich.Text = dgvGiaoDich.CurrentRow.Cells["MaGiaoDich"].Value.ToString();
                    txttaiKhoanGui.Text = dgvGiaoDich.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
                    txtTaiKhoanNhan.Text = dgvGiaoDich.CurrentRow.Cells["TaiKhoanNhan"].Value.ToString();

                    string thoiGian = dgvGiaoDich.CurrentRow.Cells["ThoiGian"].Value?.ToString();
                    if (!string.IsNullOrEmpty(thoiGian) && DateTime.TryParse(thoiGian, out DateTime ThoiGianGiaoDich))
                    {
                        dateNgayGiaoDich.Value = ThoiGianGiaoDich;
                    }
                    
                    txtSoTienGiaoDich.Text = dgvGiaoDich.CurrentRow.Cells["SoTien"].Value.ToString();
                    txtTenNguoiGui.Text = db.GetTenKhachHangByTSoTaiKhoan(txttaiKhoanGui.Text);
                    txtTenNguoiNhan.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoanNhan.Text);

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

            System.Data.DataTable searchResult = db.DocBang($"SELECT * FROM GiaoDich WHERE SoTaiKhoan LIKE '%{searchValue}%' OR TaiKhoanNhan LIKE '%{searchValue}%' ");

            if (searchResult.Rows.Count > 0)
            {
                dgvGiaoDich.DataSource = searchResult;
                MessageBox.Show("Tìm thấy kết quả tìm kiếm!");
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả nào phù hợp!");
                dgvGiaoDich.DataSource = null;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM GiaoDich";
            db.ExportDataToExcel(sql);
        }
    }
}
