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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankManagement
{
    public partial class ForgotPassword : Form
    {
        ProcessDatabase db= new ProcessDatabase();
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }


        private void txtNhapLaiMatKhau_TextChanged(object sender, EventArgs e)
        {
            string password = txtMatKhau.Text;
            string confirmPassword = txtNhapLaiMatKhau.Text;

            if (!string.IsNullOrEmpty(confirmPassword) && password != confirmPassword)
            {
                lblMessage.Text = "Mật khẩu không khớp!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (confirmPassword == " ")
                {
                    lblMessage.Enabled = false;
                }
                lblMessage.Text = "Mật khẩu khớp.";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void btnCapNhatMatKhau_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            string nhaplai = txtNhapLaiMatKhau.Text;



            try
            {
                // Kiểm tra các trường không được để trống
                if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(nhaplai))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dblogin = db.DocBang("SELECT * FROM DangNhap WHERE TaiKhoan='" + taiKhoan + "'");
                if (dblogin.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tồn tại tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string queryUpdate = "UPDATE DangNhap SET MatKhau = @MatKhau WHERE TaiKhoan = @TaiKhoan";
                    SqlParameter[] parameters = {
                        new SqlParameter("@TaiKhoan", taiKhoan),
                        new SqlParameter("@MatKhau", matKhau) };
                    db.CapNhatDuLieu(queryUpdate, parameters);
                    MessageBox.Show("Cập nhật mật khẩu thành công!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

            DangNhap_DangKi login = new DangNhap_DangKi();
            login.Show();
            this.Hide();
        }
    }
}
