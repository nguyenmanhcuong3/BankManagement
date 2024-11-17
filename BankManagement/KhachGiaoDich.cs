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
            dateNgayGiaoDich.Enabled=false;
            txtSoTien.Text = " ";
            cbbTaiKhoanNhan.Text = " ";
            txtChuTaiKhoanNhan.Text=" ";
            btnXacNhan.Enabled = true;
            btnGiaoDichMoi.Enabled = false;
            txtChuTaiKhoanNhan.Enabled=false;
            List<string> liststk = db.GetSoTaiKhoanList(db.GetSoTaiKhoanByTaiKhoan(taiKhoan));
            foreach (string i in liststk)
            {
                cbbTaiKhoanNhan.Items.Add(i);
            }
        }
       
        private void cbbTaiKhoanNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtChuTaiKhoanNhan.Text = db.GetTenKhachHangByTSoTaiKhoan(cbbTaiKhoanNhan.Text);
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            int sotaikhoan = db.GetSoTaiKhoanByTaiKhoan(taiKhoan);
            string sql = "select MaGiaoDich, ThoiGian, SoTaiKhoan as 'TaiKhoanGui', TaiKhoanNhan, SoTien from GiaoDich where SoTaiKhoan like '%{sotaikhoan}%' or TaiKhoanNhan like '%{sotaikhoan}%' ";
            db.ExportDataToExcel(sql);
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string magiaodich = txtMaGiaoDich.Text.Trim();
            string taikhoannhan = cbbTaiKhoanNhan.Text.Trim();
            string taikhoangui = txtTaiKhoanGui.Text.Trim();
            string tennguoinhan = txtChuTaiKhoanNhan.Text.Trim();
            int soTien = int.TryParse(txtSoTien.Text, out int sotien) ? sotien : 0;
            DateTime timeGiaoDich = DateTime.TryParse(dateNgayGiaoDich.Text, out DateTime ngaygiaodich) ? ngaygiaodich : DateTime.MinValue;

            // Xử lý thông tin rỗng
            if (  string.IsNullOrEmpty(taikhoannhan) ||soTien <= 0 )


            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Thêm thông tin giao dịch vào bảng
            string sqlInsert = "INSERT INTO GiaoDich (MaGiaoDich, ThoiGian, SoTaiKhoan, TaiKhoanNhan, SoTien) " +
                               "VALUES (@MaGiaoDich, @ThoiGian, @SoTaiKhoan, @TaiKhoanNhan, @SoTien)";

            SqlParameter[] parameters = {
    new SqlParameter("@MaGiaoDich", magiaodich),
    new SqlParameter("@ThoiGian", timeGiaoDich),
    new SqlParameter("@SoTaiKhoan", taikhoangui),
    new SqlParameter("@TaiKhoanNhan", taikhoangui),
    new SqlParameter("@SoTien", soTien)

};

            try
            {
                db.CapNhatDuLieu(sqlInsert, parameters);
                MessageBox.Show("Thêm giao dịch thành công!");
                dgvGiaoDich.DataSource = db.DocBang("SELECT * FROM GiaoDich");

                // Tính số tiền cho bảng tài khoản
                /*string updateQuery = string.Empty;

                switch (loaigiaodich)
                {
                    case "Nhan Tien":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien + @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Chuyen Tien":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien - @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Gui Tiet Kiem":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien - @SoTienGiaoDich, SoTienGuiTietKiem = SoTienGuiTietKiem + @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Rut Tien Tiet Kiem":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien + @SoTienGiaoDich, SoTienGuiTietKiem = SoTienGuiTietKiem - @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Vay Von":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien + @SoTienGiaoDich, SoTienVay = SoTienVay + @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                    case "Tra No":
                        updateQuery = "UPDATE TaiKhoan SET SoTien = SoTien - @SoTienGiaoDich, SoTienVay = SoTienVay - @SoTienGiaoDich WHERE MaKhachHang = @MaKhachHang";
                        break;
                }

                if (!string.IsNullOrEmpty(updateQuery))
                {
                    SqlParameter[] updateParameters = {
            new SqlParameter("@SoTienGiaoDich", soTien),
            new SqlParameter("@MaKhachHang", makh)
        };
                    db.CapNhatDuLieu(updateQuery, updateParameters);
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
