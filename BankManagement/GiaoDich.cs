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
    public partial class GiaoDich : Form
    {
        ProcessDatabase db =new ProcessDatabase();
        private KhachHang khachHangForm;
        public GiaoDich()
        {
            InitializeComponent();
        }
        private void ResetValue()
        {
            txtMaGiaoDich.Text = string.Empty;
            cbbLoaiGiaoDich.Text = string.Empty;
            txtTenKhachHang.Text = string.Empty;
            txtMaKhachHang.Text = string.Empty;
            txtSoTien.Text = string.Empty;
            txtNhanVien.Text = string.Empty;
            btnGiaoDichMoi.Enabled = true;
            btnXacNhan.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;

        }
        private void OffValue()
        {
            txtMaGiaoDich.Enabled = false;
            txtSoTien.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtMaKhachHang.Enabled = false;
            cbbLoaiGiaoDich.Enabled = false;
            txtNhanVien.Enabled = false;
            dateNgayGiaoDich.Enabled = false;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaGiaoDich.Enabled = true;
            txtSoTien.Enabled = true;
            txtTenKhachHang.Enabled = true;
            txtMaKhachHang.Enabled = true;
            cbbLoaiGiaoDich.Enabled = true;
            txtNhanVien.Enabled = true;
            dateNgayGiaoDich.Enabled = true;
            txtMaGiaoDich.Text = "";
            txtSoTien.Text = "";
            txtTenKhachHang.Text = "";
            txtMaKhachHang.Text = "";
            txtNhanVien.Text = "";
            btnXacNhan.Enabled = true;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tài khoản có mã là:" +
                    txtMaGiaoDich.Text + " không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                    System.Windows.Forms.DialogResult.Yes)
            {
                db.CapNhatDuLieu("delete GiaoDich where MaGiaoDich='" +
               txtMaGiaoDich.Text + "'", null);
                dgvGiaoDich.DataSource = db.DocBang("Select * from GiaoDich");
                MessageBox.Show("Xóa tài khoản thành công !");
                ResetValue();
            }
            txtMaGiaoDich.Enabled = false;
            txtSoTien.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtMaKhachHang .Enabled = false;
            cbbLoaiGiaoDich.Enabled = false;
            txtNhanVien.Enabled = false;
            dateNgayGiaoDich .Enabled = false;
            ResetValue();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string magiaodich = txtMaGiaoDich.Text.Trim();
            string loaigiaodich = cbbLoaiGiaoDich.Text.Trim();
            string makh = txtMaKhachHang.Text.Trim();
            string tenkh = txtTenKhachHang.Text.Trim();
            int soTien = int.TryParse(txtSoTien.Text, out int sotien) ? sotien : 0;
            DateTime timeGiaoDich = DateTime.TryParse(dateNgayGiaoDich.Text, out DateTime ngaygiaodich) ? ngaygiaodich : DateTime.MinValue;
            string tennhanvien = txtNhanVien.Text.Trim();
            // xử lý thông tin rỗng 
            if (string.IsNullOrEmpty(magiaodich) || string.IsNullOrEmpty(loaigiaodich) ||
               string.IsNullOrEmpty(makh) || string.IsNullOrEmpty(tenkh) ||
               soTien <= 0 || timeGiaoDich == DateTime.MinValue ||
               string.IsNullOrEmpty(tennhanvien))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hoặc nhập lại ô \"Số Tiền Giao Dịch\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            // Kiểm tra có tồn tại mã khách hàng từ form KhachHang
            List<string> maKhachHangList = db.GetMaKhachHangList(); 

            if (!maKhachHangList.Contains(makh))
            {
                MessageBox.Show("Mã khách hàng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // kiểm tra tên có khớp với tên trong bảng KhachHang ứng với trường MaKhachHang tương ứng 
            // Kiểm tra tên khách hàng
            string tenKhachHang = db.GetTenKhachHangByMa(makh); 
            if (!string.Equals(tenKhachHang, tenkh, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tên khách hàng không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra tên nhân viên có tồn tại trong cơ sở dữ liệu hay không
            /*if (!db.CheckNhanVienByTen(tennhanvien))
            {
                MessageBox.Show("Tên nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            // lấy mã nhân viên theo tennhanvien
            string maNhanVien = db.GetMaNhanVienByTen(tennhanvien);
            // thêm thông tin giao dịch vào bảng
            string sqlInsert = "INSERT INTO GiaoDich (MaGiaoDich, LoaiGiaoDich, MaNhanVien, TenKhachHang, MaKhachHang, ThoiGianGiaoDich, SoTienGiaoDich) " +
                   "VALUES (@MaGiaoDich, @LoaiGiaoDich, @MaNhanVien, @TenKhachHang, @MaKhachHang, @ThoiGianGiaoDich, @SoTienGiaoDich)";

            SqlParameter[] parameters = {
                    new SqlParameter("@MaGiaoDich", magiaodich),
                    new SqlParameter("@LoaiGiaoDich", loaigiaodich),
                    new SqlParameter("@MaNhanVien", maNhanVien),
                    new SqlParameter("@TenKhachHang", tenKhachHang),
                    new SqlParameter("@MaKhachHang", makh),
                    new SqlParameter("@ThoiGianGiaoDich", timeGiaoDich),
                    new SqlParameter("@SoTienGiaoDich", soTien)
};
            try
            {
                 db.CapNhatDuLieu(sqlInsert, parameters);
                 MessageBox.Show("Thêm giao dịch thành công!");
                 dgvGiaoDich.DataSource = db.DocBang("SELECT * FROM GiaoDich");

                //Tính số tiền cho bảng tài khoản
                switch (loaigiaodich)
                {
                    case "Nhan Tien":
                        db.CapNhatDuLieu("UPDATE TaiKhoan SET SoTien = SoTien +"+ soTien +" WHERE MaKhachHang like N'" + makh + "'");
                        break;

                    case "Chuyen Tien":
                        db.CapNhatDuLieu("UPDATE TaiKhoan SET SoTien = SoTien - " + soTien + " WHERE MaKhachHang like N'" + makh + "'");
                        break;

                    case "Gui Tiet Kiem":
                        db.CapNhatDuLieu("UPDATE TaiKhoan SET SoTien = SoTien - " + soTien + ", SoTienGuiTietKiem = SoTienGuiTietKiem + " + soTien + "  WHERE MaKhachHang like N'" + makh + "'");
                        break;

                    case "Rut Tien Tiet Kiem":
                        db.CapNhatDuLieu("UPDATE TaiKhoan SET SoTien = SoTien +" + soTien + " , SoTienGuiTietKiem = SoTienGuiTietKiem - " + soTien + " WHERE MaKhachHang like N'" + makh + "'");
                        break;

                    case "Vay Von":
                        db.CapNhatDuLieu("UPDATE TaiKhoan SET SoTien = SoTien +" + soTien + ", SoTienVay = SoTienVay + " + soTien + " WHERE MaKhachHang like N'" + makh + "'");
                        break;

                    case "Tra No":
                        db.CapNhatDuLieu("UPDATE TaiKhoan SET SoTien = SoTien -" + soTien + ", SoTienVay = SoTienVay - " + soTien + " WHERE MaKhachHang like N'" + makh + "'");
                        break;


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message); 
            }
            ResetValue();
        }

        private void btnXuatRaExcel_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDich_Load(object sender, EventArgs e)
        {
            DataTable dbGiaoDich = db.DocBang("select * from GiaoDich");
            dgvGiaoDich.DataSource = dbGiaoDich;
            dbGiaoDich.Dispose();
            btnGiaoDichMoi.Enabled = true;
            btnXoa.Enabled = false;
            btnXuatExcel.Enabled = true;
            btnXacNhan.Enabled = false;
            OffValue();

        }

        private void dgvGiaoDich_Click(object sender, EventArgs e)
        {
            if (dgvGiaoDich.CurrentRow != null)
            {
                txtMaGiaoDich.Text = dgvGiaoDich.CurrentRow.Cells["MaGiaoDich"].Value.ToString();
                txtMaKhachHang.Text = dgvGiaoDich.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                txtTenKhachHang.Text = dgvGiaoDich.CurrentRow.Cells["TenKhachHang"].Value.ToString();
                txtSoTien.Text = dgvGiaoDich.CurrentRow.Cells["SoTienGiaoDich"].Value.ToString();
                txtMaGiaoDich.Text = dgvGiaoDich.CurrentRow.Cells["MaGiaoDich"].Value.ToString();
                string ngayGD = dgvGiaoDich.CurrentRow.Cells["ThoiGianGiaoDich"].Value?.ToString();
                if (!string.IsNullOrEmpty(ngayGD) && DateTime.TryParse(ngayGD, out DateTime ngaygd))
                {
                    dateNgayGiaoDich.Value = ngaygd;
                }
                cbbLoaiGiaoDich.Text= dgvGiaoDich.CurrentRow.Cells["LoaiGiaoDich"].Value.ToString();
                string manv = dgvGiaoDich.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                string ten = db.GetTenNhanVienByMa(manv);
                txtNhanVien.Text = ten;
            }
            btnGiaoDichMoi.Enabled = true;
            btnXoa.Enabled = true;
            btnXuatExcel.Enabled = true;
        }

        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            string maKhachHang = txtMaKhachHang.Text.Trim();
            if (!string.IsNullOrEmpty(maKhachHang))
            {
                DataTable tenKhachHangTable = db.DocBang("SELECT TenKhachHang FROM KhachHang WHERE MaKhachHang like  N'" + maKhachHang + "'");
                if (tenKhachHangTable.Rows.Count > 0)
                {
                    txtTenKhachHang.Text = tenKhachHangTable.Rows[0]["TenKhachHang"].ToString();
                }
                else
                {
                    txtTenKhachHang.Text = "Không tìm thấy khách hàng";
                }
                DataTable loaiTaiKhoanTable = db.DocBang("SELECT LoaiTaiKhoan FROM TaiKhoan WHERE MaKhachHang like  N'" + maKhachHang + "'");
                if (loaiTaiKhoanTable.Rows.Count > 0)
                {
                   string  loaiTaiKhoan = loaiTaiKhoanTable.Rows[0]["LoaiTaiKhoan"].ToString();
                    if (loaiTaiKhoan == "ThanhToan")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                    }
                    else if (loaiTaiKhoan == "TietKiem")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                        cbbLoaiGiaoDich.Items.Add("Gui Tiet Kiem");
                        cbbLoaiGiaoDich.Items.Add("Rut Tien Tiet Kiem");
                    }
                    else if (loaiTaiKhoan == "VayVon")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                        cbbLoaiGiaoDich.Items.Add("Vay Von");
                        cbbLoaiGiaoDich.Items.Add("Tra No");
                    }
                    else if (loaiTaiKhoan == "DaNang")
                    {
                        cbbLoaiGiaoDich.Items.Clear();
                        cbbLoaiGiaoDich.Items.Add("Nhan Tien");
                        cbbLoaiGiaoDich.Items.Add("Chuyen Tien");
                        cbbLoaiGiaoDich.Items.Add("Vay Von");
                        cbbLoaiGiaoDich.Items.Add("Tra No");
                        cbbLoaiGiaoDich.Items.Add("Gui Tiet Kiem");
                        cbbLoaiGiaoDich.Items.Add("Rut Tien Tiet Kiem");
                    }

                }
            }
            else
            {
                txtTenKhachHang.Text = "";
                cbbLoaiGiaoDich.Items.Clear();
            }
        }
    }
}
