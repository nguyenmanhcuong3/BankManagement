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
        IOManager db = new IOManager();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public DangNhap_DangKi()
        {
            InitializeComponent();
            init();
            

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
            txtMaNv.Text = "Nhập mã nhân viên";
            txtMaNv.ForeColor = Color.Gray;

            txtNhapTk.Text = "Nhập tài khoản";
            txtNhapTk.ForeColor = Color.Gray;


            txtNhapMk.Text = "Nhập mật khẩu";
            txtNhapMk.ForeColor = Color.Gray;

            txtNhapLaiMk.Text = "Nhập lại mật khẩu";
            txtNhapLaiMk.ForeColor = Color.Gray;

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
            txtMaNv.Text = "Nhập mã nhân viên";
            txtMaNv.ForeColor = Color.Gray;

            txtNhapTk.Text = "Nhập tài khoản";
            txtNhapTk.ForeColor = Color.Gray;


            txtNhapMk.Text = "Nhập mật khẩu";
            txtNhapMk.ForeColor = Color.Gray;

            txtNhapLaiMk.Text = "Nhập lại mật khẩu";
            txtNhapLaiMk.ForeColor = Color.Gray;

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
                if (pbNhapLaiMkMo.Visible == true)
                {
                    txtNhapLaiMk.PasswordChar = '\0';
                }
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
            string username = txtNhapTk.Text.Trim();
            string password = txtNhapMk.Text;
            string confirmPassword = txtNhapLaiMk.Text;

            string message;
            bool isRegistered = db.RegisterUser(maNhanVien, username, password, confirmPassword, out message);

            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, isRegistered ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (isRegistered)
            {
                btnQlDangNhap.PerformClick();
            }


        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtNhapTk.Text;
            string password = txtNhapMk.Text;

            bool isAuthenticated =db.AuthenticateUser(username, password);

            if (isAuthenticated)
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

        private void txtMaNv_TextChanged(object sender, EventArgs e)
        {

        }

        private void plDiChuyen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
