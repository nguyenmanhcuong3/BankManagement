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
    public partial class KhachGiaoDich : Form
    {
        DataTransaction db = new DataTransaction();
        string taiKhoan;
        int sotaikhoan;
        public KhachGiaoDich(string taikhoan)
        {
            InitializeComponent();
            taiKhoan = taikhoan;
            btnXacNhan.Enabled = false;
            offValue();
        }


        private void offValue()
        {
            txtMaGiaoDich.Enabled = false;
            txtTaiKhoanGui.Enabled = false;
            txtSoTien.Enabled = false;
            txtChuTaiKhoanNhan.Enabled = false;
            dateNgayGiaoDich.Enabled = false;
            cbbTaiKhoanNhan.Enabled = false;
        }
        private void ResetValue()
        {
            txtMaGiaoDich.Clear();
            txtTaiKhoanGui.Clear();
            txtSoTien.Clear();
            txtChuTaiKhoanNhan.Clear();
            dateNgayGiaoDich.Enabled = false;
            cbbTaiKhoanNhan.Items.Clear();
            cbbTaiKhoanNhan.Text = " ";
        }
        private void KhachGiaoDich_Load(object sender, EventArgs e)
        {
            int sotaikhoan = db.GetSoTaiKhoanByTaiKhoan(taiKhoan);
            System.Data.DataTable dbGiaoDich = db.DocBang($"select MaGiaoDich, ThoiGian, SoTaiKhoan as 'TaiKhoanGui', TaiKhoanNhan, SoTien from GiaoDich where SoTaiKhoan like '%{sotaikhoan}%' or TaiKhoanNhan like '%{sotaikhoan}%' ");
            dgvGiaoDich.DataSource = dbGiaoDich;
            dbGiaoDich.Dispose();
        }

        private void btnGiaoDichMoi_Click(object sender, EventArgs e)
        {
            txtMaGiaoDich.Text = IOManager.GetMaGiaoDich(8);
            txtTaiKhoanGui.Text = db.GetSoTaiKhoanByTaiKhoan(taiKhoan).ToString();
            txtMaGiaoDich.Enabled = false;
            txtTaiKhoanGui.Enabled = false;
            txtSoTien.Focus();
            dateNgayGiaoDich.Enabled = false;
            txtSoTien.Text = " ";
            cbbTaiKhoanNhan.Text = " ";
            txtChuTaiKhoanNhan.Text = " ";
            btnXacNhan.Enabled = true;
            btnGiaoDichMoi.Enabled = false;
            txtChuTaiKhoanNhan.Enabled = false;
            cbbTaiKhoanNhan.Items.Clear();
            List<string> liststk = db.GetSoTaiKhoanList(db.GetSoTaiKhoanByTaiKhoan(taiKhoan));
            foreach (string i in liststk)
            {
                cbbTaiKhoanNhan.Items.Add(i);
            }
            txtSoTien.Enabled = true;
            cbbTaiKhoanNhan.Enabled = true;
        }

        private void cbbTaiKhoanNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChuTaiKhoanNhan.Text = db.GetTenKhachHangByTSoTaiKhoan(cbbTaiKhoanNhan.Text);
        }
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            int sotaikhoan = db.GetSoTaiKhoanByTaiKhoan(taiKhoan);
            string sql = $"select MaGiaoDich, ThoiGian, SoTaiKhoan as 'TaiKhoanGui', TaiKhoanNhan, SoTien from GiaoDich where SoTaiKhoan like '%{sotaikhoan}%' or TaiKhoanNhan like '%{sotaikhoan}%'";
            db.ExportDataToExcel(sql);
        }
        private bool KiemTraTaiKhoanNhan(string soTaiKhoanNhan, string taiKhoanGui)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(soTaiKhoanNhan))
                {
                    MessageBox.Show("Vui lòng nhập số tài khoản nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (soTaiKhoanNhan == taiKhoanGui)
                {
                    MessageBox.Show("Số tài khoản nhận không được trùng với số tài khoản gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Truy vấn kiểm tra tài khoản
                string query = "SELECT COUNT(*) FROM KhachHang WHERE SoTaiKhoan = @SoTaiKhoanNhan";

                // Tạo danh sách tham số
                SqlParameter[] parameters =
                {
    new SqlParameter("@SoTaiKhoanNhan", soTaiKhoanNhan)
};

                // Đọc dữ liệu từ cơ sở dữ liệu
                DataTable dt = db.DocBang(query, parameters);

                // Lấy giá trị COUNT(*) từ cột đầu tiên, hàng đầu tiên
                int count = 0;
                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    count = Convert.ToInt32(dt.Rows[0][0]);
                }

                // Kiểm tra kết quả
                if (count == 0)
                {
                    MessageBox.Show("Số tài khoản nhận không tồn tại trong cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true; // Tài khoản nhận tồn tại và hợp lệ
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Lỗi kiểm tra tài khoản: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string magiaodich = txtMaGiaoDich.Text.Trim();
            string taikhoannhan = cbbTaiKhoanNhan.Text;
            string taikhoangui = txtTaiKhoanGui.Text.Trim();
            string tennguoinhan = txtChuTaiKhoanNhan.Text.Trim();
            int soTien = int.TryParse(txtSoTien.Text, out int sotien) ? sotien : 0;
            DateTime timeGiaoDich = DateTime.TryParse(dateNgayGiaoDich.Text, out DateTime ngaygiaodich) ? ngaygiaodich : DateTime.MinValue;

            // Xử lý thông tin rỗng

            if (!KiemTraTaiKhoanNhan(cbbTaiKhoanNhan.Text, txtTaiKhoanGui.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(taikhoannhan) || soTien <= 0)


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (soTien > db.GetSoDuByTSoTaiKhoan(int.Parse(taikhoangui)))
            {
                MessageBox.Show("Không đủ số dư!");
                txtSoTien.Text = " ";
                return;
            }

            string sqlInsert = "INSERT INTO GiaoDich (MaGiaoDich, ThoiGian, SoTaiKhoan, TaiKhoanNhan, SoTien) " +
                               "VALUES (@MaGiaoDich, @ThoiGian, @SoTaiKhoan, @TaiKhoanNhan, @SoTien)";

            SqlParameter[] parameters = {
    new SqlParameter("@MaGiaoDich", magiaodich),
    new SqlParameter("@ThoiGian", timeGiaoDich),
    new SqlParameter("@SoTaiKhoan", taikhoangui),
    new SqlParameter("@TaiKhoanNhan", taikhoannhan),
    new SqlParameter("@SoTien", soTien)

};

            try
            {
                db.CapNhatDuLieu(sqlInsert, parameters);

                // Tính số tiền cho bảng tài khoản
                string updateQueryGui = "UPDATE KhachHang SET SoDu = SoDu - @SoTien WHERE SoTaiKhoan = @SoTaiKhoan";
                string updateQueryNhan = "UPDATE KhachHang SET SoDu = SoDu + @SoTien WHERE SoTaiKhoan = @TaiKhoanNhan";
                if (!string.IsNullOrEmpty(updateQueryGui))
                {
                    SqlParameter[] updateParameters = {
            new SqlParameter("@SoTien", soTien),
            new SqlParameter("@SoTaiKhoan",taikhoangui )
        };
                    db.CapNhatDuLieu(updateQueryGui, updateParameters);

                }
                if (!string.IsNullOrEmpty(updateQueryNhan))
                {
                    SqlParameter[] updateParameters = {
            new SqlParameter("@SoTien", soTien),
            new SqlParameter("@TaiKhoanNhan",taikhoannhan )
        };
                    db.CapNhatDuLieu(updateQueryNhan, updateParameters);
                    MessageBox.Show("Giao dịch thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            dgvGiaoDich.Refresh();
            System.Data.DataTable dbGiaoDich = db.DocBang($"select MaGiaoDich, ThoiGian, SoTaiKhoan as 'TaiKhoanGui', TaiKhoanNhan, SoTien from GiaoDich where SoTaiKhoan like '%{taikhoangui}%' or TaiKhoanNhan like '%{taikhoangui}%' ");
            dgvGiaoDich.DataSource = dbGiaoDich;
            btnGiaoDichMoi.Enabled = true;
            ResetValue();
            btnXacNhan.Enabled = false;
        }
    }
}