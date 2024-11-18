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
    public partial class KhachVayVon : Form
    {
        string TaiKhoanDung;
        DataTransaction db = new DataTransaction();
        public KhachVayVon(string taiKhoanDung)
        {
            InitializeComponent();
            TaiKhoanDung = taiKhoanDung;
        }

       
        private void ResetValue()
        {
            dateTra.Enabled = false;
            dateVay.Enabled = false;
            txtMaKhoanVay.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtHoatDongVay.Text = string.Empty;
            cbbKiHan.Text = string.Empty;
            cbbLaiSuat.Text = string.Empty;
            txtTienVay.Text = string.Empty;
            txtTienPhaiTra.Text = string.Empty;

            txtMaKhoanVay.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtHoTen.Enabled = false;
            txtHoatDongVay.Enabled = false;
            cbbKiHan.Enabled = false;
            cbbLaiSuat.Enabled = false;
            txtTienVay.Enabled = false;
            txtTienPhaiTra.Enabled = false;
            txtMaKhoanVayTra.Text = string.Empty;
            txtTaiKhoanTra.Text = string.Empty;
            txtHocTenTra.Text = string.Empty;
            txtHoatDongTra.Text = string.Empty;
            txtKiHan.Text = string.Empty;
            txtLaiSuat.Text = string.Empty;
            txtSoTienTra.Text = string.Empty;


            btnXacNhanTra.Enabled = true;
            txtMaKhoanVayTra.Enabled = true;
            txtTaiKhoanTra.Enabled = true;
            txtHocTenTra.Enabled = true;
            txtHoatDongTra.Enabled = true;
            txtKiHan.Enabled = true;
            txtLaiSuat.Enabled = true;
            txtSoTienTra.Enabled = true;
            dataGridView1.Refresh();
            dgvVay.Refresh();
        }
        private void KhachVayVon_Load(object sender, EventArgs e)
        {
            dateTra.Enabled = false;
            dateVay.Enabled = false;

            // Vay tien
            txtMaKhoanVay.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtHoatDongVay.Text = string.Empty;
            cbbKiHan.Text = string.Empty;
            cbbLaiSuat.Text = string.Empty;
            txtTienVay.Text = string.Empty;
            txtTienPhaiTra.Text = string.Empty;

            txtMaKhoanVay.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtHoTen.Enabled = false;
            txtHoatDongVay.Enabled = false;
            cbbKiHan.Enabled = false;
            cbbLaiSuat.Enabled = false;
            txtTienVay.Enabled = false;
            txtTienPhaiTra.Enabled = false;

            //Tra no
            txtMaKhoanVayTra.Text = string.Empty;
            txtTaiKhoanTra.Text = string.Empty;
            txtHocTenTra.Text = string.Empty;
            txtHoatDongTra.Text = string.Empty;
            txtKiHan.Text = string.Empty;
            txtLaiSuat.Text = string.Empty;
            txtSoTienTra.Text = string.Empty;


            btnXacNhanTra.Enabled = true;
            txtMaKhoanVayTra.Enabled = true;
            txtTaiKhoanTra.Enabled = true;
            txtHocTenTra.Enabled = true;
            txtHoatDongTra.Enabled = true;
            txtKiHan.Enabled = true;
            txtLaiSuat.Enabled = true;
            txtSoTienTra.Enabled = true;
            dataGridView1.Refresh();

            btnLamMoi.Enabled = false;
            btnXacNhanTra.Enabled = false;

            //Hien thi data grid view
            int sotaikhoan = db.GetSoTaiKhoanByTaiKhoan(TaiKhoanDung);
            string query = "SELECT * FROM KhoanVay WHERE SoTaiKhoan = " + sotaikhoan;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoTaiKhoan", TaiKhoanDung)
            };


            System.Data.DataTable dt = db.DocBang(query, parameters);

            dgvVay.DataSource = dt;
            dataGridView1.DataSource = dt;
            dt.Dispose();
        }

        private void btnKhoanVayMoi_Click(object sender, EventArgs e)
        {

            txtMaKhoanVay.Text = IOManager.GetMaGiaoDich(8);
            txtTaiKhoan.Text = db.GetSoTaiKhoanByTaiKhoan(TaiKhoanDung).ToString();
            txtHoTen.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoan.Text.Trim());
            txtHoatDongVay.Text = "Vay tien";
            cbbKiHan.Items.Clear();
            cbbKiHan.Items.AddRange(new string[] { "1", "3", "6", "12", "18", "24" });

            cbbKiHan.Enabled = true;
            cbbLaiSuat.Enabled = true;
            txtTienVay.Enabled = true;
            txtTienPhaiTra.Enabled = false;
            btnLamMoi.Enabled = true;
            btnKhoanVayMoi.Enabled = false;
            btnXacNhanVay.Enabled = true;
        }

        private void cbbKiHan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbLaiSuat.Items.Clear();


            string selectedKiHan = cbbKiHan.SelectedItem.ToString();
            switch (selectedKiHan)
            {
                case "1":
                    cbbLaiSuat.Items.Add("8%");
                    break;
                case "3":
                    cbbLaiSuat.Items.Add("6%");
                    break;
                case "6":
                    cbbLaiSuat.Items.Add("5,8%");
                    break;
                case "12":
                    cbbLaiSuat.Items.Add("5,2%");
                    break;
                case "18":
                    cbbLaiSuat.Items.Add("5%");
                    break;
                case "24":
                    cbbLaiSuat.Items.Add("4,7%");
                    break;
                default:
                    MessageBox.Show("Không có lãi suất cho kỳ hạn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }


            if (cbbLaiSuat.Items.Count > 0)
            {
                cbbLaiSuat.SelectedIndex = 0;
            }

        }

        private void txtTienVay_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (decimal.TryParse(txtTienVay.Text, out decimal P) && P > 0 &&
                    cbbLaiSuat.SelectedItem != null &&
                    int.TryParse(cbbKiHan.SelectedItem.ToString(), out int n))
                {

                    string laiSuatStr = cbbLaiSuat.SelectedItem.ToString().TrimEnd('%');
                    if (decimal.TryParse(laiSuatStr, out decimal r))
                    {
                        r /= 100;


                        decimal S = P * (1 + r * n / 12);


                        int S_int = (int)Math.Round(S, MidpointRounding.AwayFromZero);


                        txtTienPhaiTra.Text = S_int.ToString();
                    }
                    else
                    {
                        txtTienPhaiTra.Clear();
                        MessageBox.Show("Lãi suất không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {

                    txtTienPhaiTra.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnXacNhanVay_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(cbbKiHan.Text) || string.IsNullOrWhiteSpace(txtTienVay.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }


                if (!decimal.TryParse(txtTienVay.Text, out decimal soTienVay) || soTienVay <= 0)
                {
                    MessageBox.Show("Số tiền vay phải là số dương hợp lệ!");
                    return;
                }


                if (!int.TryParse(cbbKiHan.Text, out int kyhan) || kyhan <= 0)
                {
                    MessageBox.Show("Kỳ hạn phải là số nguyên hợp lệ!");
                    return;
                }


                string laiSuatStr = cbbLaiSuat.Text.TrimEnd('%');
                if (!decimal.TryParse(laiSuatStr, out decimal laisuat) || laisuat <= 0)
                {
                    return;
                }


                if (!int.TryParse(txtTienPhaiTra.Text, out int soTienPhaiTra) || soTienPhaiTra <= 0)
                {
                    return;
                }
                string hoatdong = txtHoatDongVay.Text.Trim();

                string maKhoanVay = txtMaKhoanVay.Text.Trim();

                if (!int.TryParse(txtTaiKhoan.Text, out int soTaiKhoan) || soTaiKhoan <= 0)
                {
                    return;
                }

                DateTime thoiGian = DateTime.Now;


                string sqlInsert = "INSERT INTO KhoanVay (MaKhoanVay, SoTaiKhoan, SoTien, ThoiGian, KyHan, LaiSuat, SoTienPhaiTra) " +
                                   "VALUES (@MaKhoanVay, @SoTaiKhoan, @SoTien, @ThoiGian, @KyHan, @LaiSuat, @SotienPhaiTra)";


                SqlParameter[] parameterskhoanvay = {
        new SqlParameter("@MaKhoanVay", maKhoanVay),
        new SqlParameter("@SoTaiKhoan", soTaiKhoan),
        new SqlParameter("@SoTien", soTienVay),
        new SqlParameter("@ThoiGian", thoiGian),
        new SqlParameter("@KyHan", kyhan),
        new SqlParameter("@LaiSuat", laisuat),
        new SqlParameter("@SoTienPhaiTra", soTienPhaiTra)
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

                MessageBox.Show("Vay thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int sotaikhoan = db.GetSoTaiKhoanByTaiKhoan(TaiKhoanDung);
            string query = "SELECT * FROM KhoanVay WHERE SoTaiKhoan = " + sotaikhoan;
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SoTaiKhoan", TaiKhoanDung)
            };


            System.Data.DataTable dt = db.DocBang(query, parameters);

            dgvVay.DataSource = dt;
        }

        private void btnXacNhanTra_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(txtSoTienTra.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền cần trả !");
                    return;
                }

                if (!int.TryParse(txtSoTienTra.Text, out int soTienTra) || soTienTra <= 0)
                {
                    MessageBox.Show("Số tiền trả phải lớn hơn 0!");
                    return;
                }
                int SoTien = db.GetSoDuByTSoTaiKhoan(int.Parse(txtTaiKhoanTra.Text));

                if (soTienTra > SoTien)
                {
                    MessageBox.Show("Số dư không đủ để thực hiện giao dịch!");
                    return;
                }

                string maKhoanVay = txtMaKhoanVayTra.Text.Trim();
                if (!int.TryParse(txtTaiKhoanTra.Text, out int soTaiKhoan) || soTaiKhoan <= 0)
                {
                    return;
                }
                if (soTienTra > db.GetSoDuByTSoTaiKhoan(soTaiKhoan))
                {
                    MessageBox.Show("Khoong đủ tiền trả khoản vay này !");
                    return;
                }
                // Thực hiện cập nhật số tiền trong tài khoản tiết kiệm

                string sqlUpdateKhoanVay = " UPDATE KhoanVay SET SoTienPhaiTra = SoTienPhaiTra - @SoTien WHERE MaKhoanVay = @MaKhoanVay";
                SqlParameter[] parametersUpdateKhoanVay =
                {
            new SqlParameter("@MaKhoanVay", maKhoanVay),
            new SqlParameter("@SoTien", soTienTra)


        };

                db.CapNhatDuLieu(sqlUpdateKhoanVay, parametersUpdateKhoanVay);

                // Thêm thông tin giao dịch vào ChiTietTietKiem
                string sqlInsertChiTiet = "INSERT INTO ChiTietKhoanVay (MaKhoanVay, HoatDong, SoTien, ThoiGianGiaoDich) " +
                                          "VALUES (@MaKhoanVay, @HoatDong, @SoTien, @ThoiGian)";
                SqlParameter[] parametersChiTiet =
                {
new SqlParameter("@MaKhoanVay",maKhoanVay),
            new SqlParameter("@HoatDong", "Tra no"),
            new SqlParameter("@SoTien", soTienTra),
            new SqlParameter("@ThoiGian", DateTime.Now)
        };
                db.CapNhatDuLieu(sqlInsertChiTiet, parametersChiTiet);

                // Cập nhật số dư tài khoản khách hàng
                string sqlUpdateKhachHang = "UPDATE KhachHang SET SoDu = SoDu - @SoTien WHERE SoTaiKhoan = @SoTaiKhoan";
                SqlParameter[] updateParameters =
                {
            new SqlParameter("@SoTien", soTienTra),
            new SqlParameter("@SoTaiKhoan", soTaiKhoan)
        };
                db.CapNhatDuLieu(sqlUpdateKhachHang, updateParameters); MessageBox.Show("Trả nợ thành công !");


                string querytra = "SELECT * FROM KhoanVay WHERE SoTaiKhoan = " + soTaiKhoan;
                SqlParameter[] parameterstra = new SqlParameter[]
                {
                new SqlParameter("@SoTaiKhoan", TaiKhoanDung)
                };


                System.Data.DataTable dt = db.DocBang(querytra, parameterstra);

                dataGridView1.DataSource = dt;

                ResetValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int sotientinh = Convert.ToInt32(dataGridView1.CurrentRow.Cells["SoTien"].Value);
                    txtMaKhoanVayTra.Text = dataGridView1.CurrentRow.Cells["MaKhoanVay"].Value.ToString();
                    txtTaiKhoanTra.Text = dataGridView1.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
                    txtHocTenTra.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoanTra.Text);
                    txtHoatDongTra.Text = "Tra no";

                    string thoiGian = dataGridView1.CurrentRow.Cells["ThoiGian"].Value?.ToString();
                    if (!string.IsNullOrEmpty(thoiGian) && DateTime.TryParse(thoiGian, out DateTime ThoiGianGiaoDich))
                    {
                        dateTra.Value = ThoiGianGiaoDich;
                    }

                    txtKiHan.Text = dataGridView1.CurrentRow.Cells["KyHan"].Value.ToString();
                    txtLaiSuat.Text = dataGridView1.CurrentRow.Cells["LaiSuat"].Value.ToString();
                    txtSoTienTra.Text = dataGridView1.CurrentRow.Cells["SoTienPhaiTra"].Value.ToString();

                }

            }
            txtMaKhoanVayTra.Enabled = false;
            txtTaiKhoanTra.Enabled = false;
            txtHocTenTra.Enabled = false;
            txtHoatDongTra.Enabled = false;
            txtKiHan.Enabled = false;
            txtLaiSuat.Enabled = false;
            txtSoTienTra.Enabled = true;
            btnXacNhanTra.Enabled = true;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnKhoanVayMoi.Enabled = true;
            btnLamMoi.Enabled = false;
            btnXacNhanVay.Enabled = false;
        }
    }
}
