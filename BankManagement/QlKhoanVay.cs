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
            txtTim.Text = "Nhập số tài khoản";
            txtTim.ForeColor = System.Drawing.Color.Gray;
        }

        private void QlKhoanVay_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dbKhoanVay = db.DocBang("select * from KhoanVay");
            dgvKhoanVay.DataSource = dbKhoanVay;
            dbKhoanVay.Dispose();
            txtMaKhoanVay.Enabled = false;
            txtHoTen.Enabled = false;   
            txtKiHan.Enabled = false;
            txtLaiSuat.Enabled = false; 
            txtSoTien.Enabled = false;
            txtSoTienDuKien.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtTrangThai.Enabled = false;
            dateNgayGiaoDich.Enabled = false;
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

        private void dgvKhoanVay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    txtTrangThai.Text = dgvKhoanVay.CurrentRow.Cells["TrangThai"].Value.ToString();

                }

            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM KhoanVay";
            db.ExportDataToExcel(sql);
        }

        private void btnDuyetKhoanVay_Click(object sender, EventArgs e)
        {
            

        }

        private void btnDuyetKhoanVay_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txtKiHan.Text) || string.IsNullOrWhiteSpace(txtSoTien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                if (txtTrangThai.Text == "Da duyet")
                {
                    MessageBox.Show("Khoản vay này đã được duyệt!");
                    return;
                }

                if (!decimal.TryParse(txtSoTien.Text, out decimal soTienVay) || soTienVay <= 0)
                {
                    MessageBox.Show("Số tiền vay phải là số dương hợp lệ!");
                    return;
                }


                if (!int.TryParse(txtKiHan.Text, out int kyhan) || kyhan <= 0)
                {
                    MessageBox.Show("Kỳ hạn phải là số nguyên hợp lệ!");
                    return;
                }


                string laiSuatStr = txtLaiSuat.Text.TrimEnd('%');
                if (!decimal.TryParse(laiSuatStr, out decimal laisuat) || laisuat <= 0)
                {
                    return;
                }


                if (!int.TryParse(txtSoTienDuKien.Text, out int soTienPhaiTra) || soTienPhaiTra <= 0)
                {
                    return;
                }
                string hoatdong = "Vay tien";
                string trangthai = "Da duyet";

                string maKhoanVay = txtMaKhoanVay.Text.Trim();

                if (!int.TryParse(txtTaiKhoan.Text, out int soTaiKhoan) || soTaiKhoan <= 0)
                {
                    return;
                }

                DateTime thoiGian = DateTime.Now;


                string sqlInsert = "update KhoanVay set TrangThai=@TrangThai where MaKhoanVay=@MaKhoanVay";


                SqlParameter[] parameterskhoanvay = {
        new SqlParameter("@MaKhoanVay", maKhoanVay),
        new SqlParameter("@TrangThai", trangthai)
    };


                db.CapNhatDuLieu(sqlInsert, parameterskhoanvay);
                string sqlInsertChiTiet = "INSERT INTO ChiTietKhoanVay (MaKhoanVay, HoatDong, SoTien, ThoiGianGiaoDich) " +
                                   "VALUES (@MaKhoanVay, @HoatDong, @SoTien, @ThoiGian)";


                SqlParameter[] parametersChiTiet = {
        new SqlParameter("@MaKhoanVay", maKhoanVay),
        new SqlParameter("@HoatDong",hoatdong ),
        new SqlParameter("@SoTien", soTienVay),
        new SqlParameter("@ThoiGian", thoiGian)
    };
                db.CapNhatDuLieu(sqlInsertChiTiet, parametersChiTiet);

                string updateQueryGui = "UPDATE KhachHang SET SoDu = SoDu + @SoTien WHERE SoTaiKhoan = @SoTaiKhoan";

                if (!string.IsNullOrEmpty(updateQueryGui))
                {
                    SqlParameter[] updateParameters = {
            new SqlParameter("@SoTien", soTienVay),
            new SqlParameter("@SoTaiKhoan",soTaiKhoan )
        };
                    db.CapNhatDuLieu(updateQueryGui, updateParameters);
                }

                MessageBox.Show("Đã duyệt khoản vay " + maKhoanVay);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            System.Data.DataTable dbKhoanVay = db.DocBang("select * from KhoanVay");
            dgvKhoanVay.DataSource = dbKhoanVay;
            dbKhoanVay.Dispose();
        }
    }
}
