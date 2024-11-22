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
using System.Windows.Media;

namespace BankManagement
{
    public partial class InfoAfterSignIn : Form
    {
        IOManager db = new IOManager();
        private string imageFilePath = "";
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public InfoAfterSignIn()
        {
            InitializeComponent();
            btnDangKi.Enabled = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            txtHoTen.Focus();
            plDiChuyen.SendToBack();
        }



        private void btnTaiAnhKH_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFilePath = openFileDialog.FileName;
                pictureKhachHang.Image = Image.FromFile(imageFilePath);
                pictureKhachHang.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text;
            string email = txtEmail.Text;
            string soCCCD = txtSoCCCD.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;
            string ngheNghiep = txtNgheNghiep.Text;
            string gioiTinh = radioNam.Checked ? "Nam" : radioNu.Checked ? "Nữ" : "Khác";
            DateTime ngaySinh = dateNgaySinh.Value;
            int soTaiKhoan;
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string duongDanAnh = null;

            try
            {
                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soCCCD) ||
                    string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(ngheNghiep) ||
                    string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(txtSoTaiKhoan.Text) || !int.TryParse(txtSoTaiKhoan.Text, out soTaiKhoan))
                {
                    MessageBox.Show("Số tài khoản phải là một số hợp lệ và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra tuổi khách hàng phải >= 16
                int tuoi = DateTime.Now.Year - ngaySinh.Year;
                if (ngaySinh > DateTime.Now.AddYears(-tuoi))
                {
                    tuoi--; // Nếu ngày sinh chưa đến ngày hiện tại trong năm thì giảm tuổi xuống
                }

                if (tuoi < 16)
                {
                    MessageBox.Show("Khách hàng chưa đủ 16 tuổi, không thể đăng ký tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra điều kiện số CCCD (12 chữ số)
                if (!System.Text.RegularExpressions.Regex.IsMatch(soCCCD, @"^\d{12}$"))
                {
                    MessageBox.Show("Số CCCD phải có đúng 12 chữ số!");
                    return;
                }
                string querycheck = "SELECT COUNT(*) as Count FROM DangNhap WHERE TaiKhoan = @TaiKhoan";
                SqlParameter[] parameterscheck = {
                new SqlParameter("@TaiKhoan", taiKhoan)
                    };
                DataTable checktk = db.DocBang(querycheck, parameterscheck);
                int count = 0;
                if (checktk.Rows.Count > 0)
                {
                    count = Convert.ToInt32(checktk.Rows[0]["Count"]);
                }
                if (count > 0)
                {
                    MessageBox.Show("Tài khoản "+taiKhoan+" đã được sử dụng vui lòng chọn tài khoản đăng nhập khác!");
                    return;
                }
                string querychecktk = "SELECT COUNT(*) as Count FROM KhachHang WHERE SoTaiKhoan = @SoTaiKhoan";
                SqlParameter[] parameterschecktk = {
                new SqlParameter("@SoTaiKhoan", soTaiKhoan)
                    };
                DataTable checkstk = db.DocBang(querychecktk, parameterschecktk);
                int counttk = 0;
                if (checkstk.Rows.Count > 0)
                {
                    counttk = Convert.ToInt32(checkstk.Rows[0]["Count"]);
                }
                if (counttk > 0)
                {
                    MessageBox.Show("Số tài khoản " + soTaiKhoan + " đã tồn tại vui lòng chọn số tài khoản khác!");
                    return;
                }
                //ktraemail
                string querycheckemail = "SELECT COUNT(*) as Count FROM KhachHang WHERE Email = @Email";
                SqlParameter[] parameterscheckemail = {
                new SqlParameter("@Email", email)
                    };
                DataTable checkemail = db.DocBang(querycheckemail, parameterscheckemail);
                int countemail = 0;
                if (checkemail.Rows.Count > 0)
                {
                    countemail = Convert.ToInt32(checkemail.Rows[0]["Count"]);
                }
                if (countemail > 0)
                {
                    MessageBox.Show("Email này đã được sử dụng!");
                    return;
                }
                //ktrasdt
                string querychecksdt = "SELECT COUNT(*) as Count FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
                SqlParameter[] parameterschecksdt = {
                new SqlParameter("@SoDienThoai", soDienThoai)
                    };
                DataTable checksdt = db.DocBang(querychecksdt, parameterschecksdt);
                int countsdt = 0;
                if (checksdt.Rows.Count > 0)
                {
                    countsdt = Convert.ToInt32(checksdt.Rows[0]["Count"]);
                }
                if (countsdt > 0)
                {
                    MessageBox.Show("Số điện thoại đã được sử dụng!");
                    return;
                }
                //ktracccd
                string querycheckcccd = "SELECT COUNT(*) as Count FROM KhachHang WHERE SoCCCD = @SoCCCD";
                SqlParameter[] parameterscheckcccd = {
                new SqlParameter("@SoCCCD", soCCCD)
                    };
                DataTable checkcccd = db.DocBang(querycheckcccd, parameterscheckcccd);
                int countcccd = 0;
                if (checkcccd.Rows.Count > 0)
                {
                    countcccd = Convert.ToInt32(checkcccd.Rows[0]["Count"]);
                }
                if (countcccd > 0)
                {
                    MessageBox.Show("Số CCCD đã được sử dụng!");
                    return;
                }
                // Kiểm tra điều kiện số điện thoại (10 chữ số và bắt đầu bằng số 0)
                if (!System.Text.RegularExpressions.Regex.IsMatch(soDienThoai, @"^0\d{9}$"))
                {
                    MessageBox.Show("Số điện thoại phải có 10 chữ số và bắt đầu bằng số 0!");
                    return;
                }

                // Kiểm tra định dạng email
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[\w\.-]+@gmail\.com$"))
                {
                    MessageBox.Show("Email phải có định dạng hợp lệ và có đuôi @gmail.com!");
                    return;
                }

                // Xử lý ảnh
                if (!string.IsNullOrEmpty(imageFilePath))
                {
                    string imageFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ImagesKhachHang");

                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }

                    string imageFileName = $"{taiKhoan}{Path.GetExtension(imageFilePath)}";
                    string saveImagePath = Path.Combine(imageFolderPath, imageFileName);

                    File.Copy(imageFilePath, saveImagePath, true);
                    duongDanAnh = imageFileName;
                }
                if(duongDanAnh == null)
                {
                    MessageBox.Show("Vui lòng tải ảnh lên !");
                    return;
                }
                
                int soDu = 0;
                // Câu lệnh SQL
                string role = "User";
                string querylog = "INSERT INTO DangNhap (TaiKhoan, MatKhau,Role) VALUES (@TaiKhoan, @MatKhau,@Role)";
                SqlParameter[] parameterslog = {
                new SqlParameter("@TaiKhoan", taiKhoan),
                new SqlParameter("@MatKhau", matKhau),
                new SqlParameter("@Role", role)
                    };

                db.CapNhatDuLieu(querylog, parameterslog);
                SqlParameter[] parameters = {
        new SqlParameter("@TenKhachHang", hoTen),
        new SqlParameter("@Email", email),
        new SqlParameter("@SoCCCD", soCCCD),
        new SqlParameter("@SoDienThoai", soDienThoai),
        new SqlParameter("@GioiTinh", gioiTinh),
        new SqlParameter("@NgaySinh", ngaySinh),
        new SqlParameter("@DiaChi", diaChi),
        new SqlParameter("@NgheNghiep", ngheNghiep),
        new SqlParameter("@SoDu", soDu),
        new SqlParameter("@TaiKhoan", taiKhoan),
        new SqlParameter("@SoTaiKhoan", soTaiKhoan),
        new SqlParameter("@DuongDanAnh", duongDanAnh)
    };

                string query = "INSERT INTO KhachHang (SoTaiKhoan,SoDu,TenKhachHang, Email, SoCCCD, SoDienThoai, GioiTinh, NgaySinh, DiaChi, NgheNghiep, TaiKhoan, Anh) " +
                               "VALUES (@SotaiKhoan,@SoDu,@TenKhachHang, @Email, @SoCCCD, @SoDienThoai, @GioiTinh, @NgaySinh, @DiaChi, @NgheNghiep, @TaiKhoan, @DuongDanAnh)";

                db.CapNhatDuLieu(query, parameters);


                MessageBox.Show("Đăng ký thông tin thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return;
            }
            DangNhap_DangKi login= new DangNhap_DangKi();
            login.Show();
            this.Hide();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                btnDangKi.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                btnDangKi.Enabled = false;
            }
        }

      

        private void pcExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void pcExit_MouseEnter(object sender, EventArgs e)
        {
            pcExit.BackColor = System.Drawing.Color.LightGray;
            pcExit.Cursor = Cursors.Hand;
        }

        private void pcExit_MouseLeave(object sender, EventArgs e)
        {
            pcExit.BackColor = System.Drawing.Color.Transparent;
            pcExit.Cursor = Cursors.Default;
        }

        // Dung panel de thay cho thanh tieu de
        private void plDiChuyen_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void plDiChuyen_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void plDiChuyen_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            DangNhap_DangKi login = new DangNhap_DangKi();
            login.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
