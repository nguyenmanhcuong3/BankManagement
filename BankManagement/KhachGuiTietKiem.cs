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
    public partial class KhachGuiTietKiem : Form
    {
        DataTransaction db = new DataTransaction();
        string TaiKhoanDung;
 
        public KhachGuiTietKiem(string taikhoan)
        {
            InitializeComponent();
            TaiKhoanDung = taikhoan;
        }

        private void KhachGuiTietKiem_Load(object sender, EventArgs e)
        {
            dateGui.Enabled = false;
            dateTra.Enabled = false;

            // Gửi tiền
            txtMaTietKiem.Text = string.Empty;
            txtTaiKhoan.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtHoatDongGuiTien.Text = string.Empty;
            cbbKiHan.Text = string.Empty;
            cbbLaiSuat.Text = string.Empty;
            txtTienGui.Text = string.Empty;
            txtTienNhanSauLai.Text = string.Empty;

            txtMaTietKiem.Enabled = false;
            txtTaiKhoan.Enabled = false;
            txtHoTen.Enabled = false;
            txtHoatDongGuiTien.Enabled = false;
            cbbKiHan.Enabled = false;
            cbbLaiSuat.Enabled = false;
            txtTienGui.Enabled = false;
            txtTienNhanSauLai.Enabled = false;

            // Rút tiền
            txtMaKhoanVayTra.Text = string.Empty;
            txtTaiKhoanRut.Text = string.Empty;
            txtHocTenRut.Text = string.Empty;
            txtHoatDongRutTien.Text = string.Empty;
            txtKiHan.Text = string.Empty;
            txtLaiSuat.Text = string.Empty;
            txtSoTienRut.Text = string.Empty;


            txtMaKhoanVayTra.Enabled = false;
            txtTaiKhoanRut.Enabled = false;
            txtHocTenRut.Enabled = false;
            txtHoatDongRutTien.Enabled = false;
            txtKiHan.Enabled = false;
            txtLaiSuat.Enabled = false;
            txtSoTienRut.Enabled = false;


            System.Data.DataTable dt = db.DocBang("select * from TietKiem");
            dgvVay.DataSource = dt;
            dgvRut.DataSource = dt;
            dt.Dispose();
        }

        private void btnKhoanGuiMoi_Click(object sender, EventArgs e)
        {


            txtMaTietKiem.Text = IOManager.GetMaGiaoDich(8);
            txtTaiKhoan.Text = db.GetSoTaiKhoanByTaiKhoan(TaiKhoanDung).ToString();
            txtHoTen.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoan.Text.Trim());
            txtHoatDongGuiTien.Text = "Nap tien tiet kiem";
 
            cbbKiHan.Items.Clear(); 
            cbbKiHan.Items.AddRange(new string[] { "1", "3", "6", "12", "18", "24" });

            cbbLaiSuat.Items.Clear(); 
            cbbLaiSuat.Items.AddRange(new string[] { "3,8%", "4%", "5,2%", "5,8%", "6%" });


            cbbKiHan.Enabled = true;
            cbbLaiSuat.Enabled = true;
            txtTienGui.Enabled = true;
            txtTienNhanSauLai.Enabled = false;
  
            if (decimal.TryParse(txtTienGui.Text, out decimal P) && cbbLaiSuat.SelectedItem != null && int.TryParse(cbbKiHan.SelectedItem.ToString(), out int n))
            {
                
                string laiSuatStr = cbbLaiSuat.SelectedItem.ToString().TrimEnd('%');

                if (decimal.TryParse(laiSuatStr, out decimal r))
                {
                    r /= 100; 

                    
                    decimal S = P * (1 + r * n); 

                    
                    txtTienNhanSauLai.Text = S.ToString();
                }
                else
                {
                    MessageBox.Show("Lãi suất không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnKhoanRutMoi_Click(object sender, EventArgs e)
        {
            
            txtMaKhoanVayTra.Enabled = true;
            txtTaiKhoanRut.Enabled = true;
            txtHocTenRut.Enabled = true;
            txtHoatDongRutTien.Enabled = true;
            txtKiHan.Enabled = true;
            txtLaiSuat.Enabled = true;
            txtSoTienRut.Enabled = true;

        }

        private void btnXacNhanGui_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (string.IsNullOrWhiteSpace(cbbKiHan.Text) || string.IsNullOrWhiteSpace(txtTienGui.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                
                if (!decimal.TryParse(txtTienGui.Text, out decimal soTienGui) || soTienGui <= 0)
                {
                    MessageBox.Show("Số tiền gửi phải là số dương hợp lệ!");
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
                    MessageBox.Show("Lãi suất phải là số hợp lệ!");
                    return;
                }
                laisuat /= 100; 

                
                if (!int.TryParse(txtTienNhanSauLai.Text, out int soTienNhanSauLai) || soTienNhanSauLai <= 0)
                {
                    MessageBox.Show("Số tiền nhận sau lãi không hợp lệ!");
                    return;
                }
                string hoatdong = txtHoatDongGuiTien.Text.Trim();
                
                string maTietKiem = txtMaTietKiem.Text.Trim();
                if (string.IsNullOrWhiteSpace(maTietKiem))
                {
                    MessageBox.Show("Mã tiết kiệm không được để trống!");
                    return;
                }

                if (!int.TryParse(txtTaiKhoan.Text, out int soTaiKhoan) || soTaiKhoan <= 0)
                {
                    MessageBox.Show("Số tài khoản không hợp lệ!");
                    return;
                }

                DateTime thoiGian = DateTime.Now;

                
                string sqlInsert = "INSERT INTO TietKiem (MaTietKiem, SoTaiKhoan, SoTien, ThoiGian, KyHan, LaiSuat, SoTienDuKienNhan) " +
                                   "VALUES (@MaTietKiem, @SoTaiKhoan, @SoTien, @ThoiGian, @KyHan, @LaiSuat, @SoTienDuKienNhan)";

                
                SqlParameter[] parameters = {
        new SqlParameter("@MaTietKiem", maTietKiem),
        new SqlParameter("@SoTaiKhoan", soTaiKhoan),
        new SqlParameter("@SoTien", soTienGui),
        new SqlParameter("@ThoiGian", thoiGian),
        new SqlParameter("@KyHan", kyhan),
        new SqlParameter("@LaiSuat", laisuat),
        new SqlParameter("@SoTienDuKienNhan", soTienNhanSauLai)
    };

                
                db.CapNhatDuLieu(sqlInsert, parameters);
                string sqlInsertChiTiet = "INSERT INTO ChiTietTietKiem (MaTietKiem, HoatDong, SoTien, ThoiGianGiaoDich) " +
                                   "VALUES (@MaTietKiem, @HoatDong, @SoTien, @ThoiGian)";

               
                SqlParameter[] parametersChiTiet = {
        new SqlParameter("@MaTietKiem", maTietKiem),
        new SqlParameter("@HoatDong",hoatdong ),
        new SqlParameter("@SoTien", soTienGui),
        new SqlParameter("@ThoiGian", thoiGian)
    };
                db.CapNhatDuLieu(sqlInsertChiTiet, parametersChiTiet);
                MessageBox.Show("Thêm thông tin tiết kiệm thành công!");

                
                dgvVay.DataSource = db.DocBang("SELECT * FROM TietKiem");

                string updateQueryGui = "UPDATE KhachHang SET SoDu = SoDu - @SoTien WHERE SoTaiKhoan = @SoTaiKhoan";

                if (!string.IsNullOrEmpty(updateQueryGui))
                {
                    SqlParameter[] updateParameters = {
            new SqlParameter("@SoTien", soTienGui),
            new SqlParameter("@SoTaiKhoan",soTaiKhoan )
        };
                    db.CapNhatDuLieu(updateQueryGui, updateParameters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbbKiHan_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            cbbLaiSuat.Items.Clear();

            
            string selectedKiHan = cbbKiHan.SelectedItem.ToString();
            switch (selectedKiHan)
            {
                case "1":
                    cbbLaiSuat.Items.Add("3,8%");
                    break;
                case "3":
                    cbbLaiSuat.Items.Add("4%");
                    break;
                case "6":
                    cbbLaiSuat.Items.Add("5,2%");
                    break;
                case "12":
                    cbbLaiSuat.Items.Add("5,8%");
                    break;
                case "18":
                    cbbLaiSuat.Items.Add("6%");
                    break;
                case "24":
                    cbbLaiSuat.Items.Add("6%");
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

        private void txtTienGui_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (decimal.TryParse(txtTienGui.Text, out decimal P) && P > 0 &&
                    cbbLaiSuat.SelectedItem != null &&
                    int.TryParse(cbbKiHan.SelectedItem.ToString(), out int n))
                {
                    
                    string laiSuatStr = cbbLaiSuat.SelectedItem.ToString().TrimEnd('%');
                    if (decimal.TryParse(laiSuatStr, out decimal r))
                    {
                        r /= 100; 

                        
                        decimal S = P * (1 + r * n / 12); 

                      
                        int S_int = (int)Math.Round(S, MidpointRounding.AwayFromZero);

                       
                        txtTienNhanSauLai.Text = S_int.ToString(); 
                    }
                    else
                    {
                        txtTienNhanSauLai.Clear();
                        MessageBox.Show("Lãi suất không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                 
                    txtTienNhanSauLai.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLamMoiGui_Click(object sender, EventArgs e)
        {
           txtHoatDongGuiTien.Clear();
            txtHocTenRut.Clear();
            txtMaTietKiem.Clear();
            txtTaiKhoan.Clear();
            txtTienGui.Clear();
            txtTienNhanSauLai.Clear();
            cbbKiHan.Text = string.Empty;
            cbbLaiSuat.Text = string.Empty;

        }

        private void btnXacNhanRut_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu đầu vào
                if (string.IsNullOrWhiteSpace(txtSoTienRut.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền cần rút!");
                    return;
                }

                if (!decimal.TryParse(txtSoTienRut.Text, out decimal soTienRut) || soTienRut <= 0)
                {
                    MessageBox.Show("Số tiền rút phải lớn hơn 0!");
                    return;
                }

                string maTietKiem = txtMaKhoanVayTra.Text.Trim();
                if (string.IsNullOrWhiteSpace(maTietKiem))
                {
                    MessageBox.Show("Mã tiết kiệm không hợp lệ!");
                    return;
                }

                if (!int.TryParse(txtTaiKhoanRut.Text, out int soTaiKhoan) || soTaiKhoan <= 0)
                {
                    MessageBox.Show("Số tài khoản không hợp lệ!");
                    return;
                }

                // Thực hiện cập nhật vào cơ sở dữ liệu
                string sqlUpdateTietKiem = "UPDATE TietKiem SET SoTien = SoTien - @SoTien, SoTienDuKienNhan=SoTienDuKienNhan-@SoTienSauLai WHERE MaTietKiem = @MaTietKiem";
                SqlParameter[] parameters = {
            new SqlParameter("@MaTietKiem", maTietKiem),
            new SqlParameter("@SoTien", soTienRut),
            new SqlParameter("@SoTienSauLai", IOManager.TinhSoTienSauLai(soTienRut,decimal.Parse(txtLaiSuat.Text),int.Parse(txtKiHan.Text)))
        };
                db.CapNhatDuLieu(sqlUpdateTietKiem, parameters);

                string sqlInsertChiTiet = "INSERT INTO ChiTietTietKiem (MaTietKiem, HoatDong, SoTien, ThoiGianGiaoDich) " +
                                          "VALUES (@MaTietKiem, @HoatDong, @SoTien, @ThoiGian)";
                SqlParameter[] parametersChiTiet = {
            new SqlParameter("@MaTietKiem", maTietKiem),
            new SqlParameter("@HoatDong", "Rut tien tiet kiem"),
            new SqlParameter("@SoTien", soTienRut),
            new SqlParameter("@ThoiGian", DateTime.Now)
        };
                db.CapNhatDuLieu(sqlInsertChiTiet, parametersChiTiet);

                string sqlUpdateKhachHang = "UPDATE KhachHang SET SoDu = SoDu + @SoTien WHERE SoTaiKhoan = @SoTaiKhoan";
                SqlParameter[] updateParameters = {
            new SqlParameter("@SoTien", soTienRut),
            new SqlParameter("@SoTaiKhoan", soTaiKhoan)
        };
                db.CapNhatDuLieu(sqlUpdateKhachHang, updateParameters);

                // Cập nhật giao diện
                MessageBox.Show("Rút tiền thành công!");
                dgvVay.DataSource = db.DocBang("SELECT * FROM TietKiem");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvRut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int sotientinh ;
        private void dgvRut_Click(object sender, EventArgs e)
        {
            if (dgvRut.CurrentRow != null)
            {
                if (dgvRut.CurrentRow != null)
                {
                    int sotientinh = Convert.ToInt32(dgvRut.CurrentRow.Cells["SoTien"].Value);
                    txtMaKhoanVayTra.Text = dgvRut.CurrentRow.Cells["MaTietKiem"].Value.ToString();
                    txtTaiKhoanRut.Text = dgvRut.CurrentRow.Cells["SoTaiKhoan"].Value.ToString();
                    txtHocTenRut.Text = db.GetTenKhachHangByTSoTaiKhoan(txtTaiKhoanRut.Text);
                    txtHoatDongRutTien.Text= "Rut tien tiet kiem";

                    string thoiGian = dgvRut.CurrentRow.Cells["ThoiGian"].Value?.ToString();
                    if (!string.IsNullOrEmpty(thoiGian) && DateTime.TryParse(thoiGian, out DateTime ThoiGianGiaoDich))
                    {
                        dateTra.Value = ThoiGianGiaoDich;
                    }

                    txtKiHan.Text = dgvRut.CurrentRow.Cells["KyHan"].Value.ToString();
                    txtLaiSuat.Text = dgvRut.CurrentRow.Cells["LaiSuat"].Value.ToString();


                }

            }
            txtMaKhoanVayTra.Enabled = false;
            txtTaiKhoanRut.Enabled = false;
            txtHocTenRut.Enabled = false;
            txtHoatDongRutTien.Enabled = false;
            txtKiHan.Enabled = false;
            txtLaiSuat.Enabled = false;
            txtSoTienRut.Enabled = true;


        }

       
    }
}
