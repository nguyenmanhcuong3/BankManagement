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
using System.Windows.Media;

namespace BankManagement
{
    public partial class DangNhap_DangKi : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public DangNhap_DangKi()
        {
            InitializeComponent();
            txtNhapTk.Text = "Nhập tài khoản";
            txtNhapTk.ForeColor = System.Drawing.Color.Gray;

            txtNhapMk.Text = "Nhập mật khẩu";
            txtNhapMk.ForeColor = System.Drawing.Color.Gray;

            pbNhapMkMo.Hide();

        }
        ProcessDatabase db = new ProcessDatabase();
        private void DangNhap_DangKi_Load(object sender, EventArgs e)
        {
            plDiChuyen.SendToBack();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            InfoAfterSignIn SignIn = new InfoAfterSignIn();
            SignIn.Show();
            this.Hide();
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
                MessageBox.Show("Sai tài khoản hoặc mật khẩu! hoặc không để trống", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapMk.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword changePasswordForm = new ForgotPassword();
            changePasswordForm.Show();
            this.Hide();
        }

        private void pcExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //tk 
        private void txtNhapTk_Enter(object sender, EventArgs e)
        {
            if (txtNhapTk.Text.Equals("Nhập tài khoản"))
            {
                txtNhapTk.Text = "";
                txtNhapTk.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtNhapTk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapTk.Text))
            {
                txtNhapTk.Text = "Nhập tài khoản";
                txtNhapTk.ForeColor = System.Drawing.Color.Gray;
            }
        }
        //mk
        private void txtNhapMk_Enter(object sender, EventArgs e)
        {
                if (txtNhapMk.Text.Equals("Nhập mật khẩu"))
                {
                    txtNhapMk.Text = "";
                    txtNhapMk.ForeColor = System.Drawing.Color.Black;
                    txtNhapMk.PasswordChar = '*';
                    if (pbNhapMkMo.Visible == true)
                    {
                        txtNhapMk.PasswordChar = '\0';
                    }
                }
            }

        private void txtNhapMk_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNhapMk.Text))
            {
                txtNhapMk.Text = "Nhập mật khẩu";
                txtNhapMk.ForeColor = System.Drawing.Color.Gray;
                txtNhapMk.PasswordChar = '\0';
            }
        }
        
        private void txtNhapTk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNhapMk.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtNhapMk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                
                    btnDangNhap.PerformClick();
                    e.SuppressKeyPress = true;
                
            }
        }

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

        private void pbNhapMkMo_Click(object sender, EventArgs e)
        {
            txtNhapMk.PasswordChar = '*';
            pcDongMk.Show();
            pbNhapMkMo.Hide();
        }

        private void pcDongMk_Click(object sender, EventArgs e)
        {
            pbNhapMkMo.Show();
            pcDongMk.Hide();
            txtNhapMk.PasswordChar = '\0';
        }
    }
}
