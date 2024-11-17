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
        public DangNhap_DangKi()
        {
            InitializeComponent();
        }
        ProcessDatabase db = new ProcessDatabase();
        private void DangNhap_DangKi_Load(object sender, EventArgs e)
        {

        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            InfoAfterSignIn SignIn = new InfoAfterSignIn();
            SignIn.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username =txtNhapTk.Text;
            string password = txtNhapMk.Text;
            DataTable dbKhachHang = db.DocBang("SELECT * FROM DangNhap WHERE TaiKhoan='" + username + "' AND MatKhau='" + password + "'");
            if(dbKhachHang.Rows.Count > 0)
            {
                string check = dbKhachHang.Rows[0]["Role"].ToString();
                if (check == "Admin")
                {
                    frmMain adminForm = new frmMain();
                    adminForm.Show();
                }
                else if (check == "User")
                {
                    Khach userForm = new Khach(username);
                    userForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapMk.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword changePasswordForm = new ForgotPassword();
            changePasswordForm.Show();
        }
    }
}
