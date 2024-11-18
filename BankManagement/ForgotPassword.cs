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
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankManagement
{
    public partial class ForgotPassword : Form
    {
        ProcessDatabase db= new ProcessDatabase();
        private bool dragging;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            plDiChuyen.SendToBack();
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
    }
}
