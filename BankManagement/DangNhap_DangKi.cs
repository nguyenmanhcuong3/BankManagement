using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class DangNhap_DangKi : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public DangNhap_DangKi()
        {
            InitializeComponent();
            init();
            txtMaNv.Text = "Nhập mã nhân viên";
            txtMaNv.ForeColor = Color.Gray;

            txtNhapTk.Text = "Nhập tài khoản";
            txtNhapTk.ForeColor = Color.Gray;


            txtNhapMk.Text = "Nhập mật khẩu";
            txtNhapMk.ForeColor = Color.Gray;

            txtNhapLaiMk.Text = "Nhập lại mật khẩu";
            txtNhapLaiMk.ForeColor = Color.Gray;

            pbNhapMkMo.Hide();
            pbNhapLaiMkMo.Hide();

            this.StartPosition = FormStartPosition.CenterScreen;
           
        }
        
        private void init()
        {
            txtMaNv.Hide();
            txtNhapLaiMk.Hide();
            pcMaNv.Hide();
            pcAnh.Hide();
            pbNhapMkMo.Hide();
            pbNhapLaiMkMo.Hide();
            pcDongLaiMk.Hide();
            btnDangKi.Hide();
            btnQlDangNhap.Hide();
            lbdk.Hide();
            pcDongMk.Show();
            
        }
        private void pcExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtMaNv.Show();
            txtNhapLaiMk.Show();
            pcMaNv.Show();
            pcAnh.Show();
            pcDongLaiMk.Show();
            btnDangKi.Show();
            btnQlDangNhap.Show();
            lbdk.Show();
            lbdn.Hide();
            btnDangNhap.Hide();
            btnThoat.Hide();
            pcDongMk.Show() ;
            pbNhapMkMo.Hide();
        }

        private void btnQlDangNhap_Click(object sender, EventArgs e)
        {
            init();
            lbdn.Show();
            btnThoat.Show();
            btnDangNhap.Show();
            plDiChuyen.SendToBack();

        }
        // Ma nv
        private void txtMaNv_Click(object sender, EventArgs e)
        {
            if (txtMaNv.Text.Equals("Nhập mã nhân viên"))
            {
                txtMaNv.Text = "";
                txtMaNv.ForeColor = Color.Black;
            }
        }

        private void txtMaNv_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNv.Text))
            {
                txtMaNv.Text = "Nhập mã nhân viên";
                txtMaNv.ForeColor = Color.Gray;
            }
        }
        // tk
        private void txtNhapTk_Enter(object sender, EventArgs e)
        {
            if (txtNhapTk.Text.Equals("Nhập tài khoản"))
            {
                txtNhapTk.Text = "";
                txtNhapTk.ForeColor = Color.Black;
            }
        }

        private void txtNhapTk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapTk.Text))
            {
                txtNhapTk.Text = "Nhập tài khoản";
                txtNhapTk.ForeColor = Color.Gray;
            }
        }
        // mk 
        private void txtNhapMk_Enter(object sender, EventArgs e)
        {
            if (txtNhapMk.Text.Equals("Nhập mật khẩu"))
            {
                txtNhapMk.Text = "";
                txtNhapMk.ForeColor = Color.Black;
                txtNhapMk.PasswordChar = '*';
            }
        }

        private void txtNhapMk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapMk.Text))
            {
                txtNhapMk.Text = "Nhập mật khẩu";
                txtNhapMk.ForeColor = Color.Gray;
                txtNhapMk.PasswordChar = '\0';
            }
        }
        // nhap lai mk
        private void txtNhapLaiMk_Enter(object sender, EventArgs e)
        {
            if (txtNhapLaiMk.Text.Equals("Nhập lại mật khẩu"))
            {
                txtNhapLaiMk.Text = "";
                txtNhapLaiMk.ForeColor = Color.Black;
                txtNhapLaiMk.PasswordChar = '*';
            }
        }

        private void txtNhapLaiMk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapLaiMk.Text))
            {
                txtNhapLaiMk.Text = "Nhập lại mật khẩu";
                txtNhapLaiMk.ForeColor = Color.Gray;
                txtNhapLaiMk.PasswordChar = '\0';
            }
        }

        private void pcDongMk_Click(object sender, EventArgs e)
        {
            pbNhapMkMo.Show();
            pcDongMk.Hide();
            txtNhapMk.PasswordChar = '\0';
        }

        private void pcDongLaiMk_Click(object sender, EventArgs e)
        {
            pbNhapLaiMkMo.Show();
            pcDongLaiMk.Hide();
            txtNhapLaiMk.PasswordChar = '\0';

        }

        private void pbNhapMkMo_Click(object sender, EventArgs e)
        {
            txtNhapMk.PasswordChar = '*';
            pcDongMk.Show();
            pbNhapMkMo.Hide();
        }

        private void pbNhapLaiMkMo_Click(object sender, EventArgs e)
        {
            txtNhapLaiMk.PasswordChar = '*';
            pcDongLaiMk.Show();
            pbNhapLaiMkMo.Hide();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNv.Text.Trim();
            string taiKhoan = txtNhapTk.Text.Trim();

            if (db.CheckMnv(maNhanVien) == false)
            {
                MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(maNhanVien) || maNhanVien.Equals("Nhập mã nhân viên bạn muốn đăng kí"))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(taiKhoan) || taiKhoan.Equals("Nhập tài khoản bạn muốn đăng kí"))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNhapMk.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (txtNhapMk.Text != txtNhapLaiMk.Text)
            {
                MessageBox.Show("Mật khẩu và mật khẩu nhập lại không khớp. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (db.CheckAccountExists(txtNhapTk.Text))
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tài khoản khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            string insertQuery = "INSERT INTO Login (MaNhanVien,username, password) VALUES ( @maNhanVien,@username, @password)"; // Điều chỉnh tên bảng và cột nếu cần
            SqlParameter[] parameters =
            {
        new SqlParameter("@username", txtNhapTk.Text),
        new SqlParameter("@password", txtNhapMk.Text),
        new SqlParameter("@maNhanVien", maNhanVien) };

            db.CapNhatDuLieu(insertQuery, parameters);
            MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtNhapTk.Text;
            string password = txtNhapMk.Text;
            DataTable dbKhachHang = db.DocBang("select * from Login where username='" + txtNhapTk.Text + "'and password ='" + txtNhapMk.Text + "'");
            if (dbKhachHang.Rows.Count > 0)
            {
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                btnDangNhap.Focus();
            }
        }
        private void btnThoat_MouseEnter(object sender, EventArgs e)
        {
            pcExit.BackColor= Color.LightGray;
            pcExit.Cursor = Cursors.Hand;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            pcExit.BackColor = Color.Transparent;
            pcExit.Cursor = Cursors.Default;
        }

        private void DangNhap_DangKi_Load(object sender, EventArgs e)
        {
            plDiChuyen.SendToBack();
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

        // enter nhay xuong mk
        private void txtNhapTk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                txtNhapMk.Focus();
                e.SuppressKeyPress = true; 
            }
        }

        // enter la dang nhap
        private void txtNhapMk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                if (txtNhapLaiMk.Visible)
                {
                    txtNhapLaiMk.Focus();
                    e.SuppressKeyPress = true; 
                }
                else
                {
                    btnDangNhap.PerformClick();
                    e.SuppressKeyPress = true; 
                }
            }
        }

        private void txtMaNv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNhapTk.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNhapLaiMk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangKi.PerformClick();
                btnDangKi.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}
/*
 private void btnDangNhap_Click(object sender, EventArgs e)
{
    string username = txtNhapTk.Text;
    string password = txtNhapMk.Text;

    // Lấy thông tin người dùng từ cơ sở dữ liệu
    DataTable dbKhachHang = db.DocBang("SELECT * FROM Login WHERE username='" + username + "' AND password='" + password + "'");

    if (dbKhachHang.Rows.Count > 0)
    {
        // Kiểm tra xem người dùng có phải là admin không
        string role = dbKhachHang.Rows[0]["Role"].ToString(); // Hoặc "UserType", tùy thuộc vào cột bạn sử dụng

        if (role == "admin")
        {
            // Hiện form admin
            frmAdmin adminForm = new frmAdmin(); // Giả sử bạn có form admin
            adminForm.Show();
        }
        else
        {
            // Hiện form chính cho người dùng bình thường
            frmMain main = new frmMain();
            main.Show();
        }

        this.Hide(); // Ẩn form đăng nhập
    }
    else
    {
        MessageBox.Show("Đăng nhập lỗi. Kiểm tra lại thông tin!");
    }
}
 */ 