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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                txtMatKhau.PasswordChar = '\0'; 
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
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
            this.Close();
        }
    }
}
