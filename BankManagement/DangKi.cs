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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankManagement
{
    public partial class DangKi : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        public DangKi()
        {
            InitializeComponent();
        }

        private void DangKi_Load(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;

            txtMaNv.Text = "Nhập mã nhân viên bạn muốn đăng kí";
            txtMaNv.ForeColor = Color.Gray;

            txtNhapTk.Text = "Nhập tài khoản bạn muốn đăng kí";
            txtNhapTk.ForeColor = Color.Gray;
            

            txtNhapMk.Text = "Nhập mật khẩu";
            txtNhapMk.ForeColor = Color.Gray;

            txtNhapLaiMk.Text = "Nhập lại mật khẩu";
            txtNhapLaiMk.ForeColor = Color.Gray;
            
            pbNhapMkMo.Hide();
            pbNhapLaiMkMo.Hide();

            label1.Focus();
        }

        private void DangKi_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        // Nhap MaNv       
        private void txtMaNv_Enter(object sender, EventArgs e)
        {
            if (txtMaNv.Text.Equals("Nhập mã nhân viên bạn muốn đăng kí"))
            {
                txtMaNv.Text = "";
                txtMaNv.ForeColor = Color.Black;
            }
        }
        private void txtMaNv_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNv.Text))
            {
                txtMaNv.Text = "Nhập mã nhân viên bạn muốn đăng kí";
                txtMaNv.ForeColor = Color.Gray;
            }
        }

        // nhap tk
        private void txtNhapTk_Enter(object sender, EventArgs e)
        {
            if (txtNhapTk.Text.Equals("Nhập tài khoản bạn muốn đăng kí"))
            {
                txtNhapTk.Text = "";
                txtNhapTk.ForeColor = Color.Black;
            }
        }

        private void TxtNhapTk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapTk.Text))
            {
                txtNhapTk.Text = "Nhập tài khoản bạn muốn đăng kí";
                txtNhapTk.ForeColor = Color.Gray;
            }
        }
        // nhap mk

        private void txtNhapMk_Enter_1(object sender, EventArgs e)
        {
            if (txtNhapMk.Text.Equals("Nhập mật khẩu"))
            {
                txtNhapMk.Text = "";
                txtNhapMk.ForeColor = Color.Black;
                txtNhapMk.PasswordChar = '*';
            }
        }

        private void txtNhapMk_Leave_1(object sender, EventArgs e)
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pbNhapMkMo.Show();
            pictureBox6.Hide();
            txtNhapMk.PasswordChar = '*'; 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pbNhapLaiMkMo.Show();
            pictureBox4.Hide();
            txtNhapLaiMk.PasswordChar = '*'; 
           
            
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNv.Text.Trim();
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
           
            if (string.IsNullOrWhiteSpace(maNhanVien) || maNhanVien.Equals("Nhập mã nhân viên bạn muốn đăng kí"))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            
            this.Hide(); 
            Login login= new Login();
            login.Show(); 
        }

        private void pbNhapMkMo_Click(object sender, EventArgs e)
        {
            txtNhapMk.PasswordChar = '\0';
            pictureBox6.Show();
            pbNhapMkMo.Hide();
        }

        private void pbNhapLaiMkMo_Click(object sender, EventArgs e)
        {
            txtNhapLaiMk.PasswordChar = '\0';
            pictureBox4.Show();
            pbNhapLaiMkMo.Hide();
        }

        private void btnThoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
