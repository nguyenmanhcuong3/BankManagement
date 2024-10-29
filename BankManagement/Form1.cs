using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BankManagement
{
    public partial class Login : Form
    {
        ProcessDatabase db = new ProcessDatabase();
        public Login()
        {
            InitializeComponent();
            
            this.txtTaiKhoan.KeyDown += new KeyEventHandler(TxtBox_KeyDown);
            this.txtMatKhau.KeyDown += new KeyEventHandler(TxtBox_KeyDown);
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            this.KeyPreview = true;
            txtTaiKhoan.Text = "Nhập tài khoản";
            txtTaiKhoan.ForeColor = Color.Gray;
            txtMatKhau.Text = "Nhập mật khẩu";
            txtMatKhau.ForeColor = Color.Gray;
            
            pbHienMk.Hide();

        }

        // tai khoan
        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Equals("Nhập tài khoản"))
            {
                txtTaiKhoan.Text = "";
                txtTaiKhoan.ForeColor = Color.Black;
            }
        }
        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTaiKhoan.Text))
            {
                txtTaiKhoan.Text = "Nhập tài khoản";
                txtTaiKhoan.ForeColor = Color.Gray;
            }
        }
        // mat khau
        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Equals("Nhập mật khẩu"))
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                txtMatKhau.Text = "Nhập mật khẩu";
                txtMatKhau.ForeColor = Color.Gray;
            }
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '\0';
            pbHienMk.Show();
            pictureBox4.Hide();
        }
        private void TxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                btnDangNhap_Click(this, new EventArgs());
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            txtMatKhau.Focus();
            txtTaiKhoan.Focus();
            string username= txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            DataTable dbKhachHang = db.DocBang("select * from Login where username='" + txtTaiKhoan.Text + "'and password ='" + txtMatKhau.Text + "'");
            if (dbKhachHang.Rows.Count > 0)
            {
                frmMain main=new frmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập lỗi . Kiểm tra lại thông tin!");
            }

        }
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.Alt && e.KeyCode == Keys.H)
            {
 
                btnThoat_LinkClicked(this, new LinkLabelLinkClickedEventArgs(null));
            }
        }
        private void btnThoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            DangKi dangKi = new DangKi();
            dangKi.Show();
        }

        private void pbHienMk_Click(object sender, EventArgs e)
        {
           
            txtMatKhau.PasswordChar = '*';
            pictureBox4.Show();
            pbHienMk.Hide();

        }
    }
}
